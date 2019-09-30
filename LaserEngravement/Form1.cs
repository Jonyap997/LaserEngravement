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
using System.IO.Ports;

namespace LaserEngravement
{
    public partial class LaserEngravementProgram : Form
    {
        public SerialPort myport;
        public int[,] picArray = new int[100, 200];
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
            ToGrayScale(bmp,picArray);
            //bmp.Save(resizedImagePath);

            picSampleImage.Image = bmp;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEngrave_Click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            int pixelValue = 0;
            myport.BaudRate = 9600;
            myport.PortName = "COM5";
            myport.Open();

            for (int y = 0; y < picArray.GetLength(0); y++) //row
            {
                for (int x = 0; x < picArray.GetLength(1); x++) //col
                {
                    if (y % 2 == 0) //even row
                    {
                        pixelValue = GrayScaleMapping(picArray[y,x]);
                    }
                    else
                    {
                        pixelValue = GrayScaleMapping(picArray[y, picArray.GetLength(1)-1-x]);
                    }

                    myport.WriteLine(pixelValue.ToString());
                }
            }

            myport.Close();
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

        private void ToGrayScale(Bitmap Bmp, int[,] picArray)
        {
            int rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                    picArray[y, x] = rgb;

                }
            }
                
        }

        private int GrayScaleMapping(int rgb)
        {
            //maps 0-255 to 0-7
            return rgb / 32;
        }

    }
}
