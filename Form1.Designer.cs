namespace PackageTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBoxTrackNum = new TextBox();
            labelTop = new Label();
            buttonSubmit = new Button();
            buttonClear = new Button();
            labelResults = new Label();
            richTextBoxResults = new RichTextBox();
            textBoxDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonMapSearch = new Button();
            textBoxMapSearch = new TextBox();
            label3 = new Label();
            listBoxHistory = new ListBox();
            buttonClearHistory = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxTrackNum
            // 
            textBoxTrackNum.Location = new Point(239, 87);
            textBoxTrackNum.Name = "textBoxTrackNum";
            textBoxTrackNum.Size = new Size(367, 23);
            textBoxTrackNum.TabIndex = 0;
            textBoxTrackNum.TextChanged += textBoxTrackNum_TextChanged;
            // 
            // labelTop
            // 
            labelTop.AutoSize = true;
            labelTop.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTop.Location = new Point(300, 53);
            labelTop.Name = "labelTop";
            labelTop.Size = new Size(226, 15);
            labelTop.TabIndex = 2;
            labelTop.Text = "Enter Tracking Number and Description";
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(362, 141);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(99, 23);
            buttonSubmit.TabIndex = 3;
            buttonSubmit.Text = "Track Package";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(379, 250);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 4;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelResults.Location = new Point(36, 299);
            labelResults.Margin = new Padding(2, 0, 2, 0);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(47, 15);
            labelResults.TabIndex = 6;
            labelResults.Text = "Results";
            // 
            // richTextBoxResults
            // 
            richTextBoxResults.Location = new Point(97, 284);
            richTextBoxResults.Margin = new Padding(2, 1, 2, 1);
            richTextBoxResults.Name = "richTextBoxResults";
            richTextBoxResults.Size = new Size(597, 364);
            richTextBoxResults.TabIndex = 7;
            richTextBoxResults.Text = "";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(239, 117);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(367, 23);
            textBoxDescription.TabIndex = 1;
            textBoxDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(117, 90);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 8;
            label1.Text = "Tracking Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(151, 120);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 9;
            label2.Text = "Description:";
            // 
            // buttonMapSearch
            // 
            buttonMapSearch.Location = new Point(372, 202);
            buttonMapSearch.Name = "buttonMapSearch";
            buttonMapSearch.Size = new Size(89, 23);
            buttonMapSearch.TabIndex = 10;
            buttonMapSearch.Text = "Map Search";
            buttonMapSearch.UseVisualStyleBackColor = true;
            buttonMapSearch.Click += button1_Click;
            // 
            // textBoxMapSearch
            // 
            textBoxMapSearch.Location = new Point(239, 178);
            textBoxMapSearch.Name = "textBoxMapSearch";
            textBoxMapSearch.Size = new Size(367, 23);
            textBoxMapSearch.TabIndex = 11;
            textBoxMapSearch.TextChanged += textBoxMapSearch_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(171, 181);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 12;
            label3.Text = "Address:";
            // 
            // listBoxHistory
            // 
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.ItemHeight = 15;
            listBoxHistory.Location = new Point(716, 318);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new Size(251, 289);
            listBoxHistory.TabIndex = 14;
            // 
            // buttonClearHistory
            // 
            buttonClearHistory.Location = new Point(784, 613);
            buttonClearHistory.Name = "buttonClearHistory";
            buttonClearHistory.Size = new Size(125, 23);
            buttonClearHistory.TabIndex = 15;
            buttonClearHistory.Text = "Finished With Item";
            buttonClearHistory.UseVisualStyleBackColor = true;
            buttonClearHistory.Click += buttonClearHistory_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(765, 287);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 16;
            label4.Text = "Tracking History";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(670, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1008, 678);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(buttonClearHistory);
            Controls.Add(listBoxHistory);
            Controls.Add(label3);
            Controls.Add(textBoxMapSearch);
            Controls.Add(buttonMapSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxDescription);
            Controls.Add(richTextBoxResults);
            Controls.Add(labelResults);
            Controls.Add(buttonClear);
            Controls.Add(buttonSubmit);
            Controls.Add(labelTop);
            Controls.Add(textBoxTrackNum);
            Name = "Form1";
            Text = "Package Tracker";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTrackNum;
        private Label labelTop;
        private Button buttonSubmit;
        private Button buttonClear;
        private Label labelResults;
        private RichTextBox richTextBoxResults;
        private TextBox textBoxDescription;
        private Label label1;
        private Label label2;
        private Button buttonMapSearch;
        private TextBox textBoxMapSearch;
        private Label label3;
        private ListBox listBoxHistory;
        private Button buttonClearHistory;
        private Label label4;
        private PictureBox pictureBox1;
    }
}