using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation
{
    public class Book
    {
        private string isbn, title, ean, binding, label, listPrice, manufacturer, publisher, readingLevel, releaseDate, publicationDate, studio, edition, dewey;
        private int numberOfPages;
        private HashSet<EditorialReview> editorialReviews;
        private HashSet<Image> images;
        private HashSet<string> subjects;
        private Dimension dimensions;
        private Dictionary<string, string> creators;
        private Dictionary<int, string> browseNodes;

        //blurbers, dedications, epigraphs, firstword, lastword,
        //quotations, series, awards, characters, places,
        //tags, similar products;

        public Book()
        {
            editorialReviews = new HashSet<EditorialReview>();
            images = new HashSet<Image>();
            subjects = new HashSet<string>();
            creators = new Dictionary<string, string>();
            browseNodes = new Dictionary<int, string>();
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

    public class Image
    {

        private string url;
        private int height, width;
        private HashSet<String> imageCategories;

        public Image(string url, int height, int width)
        {
            this.Url = url;
            this.Height = height;
            this.Width = width;
            imageCategories = new HashSet<String>();
        }

        public void addCategory(string category)
        {
            imageCategories.Add(category);
        }

        public HashSet<String> ImageCategories
        {
            get
            {
                return imageCategories;
            }

            set
            {
                imageCategories = value;
            }
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

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
    }

    public class EditorialReview
    {
        private string source, content;

        public EditorialReview(string source, string content)
        {
            this.Source = source;
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
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
