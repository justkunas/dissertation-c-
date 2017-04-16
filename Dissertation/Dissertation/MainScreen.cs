using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using Dissertation;
using Dissertation.Searching;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Testing
{
    public partial class MainScreen : Form
    {

        int currentPage = 0;
        //SearchEngine se = new SearchEngine();
        VoiceRecognition vr;
        SearchEngine se;

        public MainScreen()
        {
            InitializeComponent();
            vr = new VoiceRecognition();
            /*
			Book.GenerateDictionary();

            se.quickSearch("Tunnnel".ToUpper());
            se.loadInPage(0);
            se.loadInPage(1);

            refreshScreen(generateBooks(1));
            //*/
        }

        private void load_Click(object sender, EventArgs e)
        {
            //FileChecking.checkForAllSpecifics();
            //*
            Query query = new Query("search", Filters.FilterBuilder(1, 100, 1, 1000, 1, 2000, 1, 3000, 1, 4000, 1, 9999));
            query.filters.setAllFilters(true);
            se = new SearchEngine(query);
            se.search();
            Console.WriteLine("ser.Pages.Count: " + se.Pages.Count);
            refreshScreen(se.Pages[0]);

        }

        private void next_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) < se.Pages.Count)
            {
                currentPage++;
                refreshScreen(se.Pages[currentPage]);
            }
        }

        private void refreshScreen(Book[] books)
        {

            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }

            item1Title.Text = books[0].Title;
            item2Title.Text = books[1].Title;
            item3Title.Text = books[2].Title;
            item4Title.Text = books[3].Title;
            item5Title.Text = books[4].Title;
            item6Title.Text = books[5].Title;
            item7Title.Text = books[6].Title;
            item8Title.Text = books[7].Title;

            if ((books[0].ListPrice != ""))
            {
                item1Price.Text = books[0].ListPrice;
            }
            else
            {
                item1Price.Text = "???";
            }
            if ((books[1].ListPrice != ""))
            {
                item2Price.Text = books[1].ListPrice;
            }
            else
            {
                item2Price.Text = "???";
            }
            if ((books[2].ListPrice != ""))
            {
                item3Price.Text = books[2].ListPrice;
            }
            else
            {
                item3Price.Text = "???";
            }
            if ((books[3].ListPrice != ""))
            {
                item4Price.Text = books[3].ListPrice;
            }
            else
            {
                item4Price.Text = "???";
            }
            if ((books[4].ListPrice != ""))
            {
                item5Price.Text = books[4].ListPrice;
            }
            else
            {
                item5Price.Text = "???";
            }
            if ((books[5].ListPrice != ""))
            {
                item6Price.Text = books[5].ListPrice;
            }
            else
            {
                item6Price.Text = "???";
            }
            if ((books[6].ListPrice != ""))
            {
                item7Price.Text = books[6].ListPrice;
            }
            else
            {
                item7Price.Text = "???";
            }
            if ((books[7].ListPrice != ""))
            {
                item8Price.Text = books[7].ListPrice;
            }
            else
            {
                item8Price.Text = "???";
            }

            //*
            if (books[0].Images.Count != 0)
            {
                try
                {
                    item1img.Load(books[0].Images.ElementAt(0).Url);
                    item1img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item1img.Image = item1img.ErrorImage;
                    item1img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item1img.Image = item1img.ErrorImage;
                item1img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[1].Images.Count != 0)
            {
                try
                {

                    item2img.Load(books[1].Images.ElementAt(0).Url);
                    item2img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item2img.Image = item2img.ErrorImage;
                    item2img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item2img.Image = item2img.ErrorImage;
                item2img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[2].Images.Count != 0)
            {
                try
                {
                    item3img.Load(books[2].Images.ElementAt(0).Url);
                    item3img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item3img.Image = item3img.ErrorImage;
                    item3img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item3img.Image = item3img.ErrorImage;
                item3img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[3].Images.Count != 0)
            {
                try
                {
                    item4img.Load(books[3].Images.ElementAt(0).Url);
                    item4img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item4img.Image = item4img.ErrorImage;
                    item4img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item4img.Image = item4img.ErrorImage;
                item4img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[4].Images.Count != 0)
            {
                try
                {
                    item5img.Load(books[4].Images.ElementAt(0).Url);
                    item5img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item5img.Image = item5img.ErrorImage;
                    item5img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item5img.Image = item5img.ErrorImage;
                item5img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[5].Images.Count != 0)
            {
                try
                {
                    item6img.Load(books[5].Images.ElementAt(0).Url);
                    item6img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item6img.Image = item6img.ErrorImage;
                    item6img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item6img.Image = item6img.ErrorImage;
                item6img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[6].Images.Count != 0)
            {
                try
                {
                    item7img.Load(books[6].Images.ElementAt(0).Url);
                    item7img.BorderStyle = BorderStyle.None;

                }
                catch (System.Net.WebException err)
                {
                    item7img.Image = item7img.ErrorImage;
                    item7img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item7img.Image = item7img.ErrorImage;
                item7img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books[7].Images.Count != 0)
            {
                try
                {
                    item8img.Load(books[7].Images.ElementAt(0).Url);
                    item8img.BorderStyle = BorderStyle.None;
                }
                catch (System.Net.WebException err)
                {
                    item8img.Image = item8img.ErrorImage;
                    item8img.BorderStyle = BorderStyle.FixedSingle;
                }
            }
            else
            {
                item8img.Image = item8img.ErrorImage;
                item8img.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void previous_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                refreshScreen(se.Pages[currentPage]);
            }
        }
    }
}
