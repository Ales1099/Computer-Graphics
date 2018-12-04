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
        List<functionType> functions = new List<functionType>();
        Bitmap bmp;

        private Color color_space;
        private Color color_graphic;

        private int index_color_space = 0;
        private int index_color_graphic = 1;

        private const double d = 15.0d;

        private double AngleX = 0.0d;
        private double AngleY = 0.0d;
        private double AngleZ = 0.0d;

        private double[,] pnt;

        private bool drawOk = false;

        private Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Gray, Color.GreenYellow };

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

            graph.setBackColor(color_space);
            graph.setMainColor(color_graphic);
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

            graph.setBackColor(color_space);
            graph.setMainColor(color_graphic);
            drawSpace();
            
        }

        private void draw_image_Click(object sender, EventArgs e)
        {

        }

        private void draw_Click(object sender, EventArgs e)
        {
            drawSpace();
        }

        public void drawSpace()
        {
            this.space.BackColor = color_space; space.CreateGraphics().Clear(color_space);
            graph.setAngleX((int)(turnX.Value*d));
            graph.setAngleY((int)(turnY.Value*d));
            graph.setAngleZ((int)(turnZ.Value*d));
            graph.Draw(space.CreateGraphics(),functions[comboBox1.SelectedIndex]);
        }

        public void drawGraphic()
        {
            graph.SetFlag(false);
            graph.Draw(space.CreateGraphics(), Function.f3);
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
            drawSpace();
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
            drawSpace();
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
            drawSpace();
        }

        private void ComputerGraphicLab1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("y = sin(x+z)");
            comboBox1.Items.Add("y=(x * cos(2 * z) - z * sin(2 * x)) / 4");
            comboBox1.Items.Add("y=exp(sin(sqrt(x * x + z * z)))");

            comboBox1.SelectedIndex = 0;

            functions.Add(Function.f1);
            functions.Add(Function.f2);
            functions.Add(Function.f3);

            graph = new Graph((int)(space.Width*1.25), (int)(space.Height*1.25));
            graph.setAngleX(turnX.Value*45);
            graph.setAngleY(turnY.Value*45);
            graph.setAngleZ(turnZ.Value*45);
            graph.setMaxX(Convert.ToDouble(resolutionOfArray - 1));
            graph.setMaxZ(Convert.ToDouble(resolutionOfArray - 1));
            graph.stepsXZ(Convert.ToDouble(0.5), Convert.ToDouble(0.5));
           

            graph.setBackColor(color_space);
            graph.setMainColor(color_graphic);
        }
    }
}
