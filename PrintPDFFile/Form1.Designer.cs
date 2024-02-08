namespace PrintPDFFile
{
    partial class PrintPDFFileFm
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
            this.components = new System.ComponentModel.Container();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.SelectPrinterBtn = new System.Windows.Forms.Button();
            this.watchFolder = new System.Windows.Forms.TextBox();
            this.SelectFolderBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Location = new System.Drawing.Point(604, 100);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(167, 29);
            this.SelectFileBtn.TabIndex = 0;
            this.SelectFileBtn.Text = "Select file to print";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.pdf";
            this.openFileDialog1.Title = "Select PDF file";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // SelectPrinterBtn
            // 
            this.SelectPrinterBtn.Location = new System.Drawing.Point(604, 156);
            this.SelectPrinterBtn.Name = "SelectPrinterBtn";
            this.SelectPrinterBtn.Size = new System.Drawing.Size(167, 29);
            this.SelectPrinterBtn.TabIndex = 1;
            this.SelectPrinterBtn.Text = "Select Printer";
            this.SelectPrinterBtn.UseVisualStyleBackColor = true;
            this.SelectPrinterBtn.Click += new System.EventHandler(this.SelectPrinterBtn_Click);
            // 
            // watchFolder
            // 
            this.watchFolder.Location = new System.Drawing.Point(64, 37);
            this.watchFolder.Name = "watchFolder";
            this.watchFolder.Size = new System.Drawing.Size(476, 27);
            this.watchFolder.TabIndex = 2;
            // 
            // SelectFolderBtn
            // 
            this.SelectFolderBtn.Location = new System.Drawing.Point(604, 37);
            this.SelectFolderBtn.Name = "SelectFolderBtn";
            this.SelectFolderBtn.Size = new System.Drawing.Size(167, 29);
            this.SelectFolderBtn.TabIndex = 3;
            this.SelectFolderBtn.Text = "Select Folder to Watch";
            this.SelectFolderBtn.UseVisualStyleBackColor = true;
            this.SelectFolderBtn.Click += new System.EventHandler(this.SelectFolderBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PrintPDFFileFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectFolderBtn);
            this.Controls.Add(this.watchFolder);
            this.Controls.Add(this.SelectPrinterBtn);
            this.Controls.Add(this.SelectFileBtn);
            this.Name = "PrintPDFFileFm";
            this.Text = "Print PDF File";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SelectFileBtn;
        private OpenFileDialog openFileDialog1;
        private FileSystemWatcher fileSystemWatcher1;
        private Button SelectPrinterBtn;
        private PrintDialog printDialog1;
        private TextBox watchFolder;
        private Button SelectFolderBtn;
        private FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}