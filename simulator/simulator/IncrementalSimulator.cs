using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
    // TODO: inputs in terms of time / minutes
    //       convert simulator to integer math (t=0 at start, increment of 1)
    //       values - increments a day (start with 24)/week/month, (first day increments - start with all day).
    class IncrementalSimulator
    {
        private int _numDaysOfHourlies;
        private Graphics _graphicsObj;
        private ImageChain _chain;
        private DateTime _simulationStartTime;

        private Pen redPen = new Pen(Color.Red, THICKNESS);
        private Pen bluePen = new Pen(Color.Blue, THICKNESS);
        private Pen greenPen = new Pen(Color.Green, THICKNESS);
        private Pen blackPen = new Pen(Color.Black, THICKNESS);
        private Pen clearPen = new Pen(Color.Transparent, THICKNESS);
        private Font font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        private Brush brush = new SolidBrush(Color.Black);

        private static int LEFT_EDGE = 20;
        private static int TOP_EDGE = 80;
        private static int HEIGHT = 200;
        private static int WIDTH = 800;
        private static int THICKNESS = 4;


        internal ImageChain Simulate(Graphics graphicsObj, int numDaysOfHourlies)
        {
            _graphicsObj = graphicsObj;
            _numDaysOfHourlies = numDaysOfHourlies;

            DrawBackground();

            // initialize chain
            _chain = new ImageChain();
            _simulationStartTime = _chain.First.Value.CreateTime;

            DrawChain(_simulationStartTime, _simulationStartTime);

            // TODO: invoke simulation on separate thread
            return _chain;
        }

        private void DrawChain(DateTime previousTime, DateTime currentTime)
        {
            Pen redPen = new Pen(Color.Red, THICKNESS);
            Pen clearPen = new Pen(Color.Transparent, THICKNESS);
            
            foreach( Image img in _chain) {
                Rectangle oldDot = ComputeRectangleForImageFromTime(img, previousTime);
                Rectangle newDot = ComputeRectangleForImageFromTime(img, currentTime);
                
                // clear previous dot
                if (!oldDot.Equals(newDot))
                {
                    _graphicsObj.DrawEllipse(clearPen, oldDot);
                }

                // draw current dot
                if (img.Type == ImageType.Base)
                {
                    _graphicsObj.DrawEllipse(redPen, newDot);
                }
            }
        }

        // function to compute the location of the balls for backup images
        // TODO: compare _simulationStartTime with img.CreateTime to figure out which row it is in
        // TODO: add time parameter, so the same function can be used to hide balls as draw them.
        private Rectangle ComputeRectangleForImageFromTime(Image img, DateTime time)
        {
            var rect = new Rectangle(
                LEFT_EDGE + 4 * THICKNESS, TOP_EDGE + HEIGHT - 4 * THICKNESS,
                THICKNESS, THICKNESS);
            return rect;
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
            
            // label axis - "now"
            _graphicsObj.DrawString("now", font, brush, 
                LEFT_EDGE - 2 * THICKNESS, 
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
