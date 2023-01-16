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

        private void label1_Click(object sender, EventArgs e)
        {

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
                string ffmpegOutput = RunFFmpegCommand("-i " + videoFilePath, txtFfmpegLocation.Text);
                int startIndex = ffmpegOutput.IndexOf("Duration: ") + "Duration: ".Length;
                int endIndex = ffmpegOutput.IndexOf(",", startIndex);
                string duration = ffmpegOutput.Substring(startIndex, endIndex - startIndex).Trim();
                TimeSpan videoLength = TimeSpan.Parse(duration);

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
                Random rnd = new Random();
                outputFile = @"C:\ffmpeg\bin\vidout" + rnd.Next(10, 90) + ".mp4";
            }
            Console.WriteLine("Output file: " + outputFile);

            // FFmpeg command to convert the video file
            string command = $"-i {inputFile} -crf 18 -preset slow -c:a copy {outputFile}";
            Console.WriteLine("Using command: " + command);

            // Create a new process to run FFmpeg
            var ffmpeg = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = txtFfmpegLocation.Text,
                    Arguments = command,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            Console.WriteLine("Creating FFMPEG process using " + txtFfmpegLocation.Text);

            // Start the process
            ffmpeg.Start();
            Console.WriteLine("Starting FFMPEG process");

            // Read the output from FFmpeg
            // I don't know why, but reading standard output causes this app to hang???
            //Console.WriteLine("About to read Standard Output");
            //var output = ffmpeg.StandardOutput.ReadToEnd();
            
            // On the other ahnd, reading error output is essential otherwise ffmpeg never closes
            Console.WriteLine("About to read Error Output");
            var error = ffmpeg.StandardError.ReadToEnd();


            // Wait for the process to exit
            Console.WriteLine("Waiting for process to exit");
            ffmpeg.WaitForExit();
            Console.WriteLine("Process has exited");

            // Print the output
            //Console.WriteLine(output);
            Console.WriteLine(error);

            lblStatus.Text = "Output file created at " + outputFile;
        }

        static string RunFFmpegCommand(string arguments, string ffmpegloc)
        {
            Process process = new Process();
            process.StartInfo.FileName = ffmpegloc;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
