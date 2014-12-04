namespace BernsteinTool {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAttributes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAttributeName = new System.Windows.Forms.TextBox();
            this.buttonAddAttribute = new System.Windows.Forms.Button();
            this.buttonRemoveAttribute = new System.Windows.Forms.Button();
            this.listBoxAttributes = new System.Windows.Forms.ListBox();
            this.tabPageFunctionalDependencies = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxFDs = new System.Windows.Forms.ListBox();
            this.buttonAddFD = new System.Windows.Forms.Button();
            this.buttonRemoveFD = new System.Windows.Forms.Button();
            this.listBoxAttributesForFDs = new System.Windows.Forms.ListBox();
            this.listBoxLHS = new System.Windows.Forms.ListBox();
            this.listBoxRHS = new System.Windows.Forms.ListBox();
            this.tabPageSynthesis = new System.Windows.Forms.TabPage();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageAttributes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageFunctionalDependencies.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageAttributes);
            this.tabControl1.Controls.Add(this.tabPageFunctionalDependencies);
            this.tabControl1.Controls.Add(this.tabPageSynthesis);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 508);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAttributes
            // 
            this.tabPageAttributes.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabPageAttributes.Name = "tabPageAttributes";
            this.tabPageAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAttributes.Size = new System.Drawing.Size(852, 482);
            this.tabPageAttributes.TabIndex = 0;
            this.tabPageAttributes.Text = "tabPage1";
            this.tabPageAttributes.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAttributeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddAttribute, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemoveAttribute, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxAttributes, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBoxAttributeName
            // 
            this.textBoxAttributeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttributeName.Location = new System.Drawing.Point(3, 16);
            this.textBoxAttributeName.Name = "textBoxAttributeName";
            this.textBoxAttributeName.Size = new System.Drawing.Size(678, 20);
            this.textBoxAttributeName.TabIndex = 1;
            // 
            // buttonAddAttribute
            // 
            this.buttonAddAttribute.Location = new System.Drawing.Point(687, 16);
            this.buttonAddAttribute.Name = "buttonAddAttribute";
            this.buttonAddAttribute.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAttribute.TabIndex = 2;
            this.buttonAddAttribute.Text = "button1";
            this.buttonAddAttribute.UseVisualStyleBackColor = true;
            this.buttonAddAttribute.Click += new System.EventHandler(this.buttonAddAttribute_Click);
            // 
            // buttonRemoveAttribute
            // 
            this.buttonRemoveAttribute.Location = new System.Drawing.Point(768, 16);
            this.buttonRemoveAttribute.Name = "buttonRemoveAttribute";
            this.buttonRemoveAttribute.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAttribute.TabIndex = 3;
            this.buttonRemoveAttribute.Text = "button2";
            this.buttonRemoveAttribute.UseVisualStyleBackColor = true;
            this.buttonRemoveAttribute.Click += new System.EventHandler(this.buttonRemoveAttribute_Click);
            // 
            // listBoxAttributes
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxAttributes, 3);
            this.listBoxAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAttributes.FormattingEnabled = true;
            this.listBoxAttributes.ItemHeight = 25;
            this.listBoxAttributes.Location = new System.Drawing.Point(3, 45);
            this.listBoxAttributes.Name = "listBoxAttributes";
            this.listBoxAttributes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxAttributes.Size = new System.Drawing.Size(840, 428);
            this.listBoxAttributes.TabIndex = 4;
            // 
            // tabPageFunctionalDependencies
            // 
            this.tabPageFunctionalDependencies.Controls.Add(this.tableLayoutPanel2);
            this.tabPageFunctionalDependencies.Location = new System.Drawing.Point(4, 22);
            this.tabPageFunctionalDependencies.Name = "tabPageFunctionalDependencies";
            this.tabPageFunctionalDependencies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFunctionalDependencies.Size = new System.Drawing.Size(852, 482);
            this.tabPageFunctionalDependencies.TabIndex = 1;
            this.tabPageFunctionalDependencies.Text = "tabPage2";
            this.tabPageFunctionalDependencies.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.listBoxFDs, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddFD, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonRemoveFD, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.listBoxAttributesForFDs, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBoxLHS, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.listBoxRHS, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(846, 476);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listBoxFDs
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.listBoxFDs, 2);
            this.listBoxFDs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFDs.FormattingEnabled = true;
            this.listBoxFDs.ItemHeight = 25;
            this.listBoxFDs.Location = new System.Drawing.Point(682, 3);
            this.listBoxFDs.Name = "listBoxFDs";
            this.tableLayoutPanel2.SetRowSpan(this.listBoxFDs, 2);
            this.listBoxFDs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFDs.Size = new System.Drawing.Size(161, 440);
            this.listBoxFDs.TabIndex = 3;
            // 
            // buttonAddFD
            // 
            this.buttonAddFD.Location = new System.Drawing.Point(682, 449);
            this.buttonAddFD.Name = "buttonAddFD";
            this.buttonAddFD.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFD.TabIndex = 4;
            this.buttonAddFD.Text = "button1";
            this.buttonAddFD.UseVisualStyleBackColor = true;
            this.buttonAddFD.Click += new System.EventHandler(this.buttonAddFD_Click);
            // 
            // buttonRemoveFD
            // 
            this.buttonRemoveFD.Location = new System.Drawing.Point(763, 449);
            this.buttonRemoveFD.Name = "buttonRemoveFD";
            this.buttonRemoveFD.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveFD.TabIndex = 5;
            this.buttonRemoveFD.Text = "button2";
            this.buttonRemoveFD.UseVisualStyleBackColor = true;
            this.buttonRemoveFD.Click += new System.EventHandler(this.buttonRemoveFD_Click);
            // 
            // listBoxAttributesForFDs
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.listBoxAttributesForFDs, 2);
            this.listBoxAttributesForFDs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAttributesForFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAttributesForFDs.FormattingEnabled = true;
            this.listBoxAttributesForFDs.ItemHeight = 25;
            this.listBoxAttributesForFDs.Location = new System.Drawing.Point(3, 3);
            this.listBoxAttributesForFDs.Name = "listBoxAttributesForFDs";
            this.listBoxAttributesForFDs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxAttributesForFDs.Size = new System.Drawing.Size(673, 217);
            this.listBoxAttributesForFDs.TabIndex = 6;
            this.listBoxAttributesForFDs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxAttributesForFDs_MouseDown);
            // 
            // listBoxLHS
            // 
            this.listBoxLHS.AllowDrop = true;
            this.listBoxLHS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLHS.FormattingEnabled = true;
            this.listBoxLHS.ItemHeight = 25;
            this.listBoxLHS.Location = new System.Drawing.Point(3, 226);
            this.listBoxLHS.Name = "listBoxLHS";
            this.tableLayoutPanel2.SetRowSpan(this.listBoxLHS, 2);
            this.listBoxLHS.Size = new System.Drawing.Size(333, 247);
            this.listBoxLHS.TabIndex = 7;
            this.listBoxLHS.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxLHS_DragDrop);
            this.listBoxLHS.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxLHS_DragOver);
            this.listBoxLHS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxLHS_MouseDoubleClick);
            // 
            // listBoxRHS
            // 
            this.listBoxRHS.AllowDrop = true;
            this.listBoxRHS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxRHS.FormattingEnabled = true;
            this.listBoxRHS.ItemHeight = 25;
            this.listBoxRHS.Location = new System.Drawing.Point(342, 226);
            this.listBoxRHS.Name = "listBoxRHS";
            this.tableLayoutPanel2.SetRowSpan(this.listBoxRHS, 2);
            this.listBoxRHS.Size = new System.Drawing.Size(334, 247);
            this.listBoxRHS.TabIndex = 8;
            this.listBoxRHS.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxRHS_DragDrop);
            this.listBoxRHS.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxRHS_DragOver);
            this.listBoxRHS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxRHS_MouseDoubleClick);
            // 
            // tabPageSynthesis
            // 
            this.tabPageSynthesis.Location = new System.Drawing.Point(4, 22);
            this.tabPageSynthesis.Name = "tabPageSynthesis";
            this.tabPageSynthesis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSynthesis.Size = new System.Drawing.Size(852, 482);
            this.tabPageSynthesis.TabIndex = 2;
            this.tabPageSynthesis.Text = "tabPage1";
            this.tabPageSynthesis.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(796, 526);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "button3";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(715, 526);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "button4";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageAttributes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageFunctionalDependencies.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAttributes;
        private System.Windows.Forms.TabPage tabPageFunctionalDependencies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAttributeName;
        private System.Windows.Forms.Button buttonAddAttribute;
        private System.Windows.Forms.Button buttonRemoveAttribute;
        private System.Windows.Forms.ListBox listBoxAttributes;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TabPage tabPageSynthesis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox listBoxFDs;
        private System.Windows.Forms.Button buttonAddFD;
        private System.Windows.Forms.Button buttonRemoveFD;
        private System.Windows.Forms.ListBox listBoxAttributesForFDs;
        private System.Windows.Forms.ListBox listBoxLHS;
        private System.Windows.Forms.ListBox listBoxRHS;
    }
}