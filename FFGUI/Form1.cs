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

                string videoFilePath = openFileDialogInput.FileName;
                string ffmpegOutput = RunFFmpeg("-i " + videoFilePath, txtFfmpegLocation.Text);
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
            
            lblStatus.Text = "Processing....";
            lblStatus.Refresh();

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
                
                outputFile = Path.Combine(dir, file, ext);
            }

            Console.WriteLine($"Output file: {outputFile}");

            // Trim the video using user inputs
            string startSeconds = txtStart.Text;
            string finishSeconds = txtFinish.Text;
            
            // FFmpeg command to convert the video file
            string command = $"-i {inputFile} -ss {startSeconds} - to {finishSeconds} -crf 18 -preset fast -c:a copy {outputFile}";
            Console.WriteLine("Using command: " + command);

            // Create a new process to run FFmpeg
            string output = RunFFmpeg(command, txtFfmpegLocation.Text);
            
            Console.WriteLine("Creating FFMPEG process using " + txtFfmpegLocation.Text);

            lblStatus.Text = "Output file created at " + outputFile;
        }

        static string RunFFmpeg(string arguments, string ffmpegloc)
        {
            Process process = new Process();
            process.StartInfo.FileName = ffmpegloc;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            
            Console.WriteLine(output);
            Console.WriteLine(error);
            
            process.WaitForExit();
            
            return output;
        }
    }
}
