﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 閃避遊戲.control
{
    public partial class win_control3 : UserControl
          
    {
        List<Image> images = new List<Image>();
        List<Image> images1 = new List<Image>();
        List<Image> images2 = new List<Image>();
        Image image, image1, image2;
        int ok = 0;
        int a = 0;
        int a1 = 1;
        int timer = 0;
        int x, y, width, height;
        int x1, y1, width1, height1;
        public bool sttop;
        public static int over = 0;
        public event EventHandler Timestart;
        public win_control3()
        {
            InitializeComponent(); x = 0; y = 0; width = 980; height = 710; timer1.Start(); x1 = 400; y1 = 230; width1 = 180; height1 = 267;
        }

        private void win_control3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 13; i++)
            {
                image = new Bitmap("pic\\End\\" + i + ".png");
                images.Add(image);
            }
            for (int i = 0; i <= 40; i++)
            {
                image1 = new Bitmap("pic\\win\\心\\" + i + ".png");
                images1.Add(image1);
            }

            image = images[0];
            image1 = images1[0];
        }
        private void win_control3_Paint(object sender, PaintEventArgs e)
        {
            this.draw_img(e.Graphics);

            if (ok >= 1)
            {
                this.draw_img1(e.Graphics);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            stop(); over = 1; music.mciMusic("BK.wav", "play");
        }
        public void draw_img(Graphics g)  //畫背景
        {
            if (timer < 13 && ok == 0)
            {
                timer += 1;
                image = images[timer];
                if (timer == 13)
                {
                    ok = 1; timer = 0;
                }
            }
            g.DrawImage(image, x, y, width, height);
        }
        public void draw_img1(Graphics g)//畫物件
        {
            if (timer < 39 && ok == 1)
            {
                timer += 1;
                image1 = images1[timer];
                if (timer == 39)
                {
                    ok = 2; a1 = 0;
                }
            }
            else if (ok == 2)
            {

                a1 += 1;
                switch (a1)
                {
                    case 1: image1 = images1[39]; break;
                    case 6: image1 = images1[40]; a1 = -1; a += 1; break;
                }
                //if (a == 7)
                //{
                //    ok = 3;
                //}
            }

            g.DrawImage(image1, x1, y1, width1, height1);
        }
        public void stop()
        {
            images.Clear();
            sttop = true;
            this.Visible = false;
            this.Enabled = false;
            timer1.Stop();
         
        }
    }
}

