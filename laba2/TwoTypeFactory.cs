using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class TwoTypeFactory : IGraphicFactory
    {
        private bool k = false;
        public GraphObject CreateGraphObject()
        {
            k = !k;
            if (k)
            {
                return new Rectangle();
            }
            else
            {
                return new Ellipse();
            }
        }
    }
}