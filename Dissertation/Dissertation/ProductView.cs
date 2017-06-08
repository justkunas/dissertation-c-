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
using System.Xml.Linq;
using Newtonsoft.Json;
using static Dissertation.LuceneCommand;

namespace Dissertation
{
    public partial class ProductView : UserControl, IView
    {
        public int currentPage = 0;
        Query query;
        int dots = 3;
        public VoiceRecognition vr;
        public SearchEngine se;

        public Label[] productLabels;
        public double difference = 0;

        public int numberOfResults;
        public int tracker = 0;

        TextBox[] titles;
        Label[] prices;
        PictureBox[] imgs;

        public ProductView()
        {
            InitializeComponent();
            titles = new TextBox[] { item1Title, item2Title, item3Title, item4Title, item5Title, item6Title, item7Title, item8Title };
            prices = new Label[] { item1Price, item2Price, item3Price, item4Price, item5Price, item6Price, item7Price, item8Price };
            imgs = new PictureBox[] { item1img , item2img, item3img, item4img, item5img, item6img, item7img, item8img,};
            productLabels = new Label[] { productLabel1, productLabel2, productLabel3, productLabel4, productLabel5, productLabel6, productLabel7, productLabel8 };
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product view loaded");
            Console.ForegroundColor = ConsoleColor.White;
            hideAll();
            vr.CurrentView = this;

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
            searchBox.BackColor = SystemColors.Control;
            loading.Text = "Loading, please wait...";
            loading.Show();
            hideAll();
            dots = 0;
            changeLoading.Start();
            ThreadStart startThread = new ThreadStart(threadSearch);
            Thread thread = new Thread(startThread);
            thread.Start();

        }

        private void threadSearch()
        {
            se.Query = vr.Query;
            se.Command = vr.Command;
            se.search();
            this.Invoke((MethodInvoker)delegate { threadEnd(); });
        }

        private void threadEnd()
        {
            loading.Hide();
            showAll();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            //XElement xEle = JsonConvert.DeserializeXmlNode(JsonConvert.DeserializeObject());
            refreshScreen(se.Pages[0]);
            changeLoading.Stop();
            SaveLabel.Hide();
        }

        public void hideAll()
        {
            search.Hide();
            searchBox.Hide();
            SaveLabel.Hide();
            filterTree.Hide();
            next.Hide();
            previous.Hide();
            load.Hide();

            hideData();
        }

        public void hideData()
        {
            foreach (TextBox tb in titles)
            {
                tb.Hide();
            }

            foreach (Label l in prices)
            {
                l.Hide();
            }

            foreach (PictureBox pb in imgs)
            {
                pb.Hide();
            }
        }

        public void showData()
        {
            foreach (TextBox tb in titles)
            {
                tb.Show();
            }

            foreach (Label l in prices)
            {
                l.Show();
            }

            foreach (PictureBox pb in imgs)
            {
                pb.Show();
            }
        }

        public void showAll()
        {
            search.Show();
            searchBox.Show();
            SaveLabel.Show();
            filterTree.Show();
            next.Show();
            previous.Show();
            //load.Show();

            showData();
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
            tracker++;
            vr.Command = new LuceneCommand(Commands.NEXT, null, Util.SERVER_IP, Util.SERVER_PORT);
            querySearch();
        }

        private void refreshScreen(Book[] books)
        {
            numberOfResults = books.Length;

            if(books.Length == 0)
            {
                loading.Text = "No results found.";
                loading.Show();
            }

            difference = 8 - books.Length;

            Console.WriteLine("difference: " + difference);

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
            
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    imgs[7-i].Hide();
                    titles[7-i].Hide();
                    prices[7-i].Hide();
                }
            }else
            {
                for(int i = 0; i < 8; i++)
                {
                    imgs[i].Show();
                    titles[i].Show();
                    prices[i].Show();
                }
            }
            
        }

        private void previous_Click(object sender, EventArgs e)
        {
            previousPage();
        }

        public void previousPage()
        {
            if (tracker > 0)
            {
                tracker--;
                vr.Command = new LuceneCommand(Commands.PREVIOUS, null, Util.SERVER_IP, Util.SERVER_PORT);
                querySearch();
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

        private void changeLoading_Tick(object sender, EventArgs e)
        {
            string loadDis = "Loading, please wait";
            for(int i = 0; i < dots; i++)
            {
                loadDis += ".";
            }

            if (dots == 3)
                dots = 0;
            else
                dots++;

            loading.Text = loadDis;
        }
    }
}