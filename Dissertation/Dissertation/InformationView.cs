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

namespace Dissertation
{
    public partial class InformationView : UserControl
    {
        public InformationView()
        {
            InitializeComponent();
        }

        public void loadBook(Book book)
        {
            /*
            int width1;
            string img1 = book.Images.ElementAt(0).Url;
            int width2;
            string img2 = book.Images.ElementAt(1).Url;

            int working = 0;

            int.TryParse(book.Images.ElementAt(0).Url.Split(new char[] { '_' })[1].Remove(0, 2), out width1);
            int.TryParse(book.Images.ElementAt(1).Url.Split(new char[] { '_' })[1].Remove(0, 2), out width2);

            foreach (Image i in book.Images)
            {
                string[] urlBreakdown = i.Url.Split(new char[] { '_' });

                int.TryParse(urlBreakdown[1].Remove(0, 2), out working);

                Console.WriteLine(working + " > " + width1);

                Console.WriteLine();

                if (working > width1)
                {
                    img1 = i.Url;
                    width1 = working;
                }
                else
                {
                    Console.WriteLine(working + " > " + width2);
                    if (working > width2)
                    {
                        img2 = i.Url;
                        width2 = working;
                    }
                }

            }
            
            Console.WriteLine(img1);
            Console.WriteLine(img2);

            //*/
            if (book.Images.Count > 0)
            {
                try
                {
                    mainImage.Load(book.Images.ElementAt(0).Url);
                    mainImage.BorderStyle = BorderStyle.None;
                }
                catch (WebException)
                {
                    mainImage.Image = mainImage.ErrorImage;
                    mainImage.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                mainImage.Image = mainImage.ErrorImage;
                mainImage.BorderStyle = BorderStyle.FixedSingle;
            }

            mainImage.SizeMode = PictureBoxSizeMode.CenterImage;

            if (book.Images.Count > 1)
            {
                try
                {
                    secondaryImage.Load(book.Images.ElementAt(1).Url);
                    secondaryImage.BorderStyle = BorderStyle.None;
                }
                catch (WebException)
                {
                    secondaryImage.Image = secondaryImage.ErrorImage;
                    secondaryImage.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                secondaryImage.Image = secondaryImage.ErrorImage;
                secondaryImage.BorderStyle = BorderStyle.FixedSingle;
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

            if (book.Creators.ContainsKey("author"))
            {
                author.Text = book.Creators["author"];
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

        }
    }
}
