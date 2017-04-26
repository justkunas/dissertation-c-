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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Minimum", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("10000");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Maximum", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("false");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Enabled", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Number of pages", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("$0");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Minimum", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("$100000");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Maximum", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("false");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Enabled", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Prices", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode11,
            treeNode13});
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
            treeNode1.Name = "PagesMinimumValueNode";
            treeNode1.Text = "0";
            treeNode2.Name = "PagesMinimumNode";
            treeNode2.Tag = "";
            treeNode2.Text = "Minimum";
            treeNode3.Name = "PagesMaximumValueNode";
            treeNode3.Text = "10000";
            treeNode4.Name = "PagesMaximumNode";
            treeNode4.Text = "Maximum";
            treeNode5.Name = "PagesEnabledValueNode";
            treeNode5.Text = "false";
            treeNode6.Name = "PagesEnabledNode";
            treeNode6.Text = "Enabled";
            treeNode7.Name = "PagesNode";
            treeNode7.Text = "Number of pages";
            treeNode8.Name = "PricesMinimumValueNode";
            treeNode8.Text = "$0";
            treeNode9.Name = "PricesMinimumNode";
            treeNode9.Text = "Minimum";
            treeNode10.Name = "PricesMaximumValueNode";
            treeNode10.Text = "$100000";
            treeNode11.Name = "PricesMaximumNode";
            treeNode11.Text = "Maximum";
            treeNode12.Name = "PricesEnabledValueNode";
            treeNode12.Text = "false";
            treeNode13.Name = "PricesEnabledNode";
            treeNode13.Text = "Enabled";
            treeNode14.Name = "PriceNode";
            treeNode14.Text = "Prices";
            this.filterTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode14});
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
            this.debugButton.Visible = false;
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
