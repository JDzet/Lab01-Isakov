using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Form1 : Form
    {
        int old_x, old_y;
        List <Figure> lst = new List <Figure>();

        Figure createFigure(string fig_type)
        {
            switch (fig_type)
            {
                case "Circle": return new Circle();
                case "Square": return new Square();
                case "Triangle": return new Triangle();

            }
            return null;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, 0, 0, pictureBoxMain.Width, pictureBoxMain.Height);
            foreach (Figure fig in lst)
                fig.draw(e.Graphics);
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Figure fig in lst)
                fig.selected = false;
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                Figure fig = lst[i];
                fig.selected |= fig.test(e.X, e.Y);
                if (fig.selected == true) break;
            }
            pictureBoxMain.Invalidate();
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                int dx = e.X - old_x;
                int dy = e.Y - old_y;
                foreach (Figure fig in lst)
                {
                    if (fig.selected == false) continue;
                    fig.pos_x += dx;
                    fig.pos_y += dy;
                }
                pictureBoxMain.Invalidate();
            }
            old_x = e.X;
            old_y = e.Y;
        }


        int rectNum = 1;
        int circNum = 1;
        int triangNum = 1;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Figure fig = createFigure(comboBoxFigur.Text);
            if (fig == null) return;
            fig.pos_x = 100.0f;
            fig.pos_y = 100.0f;
            lst.Add(fig);
            switch (comboBoxFigur.Text)
            {
                case "Square": listBoxMain.Items.Add(comboBoxFigur.Text + rectNum.ToString()); rectNum++; break;
                case "Circle": listBoxMain.Items.Add(comboBoxFigur.Text + circNum.ToString()); circNum++; break;
                case "Triangle": listBoxMain.Items.Add(comboBoxFigur.Text + triangNum.ToString()); triangNum++; break;
            } 


            pictureBoxMain.Invalidate();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < lst.Count)
            { 
                if(lst[i].selected == true){ lst.RemoveAt(i); listBoxMain.Items.RemoveAt(i);}
                i++;
            }
            pictureBoxMain.Invalidate();
        }


        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Figure fig in lst)
                fig.selected = false;
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                try
                {
                    Figure fig = lst[Convert.ToInt32(listBoxMain.SelectedIndex)];
                    fig.selected = true;
                }
                catch { }

            }
            pictureBoxMain.Invalidate();
        }
    }
}
