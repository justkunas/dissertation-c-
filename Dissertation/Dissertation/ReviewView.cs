using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dissertation
{
    public partial class ReviewView : UserControl, IPagedView
    {
        public VoiceRecognition vr;
        Book book;
        public int erPage = 0;
        public int rPage = 0;

        string[] textToRemove = new string[] { "<b>", "</b>", "<i>", "</i>", "<DIV>", "<BR>", "<I>", "</I>", "</DIV>", "<P>", "</P>", "<br />" };

        public ReviewView()
        {
            InitializeComponent();

        }
        
        private void ReviewView_Load(object sender, EventArgs e)
        {
            reviewPage.Text = (rPage + 1) + "/" + Book.Reviews.Count;
            editorialReviewPage.Text = (erPage + 1) + "/" + Book.EditorialReviews.Count;

            if (book.EditorialReviews.Count > 0)
                loadEditorialReviewPage(erPage);

            if (book.Reviews.Count > 0)
                loadReviewPage(rPage);
        }

        public void loadEditorialReviewPage(int pageNumber)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Book.EditorialReviews.Count);
            Console.WriteLine(Book.EditorialReviews.ElementAt(pageNumber));
            Console.ForegroundColor = ConsoleColor.White;
            EditorialReview er = Book.EditorialReviews.ElementAt(pageNumber);
            editorialReviews.Text = "";

            string source = er.Source + "\r\n\r\n";
            string content = er.Content.Replace("<p>", "\n");

            foreach (string s in textToRemove)
            {
                content = content.Replace(s, "");
            }

            content += "\r\n";
            editorialReviews.Text += source;
            editorialReviews.Text += content;
            editorialReviews.Text += "\r\n\r\n";

            editorialReviews.Select(0, er.Source.Length);
            editorialReviews.SelectionFont = new Font(editorialReviews.Font.FontFamily, 16, FontStyle.Bold);

            editorialReviews.SelectAll();
            editorialReviews.SelectionAlignment = HorizontalAlignment.Center;

            editorialReviews.Select(source.Length, editorialReviews.TextLength);
            editorialReviews.SelectionAlignment = HorizontalAlignment.Left;

            reviewPage.Text = (rPage + 1) + "/" + Book.Reviews.Count;
            editorialReviewPage.Text = (erPage + 1) + "/" + Book.EditorialReviews.Count;
        }

        public void loadReviewPage(int pageNumber)
        {
            Review r = Book.Reviews.ElementAt(pageNumber);
            reviews.Text = "";

            string date = r.Date + ": ";
            string summary = r.Summary + "\r\n\r\n";
            string content = r.Content;

            foreach (string s in textToRemove)
            {
                content = content.Replace(s, "");
            }
            
            string rating = r.Rating + "";
            string totalVotes = r.TotalVotes + "";
            string helpfulVotes = r.HelpfulVotes + "";

            reviews.Text += date;
            reviews.Text += summary;
            reviews.Text += content;

            ratingTextBox.Text = rating;
            totalVotesTextBox.Text = totalVotes;
            helpfulVotesTextBox.Text = helpfulVotes;

            reviews.SelectAll();
            editorialReviews.SelectionAlignment = HorizontalAlignment.Left;
            
            //*
            reviews.Select(0, (date.Length + r.Summary.Length));
            reviews.SelectionAlignment = HorizontalAlignment.Center;
            reviews.SelectionFont = new Font(editorialReviews.Font.FontFamily, 16, FontStyle.Bold);
            //*/
            reviewPage.Text = (rPage + 1) + "/" + Book.Reviews.Count;
            editorialReviewPage.Text = (erPage + 1) + "/" + Book.EditorialReviews.Count;
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
                
                rPage = 0;
                erPage = 0;

                if (book.EditorialReviews.Count == 0)
                {
                    editorialReviews.Hide();
                    erLabel.Hide();
                    nextER.Hide();
                    previousER.Hide();
                    editorialReviewPage.Hide();
                }else
                {
                    editorialReviews.Show();
                    erLabel.Show();
                    nextER.Show();
                    previousER.Show();
                    editorialReviewPage.Show();
                    loadEditorialReviewPage(0);
                }

                if (book.Reviews.Count == 0)
                {
                    reviews.Hide();
                    rLabel.Hide();
                    ratingTextBox.Hide();
                    totalVotesTextBox.Hide();
                    helpfulVotesTextBox.Hide();
                    reviewPage.Hide();
                    nextReview.Hide();
                    previousReview.Hide();
                }else
                {
                    reviews.Show();
                    rLabel.Show();
                    ratingTextBox.Show();
                    totalVotesTextBox.Show();
                    helpfulVotesTextBox.Show();
                    reviewPage.Show();
                    nextReview.Show();
                    previousReview.Show();
                    loadReviewPage(0);

                }
            }
        }

        public void setBook(Book book)
        {

            
            Dictionary<string, int> editorialReviewsStartingIndexes = new Dictionary<string, int>();
            Dictionary<string, int> reviewsStartingIndexes = new Dictionary<string, int>();
            
            
            //reviews.SelectAll();
            //reviews.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            
        }

        public void nextEditorialReviewPage()
        {
            if (erPage < book.EditorialReviews.Count - 1)
            {
                erPage++;
            }
            loadEditorialReviewPage(erPage);
        }
        
        public void previousEditorialReviewPage()
        {
            if (erPage > 0)
            {
                erPage--;
            }
            loadEditorialReviewPage(erPage);
        }

        public void nextReviewPage()
        {
            Console.WriteLine(rPage);
            if (rPage < book.Reviews.Count - 1)
            {
                rPage++;
            }
            loadReviewPage(rPage);
        }

        public void previousReviewPage()
        {
            if (rPage > 0)
            {
                rPage--;
            }
            loadReviewPage(rPage);
        }

        private void previousER_Click(object sender, EventArgs e)
        {
            previousEditorialReviewPage();
        }

        private void nextER_Click(object sender, EventArgs e)
        {
            nextEditorialReviewPage();
        }

        private void previousReview_Click(object sender, EventArgs e)
        {
            previousReviewPage();
        }

        private void nextReview_Click(object sender, EventArgs e)
        {
            nextReviewPage();
        }

        public void loadNextPage()
        {
            nextReviewPage();
            nextEditorialReviewPage();
        }

        public void loadPreviousPage()
        {
            previousReviewPage();
            previousEditorialReviewPage();
        }
    }
}
