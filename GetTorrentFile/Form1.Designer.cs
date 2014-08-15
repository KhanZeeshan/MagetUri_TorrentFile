namespace GetTorrentFile
{
    partial class MainDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_MagnetLink = new System.Windows.Forms.TextBox();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.LnkLbl_Open = new System.Windows.Forms.LinkLabel();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Magnet Link:";
            // 
            // Txt_MagnetLink
            // 
            this.Txt_MagnetLink.Location = new System.Drawing.Point(12, 35);
            this.Txt_MagnetLink.Multiline = true;
            this.Txt_MagnetLink.Name = "Txt_MagnetLink";
            this.Txt_MagnetLink.Size = new System.Drawing.Size(428, 79);
            this.Txt_MagnetLink.TabIndex = 1;
            // 
            // Btn_Download
            // 
            this.Btn_Download.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Download.Location = new System.Drawing.Point(330, 127);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(110, 29);
            this.Btn_Download.TabIndex = 2;
            this.Btn_Download.Text = "Get Torrent File";
            this.Btn_Download.UseVisualStyleBackColor = true;
            this.Btn_Download.Click += new System.EventHandler(this.Btn_Download_Click);
            // 
            // LnkLbl_Open
            // 
            this.LnkLbl_Open.Location = new System.Drawing.Point(9, 127);
            this.LnkLbl_Open.Name = "LnkLbl_Open";
            this.LnkLbl_Open.Size = new System.Drawing.Size(176, 29);
            this.LnkLbl_Open.TabIndex = 3;
            this.LnkLbl_Open.TabStop = true;
            this.LnkLbl_Open.Text = "File Downloaded, Click To Open";
            this.LnkLbl_Open.Visible = false;
            this.LnkLbl_Open.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLbl_Open_LinkClicked);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Clear.Location = new System.Drawing.Point(392, 3);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(48, 25);
            this.Btn_Clear.TabIndex = 4;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 162);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.LnkLbl_Open);
            this.Controls.Add(this.Btn_Download);
            this.Controls.Add(this.Txt_MagnetLink);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainDialog";
            this.Text = "Torrent File Downloader";
            this.Load += new System.EventHandler(this.MainDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_MagnetLink;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.LinkLabel LnkLbl_Open;
        private System.Windows.Forms.Button Btn_Clear;
    }
}

