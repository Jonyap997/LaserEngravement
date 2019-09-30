namespace LaserEngravement
{
    partial class LaserEngravementProgram
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUploadImage = new System.Windows.Forms.Label();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.txtUploadImage = new System.Windows.Forms.TextBox();
            this.lblSampleImage = new System.Windows.Forms.Label();
            this.picSampleImage = new System.Windows.Forms.PictureBox();
            this.btnEngrave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.lblNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSampleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(43, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(461, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Laser engravement program";
            // 
            // lblUploadImage
            // 
            this.lblUploadImage.AutoSize = true;
            this.lblUploadImage.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadImage.Location = new System.Drawing.Point(49, 154);
            this.lblUploadImage.Name = "lblUploadImage";
            this.lblUploadImage.Size = new System.Drawing.Size(111, 23);
            this.lblUploadImage.TabIndex = 1;
            this.lblUploadImage.Text = "Upload image:";
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUploadImage.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.Location = new System.Drawing.Point(430, 155);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(35, 23);
            this.btnUploadImage.TabIndex = 3;
            this.btnUploadImage.Text = "...";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // txtUploadImage
            // 
            this.txtUploadImage.Location = new System.Drawing.Point(166, 156);
            this.txtUploadImage.Name = "txtUploadImage";
            this.txtUploadImage.ReadOnly = true;
            this.txtUploadImage.Size = new System.Drawing.Size(258, 22);
            this.txtUploadImage.TabIndex = 2;
            this.txtUploadImage.TextChanged += new System.EventHandler(this.txtUploadImage_TextChanged);
            // 
            // lblSampleImage
            // 
            this.lblSampleImage.AutoSize = true;
            this.lblSampleImage.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleImage.Location = new System.Drawing.Point(49, 199);
            this.lblSampleImage.Name = "lblSampleImage";
            this.lblSampleImage.Size = new System.Drawing.Size(114, 23);
            this.lblSampleImage.TabIndex = 4;
            this.lblSampleImage.Text = "Sample image:";
            // 
            // picSampleImage
            // 
            this.picSampleImage.Location = new System.Drawing.Point(169, 199);
            this.picSampleImage.Name = "picSampleImage";
            this.picSampleImage.Size = new System.Drawing.Size(275, 125);
            this.picSampleImage.TabIndex = 5;
            this.picSampleImage.TabStop = false;
            // 
            // btnEngrave
            // 
            this.btnEngrave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnEngrave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEngrave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEngrave.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEngrave.Location = new System.Drawing.Point(166, 371);
            this.btnEngrave.Name = "btnEngrave";
            this.btnEngrave.Size = new System.Drawing.Size(80, 35);
            this.btnEngrave.TabIndex = 6;
            this.btnEngrave.Text = "Engrave";
            this.btnEngrave.UseVisualStyleBackColor = true;
            this.btnEngrave.Click += new System.EventHandler(this.btnEngrave_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(166, 423);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 35);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEmergency
            // 
            this.btnEmergency.BackColor = System.Drawing.Color.Red;
            this.btnEmergency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnEmergency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEmergency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmergency.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmergency.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnEmergency.Location = new System.Drawing.Point(259, 371);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(110, 87);
            this.btnEmergency.TabIndex = 8;
            this.btnEmergency.Text = "Emergency Kill Switch";
            this.btnEmergency.UseVisualStyleBackColor = false;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.Location = new System.Drawing.Point(165, 336);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(186, 20);
            this.lblNotice.TabIndex = 9;
            this.lblNotice.Text = "Note: Image will be in grey scale";
            // 
            // LaserEngravementProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(582, 466);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.btnEmergency);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEngrave);
            this.Controls.Add(this.picSampleImage);
            this.Controls.Add(this.lblSampleImage);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.txtUploadImage);
            this.Controls.Add(this.lblUploadImage);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LaserEngravementProgram";
            this.Text = "Laser Engravement Program";
            this.Load += new System.EventHandler(this.LaserEngravementProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSampleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUploadImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.TextBox txtUploadImage;
        private System.Windows.Forms.Label lblSampleImage;
        private System.Windows.Forms.PictureBox picSampleImage;
        private System.Windows.Forms.Button btnEngrave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Label lblNotice;
    }
}

