using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Speech.Recognition;

namespace Dissertation
{
    public partial class InformationView : UserControl, IView
    {
        public VoiceRecognition vr;
        public Book book;

        public bool moreImgsBool, reviewsBool, blurbersBool, creatorsBool;

        public InformationView()
        {
            InitializeComponent();
        }

        private void InformationView_Load(object sender, EventArgs e)
        {
            vr.CurrentView = this;
            vr.viewLoaded();
        }

        public void loadBook(Book book)
        {
            this.book = book;

            Image img1 = null;
            string img1Code = "";
            Image img2 = null;
            
            if (book.Images.Count > 0)
            {

                img1 = book.Images.ElementAt(0);
                img1Code = img1.Url.Split(new string[] { "/I/" }, StringSplitOptions.None)[1].Split(new string[] { "._" }, StringSplitOptions.None)[0];
                
                foreach (Image img in book.Images)
                {
                    string imgCode = img.Url.Split(new string[] { "/I/" }, StringSplitOptions.None)[1].Split(new string[] { "._" }, StringSplitOptions.None)[0];
                    
                    if (img1Code != imgCode)
                    {
                        img2 = img;
                        break;
                    }
                }
            }
            

            if (book.Images.Count > 0)
            {
                Console.WriteLine(img1.Url);
                try
                {
                    mainImage.Load(img1.Url);
                    mainImage.BorderStyle = BorderStyle.None;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("NullReferenceException");
                    mainImage.Image = mainImage.ErrorImage;
                    mainImage.BorderStyle = BorderStyle.FixedSingle;
                }
                catch (WebException)
                {
                    Console.WriteLine("WebException");
                    mainImage.Image = mainImage.ErrorImage;
                    mainImage.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                Console.WriteLine("Fallen into else");
                mainImage.Image = mainImage.ErrorImage;
                mainImage.BorderStyle = BorderStyle.FixedSingle;
            }

            mainImage.SizeMode = PictureBoxSizeMode.CenterImage;

            if (book.Images.Count > 1)
            {
                try
                {
                    secondaryImage.Load(img2.Url);
                    secondaryImage.BorderStyle = BorderStyle.None;
                }
                catch (NullReferenceException)
                {
                    secondaryImage.Image = mainImage.ErrorImage;
                    secondaryImage.BorderStyle = BorderStyle.FixedSingle;
                }
                catch (WebException)
                {
                    secondaryImage.Image = mainImage.ErrorImage;
                    secondaryImage.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                secondaryImage.Image = secondaryImage.ErrorImage;
                secondaryImage.BorderStyle = BorderStyle.FixedSingle;
            }

            if (book.Images.Count < 2)
            {
                moreImages.Hide();
                moreImgsBool = false;
            }
            else
            {
                moreImages.Show();
                moreImgsBool = true;
            }
            

            secondaryImage.SizeMode = PictureBoxSizeMode.CenterImage;

            Console.WriteLine("IV: "+book.Dewey);

            uniqueIdentifiers.Text = book.Isbn + " / " + book.Ean + " / " + book.Dewey;
            
            ///Obtained from: http://stackoverflow.com/questions/9527721/resize-text-size-of-a-label-when-the-text-got-longer-than-the-label-size---------------------------
            while (uniqueIdentifiers.Width < System.Windows.Forms.TextRenderer.MeasureText(uniqueIdentifiers.Text, new Font(uniqueIdentifiers.Font.FontFamily, uniqueIdentifiers.Font.Size, uniqueIdentifiers.Font.Style)).Width)
            {
                uniqueIdentifiers.Font = new Font(uniqueIdentifiers.Font.FontFamily, uniqueIdentifiers.Font.Size - 0.5f, uniqueIdentifiers.Font.Style);
            }
            ///--------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            title.Text = book.Title;

            ///Obtained from: http://stackoverflow.com/questions/9527721/resize-text-size-of-a-label-when-the-text-got-longer-than-the-label-size---------------------------
            while (title.Width * 2 < System.Windows.Forms.TextRenderer.MeasureText(title.Text, new Font(title.Font.FontFamily, title.Font.Size, title.Font.Style)).Width)
            {
                title.Font = new Font(title.Font.FontFamily, title.Font.Size - 0.5f, title.Font.Style);
            }
            ///--------------------------------------------------------------------------------------------------------------------------------------------------------------


            if (book.Edition != "")
            {
                edition.Text = book.Edition;
            }
            else
            {
                edition.Text = "No edition";
            }

            if (book.Series.Count > 0)
            {
                foreach (string s in book.Series)
                {
                    series.Text += s + " ";
                }
            }
            else
            {
                series.Text = "No series";
            }

            if (book.Creators.ContainsValue("author"))
            {
                string bookAuthor = "";

                foreach(KeyValuePair<string,string> kv in book.Creators)
                {
                    if(kv.Value.ToLower() == "author")
                    {
                        bookAuthor = kv.Key;
                        break;
                    }
                }
                author.Text = bookAuthor;
            }
            else if (book.Creators.ContainsValue("Author"))
            {
                string bookAuthor = "";

                foreach (KeyValuePair<string, string> kv in book.Creators)
                {
                    if (kv.Value.ToLower() == "author")
                    {
                        bookAuthor = kv.Key;
                        break;
                    }
                }
                author.Text = bookAuthor;
            }
            else
            {
                author.Text = "Author not found";
            }

            if (book.ListPrice != "")
            {
                price.Text = book.ListPrice;
            }
            else
            {
                price.Text = "???";
            }

            if (book.ReadingLevel != "")
            {
                readingLevel.Text = book.ReadingLevel;
            }
            else
            {
                readingLevel.Text  = "No reading level";
            }

            if (book.Awards.Count > 0)
            {
                foreach (string s in book.Awards)
                {
                    awards.Text += s + "\n";
                }
            }
            else
            {
                awards.Text = "No awards";
            }

            if (book.Epigraphs.Count > 0)
            {

                foreach (string s in book.Epigraphs)
                {
                    epigraphs.Text += s + "\n";
                }
            }
            else
            {
                epigraphs.Text = "No epigraphs";
            }

            if (book.Blurbers.Count == 0)
            {
                blurbers.Hide();
                blurbersBool = false;
            }
            else
            {
                blurbers.Show();
                blurbersBool = true;
            }

            if (book.Reviews.Count == 0 && book.EditorialReviews.Count == 0)
            {
                reviews.Hide();
                reviewsBool = false;
            }
            else
            {
                reviews.Show();
                reviewsBool = true;
            }

            if (book.Creators.Count == 0)
            {
                creators.Hide();
                creatorsBool = false;
            }
            else
            {
                creators.Show();
                creatorsBool = true;
            }
        }

        public TextBox getSearchBox()
        {
            throw new NotImplementedException();
        }

        public TreeView getTreeView()
        {
            throw new NotImplementedException();
        }

        public Label getQuantityLabel()
        {
            throw new NotImplementedException();
        }

        public Label getSaveLabel()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> getItem()
        {
            throw new NotImplementedException();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            foreach(Grammar g in vr.getLoadedGrammars())
            {
                Console.WriteLine(g.Name);
            }
        }
        
    }
}
