using System;
using System.Drawing;
namespace laba2
{
    class Rectangle : GraphObject
    {
        protected int h;
        protected int w;
        public int H
        {
            get { return h; }
        }

        public int W
        {
            get { return w; }
        }
        public Rectangle() : base()
        {
            h = 50;
            w = 50;
        }
        public override bool ContainsPoint(Point p)
        {
            return (p.X <= x + w) & (p.X >= x) & (p.Y >= y) & (p.Y <= y + h);
        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);

            if (Selected)
            {
                g.DrawRectangle(Pens.White, x, y, w, h);
            }
            else
            {
                g.DrawRectangle(Pens.Black, x, y, w, h);
            }
        }
    }
}