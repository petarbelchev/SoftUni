using System;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)}");
                }

                this.length = value;
            }
        }
        public double Width 
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)}");
                }

                this.width = value;
            }
        }
        public double Height 
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)}");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
        }

        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return 2 * this.length * this.height + 2 * this.width * this.height;
        }

        public double Volume()
        {
            //Volume = lwh
            return this.length * this.width * this.height;
        }
    }
}
