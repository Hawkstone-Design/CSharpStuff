using System.IO.Packaging;
using System.IO.Compression;
using System.Net;

namespace UnzipFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                textBox1.Text = openFileDialog1.FileName;
                button2.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var zipFilePath = textBox1.Text;
            var tempFolderPath = textBox2.Text;
            var newTempfolder = textBox2.Text;
            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }
            statuslab.Text = zipFilePath;
            ZipFile.ExtractToDirectory(zipFilePath, tempFolderPath);
            try
            {
                foreach (string d in Directory.GetDirectories(tempFolderPath))
                {
                    foreach (string f in Directory.GetFiles(d, "*.zip"))
                    {
                        string extension = Path.GetExtension(f);
                        if (extension != null && (extension.Equals(".zip")))
                        {
                            zipFilePath = f;
                            newTempfolder = d;
                            Directory.CreateDirectory(newTempfolder);
                            statuslab.Text= f;
                            ZipFile.ExtractToDirectory(zipFilePath, newTempfolder);
                            File.Delete(zipFilePath);
                        }
                    }
                  //  DirSearch(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            statuslab.Text = "Finished";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var tempFolderPath = textBox2.Text;
            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }
            if (!tempFolderPath.EndsWith("\\")) tempFolderPath += "\\";

            using (var client = new HttpClient())
            {
                using (var s = client.GetStreamAsync(linkLabel1.Text))
                {
                    using (var fs = new FileStream(tempFolderPath+"frameOMAfiles.zip", FileMode.OpenOrCreate))
                    {
                        s.Result.CopyTo(fs);
                        textBox1.Text = tempFolderPath + "frameOMAfiles.zip";
                        button2.Visible = true;
                    }
                }
            }
        }
    }
}