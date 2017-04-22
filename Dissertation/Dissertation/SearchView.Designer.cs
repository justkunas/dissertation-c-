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
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Minimum", new System.Windows.Forms.TreeNode[] {
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("10000");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Maximum", new System.Windows.Forms.TreeNode[] {
            treeNode59});
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("false");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("Enabled", new System.Windows.Forms.TreeNode[] {
            treeNode61});
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("Number of pages", new System.Windows.Forms.TreeNode[] {
            treeNode58,
            treeNode60,
            treeNode62});
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("$0");
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("Minimum", new System.Windows.Forms.TreeNode[] {
            treeNode64});
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("$100000");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("Maximum", new System.Windows.Forms.TreeNode[] {
            treeNode66});
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("false");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("Enabled", new System.Windows.Forms.TreeNode[] {
            treeNode68});
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("Prices", new System.Windows.Forms.TreeNode[] {
            treeNode65,
            treeNode67,
            treeNode69});
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchBarLabel = new System.Windows.Forms.Label();
            this.filterTree = new System.Windows.Forms.TreeView();
            this.debugButton = new System.Windows.Forms.Button();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
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
            treeNode57.Name = "PagesMinimumValueNode";
            treeNode57.Text = "0";
            treeNode58.Name = "PagesMinimumNode";
            treeNode58.Tag = "";
            treeNode58.Text = "Minimum";
            treeNode59.Name = "PagesMaximumValueNode";
            treeNode59.Text = "10000";
            treeNode60.Name = "PagesMaximumNode";
            treeNode60.Text = "Maximum";
            treeNode61.Name = "PagesEnabledValueNode";
            treeNode61.Text = "false";
            treeNode62.Name = "PagesEnabledNode";
            treeNode62.Text = "Enabled";
            treeNode63.Name = "PagesNode";
            treeNode63.Text = "Number of pages";
            treeNode64.Name = "PricesMinimumValueNode";
            treeNode64.Text = "$0";
            treeNode65.Name = "PricesMinimumNode";
            treeNode65.Text = "Minimum";
            treeNode66.Name = "PricesMaximumValueNode";
            treeNode66.Text = "$100000";
            treeNode67.Name = "PricesMaximumNode";
            treeNode67.Text = "Maximum";
            treeNode68.Name = "PricesEnabledValueNode";
            treeNode68.Text = "false";
            treeNode69.Name = "PricesEnabledNode";
            treeNode69.Text = "Enabled";
            treeNode70.Name = "PriceNode";
            treeNode70.Text = "Prices";
            this.filterTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode63,
            treeNode70});
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
            // Search_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
