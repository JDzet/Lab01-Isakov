using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab01
{
    internal class Square: Figure
    {
        public float side;
        public float half_side;

        public Square()
        {
            side = 100;
        }

        public void set() 
        {
            side = 100;
            half_side = side + 0.5f;
        }

        public override bool test(float x, float y)
        {
            set();
            float xmin = pos_x - half_side;
            float ymin = pos_y - half_side;
            float xmax = pos_x + half_side;
            float ymax = pos_y + half_side;
            if (x < xmin || y < ymin) return false;
            if(x > xmax || y > ymax) return false;
            return true;
        }

        public override void draw(Graphics g)
        {
            set();
            float x0 = pos_x - half_side;
            float y0 = pos_y - half_side;
            Pen p = Pens.Black;
            if (selected == true) p = Pens.Red;
            g.DrawRectangle(p, x0, y0, side, side);
        }
    }
}
