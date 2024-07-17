using Shippo;
using System.Formats.Tar;
using System.Linq.Expressions;
using System.Net;
using System.Xml.Linq;

namespace PackageTracker
{
    public partial class Form1 : Form
    {
        // created for each tracking entry 
        private class TrackingEntry
        {
            public string TrackingNumber { get; set; }
            public string Description { get; set; }
        }

        private List<TrackingEntry> trackingHistory = new List<TrackingEntry>();
        private string testKey = "";
        private string prodKey = "";
        private string badDescChars = "?&^%$#@!()+-.,:;<>'\\-*[]{}/~`|\"=";  // Bad characters for the descirption entry field
        private string badTrackingChars = " ?&^%$#@!()+-.,:;<>'\\-*[]{}/~`|\"=";   // Bad characters for the tracking number field
        private string badAddressChars = "?&^%$#@!()+-.:;<>'\\-*[]{}/~`|\"=";   // Bad characters for the address field
        private String? strLatitude;
        private String? strLongitude;
        private string? trackNumber;
        private string theCarrier;
        // Put the package save file in the users AppData folder
        private string userPackageFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\userPackages.txt";



        public Form1()
        {
            InitializeComponent();
            fillListBox();  // Look for a previous list file and populate the list
            listBoxHistory.SelectedIndexChanged += ListBoxHistory_SelectedIndexChanged;
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string trackingNumber = textBoxTrackNum.Text;
            string theCarrier = "";
            string trackingDescriptor = textBoxDescription.Text;

            if (IsValidInput())
            {
                theCarrier = CheckCarrier(trackingNumber);

                //TrackingEntry for tracking and desc.
                TrackingEntry newEntry = new TrackingEntry
                {
                    TrackingNumber = trackingNumber,
                    Description = trackingDescriptor
                };
                Boolean found = false;
                foreach (var entry in trackingHistory)
                {
                    // Look to see if these entries already exist
                    if (entry.TrackingNumber == trackingNumber & entry.Description == trackingDescriptor) found = true;  // Look for duplicates
                }
                if (!found) trackingHistory.Add(newEntry);  // Don't add duplicates

                //display tracking history

                DisplayTrackingHistory();

                OpenShippo(theCarrier, trackingNumber);
            }

        }

        private void DisplayTrackingHistory()
        {
            // Clear and display the tracking history in listBoxHistory
            listBoxHistory.Items.Clear();

            // Create a fresh package list backup file
            StreamWriter outPkgStream1 = new StreamWriter(userPackageFile, false);  // Create the file
            outPkgStream1.Close();
            foreach (var entry in trackingHistory)
            {
                //display both tracking and description in the listbox
                listBoxHistory.Items.Add($"{entry.TrackingNumber} - {entry.Description}");
                // Write a current copy to a file
                try
                {
                    StreamWriter outPkgStream2 = new StreamWriter(userPackageFile, true); // re-write the list
                    outPkgStream2.WriteLine($"{entry.TrackingNumber} - {entry.Description}");
                    outPkgStream2.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }



        private Boolean IsValidInput()
        {
            bool isValidInput = true;

            if (String.IsNullOrEmpty(textBoxTrackNum.Text))
            {
                isValidInput = false;

                MessageBox.Show("Enter Tracking Number");
            }
            return isValidInput;
        }
        private string CheckCarrier(string trackingNumber)
        {
            if (trackingNumber.StartsWith("1Z") && trackingNumber.Length == 18)
            {
                theCarrier = "ups";
                return theCarrier;
            }
            else if (trackingNumber.StartsWith("9202") || trackingNumber.StartsWith("9205") || trackingNumber.StartsWith("9208") || trackingNumber.StartsWith("9270")
                    || trackingNumber.StartsWith("9303") || trackingNumber.StartsWith("9400") || trackingNumber.StartsWith("9589") && trackingNumber.Length == 22)
            {
                theCarrier = "usps";
                return theCarrier;
            }
            else if (trackingNumber.StartsWith("9274") && trackingNumber.Length == 26)
            {
                theCarrier = "usps";
                return theCarrier;
            }
            else if (trackingNumber.ToUpper().Contains("SHIPPO"))
            {
                theCarrier = "Shippo";
                return theCarrier;
            }
            MessageBox.Show("Invalid Tracking Number or Carrier");
            return "";
        }
        private void OpenShippo(string theCarrier, String trackNumber)
        {
            richTextBoxResults.Text = "RESPONSE FROM SHIPPO...\n" + textBoxDescription.Text + "\n";


            APIResource resource;
            if (theCarrier.Equals("Shippo"))
            {
                resource = new APIResource(testKey);
                RunTrackingExample(resource, theCarrier, trackNumber, richTextBoxResults);  // A test request
            }
            else
            {
                resource = new APIResource(prodKey);
                RunTrackingExample(resource, theCarrier, trackNumber, richTextBoxResults);  // A live request
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTrackNum.Text = "";
            richTextBoxResults.Text = "";
            textBoxDescription.Text = "";
            textBoxMapSearch.Text = "";
        }
        static void RunTrackingExample(APIResource resource, string theCarrier, string trackingNumber, RichTextBox responseBox)
        {
            String statusText;
            try
            {
                Shippo.Track track = resource.RetrieveTracking(theCarrier, trackingNumber);
                responseBox.Text = responseBox.Text + "\nCarrier = " + track.Carrier.ToUpper() + "\n";
                responseBox.Text = responseBox.Text + "\nTracking number = " + track.TrackingNumber + "\n";
                responseBox.Text = responseBox.Text + "\nService level = " + track.Servicelevel + "\n";
                responseBox.Text = responseBox.Text + "\nFrom = " + track.AddressFrom + "\n";
                responseBox.Text = responseBox.Text + "\nTo = " + track.AddressTo + "\n";
                responseBox.Text = responseBox.Text + "\nETA = " + track.Eta + "\n";
                if (track.TrackingStatus != null)
                {
                    statusText = track.TrackingStatus.ToString();
                }
                else
                {
                    statusText = "";
                }
                responseBox.Text = responseBox.Text + "\nTracking status = " + statusText.Replace(", ", "\n").Replace(": ", "\n") + "\n";  // Change colon and commas to a new line
                responseBox.Text = responseBox.Text + "\nTracking history = " + track.TrackingHistory + "\n";
                responseBox.Text = responseBox.Text + "\nMetadata = " + track.Metadata + "\n";
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                responseBox.Text = responseBox.Text + "\n  ***** Retrieve Tracking error " + e2.Message + " ***** \n\n";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidInput1())
            {
                if (SetLatLong())
                {
                    OpenGoogleMaps();
                }
            }
        }

        private Boolean IsValidInput1()
        {
            bool isValidInput1 = true;
            if (String.IsNullOrEmpty(textBoxMapSearch.Text))
            {
                isValidInput1 = false;
                MessageBox.Show("Incomplete or incorrect address! Please enter a valid address.");
            }

            return isValidInput1;
        }

        private bool SetLatLong()
        {
            string address = textBoxMapSearch.Text;

            var gKey = "";
            var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false",
                                       Uri.EscapeDataString(address), gKey);
            var request = WebRequest.Create(requestUri);

            try
            {
                var response = request.GetResponse();
                var xdoc = XDocument.Load(response.GetResponseStream());
                var result = xdoc.Element("GeocodeResponse")?.Element("result");

                if (result != null)
                {
                    var locationElement = result.Element("geometry")?.Element("location");

                    if (locationElement != null)
                    {
                        strLatitude = locationElement.Element("lat")?.Value;
                        strLongitude = locationElement.Element("lng")?.Value;
                        return true;
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect address! Please enter a valid address.");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Sorry, there is an Error. Please try again later or enter a valid address.");
            }

            return false;
        }

        private void OpenGoogleMaps()
        {
            var uri = string.Format("https://maps.google.com/maps/search/{0},{1}", strLatitude, strLongitude);
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }

        private void buttonClearHistory_Click(object sender, EventArgs e)
        {
            // Remove the currently selected item - done with it
            if (listBoxHistory.SelectedIndex > -1)  // Make sure something was selected
            {
                TrackingEntry selectedEntry = trackingHistory[listBoxHistory.SelectedIndex];
                trackingHistory.Remove(selectedEntry);
                DisplayTrackingHistory();
                textBoxTrackNum.Text = "";
                textBoxDescription.Text = "";
            }
        }

        private void ListBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selection change in listBoxHistory
            if (listBoxHistory.SelectedIndex > -1)
            {
                //get the tracking entry 
                TrackingEntry selectedEntry = trackingHistory[listBoxHistory.SelectedIndex];

                //insert tracking info
                textBoxTrackNum.Text = selectedEntry.TrackingNumber;
                textBoxDescription.Text = selectedEntry.Description;
            }
        }
        public void fillListBox()
        {
            trackingHistory.Clear();  // 
            if (!File.Exists(userPackageFile))
            {
                StreamWriter outPkgStream1 = new StreamWriter(userPackageFile, false);  // Create the file if needed
                outPkgStream1.Close();
            }
            try  // Populate the user packages pulldown
            {
                using (StreamReader inStream = new StreamReader(userPackageFile))
                {
                    String aLine;
                    while ((aLine = inStream.ReadLine()) != null)
                    {
                        string[] theParams = aLine.ToString().Split(" - ");
                        //TrackingEntry for tracking and desc.
                        TrackingEntry newEntry = new TrackingEntry
                        {
                            TrackingNumber = theParams[0],
                            Description = theParams[1]
                        };
                        trackingHistory.Add(newEntry);
                    }
                    inStream.Close();
                }
                DisplayTrackingHistory();  // Now show the stuff
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
                richTextBoxResults.Text = richTextBoxResults.Text + "\n  ***** Fill History Box error " + e3.Message + " ***** \n\n";
            }
        }
        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in badDescChars)
            {
                textBoxDescription.Text = textBoxDescription.Text.Replace(chr.ToString(), string.Empty);  // Remove any undesired characters
                textBoxDescription.SelectionStart = textBoxDescription.Text.Length;  // Move the cursor back to the end of the string
            }
        }

        private void textBoxMapSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in badAddressChars)
            {
                textBoxMapSearch.Text = textBoxMapSearch.Text.Replace(chr.ToString(), string.Empty);  // Remove any undesired characters
                textBoxMapSearch.SelectionStart = textBoxMapSearch.Text.Length;  // Move the cursor back to the end of the string
            }

        }

        private void textBoxTrackNum_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in badTrackingChars)  // Test environment
            {
                textBoxTrackNum.Text = textBoxTrackNum.Text.Replace(chr.ToString(), string.Empty);  // Remove any undesired characters
                textBoxTrackNum.SelectionStart = textBoxTrackNum.Text.Length;  // Move the cursor back to the end of the string
            }

        }
    }
}