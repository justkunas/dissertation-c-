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
    public partial class ImageView : UserControl
    {
        public VoiceRecognition vr;

        private Book book;
        public int page = 0;

        PictureBox[] imgs;

        public ImageView()
        { 
            InitializeComponent();
            imgs = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
        }

        public void loadPage(int page)
        {
            for(int i = 0; i < 8; i++)
            {
                if (book.Images.Count > i)
                {
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(new WebClient().DownloadData(Book.Images.ElementAt(i + (page * 8)).Url)));
                        imgs[i].Image = img;
                        imgs[i].BorderStyle = BorderStyle.None;

                        if (img.Height > imgs[i].Height || img.Width > imgs[i].Width)
                            imgs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        else
                            imgs[i].SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    catch (System.Net.WebException)
                    {
                        imgs[i].Image = imgs[i].ErrorImage;
                        imgs[i].BorderStyle = BorderStyle.FixedSingle;
                        imgs[i].SizeMode = PictureBoxSizeMode.Normal;
                    }
                }else
                {
                    imgs[i].Hide();
                }
            }

            pageNumber.Text = page+1 + "/" + (Math.Ceiling((Decimal)Book.Images.Count / 8));
        }

        public Book Book
        {
            get
            {
                return book;
            }

            set
            {
                book = value;
                loadPage(page);
            }
        }

        public void loadNextPage()
        {
            if (page < (Math.Ceiling((Decimal)Book.Images.Count / 8)) - 1)
            {
                page++;
                loadPage(page);
            }
        }

        public void loadPreviousPage()
        {
            if (page > 0)
            {
                page--;
                loadPage(page);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            loadNextPage();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            loadPreviousPage();
        }
    }
}
