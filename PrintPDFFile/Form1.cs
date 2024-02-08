using Spire.Pdf;
using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using PDFFilePrint;

namespace PrintPDFFile
{
    public partial class PrintPDFFileFm : Form
    {
        string UsePrinterName;
        string WatchThisFolder;
       
        public PrintPDFFileFm()
        {
            InitializeComponent();
           


        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PdfDocument doc = new PdfDocument(openFileDialog1.FileName);
            doc.PrintSettings.PrinterName = UsePrinterName;
            doc.Print();

        }

        private void SelectPrinterBtn_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            UsePrinterName = printDialog1.PrinterSettings.PrinterName;
            AddUpdateAppSettings("Printername", UsePrinterName);
          //  ConfigurationManager.AppSettings.Set("Printername", UsePrinterName);
        }

        static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        private void SelectFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            watchFolder.Text = folderBrowserDialog1.SelectedPath;
            fileSystemWatcher1.Filter = "*.PDF";
            fileSystemWatcher1.Path = watchFolder.Text;
            WatchThisFolder = watchFolder.Text;
            AddUpdateAppSettings("WatchFolder", WatchThisFolder);

          //  var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
          //  var settings = configFile.AppSettings.Settings;
          //  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
          //  ConfigurationManager.AppSettings.Set("Watchfolder", WatchThisFolder);

            //  ConfigurationManager.
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            string archiveFolder = Path.GetDirectoryName(e.FullPath)+Path.DirectorySeparatorChar+"archive";
            if (!Directory.Exists(archiveFolder))
            {
                Directory.CreateDirectory(archiveFolder);
            }

            PdfDocument doc = new PdfDocument(e.FullPath);
            doc.PrintSettings.PrinterName = UsePrinterName;
            doc.Print();
            if (File.Exists(e.FullPath)) 
            {
                File.Copy(e.FullPath, archiveFolder+Path.DirectorySeparatorChar+ e.Name);
                File.Delete(e.FullPath);
             }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            UsePrinterName = ConfigurationManager.AppSettings.Get("Printername");
            WatchThisFolder = ConfigurationManager.AppSettings.Get("Watchfolder");
            if (Directory.Exists(WatchThisFolder)) {
                fileSystemWatcher1.Filter = "*.PDF";
                fileSystemWatcher1.Path = WatchThisFolder;
                watchFolder.Text = WatchThisFolder;

            }
           
        }
    }
}