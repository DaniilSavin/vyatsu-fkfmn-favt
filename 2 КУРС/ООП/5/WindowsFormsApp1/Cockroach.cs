using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Cockroach
    {
        public Bitmap Image;
        direction trend = direction.Right;
        const int step = 30;
        public int X, Y;
        public Cockroach(Bitmap _Image)
        {
            Image = _Image;
        }
        public Cockroach(Cockroach _Cockroach)
        {
            Image = _Cockroach.Image;
            trend = _Cockroach.trend;
            X = _Cockroach.X;
            Y = _Cockroach.Y;
        }
        ~Cockroach()  // finalizer
        {
            // cleanup statements...
        }
        public void Step()
        {
            switch (trend)
            {
                case direction.Right:
                    X += step;
                    break;
                case direction.Left:
                    X -= step;
                    break;
                case direction.Up:
                    Y -= step;
                    break;
                case direction.Down:
                    Y += step;
                    break;
            }
        }
        public void ChangeTrend(char c)
        {
            direction newtrend = trend;
            for (direction y = direction.Up; y <= direction.Left; y++ )
            if (char.ToLower(c) == char.ToLower(y.ToString()[0]))
            {
                newtrend = y;
                break;
            }
            switch (trend)
            {
                case direction.Up:
                    switch (newtrend)
                    {
                        case direction.Right:
                            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Down:
                            Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Left:
                            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
                case direction.Right:
                    switch (newtrend)
                    {
                        case direction.Down:
                            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Left:
                            Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Up:
                            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
                case direction.Down:
                    switch (newtrend)
                    {
                        case direction.Left:
                            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Up:
                            Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Right:
                            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
                case direction.Left:
                    switch (newtrend)
                    {
                        case direction.Up:
                            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case direction.Right:
                            Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case direction.Down:
                            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    break;
            }
            trend = newtrend;
        }
    }
}

