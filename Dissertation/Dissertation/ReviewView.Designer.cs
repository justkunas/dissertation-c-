namespace Dissertation
{
    partial class ReviewView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.erLabel = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.editorialReviews = new System.Windows.Forms.RichTextBox();
            this.reviews = new System.Windows.Forms.RichTextBox();
            this.debugButton = new System.Windows.Forms.Button();
            this.previousER = new System.Windows.Forms.Button();
            this.nextER = new System.Windows.Forms.Button();
            this.nextReview = new System.Windows.Forms.Button();
            this.previousReview = new System.Windows.Forms.Button();
            this.ratingTextBox = new System.Windows.Forms.TextBox();
            this.helpfulVotesTextBox = new System.Windows.Forms.TextBox();
            this.totalVotesTextBox = new System.Windows.Forms.TextBox();
            this.reviewPage = new System.Windows.Forms.Label();
            this.editorialReviewPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // erLabel
            // 
            this.erLabel.AutoSize = true;
            this.erLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erLabel.Location = new System.Drawing.Point(67, 48);
            this.erLabel.Name = "erLabel";
            this.erLabel.Size = new System.Drawing.Size(371, 51);
            this.erLabel.TabIndex = 0;
            this.erLabel.Text = "Editorial Reviews";
            this.erLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel.Location = new System.Drawing.Point(755, 48);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(193, 51);
            this.rLabel.TabIndex = 0;
            this.rLabel.Text = "Reviews";
            this.rLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // editorialReviews
            // 
            this.editorialReviews.BackColor = System.Drawing.SystemColors.Control;
            this.editorialReviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editorialReviews.Location = new System.Drawing.Point(12, 102);
            this.editorialReviews.Name = "editorialReviews";
            this.editorialReviews.ReadOnly = true;
            this.editorialReviews.Size = new System.Drawing.Size(500, 400);
            this.editorialReviews.TabIndex = 3;
            this.editorialReviews.Text = "";
            // 
            // reviews
            // 
            this.reviews.BackColor = System.Drawing.SystemColors.Control;
            this.reviews.Location = new System.Drawing.Point(570, 102);
            this.reviews.Name = "reviews";
            this.reviews.ReadOnly = true;
            this.reviews.Size = new System.Drawing.Size(500, 381);
            this.reviews.TabIndex = 3;
            this.reviews.Text = "";
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(504, 73);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(75, 23);
            this.debugButton.TabIndex = 4;
            this.debugButton.Text = "Debug Button";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Visible = false;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // previousER
            // 
            this.previousER.Location = new System.Drawing.Point(12, 508);
            this.previousER.Name = "previousER";
            this.previousER.Size = new System.Drawing.Size(136, 23);
            this.previousER.TabIndex = 5;
            this.previousER.Text = "Previous Editorial Review";
            this.previousER.UseVisualStyleBackColor = true;
            this.previousER.Click += new System.EventHandler(this.previousER_Click);
            // 
            // nextER
            // 
            this.nextER.Location = new System.Drawing.Point(393, 508);
            this.nextER.Name = "nextER";
            this.nextER.Size = new System.Drawing.Size(119, 23);
            this.nextER.TabIndex = 5;
            this.nextER.Text = "Next Editorial Review";
            this.nextER.UseVisualStyleBackColor = true;
            this.nextER.Click += new System.EventHandler(this.nextER_Click);
            // 
            // nextReview
            // 
            this.nextReview.Location = new System.Drawing.Point(986, 508);
            this.nextReview.Name = "nextReview";
            this.nextReview.Size = new System.Drawing.Size(84, 23);
            this.nextReview.TabIndex = 5;
            this.nextReview.Text = "Next Review";
            this.nextReview.UseVisualStyleBackColor = true;
            this.nextReview.Click += new System.EventHandler(this.nextReview_Click);
            // 
            // previousReview
            // 
            this.previousReview.Location = new System.Drawing.Point(570, 508);
            this.previousReview.Name = "previousReview";
            this.previousReview.Size = new System.Drawing.Size(106, 23);
            this.previousReview.TabIndex = 5;
            this.previousReview.Text = "Previous Review";
            this.previousReview.UseVisualStyleBackColor = true;
            this.previousReview.Click += new System.EventHandler(this.previousReview_Click);
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Location = new System.Drawing.Point(571, 481);
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.ReadOnly = true;
            this.ratingTextBox.Size = new System.Drawing.Size(166, 20);
            this.ratingTextBox.TabIndex = 6;
            this.ratingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // helpfulVotesTextBox
            // 
            this.helpfulVotesTextBox.Location = new System.Drawing.Point(903, 481);
            this.helpfulVotesTextBox.Name = "helpfulVotesTextBox";
            this.helpfulVotesTextBox.ReadOnly = true;
            this.helpfulVotesTextBox.Size = new System.Drawing.Size(166, 20);
            this.helpfulVotesTextBox.TabIndex = 6;
            this.helpfulVotesTextBox.Text = "`";
            this.helpfulVotesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalVotesTextBox
            // 
            this.totalVotesTextBox.Location = new System.Drawing.Point(736, 481);
            this.totalVotesTextBox.Name = "totalVotesTextBox";
            this.totalVotesTextBox.ReadOnly = true;
            this.totalVotesTextBox.Size = new System.Drawing.Size(168, 20);
            this.totalVotesTextBox.TabIndex = 6;
            this.totalVotesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // reviewPage
            // 
            this.reviewPage.AutoSize = true;
            this.reviewPage.Location = new System.Drawing.Point(812, 518);
            this.reviewPage.Name = "reviewPage";
            this.reviewPage.Size = new System.Drawing.Size(35, 13);
            this.reviewPage.TabIndex = 7;
            this.reviewPage.Text = "label1";
            // 
            // editorialReviewPage
            // 
            this.editorialReviewPage.AutoSize = true;
            this.editorialReviewPage.Location = new System.Drawing.Point(246, 518);
            this.editorialReviewPage.Name = "editorialReviewPage";
            this.editorialReviewPage.Size = new System.Drawing.Size(35, 13);
            this.editorialReviewPage.TabIndex = 7;
            this.editorialReviewPage.Text = "label1";
            // 
            // ReviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editorialReviewPage);
            this.Controls.Add(this.reviewPage);
            this.Controls.Add(this.totalVotesTextBox);
            this.Controls.Add(this.helpfulVotesTextBox);
            this.Controls.Add(this.ratingTextBox);
            this.Controls.Add(this.previousReview);
            this.Controls.Add(this.nextER);
            this.Controls.Add(this.nextReview);
            this.Controls.Add(this.previousER);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.reviews);
            this.Controls.Add(this.editorialReviews);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.erLabel);
            this.Name = "ReviewView";
            this.Size = new System.Drawing.Size(1088, 541);
            this.Load += new System.EventHandler(this.ReviewView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label erLabel;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.RichTextBox editorialReviews;
        private System.Windows.Forms.RichTextBox reviews;
        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.Button previousER;
        private System.Windows.Forms.Button nextER;
        private System.Windows.Forms.Button nextReview;
        private System.Windows.Forms.Button previousReview;
        private System.Windows.Forms.TextBox ratingTextBox;
        private System.Windows.Forms.TextBox helpfulVotesTextBox;
        private System.Windows.Forms.TextBox totalVotesTextBox;
        private System.Windows.Forms.Label reviewPage;
        private System.Windows.Forms.Label editorialReviewPage;
    }
}
