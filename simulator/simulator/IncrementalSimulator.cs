using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
    class IncrementalSimulator
    {
        private int _numDaysOfHourlies;
        private Graphics _graphicsObj;
        private ImageChain _chain;
        private DateTime _simulationStartTime;
        
        private static int LEFT_EDGE = 20;
        private static int TOP_EDGE = 80;
        private static int HEIGHT = 200;
        private static int WIDTH = 800;
        private static int AXIS_THICKNESS = 4; 

        internal ImageChain Simulate(Graphics graphicsObj, int numDaysOfHourlies)
        {
            _numDaysOfHourlies = numDaysOfHourlies;
            _graphicsObj = graphicsObj;

            DrawBackground();

            // initialize chain
            _chain = new ImageChain();
            _simulationStartTime = _chain.First.Value.CreateTime;

            DrawChain();

            // TODO: invoke simulation on separate thread
            return _chain;
        }

        private void DrawChain()
        {
            Pen redPen = new Pen(Color.Red, AXIS_THICKNESS);
            
            foreach( Image img in _chain) {
                Rectangle myRectangle = ComputeRectangle(img);
                if (img.Type == ImageType.Base)
                {
                    _graphicsObj.DrawEllipse(redPen, myRectangle);
                }
            }
        }

        private Rectangle ComputeRectangle(Image img)
        {
            // TODO compare _simulationStartTime with img.CreateTime to figure out which row it is in

            var rect = new Rectangle(
                LEFT_EDGE + 4 * AXIS_THICKNESS, TOP_EDGE + HEIGHT - 4 * AXIS_THICKNESS,
                AXIS_THICKNESS, AXIS_THICKNESS);
            return rect;
        }

        private void DrawBackground()
        {
            // draw axis
            Pen blackPen = new Pen(Color.Black, AXIS_THICKNESS);
            _graphicsObj.DrawLine(blackPen,
                LEFT_EDGE, TOP_EDGE,
                LEFT_EDGE, HEIGHT + TOP_EDGE + 2 * AXIS_THICKNESS);
            _graphicsObj.DrawLine(blackPen, 
                LEFT_EDGE - 2 * AXIS_THICKNESS, HEIGHT + TOP_EDGE,
                WIDTH + LEFT_EDGE, HEIGHT + TOP_EDGE);
        }
    }
}
