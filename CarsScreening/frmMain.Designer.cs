namespace CarsScreening
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.urlBttn = new System.Windows.Forms.Button();
            this.pContainer = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // urlBttn
            // 
            this.urlBttn.Location = new System.Drawing.Point(12, 7);
            this.urlBttn.Name = "urlBttn";
            this.urlBttn.Size = new System.Drawing.Size(75, 23);
            this.urlBttn.TabIndex = 0;
            this.urlBttn.Text = "Start";
            this.urlBttn.UseVisualStyleBackColor = true;
            this.urlBttn.Click += new System.EventHandler(this.urlBttn_Click);
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.Location = new System.Drawing.Point(12, 38);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(1880, 991);
            this.pContainer.TabIndex = 1;
            // 
            // panelStatus
            // 
            this.panelStatus.Location = new System.Drawing.Point(93, 7);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(23, 23);
            this.panelStatus.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(122, 12);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.pContainer);
            this.Controls.Add(this.urlBttn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button urlBttn;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label statusLabel;
    }
}

