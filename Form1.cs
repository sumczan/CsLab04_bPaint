using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class Form1 : Form
    {
        private enum Shape
        {
            Pen,
            Rectangle,
            Line
        }

        private Shape currentShape;
        private Color currentColor;

        Point start;
        Point end;

        Graphics drawing;

        Pen pen;

        float penThickness;

        public Form1()
        {
            InitializeComponent();
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox2.SelectedIndex = 0;
            drawing = pictureBox1.CreateGraphics();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            currentShape = (Shape)Enum.Parse(typeof(Shape), (String)toolStripComboBox1.SelectedItem);
            //currentShape = (Shape)toolStripComboBox1.SelectedItem;
            //currentColor = (Color)toolStripComboBox2.SelectedItem;
            currentColor = Color.FromName((String)toolStripComboBox2.SelectedItem);
            start.X = e.X;
            start.Y = e.Y;

            Brush brush = new SolidBrush(currentColor);
            pen = new Pen(brush);
            penThickness = 2.0f;
            pen.Width = penThickness;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                end.X = e.X;
                end.Y = e.Y;
                if(currentShape == Shape.Pen)
                {
                    DrawPen();
                    start.X = e.X;
                    start.Y = e.Y;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currentShape)
            {
                case Shape.Pen:
                    DrawPen();
                    break;
                case Shape.Rectangle:
                    DrawRectangle();
                    break;
                case Shape.Line:
                    DrawLine();
                    break;
                default:
                    break;
            }
                
        }

        private void DrawPen()
        {
            drawing.SmoothingMode = SmoothingMode.AntiAlias;
            drawing.DrawLine(pen, start, end);
        }

        private void DrawRectangle()
        {
            drawing.SmoothingMode = SmoothingMode.AntiAlias;
            int x;
            int y;
            int width;
            int height;

            x = ((start.X < end.X) ? start.X : end.X);
            y = ((start.Y < end.Y) ? start.Y : end.Y);
            width = Math.Abs(start.X - end.X);
            height = Math.Abs(start.Y - end.Y);

            drawing.DrawRectangle(pen, x, y, width, height);
        }

        private void DrawLine()
        {
            drawing.SmoothingMode = SmoothingMode.AntiAlias;
            drawing.DrawLine(pen, start, end);
        }


    }
}
