namespace Dissertation
{
    partial class Search_View
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
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Minimum", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("10000");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Maximum", new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("false");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Enabled", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Number of pages", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode18,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("$0");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Minimum", new System.Windows.Forms.TreeNode[] {
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("$100000");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Maximum", new System.Windows.Forms.TreeNode[] {
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("false");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Enabled", new System.Windows.Forms.TreeNode[] {
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Prices", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode25,
            treeNode27});
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchBarLabel = new System.Windows.Forms.Label();
            this.filterTree = new System.Windows.Forms.TreeView();
            this.debugButton = new System.Windows.Forms.Button();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.searchBox.Location = new System.Drawing.Point(256, 156);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(585, 20);
            this.searchBox.TabIndex = 0;
            // 
            // searchBarLabel
            // 
            this.searchBarLabel.AutoSize = true;
            this.searchBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBarLabel.Location = new System.Drawing.Point(238, 45);
            this.searchBarLabel.Name = "searchBarLabel";
            this.searchBarLabel.Size = new System.Drawing.Size(603, 108);
            this.searchBarLabel.TabIndex = 1;
            this.searchBarLabel.Text = "Book Search";
            // 
            // filterTree
            // 
            this.filterTree.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filterTree.BackColor = System.Drawing.SystemColors.ControlLight;
            this.filterTree.Location = new System.Drawing.Point(473, 208);
            this.filterTree.Name = "filterTree";
            treeNode15.Name = "PagesMinimumValueNode";
            treeNode15.Text = "0";
            treeNode16.Name = "PagesMinimumNode";
            treeNode16.Tag = "";
            treeNode16.Text = "Minimum";
            treeNode17.Name = "PagesMaximumValueNode";
            treeNode17.Text = "10000";
            treeNode18.Name = "PagesMaximumNode";
            treeNode18.Text = "Maximum";
            treeNode19.Name = "PagesEnabledValueNode";
            treeNode19.Text = "false";
            treeNode20.Name = "PagesEnabledNode";
            treeNode20.Text = "Enabled";
            treeNode21.Name = "PagesNode";
            treeNode21.Text = "Number of pages";
            treeNode22.Name = "PricesMinimumValueNode";
            treeNode22.Text = "$0";
            treeNode23.Name = "PricesMinimumNode";
            treeNode23.Text = "Minimum";
            treeNode24.Name = "PricesMaximumValueNode";
            treeNode24.Text = "$100000";
            treeNode25.Name = "PricesMaximumNode";
            treeNode25.Text = "Maximum";
            treeNode26.Name = "PricesEnabledValueNode";
            treeNode26.Text = "false";
            treeNode27.Name = "PricesEnabledNode";
            treeNode27.Text = "Enabled";
            treeNode28.Name = "PriceNode";
            treeNode28.Text = "Prices";
            this.filterTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode28});
            this.filterTree.Size = new System.Drawing.Size(154, 244);
            this.filterTree.TabIndex = 2;
            // 
            // debugButton
            // 
            this.debugButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.debugButton.Location = new System.Drawing.Point(943, 463);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(90, 23);
            this.debugButton.TabIndex = 3;
            this.debugButton.Text = "Debug button";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // SaveLabel
            // 
            this.SaveLabel.Location = new System.Drawing.Point(447, 179);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(200, 13);
            this.SaveLabel.TabIndex = 4;
            this.SaveLabel.Text = "Would you like to update the filters?";
            this.SaveLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(514, 192);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(0, 13);
            this.quantityLabel.TabIndex = 5;
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(841, 154);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(50, 23);
            this.search.TabIndex = 6;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // Search_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.search);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.SaveLabel);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.filterTree);
            this.Controls.Add(this.searchBarLabel);
            this.Controls.Add(this.searchBox);
            this.Name = "Search_View";
            this.Size = new System.Drawing.Size(1088, 541);
            this.Load += new System.EventHandler(this.Search_View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchBarLabel;
        private System.Windows.Forms.TreeView filterTree;
        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.Label SaveLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Button search;
    }
}
