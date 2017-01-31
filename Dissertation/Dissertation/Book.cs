using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Book
    {
        private string isbn, title, ean;
        private Dimension dimensions;

        public Book()
        {

        }

        public Dimension Dimensions
        {
            get
            {
                return dimensions;
            }

            set
            {
                dimensions = value;
            }
        }

    }

    public class Dimension
    {
        private int height, width, length, weight;

        public Dimension(int height, int width, int length, int weight)
        {
            this.Height = height;
            this.Width = width;
            this.Length = length;
            this.Weight = weight;
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
    }
}
