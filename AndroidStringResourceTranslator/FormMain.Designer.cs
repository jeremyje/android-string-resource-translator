namespace AndroidStringResourceTranslator
{
    partial class FormMain
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
            this.cbSourceLang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkApiKey = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBingApiKey = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStartProcess = new System.Windows.Forms.Button();
            this.txtRootDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbTranslateService = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSourceLang
            // 
            this.cbSourceLang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSourceLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceLang.FormattingEnabled = true;
            this.cbSourceLang.Location = new System.Drawing.Point(122, 106);
            this.cbSourceLang.Name = "cbSourceLang";
            this.cbSourceLang.Size = new System.Drawing.Size(398, 21);
            this.cbSourceLang.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Original Language:";
            // 
            // linkApiKey
            // 
            this.linkApiKey.AutoSize = true;
            this.linkApiKey.Location = new System.Drawing.Point(119, 63);
            this.linkApiKey.Name = "linkApiKey";
            this.linkApiKey.Size = new System.Drawing.Size(256, 13);
            this.linkApiKey.TabIndex = 17;
            this.linkApiKey.TabStop = true;
            this.linkApiKey.Text = "Click Here to get an Api Key. (Login maybe required.)";
            this.linkApiKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkApiKey_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Api Key:";
            // 
            // txtBingApiKey
            // 
            this.txtBingApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBingApiKey.Location = new System.Drawing.Point(122, 40);
            this.txtBingApiKey.Name = "txtBingApiKey";
            this.txtBingApiKey.Size = new System.Drawing.Size(398, 20);
            this.txtBingApiKey.TabIndex = 15;
            this.txtBingApiKey.Leave += new System.EventHandler(this.txtBingApiKey_Leave);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.AutoSize = true;
            this.txtStatus.Location = new System.Drawing.Point(12, 152);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(72, 13);
            this.txtStatus.TabIndex = 14;
            this.txtStatus.Text = "[Status Label]";
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Select Android Project Folder";
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartProcess.Location = new System.Drawing.Point(445, 147);
            this.btnStartProcess.Name = "btnStartProcess";
            this.btnStartProcess.Size = new System.Drawing.Size(75, 23);
            this.btnStartProcess.TabIndex = 13;
            this.btnStartProcess.Text = "Start";
            this.btnStartProcess.UseVisualStyleBackColor = true;
            this.btnStartProcess.Click += new System.EventHandler(this.btnStartProcess_Click);
            // 
            // txtRootDirectory
            // 
            this.txtRootDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootDirectory.Location = new System.Drawing.Point(122, 14);
            this.txtRootDirectory.Name = "txtRootDirectory";
            this.txtRootDirectory.Size = new System.Drawing.Size(317, 20);
            this.txtRootDirectory.TabIndex = 12;
            this.txtRootDirectory.TextChanged += new System.EventHandler(this.txtRootDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Project Directory:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(445, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbTranslateService
            // 
            this.cbTranslateService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTranslateService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTranslateService.FormattingEnabled = true;
            this.cbTranslateService.Location = new System.Drawing.Point(122, 79);
            this.cbTranslateService.Name = "cbTranslateService";
            this.cbTranslateService.Size = new System.Drawing.Size(398, 21);
            this.cbTranslateService.TabIndex = 21;
            this.cbTranslateService.SelectedIndexChanged += new System.EventHandler(this.cbTranslateService_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Translation Provider:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 182);
            this.Controls.Add(this.cbTranslateService);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSourceLang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkApiKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBingApiKey);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnStartProcess);
            this.Controls.Add(this.txtRootDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Android String Resource Translator Tool";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSourceLang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkApiKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBingApiKey;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Button btnStartProcess;
        private System.Windows.Forms.TextBox txtRootDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cbTranslateService;
        private System.Windows.Forms.Label label4;
    }
}

