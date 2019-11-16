﻿using System;
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
using System.Threading;
using System.Diagnostics;

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
        public byte[] picArrayGS = new byte[GS_NUM_OF_ELEMENTS];
        public byte[] picArrayBW = new byte[BW_NUM_OF_ELEMENTS];
        public string handshakeCommand = "";
        public bool blackWhite = true;
        public string in_data = "";
        public bool dataTransfer = true;
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

            btnEngrave.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            myport.Close();

            this.Close();

        }

        private void btnEngrave_Click(object sender, EventArgs e)
        {
            int i = 0;
            btnEngrave.Enabled = false;
            btnExit.Enabled = false;
            myport = new SerialPort();
            myport.BaudRate = 19200;
            myport.PortName = "COM3";
            //myport.DataReceived += DataReceivedHandler;
            myport.Open();
            sendData();

            btnExit.Enabled = true;
        }

        private void sendData()
        {
            int i = 0;

            myport.WriteLine("READY");
            waitForConfirmation("READY");

            if (blackWhite)
            {
                myport.WriteLine("BW MODE");
                while (i < picArrayBW.Length)
                {
                    waitForConfirmation("READY TO RECEIVE DATA");
                    myport.WriteLine("SENDING DATA");
                    myport.WriteLine(i.ToString());
                    waitForConfirmation("BYTE RECEIVED");
                    waitForConfirmation("SENDING CHECK");

                    in_data = myport.ReadLine();

                    if (in_data.Trim() == i.ToString())
                        myport.WriteLine("DATA VALID");
                    else
                        myport.WriteLine("DATA INVALID");

                    waitForConfirmation("PIXELS DONE");
                    i++;

                    if (i < picArrayBW.Length)
                    {
                        waitForConfirmation("DONE?");
                        myport.WriteLine("NOT DONE");
                        waitForConfirmation("SEND NEXT BYTE");
                    }
                }

                
            }
            else
            {
                 myport.WriteLine("GS MODE");
                 while (i < picArrayGS.Length)
                 {
                    waitForConfirmation("READY TO RECEIVE DATA");
                    myport.WriteLine("SENDING DATA");
                    myport.WriteLine(i.ToString());
                    waitForConfirmation("BYTE RECEIVED");
                    waitForConfirmation("SENDING CHECK");

                    in_data = myport.ReadLine();

                    if (in_data.Trim() == i.ToString())
                        myport.WriteLine("DATA VALID");
                    else
                        myport.WriteLine("DATA INVALID");

                    waitForConfirmation("PIXELS DONE");
                    i++;

                    if (i < picArrayBW.Length)
                    {
                        waitForConfirmation("DONE?");
                        myport.WriteLine("NOT DONE");
                        waitForConfirmation("SEND NEXT BYTE");
                    }

                }        

             }
            myport.WriteLine("DONE");
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
            btnEngrave.Enabled = false;
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

       private void waitForConfirmation(string confirmMsg)
        {
            do
            {
                in_data = myport.ReadLine();
            } while (in_data.Trim() != confirmMsg);
        }
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
