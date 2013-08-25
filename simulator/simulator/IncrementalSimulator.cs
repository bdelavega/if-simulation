using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace simulator
{
    class IncrementalSimulator : BackgroundWorker
    {
        private int _numDaysOfHourlies;
        private double _minutesBetweenBackups;
        private int _columnsPerDay;
       
        private Graphics _graphicsObj;
        private ImageChain _chain;

        private Pen redPen = new Pen(Color.Red, THICKNESS);
        private Pen bluePen = new Pen(Color.Blue, THICKNESS);
        private Pen greenPen = new Pen(Color.Green, THICKNESS);
        private Pen blackPen = new Pen(Color.Black, THICKNESS);
        private Pen clearPen = new Pen(Color.Transparent, THICKNESS);
        private Font font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        private Brush brush = new SolidBrush(Color.Black);

        private static int LEFT_EDGE = 20;
        private static int TOP_EDGE = 60;
        private static int HEIGHT = 300;
        private static int WIDTH = 800;
        private static int THICKNESS = 4;
        private static int GAP = 2;

        private static int MAX_ROWS = 24;


        internal IncrementalSimulator(Graphics graphicsObj, int numDaysOfHourlies, int numBackupsPerHour)
        {
            _graphicsObj = graphicsObj;
            _numDaysOfHourlies = numDaysOfHourlies;
            _minutesBetweenBackups = 60 / numBackupsPerHour;
            _columnsPerDay = numBackupsPerHour;  // since we show 24 in a column...

            this.DoWork += Simulate;
        }

        internal void Simulate(object sender, DoWorkEventArgs e)
        {
            DrawBackground();

            // initialize chain
            _chain = new ImageChain();
            DateTime startTime = _chain.First.Value.CreateTime;
            DateTime previousTime = startTime;
            DateTime currentTime = startTime;

            int i = 0;
            while (true)
            {
                i++;

                if (this.CancellationPending)
                    return;

                DrawImageDot(startTime, _chain.First.Value);
                
                Thread.Sleep(200);

                if (this.CancellationPending)
                    return;
                
                previousTime = currentTime;
                currentTime = currentTime.AddMinutes(_minutesBetweenBackups);

                if (previousTime.Day != currentTime.Day)
                {
                    // TODO: move lines over
                    // TODO: do rollup
                    Console.WriteLine("end of the day");
                }

                _chain.AddIncrementalImage(_minutesBetweenBackups);

                if (i % 24 == 0)
                {
                    Console.WriteLine("too many iterations");
                }
            }
        }

        private void DrawChainDots(DateTime startTime, DateTime currentTime)
        {   
            foreach( Image img in _chain) {
                DrawImageDot(startTime, img);
            }
        }

        private void DrawImageDot(DateTime startTime, Image img)
        {
            Rectangle newDot = ComputeRectangleForImageFromTime(img, startTime);

            // draw current dot
            if (img.Type == ImageType.Base)
            {
                _graphicsObj.DrawEllipse(redPen, newDot);
            }
            else if (img.Type == ImageType.Incremental)
            {
                _graphicsObj.DrawEllipse(bluePen, newDot);
            }
        }

        // function to compute the location of the balls for backup images
        private Rectangle ComputeRectangleForImageFromTime(Image img, DateTime startTime)
        {
            // locate first image's circle  
            int left = LEFT_EDGE + 4 * THICKNESS;
            int top = TOP_EDGE + HEIGHT - 4 * THICKNESS;

            // adjust for current image
            int col, row;
            CalculateDotPositionFromTime(img, startTime, out col, out row);
            left = left + col * 2 * (THICKNESS + GAP);
            top = top - (row * 2 * (THICKNESS + GAP));

            var rect = new Rectangle(left, top, THICKNESS, THICKNESS);
            return rect;
        }

        private void CalculateDotPositionFromTime(Image img, DateTime startTime, out int col, out int row)
        {
            TimeSpan deltaTimeSpan;
            if (img.ModifiedTime.Year == startTime.Year &&
                img.ModifiedTime.Month == startTime.Month &&
                img.ModifiedTime.Day == startTime.Day)
            {
                deltaTimeSpan = img.ModifiedTime - startTime;
            }
            else
            {
                deltaTimeSpan = new TimeSpan(
                    img.ModifiedTime.Hour,
                    img.ModifiedTime.Minute,
                    img.ModifiedTime.Second);
            }

            var hour = deltaTimeSpan.TotalMinutes / 60;
            col = (int)_columnsPerDay - 1 - (int)(hour / (24 / _columnsPerDay));

            int deltaCount = (int)(deltaTimeSpan.TotalMinutes / _minutesBetweenBackups);
            row = deltaCount % MAX_ROWS;
        }

        private void DrawBackground()
        {
            // draw axis
            _graphicsObj.DrawLine(blackPen,
                LEFT_EDGE, TOP_EDGE,
                LEFT_EDGE, HEIGHT + TOP_EDGE + 2 * THICKNESS);
            _graphicsObj.DrawLine(blackPen, 
                LEFT_EDGE - 2 * THICKNESS, HEIGHT + TOP_EDGE,
                WIDTH + LEFT_EDGE, HEIGHT + TOP_EDGE);
            _graphicsObj.DrawString("now", font, brush, 
                LEFT_EDGE - 3 * THICKNESS, 
                TOP_EDGE + HEIGHT + 3 * THICKNESS);


            // draw legend
            var height = TOP_EDGE + HEIGHT + 15 + 6 * THICKNESS;
            var left = LEFT_EDGE + 4 * THICKNESS;

            DrawIconAndLabel(redPen, " - base image", height, left);
            left = left + 30 * THICKNESS;
            DrawIconAndLabel(bluePen, " - incremental image", height, left);
            left = left + 40 * THICKNESS;
            DrawIconAndLabel(greenPen, " - synthetic image", height, left);
        }

        private void DrawIconAndLabel(Pen p, string label, int height, int left)
        {
            var rect = new Rectangle(left, height + THICKNESS, THICKNESS, THICKNESS);
            _graphicsObj.DrawEllipse(p, rect);
            _graphicsObj.DrawString(label, font, brush,
                left + 2 * THICKNESS, height);
        }
    }
}
