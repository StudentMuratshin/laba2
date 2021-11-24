using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba2
{
    class BoxRectangle : GraphObject
    {
        public override bool ContainsPoint(Point p)
        {
            if ((p.X <= x + 100) & (p.X >= x) & (p.Y >= y) & (p.Y <= y + 50))
            {
                if ((p.X <= x + 95) & (p.X >= x + 5) & (p.Y >= y + 5) & (p.Y <= y + 45))
                {
                    return false;
                }
                else return true;
            }
            else return false;
        }

        
        public override void Draw(Graphics g)
        {
            if (Selected)
            {
                Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
                g.DrawRectangle(blackPen, x, y, 100, 50);
            }
            else
            {
                Pen blackPen = new Pen(Color.FromArgb(255, 255, 255, 0), 5);
                g.DrawRectangle(blackPen, x, y, 100, 50);
            }
        }
    }
}