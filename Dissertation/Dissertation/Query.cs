using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation
{
    public class Query
    {
        string QueryString;
        Filters Filters;
        string Path;

        public Query(string query, Filters filters)
        {
            this.query = query;
            this.Filters = filters;

            useDefaultPath();
        }

        public void useDefaultPath()
        {
            Path = "Dissertation Index";
        }

        public string path
        {
            get
            {
                return Path;
            }

            set
            {
                Path = value;
            }
        }


        public string query
        {
            get
            {
                return QueryString;
            }

            set
            {
                QueryString = value;
            }
        }

        public Filters filters
        {
            get
            {
                return Filters;
            }

            set
            {
                Filters = value;
            }
        }
    }

    public class Filters
    {
        ListPrice Listprice;
        Dimensions DimensionsVal;
        NumberOfPages Numberofpages;

        public Filters(ListPrice listprice, Dimensions dimensions, NumberOfPages numberofpages)
        {
            this.listprice = listprice;
            this.dimensions = dimensions;
            this.numberofpages = numberofpages;
        }

        public static Filters FilterBuilder(int listPriceMin, int listPriceMax, int heightMin, int heightMax, int widthMin, int widthMax, int lengthMin, int lengthMax, int weightMin, int weightMax, int pageMin, int pageMax)
        {
            Filters filters = new Filters(
                new ListPrice(listPriceMax, listPriceMin),
                new Dimensions(
                    new FilterDimension(heightMax, heightMin),
                    new FilterDimension(widthMax, widthMin),
                    new FilterDimension(lengthMax, lengthMin),
                    new FilterDimension(weightMax, weightMin)),
                new NumberOfPages(pageMax, pageMin));
            return filters;
        }

        public void setAllFilters(bool value)
        {
            listprice.enabled = value;
            dimensions.height.enabled = value;
            dimensions.width.enabled = value;
            dimensions.length.enabled = value;
            dimensions.weight.enabled = value;
            numberofpages.enabled = value;
        }

        public ListPrice listprice
        {
            get
            {
                return Listprice;
            }

            set
            {
                Listprice = value;
            }
        }

        public Dimensions dimensions
        {
            get
            {
                return DimensionsVal;
            }

            set
            {
                DimensionsVal = value;
            }
        }

        public NumberOfPages numberofpages
        {
            get
            {
                return Numberofpages;
            }

            set
            {
                Numberofpages = value;
            }
        }
    }

    public class ListPrice
    {
        int Max;
        int Min;
        bool Enabled = false;

        public ListPrice(int max, int min)
        {
            this.max = max;
            this.min = min;
        }

        public bool enabled
        {
            get
            {
                return Enabled;
            }

            set
            {
                Enabled = value;
            }
        }

        public int max
        {
            get
            {
                return Max;
            }

            set
            {
                Max = value;
            }
        }

        public int min
        {
            get
            {
                return Min;
            }

            set
            {
                Min = value;
            }
        }
    }

    public class Dimensions
    {
        FilterDimension Height;
        FilterDimension Width;
        FilterDimension Length;
        FilterDimension Weight;

        public Dimensions(FilterDimension height, FilterDimension width, FilterDimension length, FilterDimension weight)
        {
            this.height = height;
            this.width = width;
            this.length = length;
            this.weight = weight;
        }

        public FilterDimension height
        {
            get
            {
                return Height;
            }

            set
            {
                Height = value;
            }
        }

        public FilterDimension width
        {
            get
            {
                return Width;
            }

            set
            {
                Width = value;
            }
        }

        public FilterDimension length
        {
            get
            {
                return Length;
            }

            set
            {
                Length = value;
            }
        }

        public FilterDimension weight
        {
            get
            {
                return Weight;
            }

            set
            {
                Weight = value;
            }
        }
    }

    public class FilterDimension
    {
        int Max;
        int Min;
        bool Enabled = false;

        public FilterDimension(int max, int min)
        {
            this.max = max;
            this.min = min;
        }

        public bool enabled
        {
            get
            {
                return Enabled;
            }

            set
            {
                Enabled = value;
            }
        }

        public int max
        {
            get
            {
                return Max;
            }

            set
            {
                Max = value;
            }
        }

        public int min
        {
            get
            {
                return Min;
            }

            set
            {
                Min = value;
            }
        }
    }

    public class NumberOfPages
    {
        int Max;
        int Min;
        bool Enabled = false;

        public NumberOfPages(int max, int min)
        {
            this.max = max;
            this.min = min;
        }

        public bool enabled
        {
            get
            {
                return Enabled;
            }

            set
            {
                Enabled = value;
            }
        }

        public int max
        {
            get
            {
                return Max;
            }

            set
            {
                Max = value;
            }
        }

        public int min
        {
            get
            {
                return Min;
            }

            set
            {
                Min = value;
            }
        }

    }
}
