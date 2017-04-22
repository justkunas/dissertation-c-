using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dissertation
{
    public class Book
    {
        private string isbn, title, ean, binding, label, listPrice, manufacturer, publisher, readingLevel, releaseDate,
            publicationDate, studio, edition, dewey, firstWords, lastWords = "";
        private int numberOfPages = 0;
        private double priceValue;
        private HashSet<EditorialReview> editorialReviews = new HashSet<EditorialReview>();
        private HashSet<Review> reviews = new HashSet<Review>();
        private HashSet<Image> images = new HashSet<Image>();
        private HashSet<string> subjects = new HashSet<string>();
        private HashSet<string> awards = new HashSet<string>();
        private HashSet<string> places = new HashSet<string>();
        private HashSet<string> characters = new HashSet<string>();
        private HashSet<string> similarProducts = new HashSet<string>(); 
        private HashSet<string> blurbers = new HashSet<string>();
        private HashSet<string> dedications = new HashSet<string>();
        private HashSet<string> series = new HashSet<string>();
        private HashSet<string> epigraphs = new HashSet<string>();
        private HashSet<string> quotations = new HashSet<string>();
        private Dimension dimensions = new Dimension();
        private Dictionary<string, string> creators = new Dictionary<string, string>();
        private Dictionary<int, string> browseNodes = new Dictionary<int, string>();
        private Dictionary<int, string> tags = new Dictionary<int, string>();

		private static Dictionary<string, int> values = new Dictionary<string, int>();

        public Book()
        {

        }

		public static void GenerateDictionary()
		{
			values.Add("Isbn", 10);
			values.Add("Title", 9);
			values.Add("Ean", 10);
			values.Add("Binding", 1);
			values.Add("Label", 2);
			values.Add("Manufacturer", 3);
			values.Add("Publisher", 3);
			values.Add("ReadingLevel", 2);
			values.Add("Studio", 2);
			values.Add("Dewey", 10);
			values.Add("FirstWords", 4);
			values.Add("LastWords", 4);
			values.Add("Subjects", 8);
			values.Add("Awards", 3);
			values.Add("Places", 8);
			values.Add("Characters", 8);
			values.Add("Series", 8);
			values.Add("Epigraphs", 4);
			values.Add("Edition", 5);
			values.Add("Quotations", 2);
			values.Add("Creators", 8);
			values.Add("BrowseNodes", 8);
			values.Add("Tags", 8);
		}

		public override string ToString()
        {
            string value = "";

            value += "isbn: " + Isbn;
            value += "\nean: " + Ean;
            value += "\nbinding: " + Binding;
            value += "\nlabel: " + Label;
            value += "\nlist price: " + ListPrice;
            value += "\nmanufacturer: " + Manufacturer;
            value += "\npublisher: " + Publisher;
            value += "\nreading level: " + ReadingLevel;
            value += "\nrelease date: " + ReleaseDate;
            value += "\npublicationdate: " + PublicationDate;
            value += "\nstudio: " + Studio;
            value += "\nedition: " + Edition;
            value += "\ndewey: " + Dewey;
            value += "\nnumber of pages: " + Isbn;

            value += "\ndimensions:";
            value += "\n\theight: " + Dimensions.Height;
            value += "\n\twidth: " + Dimensions.Width;
            value += "\n\tlength: " + Dimensions.Length;
            value += "\n\tweight: " + Dimensions.Weight;

            value += "\nreviews:";
            foreach (Review review in Reviews)
            {
                value += "\n\treview:";
                value += "\n\t\tdate: " + review.Date;
                value += "\n\t\tsummary: " + review.Summary;
                value += "\n\t\tcontent: " + review.Content;
                value += "\n\t\tauthor id: " + review.AuthorID;
                value += "\n\t\trating: " + review.Rating;
                value += "\n\t\ttotal votes: " + review.TotalVotes;
                value += "\n\t\thelpful votes: " + review.HelpfulVotes;
            }

            value += "\neditorial reviews:";
            foreach(EditorialReview er in EditorialReviews)
            {
                value += "\n\teditorial reviews:";
                value += "\n\t\tsource: " + er.Source;
                value += "\n\t\tcontent: " + er.Content;
            }

            value += "\nimages:";
            foreach (Image img in Images)
            {
                value += "\n\timage:";
                value += "\n\t\turl: " + img.Url;
                value += "\n\t\theight: " + img.Height;
                value += "\n\t\twidth: " + img.Width;
                value += "\n\t\timage categories:";

                foreach (string imgCat in img.ImageCategories)
                {
                    value += "\n\t\t\timage category: " + imgCat;
                }
            }

            value += "\ncreators:";
            foreach(KeyValuePair<string,string> creator in Creators)
            {
                value += "\n\tcreator:";
                value += "\n\t\tname: " + creator.Key;
                value += "\n\t\trole: " + creator.Value;
            }

            value += "\nblurbers:";
            foreach(string blurber in Blurbers)
            {
                value += "\n\tblurber: " + blurber;
            }

            value += "\ndedications:";
            foreach (string dedication in Dedications)
            {
                value += "\n\tdedication: " + dedication;
            }

            value += "\nepigraphs:";
            foreach (string epigraph in epigraphs)
            {
                value += "\n\tepigraph: " + epigraph;
            }

            value += "\nfirst words: " + FirstWords;
            value += "\nlast words: " + LastWords;

            value += "\nquotations:";
            foreach (string quotation in Quotations)
            {
                value += "\n\tquotation: " + quotation;
            }

            value += "\nseries:";
            foreach (string s in Series)
            {
                value += "\n\tseries: " + s;
            }

            value += "\nawards:";
            foreach (string award in Awards)
            {
                value += "\n\taward: " + award;
            }

            value += "\ncharacters:";
            foreach (string character in Characters)
            {
                value += "\n\tcharacter: " + character;
            }

            value += "\nplaces:";
            foreach (string place in Places)
            {
                value += "\n\tplace: " + place;
            }

            value += "\nsubjects:";
            foreach (string subject in Subjects)
            {
                value += "\n\tsubject: " + subject;
            }

            value += "\ntags:";
            foreach (KeyValuePair<int, string> tag in Tags)
            {
                value += "\n\ttag:";
                value += "\n\t\tcount: " + tag.Key;
                value += "\n\t\ttag: " + tag.Value;
            }

            value += "\nsimilar products";
            foreach (string sp in SimilarProducts)
            {
                value += "\n\tsimilar product: " + sp;
            }

            value += "\nbrowse nodes:";
            foreach (KeyValuePair<int, string> bn in BrowseNodes)
            {
                value += "\n\tbrowse node:";
                value += "\n\t\tid: " + bn.Key;
                value += "\n\t\tbrowse node: " + bn.Value;
            }

            return value;
        }

        public static Book parseXML(XElement element)
        {
            Book book = new Book();
            
            if (element.Element("dewey") != null)
                book.Dewey = element.Element("dewey").Value;

            if (element.Element("isbn") != null)
                book.Isbn = element.Element("isbn").Value;

            if (element.Element("title") != null)
                book.Title = element.Element("title").Value;

            if (element.Element("ean") != null)
                book.Ean = element.Element("ean").Value;

            if (element.Element("binding") != null)
                book.Binding = element.Element("binding").Value;

            if (element.Element("label") != null)
                book.Label = element.Element("label").Value;

            if (element.Element("listprice") != null)
                book.ListPrice = element.Element("listprice").Value;

            if (element.Element("manufacturer") != null)
                book.Manufacturer = element.Element("manufacturer").Value;

            if (element.Element("publisher") != null)
                book.Publisher = element.Element("publisher").Value;

            if (element.Element("readinglevel") != null)
                book.ReadingLevel = element.Element("readinglevel").Value;

            if (element.Element("releasedate") != null)
                book.ReleaseDate = element.Element("releasedate").Value;

            if (element.Element("publicationdate") != null)
                book.PublicationDate = element.Element("publicationdate").Value;

            if (element.Element("studio") != null)
                book.Studio = element.Element("studio").Value;

            if (element.Element("edition") != null)
                book.Edition = element.Element("edition").Value;

            if (element.Element("firstwords") != null)
                if (element.Element("firstwordsitem") != null)
                    book.FirstWords = element.Element("firstwords").Element("firstwordsitem").Value;

            if (element.Element("lastwords") != null)
                if (element.Element("lastwordsitem") != null)
                    book.LastWords = element.Element("lastwords").Element("lastwordsitem").Value;

            if (element.Element("editorialreviews") != null && element.Element("editorialreviews").Value != "")
            {
                foreach (XElement ele in element.Element("editorialreviews").Elements())
                {
                    string source = "None";
                    string content = "None";

                    if(ele.Element("source") != null && ele.Element("source").Value != "")
                        source = ele.Element("source").Value;

                    if (ele.Element("content") != null && ele.Element("content").Value != "")
                        content = ele.Element("content").Value;

                    book.EditorialReviews.Add(new EditorialReview(source, content));
                }
            }

            if (element.Element("reviews") != null && element.Element("reviews").Value != "")
            {
                
                foreach (XElement ele in element.Element("reviews").Elements())
                {
                    //Console.WriteLine(ele);

                    int rating = 0;
                    int totalvotes = 0;
                    int helpfulvotes = 0;
                    string authorid = "None";
                    string summary = "None";
                    string date = "None";
                    string content = "None";

                    if (ele.Element("rating") != null && ele.Element("rating").Value != "")
                        rating = int.Parse(ele.Element("rating").Value);


                    if (ele.Element("totalvotes") != null && ele.Element("totalvotes").Value != "")
                        totalvotes = int.Parse(ele.Element("totalvotes").Value);


                    if (ele.Element("helpfulvotes") != null && ele.Element("helpfulvotes").Value != "")
                        helpfulvotes = int.Parse(ele.Element("helpfulvotes").Value);


                    if (ele.Element("authorid") != null && ele.Element("authorid").Value != "")
                        authorid = ele.Element("authorid").Value;


                    if (ele.Element("date") != null && ele.Element("date").Value != "")
                        date = ele.Element("date").Value;


                    if (ele.Element("summary") != null && ele.Element("summary").Value != "")
                        summary = ele.Element("summary").Value;


                    if (ele.Element("content") != null && ele.Element("content").Value != "")
                        content = ele.Element("content").Value;

                    book.Reviews.Add(new Review( authorid, date, summary, content, rating, totalvotes, helpfulvotes));
                }
            }

            if (element.Element("images") != null && element.Element("images").Value != "")
            {
                foreach (XElement ele in element.Element("images").Elements())
                {
                    HashSet<string> imageCategories = new HashSet<string>();

                    foreach (XElement subEle in ele.Element("imageCategories").Elements())
                    {
                        if (subEle.Element("imagecategory") != null && subEle.Element("imagecategory").Value != "")
                            imageCategories.Add(subEle.Element("imagecategory").Value);
                    }

                    int height = 0;
                    int width = 0;

                    if (ele.Element("height") != null && ele.Element("height").Value != "")
                        height = int.Parse(ele.Element("height").Value);


                    if (ele.Element("width") != null && ele.Element("width").Value != "")
                        height = int.Parse(ele.Element("width").Value);

                    book.Images.Add(new Image(ele.Element("url").Value, height, width, imageCategories));
                }
            }

            if (element.Element("subjects") != null && element.Element("subjects").Value != "")
            {
                foreach (XElement ele in element.Element("subjects").Elements())
                {
                    book.Subjects.Add(ele.Value);
                }
            }

            if (element.Element("awards") != null && element.Element("awards").Value != "")
            {
                foreach (XElement ele in element.Element("awards").Elements())
                {
                    book.Awards.Add(ele.Value);
                }
            }

            if (element.Element("places") != null && element.Element("places").Value != "")
            {
                foreach (XElement ele in element.Element("places").Elements())
                {
                    book.Places.Add(ele.Value);
                }
            }

            if (element.Element("characters") != null && element.Element("characters").Value != "")
            {
                foreach (XElement ele in element.Element("characters").Elements())
                {
                    book.Characters.Add(ele.Value);
                }
            }

            if (element.Element("similarproducts") != null && element.Element("similarproducts").Value != "")
            {
                foreach (XElement ele in element.Element("similarproducts").Elements())
                {
                    book.SimilarProducts.Add(ele.Value);
                }
            }

            if (element.Element("blurbers") != null && element.Element("blurbers").Value != "")
            {
                foreach (XElement ele in element.Element("blurbers").Elements())
                {
                    book.Blurbers.Add(ele.Value);
                }
            }

            if (element.Element("dedications") != null && element.Element("dedications").Value != "")
            {
                foreach (XElement ele in element.Element("dedications").Elements())
                {
                    book.Dedications.Add(ele.Value);
                }
            }

            if (element.Element("series") != null && element.Element("series").Value != "")
            {
                foreach (XElement ele in element.Element("series").Elements())
                {
                    book.Series.Add(ele.Value);
                }
            }

            if (element.Element("epigraphs") != null && element.Element("epigraphs").Value != "")
            {
                foreach (XElement ele in element.Element("epigraphs").Elements())
                {
                    book.Epigraphs.Add(ele.Value);
                }
            }

            if (element.Element("quotations") != null && element.Element("quotations").Value != "")
            {
                foreach (XElement ele in element.Element("quotations").Elements())
                {
                    book.Quotations.Add(ele.Value);
                }
            }

            if (element.Element("dimensions") != null && element.Element("dimensions").Value != "")
            {

                int height = 0;
                int width = 0;
                int length = 0;
                int weight = 0;


                if (element.Element("dimensions").Element("height") != null && element.Element("dimensions").Element("height").Value != "")
                    height = int.Parse(element.Element("dimensions").Element("height").Value);

                if (element.Element("dimensions").Element("width") != null && element.Element("dimensions").Element("width").Value != "")
                    width = int.Parse(element.Element("dimensions").Element("width").Value);

                if (element.Element("dimensions").Element("width") != null && element.Element("dimensions").Element("width").Value != "")
                    width = int.Parse(element.Element("dimensions").Element("width").Value);

                if (element.Element("dimensions").Element("length") != null && element.Element("dimensions").Element("length").Value != "")
                    length = int.Parse(element.Element("dimensions").Element("length").Value);


                if (element.Element("dimensions").Element("weight") != null && element.Element("dimensions").Element("weight").Value != "")
                    weight = int.Parse(element.Element("dimensions").Element("weight").Value);

                book.Dimensions = new Dimension(height,width,length,weight);
            }

            if (element.Element("creators") != null && element.Element("creators").Value != "")
            {
                foreach (XElement ele in element.Element("creators").Elements())
                {
                    if (!book.Creators.ContainsKey(ele.Element("name").Value)) 
                        book.Creators.Add(ele.Element("name").Value, ele.Element("role").Value);
                }
            }

            char[] bannedChars = { 'i', 'd', '=', '\"', 'c', 'o', 'u', 'n', 't' };
            if (element.Element("browseNodes") != null && element.Element("browseNodes").Value != "")
            {
                foreach (XElement ele in element.Element("browseNodes").Elements())
                {
                    int id = 0;

                    if (ele.Attribute("id") != null && ele.Attribute("id").Value != "")
                        id = int.Parse(ele.Attribute("id").Value.Trim(bannedChars));
                    book.BrowseNodes.Add(id, ele.Value);
                }
            }

            if (element.Element("tags") != null && element.Element("tags").Value != "")
            {
                foreach (XElement ele in element.Element("tags").Elements())
                {

                    int count = 0;

                    if (ele.Attribute("count") != null && ele.Attribute("count").Value != "")
                        count = int.Parse(ele.Attribute("count").Value.Trim(bannedChars));
                    
                    if (!book.Tags.ContainsKey(count))
                        book.Tags.Add(count, ele.Value);
                }
            }

            return book;
        }

        public string Isbn
        {
            get
            {
                return isbn;
            }

            set
            {
                isbn = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Ean
        {
            get
            {
                return ean;
            }

            set
            {
                ean = value;
            }
        }

        public string Binding
        {
            get
            {
                return binding;
            }

            set
            {
                binding = value;
            }
        }

        public string Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
            }
        }

        public string ListPrice
        {
            get
            {
                return listPrice;
            }

            set
            {
                listPrice = value;
                if (value != null && value != "")
                    double.TryParse((value.Remove(0, 1)), out priceValue);
            }
        }

        public double ListPriceValue
        {
            get
            {
                return priceValue;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }

            set
            {
                manufacturer = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                publisher = value;
            }
        }

        public string ReadingLevel
        {
            get
            {
                return readingLevel;
            }

            set
            {
                readingLevel = value;
            }
        }

        public string ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                releaseDate = value;
            }
        }

        public string PublicationDate
        {
            get
            {
                return publicationDate;
            }

            set
            {
                publicationDate = value;
            }
        }

        public string Studio
        {
            get
            {
                return studio;
            }

            set
            {
                studio = value;
            }
        }

        public string Edition
        {
            get
            {
                return edition;
            }

            set
            {
                edition = value;
            }
        }

        public string Dewey
        {
            get
            {
                return dewey;
            }

            set
            {
                dewey = value;
            }
        }

        public string FirstWords
        {
            get
            {
                return firstWords;
            }

            set
            {
                firstWords = value;
            }
        }

        public string LastWords
        {
            get
            {
                return lastWords;
            }

            set
            {
                lastWords = value;
            }
        }

        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }

            set
            {
                numberOfPages = value;
            }
        }

        public HashSet<EditorialReview> EditorialReviews
        {
            get
            {
                return editorialReviews;
            }

            set
            {
                editorialReviews = value;
            }
        }

        public HashSet<Review> Reviews
        {
            get
            {
                return reviews;
            }

            set
            {
                reviews = value;
            }
        }

        public HashSet<Image> Images
        {
            get
            {
                return images;
            }

            set
            {
                images = value;
            }
        }

        public HashSet<string> Subjects
        {
            get
            {
                return subjects;
            }

            set
            {
                subjects = value;
            }
        }

        public HashSet<string> Awards
        {
            get
            {
                return awards;
            }

            set
            {
                awards = value;
            }
        }

        public HashSet<string> Places
        {
            get
            {
                return places;
            }

            set
            {
                places = value;
            }
        }

        public HashSet<string> Characters
        {
            get
            {
                return characters;
            }

            set
            {
                characters = value;
            }
        }

        public HashSet<string> SimilarProducts
        {
            get
            {
                return similarProducts;
            }

            set
            {
                similarProducts = value;
            }
        }

        public HashSet<string> Blurbers
        {
            get
            {
                return blurbers;
            }

            set
            {
                blurbers = value;
            }
        }

        public HashSet<string> Dedications
        {
            get
            {
                return dedications;
            }

            set
            {
                dedications = value;
            }
        }

        public HashSet<string> Series
        {
            get
            {
                return series;
            }

            set
            {
                series = value;
            }
        }

        public HashSet<string> Epigraphs
        {
            get
            {
                return epigraphs;
            }

            set
            {
                epigraphs = value;
            }
        }

        public HashSet<string> Quotations
        {
            get
            {
                return quotations;
            }

            set
            {
                quotations = value;
            }
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

        public Dictionary<string, string> Creators
        {
            get
            {
                return creators;
            }

            set
            {
                creators = value;
            }
        }

        public Dictionary<int, string> BrowseNodes
        {
            get
            {
                return browseNodes;
            }

            set
            {
                browseNodes = value;
            }
        }

        public Dictionary<int, string> Tags
        {
            get
            {
                return tags;
            }

            set
            {
                tags = value;
            }
        }

		public static Dictionary<string, int> Values
		{
			get
			{
				return values;
			}

			set
			{
				values = value;
			}
		}
    }


    public class Image
    {

        private string url;
        private int height, width;
        private HashSet<string> imageCategories;

        public Image()
        {

        }

        public Image(string url, int height, int width, HashSet<string> imageCategories)
        {
            this.Url = url;
            this.Height = height;
            this.Width = width;
            this.ImageCategories = imageCategories;
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

    public class Review
    {
        private string date, summary, content, authorID;
        private int rating, totalVotes, helpfulVotes;

        public Review()
        {

        }

        public Review(string authorID, string date, string summary, string content, int rating, int totalVotes, int helpfulVotes)
        {
            this.AuthorID = authorID;
            this.Date = date;
            this.Summary = summary;
            this.Content = content;
            this.Rating = rating;
            this.TotalVotes = totalVotes;
            this.HelpfulVotes = helpfulVotes;
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Summary
        {
            get
            {
                return summary;
            }

            set
            {
                summary = value;
            }
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

        public int Rating
        {
            get
            {
                return rating;
            }

            set
            {
                rating = value;
            }
        }

        public int TotalVotes
        {
            get
            {
                return totalVotes;
            }

            set
            {
                totalVotes = value;
            }
        }

        public int HelpfulVotes
        {
            get
            {
                return helpfulVotes;
            }

            set
            {
                helpfulVotes = value;
            }
        }

        public string AuthorID
        {
            get
            {
                return authorID;
            }

            set
            {
                authorID = value;
            }
        }
    }

    public class EditorialReview
    {
        private string source, content;

        public EditorialReview()
        {

        }

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

        public Dimension()
        {

        }

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
