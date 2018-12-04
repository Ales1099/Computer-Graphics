using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab1
{
    public partial class ComputerGraphicLab1 : Form
    {
        Graph graph;
        public double[,] inmas = new double[67, 67];
        int resolutionOfArray = 67;
        int ang;
        public delegate double functionType(double x, double z);
        List<functionType> functions = new List<functionType>();
        Bitmap bmp;

        private Color color_space;
        private Color color_graphic;

        private int index_color_space = 0;
        private int index_color_graphic = 0;

        private const double d = 20.0d;

        private double AngleX = d;
        private double AngleY = d;
        private double AngleZ = d;

        private double[,] pnt;

        private bool drawOk = false;

        private Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Gray, Color.Yellow };

        public ComputerGraphicLab1()
        {
            color_space = colors[index_color_space];
            color_graphic = colors[1];
            InitializeComponent();
            this.graphic.BackColor = color_graphic;
            this.background.BackColor = color_space;
        }

        private void background_Click(object sender, EventArgs e)
        {
            if (index_color_space >= 4)
            {
                index_color_space = 0;
            }
            else
            {
                index_color_space++;
            }
            
            color_space = colors[index_color_space];
            this.background.BackColor = color_space;

            drawSpace();   
        }

        private void graphic_Click(object sender, EventArgs e)
        {
            if (index_color_graphic >= 4)
            {
                index_color_graphic = 0;
            }
            else
            {
                index_color_graphic++;
            }
               
            color_graphic = colors[index_color_graphic];
            this.graphic.BackColor = color_graphic;

            if(drawOk)
                drawGraphic();
            
        }

        private void draw_image_Click(object sender, EventArgs e)
        {

        }

        private void draw_Click(object sender, EventArgs e)
        {
            //drawOk = true;
            //drawSpace();
            graph.Draw(space.CreateGraphics(), Function.f1);
        }

        public void drawSpace()
        {
            this.space.BackColor = color_space;
        }

        public void drawGraphic()
        {
            graph.SetFlag(false);
            graph.Draw(space.CreateGraphics(), Function.f1);
        }

        private void turnX_Scroll(object sender, EventArgs e)
        {
            if (turnX.Value == 0)
            {
                AngleX = d;
            }
            else
            {
                AngleX = (double)(turnX.Value * d);
            }
            space.CreateGraphics().Clear(color_space);
            graph.setAngleX(turnX.Value*15);
            graph.Draw(space.CreateGraphics(), Function.f1);
        }

        private void turnY_Scroll(object sender, EventArgs e)
        {
            if (turnY.Value == 0)
            {
                AngleY = d;
            }
            else
            {
                AngleY = (double)(turnY.Value * d);
            }
            //drawSpace();
            space.CreateGraphics().Clear(color_space);
            graph.setAngleY(turnY.Value*15);
            graph.Draw(space.CreateGraphics(), Function.f1);
        }

        private void turnZ_Scroll(object sender, EventArgs e)
        {
            if (turnZ.Value == 0)
            {
                AngleZ = d; 
            }
            else
            {
                AngleZ = (double)(turnZ.Value * d);
            }
            //drawSpace();
            space.CreateGraphics().Clear(color_space);
            graph.setAngleZ(turnZ.Value*15);
            graph.Draw(space.CreateGraphics(), Function.f2);
        }

        private void ComputerGraphicLab1_Load(object sender, EventArgs e)
        {
            functions.Add(Function.f1);
            functions.Add(Function.f2);
            functions.Add(Function.f3);

            graph = new Graph(space.Width, space.Height);
            graph.setAngleX(turnX.Value);
            graph.setAngleY(turnY.Value);
            graph.setAngleZ(turnZ.Value);
            graph.setMaxX(Convert.ToDouble(resolutionOfArray - 1));
            graph.setMaxZ(Convert.ToDouble(resolutionOfArray - 1));
            graph.stepsXZ(Convert.ToDouble(0.5), Convert.ToDouble(0.5));
           

            graph.setBackColor(color_space);
            graph.setMainColor(color_graphic);
            graph.setReflect(space.CreateGraphics());
        }
    }
}
