namespace FFGUI
{
    partial class frmGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFfmpegLocation = new System.Windows.Forms.TextBox();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.lblExeLocation = new System.Windows.Forms.Label();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtFinish = new System.Windows.Forms.TextBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnExeLocation = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.grpFileInfo = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.openFileDialogFFMPEG = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.grpFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFfmpegLocation
            // 
            this.txtFfmpegLocation.Location = new System.Drawing.Point(133, 9);
            this.txtFfmpegLocation.Name = "txtFfmpegLocation";
            this.txtFfmpegLocation.Size = new System.Drawing.Size(399, 20);
            this.txtFfmpegLocation.TabIndex = 0;
            this.txtFfmpegLocation.Text = "C:\\ffmpeg\\bin\\ffmpeg.exe";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(133, 35);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(399, 20);
            this.txtInputFile.TabIndex = 1;
            this.txtInputFile.Text = "C:\\ffmpeg\\bin\\vid.mp4";
            // 
            // lblExeLocation
            // 
            this.lblExeLocation.AutoSize = true;
            this.lblExeLocation.Location = new System.Drawing.Point(13, 12);
            this.lblExeLocation.Name = "lblExeLocation";
            this.lblExeLocation.Size = new System.Drawing.Size(110, 13);
            this.lblExeLocation.TabIndex = 2;
            this.lblExeLocation.Text = "FFMPEG exe location";
            this.lblExeLocation.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(12, 38);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(87, 13);
            this.lblInputFile.TabIndex = 3;
            this.lblInputFile.Text = "Input file location";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(12, 65);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(78, 13);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start (seconds)";
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Location = new System.Drawing.Point(12, 89);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(83, 13);
            this.lblFinish.TabIndex = 5;
            this.lblFinish.Text = "Finish (seconds)";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(133, 62);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 6;
            // 
            // txtFinish
            // 
            this.txtFinish.Location = new System.Drawing.Point(133, 89);
            this.txtFinish.Name = "txtFinish";
            this.txtFinish.Size = new System.Drawing.Size(100, 20);
            this.txtFinish.TabIndex = 7;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(15, 119);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(128, 17);
            this.chkOverwrite.TabIndex = 8;
            this.chkOverwrite.Text = "Overwrite source file?";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(15, 143);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnExeLocation
            // 
            this.btnExeLocation.Location = new System.Drawing.Point(539, 7);
            this.btnExeLocation.Name = "btnExeLocation";
            this.btnExeLocation.Size = new System.Drawing.Size(106, 23);
            this.btnExeLocation.TabIndex = 10;
            this.btnExeLocation.Text = "Find FFMPEG";
            this.btnExeLocation.UseVisualStyleBackColor = true;
            this.btnExeLocation.Click += new System.EventHandler(this.btnExeLocation_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(539, 35);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(106, 23);
            this.btnOpenFile.TabIndex = 11;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // grpFileInfo
            // 
            this.grpFileInfo.Controls.Add(this.lblStatus);
            this.grpFileInfo.Location = new System.Drawing.Point(251, 65);
            this.grpFileInfo.Name = "grpFileInfo";
            this.grpFileInfo.Size = new System.Drawing.Size(393, 100);
            this.grpFileInfo.TabIndex = 12;
            this.grpFileInfo.TabStop = false;
            this.grpFileInfo.Text = "File Info";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 0;
            // 
            // openFileDialogFFMPEG
            // 
            this.openFileDialogFFMPEG.FileName = "openFileDialogFFMPEG";
            this.openFileDialogFFMPEG.Title = "Locate the FFMPEG Executable";
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.FileName = "openFileDialogInput";
            this.openFileDialogInput.Title = "Select an input file";
            // 
            // frmGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 178);
            this.Controls.Add(this.grpFileInfo);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnExeLocation);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.txtFinish);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblFinish);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblInputFile);
            this.Controls.Add(this.lblExeLocation);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.txtFfmpegLocation);
            this.Name = "frmGUI";
            this.Text = "FFMPEG GUI";
            this.grpFileInfo.ResumeLayout(false);
            this.grpFileInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFfmpegLocation;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label lblExeLocation;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtFinish;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnExeLocation;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox grpFileInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialogFFMPEG;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
    }
}

