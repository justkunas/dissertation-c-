using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dissertation.Searching;
using System.Web.Script.Serialization;
using System.Threading;

namespace Dissertation
{
    public partial class ProductView : UserControl, IView
    {
        public int currentPage = 0;
        Query query;
        public VoiceRecognition vr;
        public SearchEngine se;

        public Label[] productLabels;

        TextBox[] titles;
        Label[] prices;
        PictureBox[] imgs;

        public ProductView()
        {
            InitializeComponent();
            titles = new TextBox[] { item1Title, item2Title, item3Title, item4Title, item5Title, item6Title, item7Title, item8Title };
            prices = new Label[] { item1Price, item2Price, item3Price, item4Price, item5Price, item6Price, item7Price, item8Price };
            imgs = new PictureBox[] { item1img , item2img, item3img, item4img, item5img, item6img, item7img, item8img,};
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product view loaded");
            Console.ForegroundColor = ConsoleColor.White;
            vr.CurrentView = this;

            productLabels = new Label[] { productLabel1, productLabel2, productLabel3, productLabel4, productLabel5, productLabel6, productLabel7, productLabel8 };
            foreach(Label l in productLabels)
            {
                l.Hide();
            }
            
            filterTree.ExpandAll();
            se = new SearchEngine(null);

            this.querySearch();

            vr.viewLoaded();
            vr.startKeyWordRecogniser();
        }

        public void querySearch()
        {
            se.Query = vr.Query;
            se.search();
            refreshScreen(se.Pages[0]);
        }

        public TextBox getSearchBox()
        {
            return searchBox;
        }

        public TreeView getTreeView()
        {
            return filterTree;
        }

        private void load_Click(object sender, EventArgs e)
        {
            Testing.Program.ms.Master.Controls.Remove(Testing.Program.ms.pv);
            Testing.Program.ms.Master.Controls.Add(Testing.Program.ms.sv);
        }

        private void next_Click(object sender, EventArgs e)
        {
            nextPage();
        }

        public void nextPage()
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

            for(int i = 0; i < books.Length; i++)
            {
                titles[i].Text = books[i].Title;

                if ((books[i].ListPrice != ""))
                {
                    prices[i].Text = books[i].ListPrice;
                }
                else
                {
                    prices[i].Text = "???";
                }

                if (books[i].Images.Count != 0)
                {
                    try
                    {
                        imgs[i].Load(books[i].Images.ElementAt(0).Url);
                        imgs[i].BorderStyle = BorderStyle.None;
                        imgs[i].SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    catch (System.Net.WebException)
                    {
                        imgs[i].Image = imgs[i].ErrorImage;
                        imgs[i].BorderStyle = BorderStyle.FixedSingle;
                        imgs[i].SizeMode = PictureBoxSizeMode.Normal;
                    }
                }
                else
                {
                    imgs[i].Image = imgs[i].ErrorImage;
                    imgs[i].BorderStyle = BorderStyle.FixedSingle;
                    imgs[i].SizeMode = PictureBoxSizeMode.Normal;
                }

            }
            
        }

        private void previous_Click(object sender, EventArgs e)
        {
            previousPage();
        }

        public void previousPage()
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                refreshScreen(se.Pages[currentPage]);
            }
        }

        public Dictionary<string, object> getItem()
        {
            Dictionary<string, object> returnDictionary = new Dictionary<string, object>();
            returnDictionary.Add("query", query);
            return returnDictionary;
        }

        public Label getSaveLabel()
        {
            return SaveLabel;
        }

        public Label getQuantityLabel()
        {
            return quantityLabel;
        }
    }
}