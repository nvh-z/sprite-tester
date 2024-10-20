using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using WindowsFormsApp1.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int ani;

        public Form1()
        {
            base.Load += Form1_Load;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBox1.Text = "Down";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Images (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox3.Image = Image.FromFile(openFileDialog.FileName);
                Timer1.Enabled = true;
            }
            openFileDialog.Dispose();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(233, 164, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            Application.DoEvents();
            ref int reference = ref ani;
            ref int reference2 = ref reference;
            reference = reference2 + 1;
            if (ani > 3)
            {
                ani = 0;
            }
            graphics.DrawImage(PictureBox2.Image, 0, 0);
            if (PictureBox3.Image.Width > 256)
            {
                Rectangle destRect = new Rectangle(17, -5, 128, 128);
                if (string.Compare(ComboBox1.Text, "Right", false) == 0)
                {
                    graphics.DrawImage(PictureBox3.Image, destRect, ani * 128, 256, 128, 128, GraphicsUnit.Pixel);
                    goto graphdisposing;
                }
                if (string.Compare(ComboBox1.Text, "Up", false) == 0)
                {
                    graphics.DrawImage(PictureBox3.Image, destRect, ani * 128, 384, 128, 128, GraphicsUnit.Pixel);
                    goto graphdisposing;
                }
                if (string.Compare(ComboBox1.Text, "Left", false) == 0)
                {
                    graphics.DrawImage(PictureBox3.Image, destRect, ani * 128, 128, 128, 128, GraphicsUnit.Pixel);
                    goto graphdisposing;
                }
                graphics.DrawImage(PictureBox3.Image, destRect, ani * 128, 0, 128, 128, GraphicsUnit.Pixel);
                goto graphdisposing;
            }
            Rectangle destRect2 = new Rectangle(48, 60, 64, 64);
            if (string.Compare(ComboBox1.Text, "Right", false) == 0)
            {
                graphics.DrawImage(PictureBox3.Image, destRect2, ani * 64, 128, 64, 64, GraphicsUnit.Pixel);
                goto graphdisposing;
            }
            if (string.Compare(ComboBox1.Text, "Up", false) == 0)
            {
                graphics.DrawImage(PictureBox3.Image, destRect2, ani * 64, 192, 64, 64, GraphicsUnit.Pixel);
                goto graphdisposing;
            }
            if (string.Compare(ComboBox1.Text, "Left", false) == 0)
            {
                graphics.DrawImage(PictureBox3.Image, destRect2, ani * 64, 64, 64, 64, GraphicsUnit.Pixel);
                goto graphdisposing;
            }
            graphics.DrawImage(PictureBox3.Image, destRect2, ani * 64, 0, 64, 64, GraphicsUnit.Pixel);
            goto graphdisposing;
            graphdisposing:
            graphics.Dispose();
            PictureBox1.Image = image;
        }
    }
}
