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
            return false;
        }

        
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Red, x, y, 100, 50);
        }
    }
}