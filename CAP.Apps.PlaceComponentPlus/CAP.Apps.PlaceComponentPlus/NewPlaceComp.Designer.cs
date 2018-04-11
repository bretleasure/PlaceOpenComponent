namespace CAP.Apps.PlaceComponentPlus
{
    partial class PlaceOpenCompUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaceOpenCompUI));
            this.lb_OpenDocs = new System.Windows.Forms.ListBox();
            this.btn_Place = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_OpenDocs
            // 
            this.lb_OpenDocs.FormattingEnabled = true;
            this.lb_OpenDocs.Location = new System.Drawing.Point(12, 43);
            this.lb_OpenDocs.Name = "lb_OpenDocs";
            this.lb_OpenDocs.Size = new System.Drawing.Size(195, 147);
            this.lb_OpenDocs.TabIndex = 0;
            this.lb_OpenDocs.SelectedIndexChanged += new System.EventHandler(this.lb_OpenDocs_SelectedIndexChanged);
            this.lb_OpenDocs.DoubleClick += new System.EventHandler(this.btn_Place_Click);
            // 
            // btn_Place
            // 
            this.btn_Place.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Place.Location = new System.Drawing.Point(213, 204);
            this.btn_Place.Name = "btn_Place";
            this.btn_Place.Size = new System.Drawing.Size(147, 23);
            this.btn_Place.TabIndex = 1;
            this.btn_Place.Text = "Place in Assembly";
            this.btn_Place.UseVisualStyleBackColor = true;
            this.btn_Place.Click += new System.EventHandler(this.btn_Place_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a Component to Place";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(213, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // PlaceOpenCompUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 239);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Place);
            this.Controls.Add(this.lb_OpenDocs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaceOpenCompUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Place Open Component";
            this.Load += new System.EventHandler(this.PlaceComponentUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_OpenDocs;
        private System.Windows.Forms.Button btn_Place;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}