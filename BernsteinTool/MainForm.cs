using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RelationLibrary;
using Attribute = RelationLibrary.Attribute;

namespace BernsteinTool {
    public partial class MainForm : Form {
        BindingList<Attribute> attributes;

        BindingList<Attribute> lhs;
        BindingList<Attribute> rhs;

        BindingList<FunctionalDependency> fds;

        public MainForm() {
            attributes = new BindingList<Attribute>();

            lhs = new BindingList<Attribute>();
            rhs = new BindingList<Attribute>();

            fds = new BindingList<FunctionalDependency>();

            InitializeComponent();
            BindData();
        }

        private void BindData() {
            listBoxAttributes.DataSource = attributes;
            listBoxAttributesForFDs.DataSource = attributes;
            listBoxLHS.DataSource = lhs;
            listBoxRHS.DataSource = rhs;
            listBoxFDs.DataSource = fds;
        }

        #region Attributes

        private void buttonAddAttribute_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(textBoxAttributeName.Text)) {
                attributes.Add(new Attribute(textBoxAttributeName.Text));
                textBoxAttributeName.ResetText();
            }
        }

        private void buttonClearAttributes_Click(object sender, EventArgs e) {
            if (fds.Count > 0) {
                MessageBox.Show("You can't remove attributes when you have FDs.");
                return;
            }
            attributes.Clear();
        }

        private void listBoxAttributes_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (fds.Count > 0) {
                MessageBox.Show("You can't remove attributes when you have FDs.");
                return;
            }
            var index = listBoxAttributes.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                attributes.RemoveAt(index);
            }
        }

        #endregion

        #region FDs

        #region Drag & drop

        private void listBoxAttributesForFDs_MouseDown(object sender, MouseEventArgs e) {
            DoDragDrop(listBoxAttributesForFDs.SelectedItems, DragDropEffects.Copy);
        }

        private void listBoxLHS_DragDrop(object sender, DragEventArgs e) {
            var u = lhs.Union(listBoxAttributesForFDs.SelectedItems.Cast<Attribute>()).ToList();
            lhs.Clear();
            foreach (var x in u) {
                lhs.Add(x);
            }
        }

        private void listBoxLHS_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBoxRHS_DragDrop(object sender, DragEventArgs e) {
            var u = rhs.Union(listBoxAttributesForFDs.SelectedItems.Cast<Attribute>()).ToList();
            rhs.Clear();
            foreach (var x in u) {
                rhs.Add(x);
            }
        }

        private void listBoxRHS_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        #endregion

        private void listBoxLHS_MouseDoubleClick(object sender, MouseEventArgs e) {
            var index = listBoxLHS.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                lhs.RemoveAt(index);
            }
        }

        private void listBoxRHS_MouseDoubleClick(object sender, MouseEventArgs e) {
            var index = listBoxRHS.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                rhs.RemoveAt(index);
            }
        }

        private void buttonAddFD_Click(object sender, EventArgs e) {
            if (lhs.Count > 0 && rhs.Count > 0) {
                foreach (var r in rhs) {
                    fds.Add(r.DependsOn(lhs));
                }
            }
            lhs.Clear();
            rhs.Clear();
        }

        private void buttonClearFDs_Click(object sender, EventArgs e) {
            fds.Clear();
        }

        private void listBoxFDs_MouseDoubleClick(object sender, MouseEventArgs e) {
            var index = listBoxFDs.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                fds.RemoveAt(index);
            }
        }

        #endregion

        #region Synthesis

        private void buttonRun_Click(object sender, EventArgs e) {
            Relation rel = new Relation(new HashSet<Attribute>(attributes), new HashSet<FunctionalDependency>(fds));

            textBoxOutput.AppendText("Step 0. Begin\n");
            textBoxOutput.AppendText(string.Format("Original relation: {0}\n", rel.ToString()));
            textBoxOutput.AppendText("\n");

            textBoxOutput.AppendText("Step 1. Eliminate extraneous attributes\n");
            rel.FDs = new HashSet<FunctionalDependency>(rel.FDs.Select(fd => rel.GetMinimalFD(fd)));
            textBoxOutput.AppendText(string.Format("Output: {0}\n", rel.ToString()));
            textBoxOutput.AppendText("\n");

            textBoxOutput.AppendText("Step 2. Find minimal covering\n");
            rel.FDs = rel.GetMinimalCovering();
            textBoxOutput.AppendText(string.Format("Output: {0}\n", rel.ToString()));
            textBoxOutput.AppendText("\n");

            textBoxOutput.AppendText("Step 4. Construct 3NF relations\n");
            textBoxOutput.AppendText("Output:\n");
            foreach (var r in rel.CreateRelations()) {
                textBoxOutput.AppendText(r.ToString());
                textBoxOutput.AppendText("\n");
            }
        }

        #endregion
    }
}
