using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab01
{
    internal class Triangle : Figure
    {
        float size;


        public void Set()
        {
            size = 100;
        }
        public Triangle()
        {
        }
        public PointF ptest = new PointF();
        public override bool test(float x, float y)
        {

            return true;
        }
        public PointF[] p = new PointF[3];
        public override void draw(Graphics g)
        {
            Set();
            p[0].X = pos_x;
            p[0].Y = pos_y;

            p[1].X = (float)(pos_x + size * -Math.Cos(0));
            p[1].Y = (float)(pos_y + size * -Math.Sin(0));

            p[2].X = (float)(pos_x + size * -Math.Cos(Math.PI / 3));
            p[2].Y = (float)(pos_y + size * -Math.Sin(Math.PI / 3));
            Pen pen = Pens.Black;
            if (selected == true) pen = Pens.Red;
            g.DrawPolygon(pen, p);
        }
       
    }
}
