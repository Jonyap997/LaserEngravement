using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LaserEngravement
{
    public partial class LaserEngravementProgram : Form
    {
        public LaserEngravementProgram()
        {
            InitializeComponent();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadImage = new OpenFileDialog();

            uploadImage.InitialDirectory = @"C:\";
            uploadImage.RestoreDirectory = true;
            uploadImage.Title = "Upload Image File";
            uploadImage.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            uploadImage.CheckFileExists = true;
            uploadImage.CheckPathExists = true;
            uploadImage.Multiselect = false;

            if (uploadImage.ShowDialog() == DialogResult.OK)
            {
                txtUploadImage.Text = uploadImage.FileName;
                
            }

        }

        private void txtUploadImage_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"(\.(png|jpg|jpeg||jpe|jfif|bmp))";
            string replacement = "_resized" + "$1";
            string resizedImagePath = Regex.Replace(txtUploadImage.Text, pattern, replacement,RegexOptions.IgnoreCase);
            System.Drawing.Image img = System.Drawing.Image.FromFile(txtUploadImage.Text);
            Bitmap bmp = Resize(img, 200, 100);
            ToGrayScale(bmp);
            bmp.Save(resizedImagePath);

            picSampleImage.Image = new Bitmap(resizedImagePath);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEngrave_Click(object sender, EventArgs e)
        {

        }

        //resize image 
        private Bitmap Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return bmp;
        }

        private void LaserEngravementProgram_Load(object sender, EventArgs e)
        {

        }

        private void ToGrayScale(Bitmap Bmp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
