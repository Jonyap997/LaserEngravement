﻿namespace LaserEngravement
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
            this.lblMode = new System.Windows.Forms.Label();
            this.rbBW = new System.Windows.Forms.RadioButton();
            this.rbGreyScale = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusBox = new System.Windows.Forms.Label();
            this.progStatus = new System.Windows.Forms.ProgressBar();
            this.lblProg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lblUploadImage.Location = new System.Drawing.Point(66, 109);
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
            this.btnUploadImage.Location = new System.Drawing.Point(447, 110);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(35, 23);
            this.btnUploadImage.TabIndex = 3;
            this.btnUploadImage.Text = "...";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // txtUploadImage
            // 
            this.txtUploadImage.Location = new System.Drawing.Point(183, 111);
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
            this.lblSampleImage.Location = new System.Drawing.Point(66, 154);
            this.lblSampleImage.Name = "lblSampleImage";
            this.lblSampleImage.Size = new System.Drawing.Size(114, 23);
            this.lblSampleImage.TabIndex = 4;
            this.lblSampleImage.Text = "Sample image:";
            // 
            // picSampleImage
            // 
            this.picSampleImage.Location = new System.Drawing.Point(186, 154);
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
            this.btnEngrave.Location = new System.Drawing.Point(195, 421);
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
            this.btnExit.Location = new System.Drawing.Point(357, 421);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 35);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(76, 291);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(104, 23);
            this.lblMode.TabIndex = 9;
            this.lblMode.Text = "Colour mode:";
            // 
            // rbBW
            // 
            this.rbBW.AutoSize = true;
            this.rbBW.Checked = true;
            this.rbBW.Location = new System.Drawing.Point(195, 291);
            this.rbBW.Name = "rbBW";
            this.rbBW.Size = new System.Drawing.Size(131, 21);
            this.rbBW.TabIndex = 10;
            this.rbBW.TabStop = true;
            this.rbBW.Text = "Black and White";
            this.rbBW.UseVisualStyleBackColor = true;
            this.rbBW.CheckedChanged += new System.EventHandler(this.rbBW_CheckedChanged);
            // 
            // rbGreyScale
            // 
            this.rbGreyScale.AutoSize = true;
            this.rbGreyScale.Location = new System.Drawing.Point(340, 291);
            this.rbGreyScale.Name = "rbGreyScale";
            this.rbGreyScale.Size = new System.Drawing.Size(97, 21);
            this.rbGreyScale.TabIndex = 11;
            this.rbGreyScale.Text = "Grey scale\r\n";
            this.rbGreyScale.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(121, 337);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 23);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusBox
            // 
            this.lblStatusBox.AutoSize = true;
            this.lblStatusBox.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBox.Location = new System.Drawing.Point(191, 337);
            this.lblStatusBox.Name = "lblStatusBox";
            this.lblStatusBox.Size = new System.Drawing.Size(0, 23);
            this.lblStatusBox.TabIndex = 13;
            // 
            // progStatus
            // 
            this.progStatus.Location = new System.Drawing.Point(195, 371);
            this.progStatus.Name = "progStatus";
            this.progStatus.Size = new System.Drawing.Size(246, 17);
            this.progStatus.TabIndex = 14;
            // 
            // lblProg
            // 
            this.lblProg.AutoSize = true;
            this.lblProg.Location = new System.Drawing.Point(225, 391);
            this.lblProg.Name = "lblProg";
            this.lblProg.Size = new System.Drawing.Size(16, 17);
            this.lblProg.TabIndex = 15;
            this.lblProg.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "/";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(366, 391);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(16, 17);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "pixels";
            // 
            // LaserEngravementProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(582, 483);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProg);
            this.Controls.Add(this.progStatus);
            this.Controls.Add(this.lblStatusBox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rbGreyScale);
            this.Controls.Add(this.rbBW);
            this.Controls.Add(this.lblMode);
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
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.RadioButton rbBW;
        private System.Windows.Forms.RadioButton rbGreyScale;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusBox;
        private System.Windows.Forms.ProgressBar progStatus;
        private System.Windows.Forms.Label lblProg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
    }
}

