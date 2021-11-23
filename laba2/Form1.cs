using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        IGraphicFactory factory = new RandomObjectFactory();
        string object_name;
        int id = -1;
        private List<GraphObject> elements = new List<GraphObject>();

        public Form1()
        {
            Random rand = new Random();

            if (rand.Next(0, 2) == 0)
            {
                object_name = "Rectangle";
            }
            else 
            {
                object_name = "Ellipse";
            }
            InitializeComponent();
        }
        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
            
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (GraphObject elem in elements)
            {
                elem.Draw(e.Graphics);
            }
        }

        private void Draw(GraphObject go)
        {
            elements.Add(go);
            this.panel1.Invalidate();
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (object_name == "Rectangle")
            {
                Rectangle go = new Rectangle();
                Draw(go);
            }
            else if (object_name == "Ellipse")
            {
                Ellipse go = new Ellipse();
                Draw(go);
            }
            else if (object_name == "BoxRectangle")
            {
                BoxRectangle go = new BoxRectangle();
                Draw(go);
            }
        }


        private void panel1_DoubleClick(object sender, MouseEventArgs e)
        {
            if (object_name == "Rectangle")
            {
                Rectangle go = new Rectangle();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex) { MessageBox.Show("Incorrect coord"); }
                elements.Add(go);
            }
            else if (object_name == "Ellipse")
            {
                Ellipse go = new Ellipse();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Incorrect coord");
                }
                elements.Add(go);
            }
            else if (object_name == "BoxRectangle")
            {
                BoxRectangle go = new BoxRectangle();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Incorrect coord");
                }
                elements.Add(go);
            }
            this.panel1.Invalidate();
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (elements.Count > 0)
            {
                int i = 0;
                foreach (GraphObject element in elements)
                {
                    if (element.ContainsPoint(e.Location))
                    {
                        id = i;
                    }
                    element.Selected = false;
                    i++;
                }
                if (id > -1)
                {
                    elements[id].Selected = true;
                    this.panel1.Invalidate();
                }
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elements.Clear();
            this.panel1.Invalidate();
        }

        private void вверхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id > -1)
            {
                elements[id].Y -= 1;
                this.panel1.Invalidate();
            }
        }

            private void внизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id > -1) 
            { 
            elements[id].Y += 1;
            this.panel1.Invalidate();
            }
        }

        private void вправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id > -1)
            { 
            elements[id].X += 1;
            this.panel1.Invalidate();
            }
        }

        private void вЛевоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id > -1)
            { 
            elements[id].X -= 1;
            this.panel1.Invalidate();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id > -1)
            {
                elements.Remove(elements[id]);
                id = -1;
                this.panel1.Invalidate();
            }
        }

        private void twoTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new TwoTypeFactory();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new RandomObjectFactory();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                Draw(factory.CreateGraphObject());
            }
        }

        private void boxRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object_name = "BoxRectangle";
        }
    }
}
