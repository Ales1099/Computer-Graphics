using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace ComputerGraphicsLab1
{
    public class Graph
    {
        public delegate double functionType(double x, double z);
        const double NULL = -1;
        int imageWidth, imageHeight;
        double[] lowHor, upHor;
        public double[,] mas = new double[67, 67];
        double zMin = NULL, zMax = NULL,
               yMin = NULL, yMax = NULL,
               xMin = NULL, xMax = NULL;
        double xStep = 0, zStep = 0;
        double angleX = 0, angleY = 0, angleZ = 0;
        bool cur = false;
        public int resttt = 67;
        Graphics graphics;
        Graphics reflect;
        Bitmap bitmap;
        Color backColor, mainColor;
        Point3D center = new Point3D();
        bool flag = false;
        int resTemp = 0;
        public Bitmap bmp() { return bitmap; }
        private Pen penGraphic;

        enum Vis
        {
            upper,
            lower,
            invis
        }

        public Graph()
        {

        }

        public void Draw(Graphics g, functionType function)
        {
            if (!flag) { CalcFunction(function); }
            if (resTemp != resttt)
            {
                CalcBodyCenter(function);
                resTemp = resttt;
            }
            StartDoubleBuffering();
            ResetHor();
            drawZ(g,function);
            finishDoubleBuffering();
        }

        public Graph(int imageWidth, int imageHeight)
        {
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            bitmap = new Bitmap(imageWidth, imageHeight);
            lowHor = new double[imageWidth];
            upHor = new double[imageWidth];
            backColor = Color.White;
            mainColor = Color.GreenYellow;
            penGraphic = new Pen(mainColor);
        }

        public void SetMasRes(int v)
        {
            mas = new double[v, v];
        }

        public void ResetHor()
        {
            for (int i = 0; i < imageWidth; ++i)
            {
                lowHor[i] = imageHeight;
                upHor[i] = 0;
            }
        }

        public void SetFlag(bool bb)
        {
            this.flag = bb;
        }

        public void SetMaxMinY(double maxY, double minY)
        {
            this.yMax = maxY;
            this.yMin = minY;
        }

        public void granX(double xMin, double xMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
        }

        public void granZ(double zMin, double zMax)
        {
            this.zMin = zMin;
            this.zMax = zMax;
        }

        public void stepsXZ(double stepX, double stepZ)
        {
            this.zStep = stepZ;
            this.xStep = stepX;
        }

        public void setAngleX(int angle)
        {
            this.angleX = DegreeToRadian(angle);
        }

        public void setAngleY(int angle)
        {
            this.angleY = DegreeToRadian(angle);
        }

        public void setAngleZ(int angle)
        {
            this.angleZ = DegreeToRadian(angle);
        }

        public void setMaxX(double maxX)
        {
            this.xMax = maxX;
        }

        public void setMaxZ(double maxZ)
        {
            this.zMax = maxZ;
        }

        private double DegreeToRadian(int angleInDegrees)
        {
            return Math.PI * angleInDegrees / 180;
        }

        public void setMainColor(Color c)
        {
            this.mainColor = c;
        }

        public void setBackColor(Color c)
        {
            this.backColor = c;

        }

        public void setReflect(Graphics g)
        {
            this.reflect = g;
        }

        private void DrawLine(Point2D one, Point2D two)
        {
            graphics.DrawLine(penGraphic, one, two);
        }
        
        public void drawZ(Graphics g, functionType function)
        {
            graphics = g;
            Point2D prevPoint,
                leftPoint = new Point2D(NULL, NULL),
                rigthPoint = new Point2D(NULL, NULL);

            for (double currentZ = zMax; currentZ >= zMin; currentZ -= zStep)
            {
                double y;
                y = function(xMin,currentZ);
                prevPoint = c3Dto2D(xMin, y, currentZ);
                DrawifOK(prevPoint, ref leftPoint);
                if (!(CheckPoint(prevPoint) && CheckPoint(leftPoint)))
                    continue;

                Vis prevVisible = CheckVis(prevPoint);

                Point2D currentPoint = new Point2D();
                for (double currentX = xMin; currentX <= xMax; currentX += xStep)
                {
                    cur = false;
                    if (currentX > xMax - zStep / 2)
                    {
                       // cur = true;
                    }

                    y = function(currentX,currentZ);
                    currentPoint = c3Dto2D(currentX, y, currentZ);
                    if (!CheckPoint(currentPoint))
                        continue;
                    Vis currentVisibily = CheckVis(currentPoint);
                    if(currentVisibily == prevVisible)
                    {
                        if(currentVisibily == Vis.lower || currentVisibily == Vis.upper)
                        {
                            DrawLine(prevPoint, currentPoint);
                            Smooth(prevPoint, currentPoint);
                        }
                        prevVisible = currentVisibily;
                        prevPoint = currentPoint;
                    }
                    DrawifOK(currentPoint, ref rigthPoint);
                }
            }

        }

        private Vis CheckVis(Point2D currentPoint)
        {
            if (currentPoint.y < upHor[(int)Math.Round(currentPoint.x)] && currentPoint.y > lowHor[(int)Math.Round(currentPoint.x)])
                return Vis.invis;
            else
                if (currentPoint.y >= upHor[(int)Math.Round(currentPoint.x)])
                return Vis.upper;
            else
                return Vis.lower;
        }

        private bool CheckPoint(Point2D point)
        {
            if ((int)Math.Round(point.x) < 0 || (int)Math.Round(point.x) >= imageWidth)
                return false;
            return true;
        }

        private void DrawifOK(Point2D prevPoint, ref Point2D currentPoint)
        {
            if (currentPoint.x != NULL)
            {
                int currentX = (int)Math.Round(currentPoint.x);
                if (Math.Round(prevPoint.y) >= Math.Round(upHor[currentX]) ||
                    Math.Round(prevPoint.y) <= Math.Round(lowHor[currentX]) ||
                    Math.Round(currentPoint.y) >= Math.Round(upHor[currentX]) ||
                    Math.Round(currentPoint.y) <= Math.Round(lowHor[currentX]))
                {
                    DrawLine(prevPoint, currentPoint);
                    Smooth(prevPoint, currentPoint);
                }
            }
            currentPoint = prevPoint;
        }

        private void Smooth(Point2D firstPoint, Point2D secondPoint)
        {
            if (Math.Round(firstPoint.x) == Math.Round(secondPoint.x))
            {
                upHor[(int)Math.Round(secondPoint.x)] = Math.Max(upHor[(int)Math.Round(secondPoint.x)], Math.Max(secondPoint.y, firstPoint.y));
                lowHor[(int)Math.Round(secondPoint.x)] = Math.Min(lowHor[(int)Math.Round(secondPoint.x)], Math.Min(secondPoint.y, firstPoint.y));
            }
            else
            {
                if (secondPoint.x < firstPoint.x)
                {
                    Point2D buf = firstPoint;
                    firstPoint = secondPoint;
                    secondPoint = buf;
                }
                double lineCoef = (secondPoint.y - firstPoint.y) / (secondPoint.x - firstPoint.x);
                double currentY;

                for (int currentX = (int)Math.Round(firstPoint.x); currentX <= Math.Round(secondPoint.x); ++currentX)
                {
                    currentY = lineCoef * (currentX - firstPoint.x) + firstPoint.y;
                    upHor[currentX] = Math.Max(upHor[currentX], currentY);
                    lowHor[currentX] = Math.Min(lowHor[currentX], currentY);
                }
                for (int currentX = (int)Math.Round(secondPoint.x); currentX <= Math.Round(firstPoint.x); ++currentX)
                {
                    currentY = lineCoef * (currentX - secondPoint.x) + secondPoint.y;
                    upHor[currentX] = Math.Max(upHor[currentX], currentY);
                    lowHor[currentX] = Math.Min(lowHor[currentX], currentY);
                }
            }
        }

        private void drawPer(Vis currentVis, Vis prevVis, Point2D prevPoint, Point2D currentPoint)
        {
            Point2D currentPer;

            if(currentVis == Vis.invis)
            {
                if(prevVis == Vis.upper)
                {
                    currentPer = GetPer(prevPoint, currentPoint, upHor);
                }
                else
                {
                    currentPer = GetPer(prevPoint, currentPoint, lowHor);
                }
                DrawLine(prevPoint, currentPoint);
                Smooth(prevPoint, currentPoint);
            }
            else
            {
                if (currentVis == Vis.upper)
                    currentPoint = GetPer(prevPoint, currentPoint, lowHor);
                else
                    currentPoint = GetPer(prevPoint, currentPoint, upHor);

                DrawLine(prevPoint, currentPoint);
                Smooth(prevPoint, currentPoint);

                if (currentVis == Vis.upper)
                    currentPoint = GetPer(prevPoint, currentPoint, upHor);
                else
                    currentPoint = GetPer(prevPoint, currentPoint, lowHor);

                DrawLine(prevPoint, currentPoint);
                Smooth(prevPoint, currentPoint);
            }
        }

        private Point2D GetPer(Point2D firstPoint, Point2D secondPoint, double[] currentHorizot)
        {
            if(Math.Round(firstPoint.x) == Math.Round(secondPoint.x))
            {
                return new Point2D(secondPoint.x,currentHorizot[(int)Math.Round(secondPoint.x)]);
            }

            if(Math.Round(secondPoint.x) < Math.Round(firstPoint.x))
            {
                Point2D buf = firstPoint;
                firstPoint = secondPoint;
                secondPoint = buf;
            }

            double lineCoef = (secondPoint.y - firstPoint.y) / (secondPoint.x - firstPoint.x);

            int currentX = (int)Math.Floor(firstPoint.x) + 1;
            double currentY = firstPoint.y + lineCoef;
            int prevSignY = Math.Sign(firstPoint.y + lineCoef - currentHorizot[currentX]);
            int currentSignY = prevSignY;

            while(prevSignY == currentSignY && currentX <= Math.Floor(secondPoint.x))
            {
                currentY += lineCoef;
                ++currentX;
                currentSignY = Math.Sign(currentY - currentHorizot[currentX]);
            }

            if(Math.Abs(currentY-lineCoef-currentHorizot[currentX - 1]) <= Math.Abs(currentY - currentHorizot[currentX]))
            {
                currentY -= lineCoef;
                --currentX;
            }

            return new Point2D(currentX,currentY);
        }

        private Point2D c3Dto2D(double x, double y, double z)
        {
            double sc = 1.5;
            double scale = Math.Min(imageWidth, imageHeight) / (Math.Max(xMax - xMin, zMax - zMin) * sc);
            x = center.X + (x - center.X) * scale;
            y = -(center.Y + (y - center.Y) * scale);
            z = center.Z + (z - center.Z) * scale;

            // y 
            double temp = z * Math.Cos(angleY) + x * Math.Sin(angleY);
            x = -z * Math.Sin(angleY) + x * Math.Cos(angleY);
            z = temp;

            // x 
            temp = y * Math.Cos(angleX) + z * Math.Sin(angleX);
            z = -y * Math.Sin(angleX) + z * Math.Cos(angleX);
            y = temp;

            // z 
            temp = x * Math.Cos(angleZ) + y * Math.Sin(angleZ);
            y = -x * Math.Sin(angleZ) + y * Math.Cos(angleZ);
            x = temp;

            x += imageWidth / 2 - center.X;
            y += imageHeight / 3 - center.Y;

            return new Point2D(x, y);
        }

        private void CalcBodyCenter(functionType function)
        {
            center.X = (xMax + xMin) / 2;
            center.Z = (zMin + zMax) / 2;
            center.Y = function(center.X, center.Z);

            //center.Y = mas[(int)Math.Round((center.X + 2) / xStep), (int)Math.Round((center.Z + 2) / zStep)];

        }

        private void CalcFunction(functionType function)
        {
            int i = 0, j = 0;
            for(double currentZ = zMin; currentZ <= zMax; currentZ += zStep)
            {
                if (i >= 67) i = 0;
                for(double currentX = xMin; currentX <= xMax; currentX += xStep)
                {
                    if (j >= 67) j = 0;
                    mas[i, j] = function(currentX, currentZ);
                    j++;
                }
                i++;
                j = 0;
            }
        }

        public void readFile(Image image, int imageWidth, int imagHeight)
        {
            bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
            g.RotateTransform((float)angleX);
            g.DrawImage(bitmap,0,0);

            for(int i=0; i<67; i++)
            {
                for(int j = 0; j<67; j++)
                {
                    double B = bitmap.GetPixel(i, j).GetBrightness();
                    mas[i, j] = (B - 0.5) * 10;
                }
            }

        }

        public void setMas(double[,] im)
        {
            mas = im;
            flag = true;
        }

        public void StartDoubleBuffering()
        {
            this.graphics = Graphics.FromImage(bitmap);
            //this.graphics.Clear(backColor);
            this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public void finishDoubleBuffering()
        {
            reflect.DrawImage(bitmap, 0, 0);
        }
    }
}
