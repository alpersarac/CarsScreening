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
            this.urlTxbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // urlBttn
            // 
            this.urlBttn.Location = new System.Drawing.Point(713, 12);
            this.urlBttn.Name = "urlBttn";
            this.urlBttn.Size = new System.Drawing.Size(75, 23);
            this.urlBttn.TabIndex = 0;
            this.urlBttn.Text = "GO";
            this.urlBttn.UseVisualStyleBackColor = true;
            // 
            // pContainer
            // 
            this.pContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContainer.Location = new System.Drawing.Point(12, 38);
            this.pContainer.Name = "pContainer";
            this.pContainer.Size = new System.Drawing.Size(776, 400);
            this.pContainer.TabIndex = 1;
            // 
            // urlTxbx
            // 
            this.urlTxbx.Location = new System.Drawing.Point(12, 12);
            this.urlTxbx.Name = "urlTxbx";
            this.urlTxbx.Size = new System.Drawing.Size(695, 20);
            this.urlTxbx.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.urlTxbx);
            this.Controls.Add(this.pContainer);
            this.Controls.Add(this.urlBttn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button urlBttn;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.TextBox urlTxbx;
    }
}

