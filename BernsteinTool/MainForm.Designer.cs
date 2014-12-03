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
            this.tabPageFunctionalDependencies = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAttributeName = new System.Windows.Forms.TextBox();
            this.buttonAddAttribute = new System.Windows.Forms.Button();
            this.buttonRemoveAttribute = new System.Windows.Forms.Button();
            this.listBoxAttributes = new System.Windows.Forms.ListBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.tabPageSynthesis = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewAttributesForFD = new System.Windows.Forms.ListView();
            this.listViewLHS = new System.Windows.Forms.ListView();
            this.listViewRHS = new System.Windows.Forms.ListView();
            this.listBoxFD = new System.Windows.Forms.ListBox();
            this.buttonAddFD = new System.Windows.Forms.Button();
            this.buttonRemoveFD = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageAttributes.SuspendLayout();
            this.tabPageFunctionalDependencies.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            // 
            // buttonRemoveAttribute
            // 
            this.buttonRemoveAttribute.Location = new System.Drawing.Point(768, 16);
            this.buttonRemoveAttribute.Name = "buttonRemoveAttribute";
            this.buttonRemoveAttribute.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAttribute.TabIndex = 3;
            this.buttonRemoveAttribute.Text = "button2";
            this.buttonRemoveAttribute.UseVisualStyleBackColor = true;
            // 
            // listBoxAttributes
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxAttributes, 3);
            this.listBoxAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAttributes.FormattingEnabled = true;
            this.listBoxAttributes.Location = new System.Drawing.Point(3, 45);
            this.listBoxAttributes.Name = "listBoxAttributes";
            this.listBoxAttributes.Size = new System.Drawing.Size(840, 428);
            this.listBoxAttributes.TabIndex = 4;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.listViewAttributesForFD, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listViewLHS, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.listViewRHS, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.listBoxFD, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddFD, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonRemoveFD, 3, 2);
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
            // listViewAttributesForFD
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.listViewAttributesForFD, 2);
            this.listViewAttributesForFD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAttributesForFD.Location = new System.Drawing.Point(3, 3);
            this.listViewAttributesForFD.Name = "listViewAttributesForFD";
            this.listViewAttributesForFD.Size = new System.Drawing.Size(677, 217);
            this.listViewAttributesForFD.TabIndex = 0;
            this.listViewAttributesForFD.UseCompatibleStateImageBehavior = false;
            // 
            // listViewLHS
            // 
            this.listViewLHS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLHS.Location = new System.Drawing.Point(3, 226);
            this.listViewLHS.Name = "listViewLHS";
            this.tableLayoutPanel2.SetRowSpan(this.listViewLHS, 2);
            this.listViewLHS.Size = new System.Drawing.Size(335, 247);
            this.listViewLHS.TabIndex = 1;
            this.listViewLHS.UseCompatibleStateImageBehavior = false;
            // 
            // listViewRHS
            // 
            this.listViewRHS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRHS.Location = new System.Drawing.Point(344, 226);
            this.listViewRHS.Name = "listViewRHS";
            this.tableLayoutPanel2.SetRowSpan(this.listViewRHS, 2);
            this.listViewRHS.Size = new System.Drawing.Size(336, 247);
            this.listViewRHS.TabIndex = 2;
            this.listViewRHS.UseCompatibleStateImageBehavior = false;
            // 
            // listBoxFD
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.listBoxFD, 2);
            this.listBoxFD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFD.FormattingEnabled = true;
            this.listBoxFD.Location = new System.Drawing.Point(686, 3);
            this.listBoxFD.Name = "listBoxFD";
            this.tableLayoutPanel2.SetRowSpan(this.listBoxFD, 2);
            this.listBoxFD.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFD.Size = new System.Drawing.Size(157, 440);
            this.listBoxFD.TabIndex = 3;
            // 
            // buttonAddFD
            // 
            this.buttonAddFD.Location = new System.Drawing.Point(686, 449);
            this.buttonAddFD.Name = "buttonAddFD";
            this.buttonAddFD.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFD.TabIndex = 4;
            this.buttonAddFD.Text = "button1";
            this.buttonAddFD.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveFD
            // 
            this.buttonRemoveFD.Location = new System.Drawing.Point(767, 449);
            this.buttonRemoveFD.Name = "buttonRemoveFD";
            this.buttonRemoveFD.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveFD.TabIndex = 5;
            this.buttonRemoveFD.Text = "button2";
            this.buttonRemoveFD.UseVisualStyleBackColor = true;
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
            this.tabPageFunctionalDependencies.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.ListView listViewAttributesForFD;
        private System.Windows.Forms.ListView listViewLHS;
        private System.Windows.Forms.ListView listViewRHS;
        private System.Windows.Forms.ListBox listBoxFD;
        private System.Windows.Forms.Button buttonAddFD;
        private System.Windows.Forms.Button buttonRemoveFD;
    }
}