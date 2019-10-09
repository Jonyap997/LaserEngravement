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
        public const int ROW = 100;
        public const int COL = 200;
        public const int BW_PIXEL_PER_BYTE = 8; //black & white
        public const int GS_PIXEL_PER_BYTE = 2; //grey scale
        public const int BW_NUM_OF_ELEMENTS = (ROW * COL) / BW_PIXEL_PER_BYTE;
        public const int GS_NUM_OF_ELEMENTS = (ROW * COL) / GS_PIXEL_PER_BYTE;

        public SerialPort myport;
        //public byte[,] picArray = new byte[100, 200];
        public byte[] picArrayGS = new byte[GS_NUM_OF_ELEMENTS];
        public byte[] picArrayBW = new byte[BW_NUM_OF_ELEMENTS];
        public string handshakeCommand = "";
        public bool blackWhite = true;
        Bitmap bmpBW, bmpGS;

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
            bmpBW = Resize(img, 200, 100);
            bmpGS = Resize(img, 200, 100);
            picArrayBW = ToBlackWhite(bmpBW);
            picArrayGS = ToGrayScale(bmpGS);

            if (blackWhite)
                picSampleImage.Image = bmpBW;     
            else
                picSampleImage.Image = bmpGS;   
            //bmp.Save(resizedImagePath);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEngrave_Click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM5";
            myport.DataReceived += DataReceivedHandler;
            myport.Open();

            

            myport.Close();
        }

        private void sendData()
        {
            if (blackWhite)
            {
                for(int i = 0; i < picArrayBW.Length; i++)
                {
                    myport.WriteLine(picArrayBW[i].ToString());
                    while (handshakeCommand != "BYTE RECEIVED") ; //wait byte is received
                }
            }
            else
            {
                for (int i = 0; i < picArrayGS.Length; i++)
                {
                    myport.WriteLine(picArrayGS[i].ToString());
                    while (handshakeCommand != "BYTE RECEIVED") ; //wait byte is received
                }        

            }
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

        private byte[] ToGrayScale(Bitmap Bmp)
        {
            byte rgb;
            Color c;
            string rowBits = "", totalBits = "";

            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (byte)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));

                    if (y % 2 == 0) //even row
                        rowBits += ToBinary(rgb);
                    else
                        rowBits.Insert(0,ToBinary(rgb));
                }
                rowBits = "";
                totalBits += rowBits;
            }

            return GetBytesFromBinaryString(totalBits);
        }

        private string ToBinary(byte rgb)
        {
            switch(rgb)
            {
                case 0:
                    return "0000";
                case 1:
                    return "0001";
                case 2:
                    return "0010";
                case 3:
                    return "0011";
                case 4:
                    return "0100";
                case 5:
                    return "0101";
                case 6:
                    return "0110";
                case 7:
                    return "0111";
                default:
                    return "0000";
            }
        }

        /*
        private void ToGrayScale(Bitmap Bmp, byte[,] picArray)
        {
            byte rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (byte)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                    picArray[y, x] = rgb; 

                }
            }
                
        }
        */
        private byte[] ToBlackWhite(Bitmap Bmp)
        {
            byte rgb;
            Color c;
            string rowBits="", totalBits="";

            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (byte)((c.R +  c.G +  c.B) /3);

                    if (rgb < 128)
                    {
                        rgb = 0;
                        if (y % 2 == 0) //even row
                            rowBits += 1; //set bit as black (left -> right)
                        else //odd row
                            rowBits.Insert(0,"1"); //set bit as black (left <- right)
                    } 
                    else
                    {
                        rgb = 255;
                        if (y % 2 == 0) //even row
                            rowBits += 0; //set bit as black (left -> right)
                        else //odd row
                            rowBits.Insert(0, "0"); //set bit as black (left <- right)
                    }
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
                totalBits += rowBits;
                rowBits = ""; //reset row bits
            }
            return GetBytesFromBinaryString(totalBits);
        }

        private byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            handshakeCommand = sp.ReadExisting();
        }

        private void rbBW_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                picSampleImage.Image = bmpBW;
                blackWhite = true;
            }
                
            else
            {
                picSampleImage.Image = bmpGS;
                blackWhite = false;
            }
                
            
        }
    }
}
