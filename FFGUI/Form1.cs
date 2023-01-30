using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FFGUI
{
    public partial class frmGUI : Form
    {
        public frmGUI()
        {
            InitializeComponent();
        }

        private void btnExeLocation_Click(object sender, EventArgs e)
        {
            if ( openFileDialogFFMPEG.ShowDialog() == DialogResult.OK )
            {
                txtFfmpegLocation.Text = openFileDialogFFMPEG.FileName;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if ( openFileDialogInput.ShowDialog() == DialogResult.OK )
            {
                txtInputFile.Text = openFileDialogInput.FileName;
                txtInputFile.Refresh();
                string videoFilePath = txtInputFile.Text;
                string exeFilePath = txtFfmpegLocation.Text;
                string ffmpegOutput = RunFFmpeg("", videoFilePath, exeFilePath);
                
                int startIndex = ffmpegOutput.IndexOf("Duration: ") + "Duration: ".Length;
                int endIndex = ffmpegOutput.IndexOf(",", startIndex);
                string duration = ffmpegOutput.Substring(startIndex, endIndex - startIndex).Trim();
                TimeSpan videoLength = TimeSpan.Parse(duration);

                Console.WriteLine("Length in seconds: " + videoLength.TotalSeconds);
                txtStart.Text = "0";
                txtFinish.Text = videoLength.TotalSeconds.ToString();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string outputFile;

            lblStatus.Text = "";
            lblStatus.Refresh();

            // Exe file path
            string exeFile = txtFfmpegLocation.Text;
            Console.Writeline("Exe file: " + exeFile);
            
            // Input file path
            string inputFile = txtInputFile.Text;
            Console.WriteLine("Input file: " + inputFile);
            
            // Output file path
            if (chkOverwrite.Checked)
            {
                //currently seems to hang???
                outputFile = inputFile;
            }
            else
            {
                // Generate a random number between 10 and 90 and append this to the file name before the extension
                Random rnd = new Random();
                string dir = Path.GetDirectoryName(inputFile);
                string file = Path.GetFileNameWithoutExtension(inputFile) + rnd.Next(10, 90);
                string ext = Path.GetExtension(inputFile);

                outputFile = $@"{dir}\{file}{ext}";
            }

            lblStatus.Text = "Creating file at " + outputFile + "\nProcessing....";
            lblStatus.Refresh();

            Console.WriteLine($"Output file: {outputFile}");

            // Trim the video using user inputs
            string startSeconds = txtStart.Text;
            string finishSeconds = txtFinish.Text;

            // Get target bitrate
            int targetFileSize = Int16.Parse(txtFileSize.Text);
            int targetBitrate = (targetFileSize * 8000000) / (int)(Single.Parse(finishSeconds) - Single.Parse(startSeconds));
            Console.WriteLine(targetBitrate);
            
            // FFmpeg command to convert the video file
            string command = $"-ss {startSeconds} -to {finishSeconds} -b:v {targetBitrate} -preset fast -c:a copy {outputFile}";
            Console.WriteLine("Using command: " + command);

            // Create a new process to run FFmpeg
            string output = RunFFmpeg(command, inputFile, exeFile);
            
            Console.WriteLine("Creating FFMPEG process using " + exeFile);
            Console.WriteLine(output);

            lblStatus.Text = lblStatus.Text + "/nOutput file created at " + outputFile;
            
            lnkOutputFile.Text = "Open output file";
            lnkOutputFile.Tag = outputFile;
            lnkOutputFolder.Text = "Open output folder";
            lnkOutputFolder.Tag = Path.GetDirectoryName(outputFile);
            lnkOutputFile.Visible = true;
            lnkOutputFolder.Visible = true;
        }
        
        void lnkOutputFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = (string)lnkOutputFile.Tag;
            process.Start();
        }
        
        void lnkOutputFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = (string)lnkOutputFolder.Tag;
            process.Start();
        }

        static string RunFFmpeg(string arguments, string videoloc, string ffmpegloc)
        {
            Console.WriteLine("Starting ffmpeg process");
            Process process = new Process();
            process.StartInfo.FileName = "\"" + ffmpegloc + "\"";
            process.StartInfo.Arguments = "-i \"" + videoloc + "\" " + arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            Console.WriteLine("About to start ffmpeg process....");
            process.Start();

            var output = "x";//process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            
            //Console.WriteLine(output);
            Console.WriteLine(error);
            
            process.WaitForExit();
            
            return error;
        }

        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
