using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plane_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        float x0 = 0;
        float y0 = 0;
        float t = 0;
        Graphics g;

        bool landing = false;

        bool waitend = false;

        bool back = false;
        bool ace = false;
        bool strongwind = false;
        bool snow = false;
       

        bool light = false;
        bool takeoff = false;
        int n = 0;
        
        float x1=100;
        float x2 = 91;
        float x3 = 950;
        float y3 = 75;


        private void onPaint(object sender, PaintEventArgs e)
        {
           g = e.Graphics;

           
            DrawRunway(g, x0+150, y0+40);
            DrawRunway(g, x0 + 150, y0 + 120);    
            
            //DrawHangar(g, x0 + 10, y0 + 40);
            DrawHangar(g, x0 + 10, y0 + 40);
           

            if (x2<600 && !back && snow)
            {
                DrawSnow(g, x0 + 160, y0 + 48);
                DrawSnow(g, x0 + 160, y0 + 128);
                
            }
            

            

            

            if (x1 > 950)
            {
                takeoff = false;
                x1 = 100;
                timer1.Enabled = false;
               
            }

            if(y3<10)
            {
                y3 = 75;
                x3 = 950;
            }

            if (x3 <130)
            {
                landing = false;
                x3 = 950;
                waitend = false;
                timer4.Enabled = false;

            }

            if (!ace && takeoff && !strongwind && !snow)
            {
                timer1.Enabled = true;
                timer1.Interval = 50;
            }

            //if (landing && !strongwind && !snow)
            if (landing)
            {
                timer4.Enabled = true;
                timer4.Interval = 50;
            }

            if (light)
                label5.Text = "Темно";
            else
                label5.Text = "Светло";

            if (snow)
            {
                if (x2 > 600)
                    back = true;
                if (x2 > 100 && x2 < 600 && !back)
                {
                    DrawRunway2(g, x0 + 150, y0 + 40, x2 + 40 - 150);
                    DrawRunway2(g, x0 + 150, y0 + 120, x2 + 40 - 150);
                }
                if(x2>90)
                {
                    DrawCar(g, x2, y0 + 60);
                    DrawCar(g, x2, y0 + 140);
                }
            }

            if (light)
                DrawLight(g);

            if (takeoff)
                DrawPlane(g, x1, y0 + 152);

            if (landing)
                DrawPlane2(g, x3, y3);

           
        }

        void DrawPlane(Graphics g, float x0, float y0)
        {

            //SolidBrush p = new SolidBrush(Color.Blue);
            //g.FillEllipse(p, x0, y0, 25, 25);
            Pen p1 = new Pen(Color.Blue, 4);
            g.DrawLines(p1, new PointF[] { new PointF(x0, y0),  new PointF(x0+45, y0) });
            g.DrawLines(p1, new PointF[] { new PointF(x0-10, y0-10), new PointF(x0, y0), new PointF(x0 -10, y0+10) });
            g.DrawLines(p1, new PointF[] { new PointF(x0 +10, y0 - 25), new PointF(x0+30, y0), new PointF(x0+10, y0 + 25) });

        }

        void DrawPlane2(Graphics g, float x0, float y0)
        {

            //SolidBrush p = new SolidBrush(Color.Blue);
            //g.FillEllipse(p, x0, y0, 25, 25);
            Pen p1 = new Pen(Color.Blue, 4);
            g.DrawLines(p1, new PointF[] { new PointF(x0-45, y0), new PointF(x0, y0) });
            g.DrawLines(p1, new PointF[] { new PointF(x0 + 10, y0 + 10), new PointF(x0, y0), new PointF(x0 + 10, y0 - 10) });
            g.DrawLines(p1, new PointF[] { new PointF(x0 -10, y0 - 25), new PointF(x0 - 30, y0), new PointF(x0-10 , y0 + 25) });

        }

        void DrawSnow(Graphics g, float x0, float y0)
        {
            //SolidBrush r = new SolidBrush(Color.WhiteSmoke);
            SolidBrush r = new SolidBrush(Color.WhiteSmoke);
            Image image1 = new Bitmap("snow.bmp");
            TextureBrush r1 = new TextureBrush(image1);
            
            g.FillRectangle(r1, x0, y0, 480, 55);
        }

        void DrawLight(Graphics g)
        {
            DrawLight(g, x0 + 160, y0 + 39);
            DrawLight(g, x0 + 160, y0 + 102);
            DrawLight(g, x0 + 160, y0 + 119);
            DrawLight(g, x0 + 160, y0 + 183);
        }

        void DrawLight(Graphics g, float x0, float y0)
        {
             SolidBrush l = new SolidBrush(Color.Red);
             float delta = 0;
             for (int i = 1; i <= 6; i++)
             {
                 g.FillEllipse(l, x0+delta, y0, 6, 6);
                 delta += 90;
             }
        }


        void DrawHangar(Graphics g, float x0, float y0)
        {
            SolidBrush r = new SolidBrush(Color.Orange);
            g.FillRectangle(r, x0, y0, 80, 150);
        }

        void DrawCar(Graphics g, float x0, float y0)
        {
            SolidBrush r = new SolidBrush(Color.Red);
            g.FillRectangle(r, x0, y0, 40, 20);
        }

        void DrawRunway(Graphics g, float x0, float y0)
        {
             SolidBrush r = new SolidBrush(Color.Black);
             g.FillRectangle(r, x0, y0, 500, 70);
        }

        void DrawRunway2(Graphics g, float x0, float y0, float x2)
        {
            SolidBrush r = new SolidBrush(Color.Black);
            g.FillRectangle(r, x0, y0, x2, 70);
        }
        
        private void onTick(object sender, EventArgs e)
        {

            x1 += 10;
            panel1.Invalidate();
        }

        private void onDoubleClick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            light = true;            
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            light = false;          
            panel1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            takeoff = true;
            panel1.Invalidate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label13.Text = numericUpDown1.Value.ToString();
            if (numericUpDown1.Value > 10)
            {
                numericUpDown1.BackColor = Color.DarkSalmon;
                label13.ForeColor = Color.Red;
                strongwind = true;
                panel1.Invalidate();
            }
            else
            {
                label13.ForeColor = Color.Green;
                numericUpDown1.BackColor = Color.White;
                strongwind = false;
                panel1.Invalidate();
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ace = true;
            panel1.Invalidate();
            label9.Text = "Есть";
            label9.ForeColor = Color.Red;
            label16.ForeColor = Color.DarkBlue;
            
            label16.Text = "Включение подогрева крыльев...";
            timer2.Enabled = true;
            timer2.Interval = 15000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void onTick2(object sender, EventArgs e)
        {
            ace = false;
            label16.Text = "";
            label9.Text = "Нет";
            label9.ForeColor = Color.Green;
            panel1.Invalidate();
            timer2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            snow = true;
            label11.ForeColor = Color.Red;
            label11.Text = "Есть";
            label17.ForeColor = Color.DarkBlue;
            label17.Text = "Выезд снегоуборочных машин...";
            panel1.Invalidate();

            timer3.Enabled = true;
            timer3.Interval = 100;
        }

        private void onTick3(object sender, EventArgs e)
        {            
            if (back)
                x2 -= 4;
            else
                 x2 += 4;

            if (x2 < 90)
            {
                snow = false;
                x2 = 91;
                back = false;
                label17.Text = "";
                label11.ForeColor = Color.Green;
                label11.Text = "Нет";
                timer3.Enabled = false;

            }
            panel1.Invalidate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            landing = true;
            panel1.Invalidate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (landing && !strongwind && !snow && y3==75)
            {
                waitend=true;
            }

            if (waitend)
            {
                x3 -= 10;                
            }
            else
            {
                x3 -= 8;
                y3 -= 1;
            }


            panel1.Invalidate();
        }

    
    }
}
