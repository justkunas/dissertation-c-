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

        int currentPage = 1;
        int pagesLoaded = 2;
        SearchEngine se = new SearchEngine();

        public MainScreen()
		{
			InitializeComponent();
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
            FileChecking.checkForAllSpecifics();
            /*
            string strIndexDir = "C:\\Users\\Justkunas\\Documents\\Projects\\Index";
            string file = "C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml\\999\\0002254999.xml";
            Book book = Book.parseXML(XElement.Load("C:\\Users\\Justkunas\\Documents\\Amazon Books\\xml\\999\\0002254999.xml"));
            /*   
			var sd = new SortedDictionary<int,char>();
			char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			var start = DateTime.Now;
            
            //*/
        }

        private HashSet<Book> generateBooks(int page)
        {
            HashSet<Book> books = new HashSet<Book>();

            foreach (XElement ele in se.pages[page])
            {
                XElement xEle = XElement.Load(ele.Element("Path").Value);
                books.Add(Book.parseXML(xEle));
            }

            return books;
        }

        private void refreshScreen(HashSet<Book> books)
        {

			foreach (Book book in books)
			{
				Console.WriteLine(book.Title);
			}

            item1Title.Text = books.ElementAt(0).Title;
            item2Title.Text = books.ElementAt(1).Title;
            item3Title.Text = books.ElementAt(2).Title;
            item4Title.Text = books.ElementAt(3).Title;
            item5Title.Text = books.ElementAt(4).Title;
            item6Title.Text = books.ElementAt(5).Title;
            item7Title.Text = books.ElementAt(6).Title;
            item8Title.Text = books.ElementAt(7).Title;


            Console.WriteLine("Loading prices: \"" + (books.ElementAt(1).ListPrice == "") + "\"");

            if ((books.ElementAt(0).ListPrice != ""))
            {
                item1Price.Text = books.ElementAt(0).ListPrice;
            }
            else
            {
                item1Price.Text = "???";
            }
            if ((books.ElementAt(1).ListPrice != ""))
            {
                item2Price.Text = books.ElementAt(1).ListPrice;
            }
            else
            {
                item2Price.Text = "???";
            }
            if ((books.ElementAt(2).ListPrice != ""))
            {
                item3Price.Text = books.ElementAt(2).ListPrice;
            }
            else
            {
                item3Price.Text = "???";
            }
            if ((books.ElementAt(3).ListPrice != ""))
            {
                item4Price.Text = books.ElementAt(3).ListPrice;
            }
            else
            {
                item4Price.Text = "???";
            }
            if ((books.ElementAt(4).ListPrice != ""))
            {
                item5Price.Text = books.ElementAt(4).ListPrice;
            }
            else
            {
                item5Price.Text = "???";
            }
            if ((books.ElementAt(5).ListPrice != ""))
            {
				item6Price.Text = books.ElementAt(5).ListPrice;
            }
            else
            {
                item6Price.Text = "???";
            }
            if ((books.ElementAt(6).ListPrice != ""))
            {
                item7Price.Text = books.ElementAt(6).ListPrice;
            }
            else
            {
                item7Price.Text = "???";
            }
            if ((books.ElementAt(7).ListPrice != ""))
            {
                item8Price.Text = books.ElementAt(7).ListPrice;
            }
            else
            {
                item8Price.Text = "???";
            }

            Console.WriteLine("Loading Images: \"" + books.ElementAt(0).Images.Count + "\"");
            //*
            if (books.ElementAt(0).Images.Count != 0)
            {
                item1img.Load(books.ElementAt(0).Images.ElementAt(0).Url);
				item1img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item1img.Image = item1img.ErrorImage;
				item1img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(1).Images.Count != 0)
            {
                item2img.Load(books.ElementAt(1).Images.ElementAt(0).Url);
				item2img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item2img.Image = item2img.ErrorImage;
				item2img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(2).Images.Count != 0)
            {
                item3img.Load(books.ElementAt(2).Images.ElementAt(0).Url);
				item3img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item3img.Image = item3img.ErrorImage;
				item3img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(3).Images.Count != 0)
            {
                item4img.Load(books.ElementAt(3).Images.ElementAt(0).Url);
				item4img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item4img.Image = item4img.ErrorImage;
				item4img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(4).Images.Count != 0)
            {
                item5img.Load(books.ElementAt(4).Images.ElementAt(0).Url);
				item5img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item5img.Image = item5img.ErrorImage;
				item5img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(5).Images.Count != 0)
            {
                item6img.Load(books.ElementAt(5).Images.ElementAt(0).Url);
				item6img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item6img.Image = item6img.ErrorImage;
				item6img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(6).Images.Count != 0)
            {
                item7img.Load(books.ElementAt(6).Images.ElementAt(0).Url);
				item7img.BorderStyle = BorderStyle.None;
            }
            else
            {
                item7img.Image = item7img.ErrorImage;
				item7img.BorderStyle = BorderStyle.FixedSingle;
            }
            if (books.ElementAt(7).Images.Count != 0)
            {
                item8img.Load(books.ElementAt(7).Images.ElementAt(0).Url);
				item8img.BorderStyle = BorderStyle.None;
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
			Console.WriteLine("MainScreen()_Load");
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

        private void previous_Click(object sender, EventArgs e)
        {
            Console.WriteLine(currentPage + " : " + pagesLoaded);
			if (currentPage > 1)
			{
				currentPage--;
				refreshScreen(generateBooks(currentPage));
			}
        }

        private void next_Click(object sender, EventArgs e)
        {
            Console.WriteLine(currentPage + " : " + pagesLoaded);
			currentPage++;
            if((pagesLoaded-1) <= currentPage)
            {
                se.loadInPage(currentPage);
                refreshScreen(generateBooks(currentPage));
            }else
            {
                refreshScreen(generateBooks(currentPage));
            }
        }
    }
}
