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
            attributes.Add(new Attribute(textBoxAttributeName.Text));
            textBoxAttributeName.ResetText();
        }

        private void buttonRemoveAttribute_Click(object sender, EventArgs e) {
            if (fds.Count > 0) {
                MessageBox.Show("You can't remove attributes when you have FDs.");
                return;
            }
            // TODO
        }

        #endregion

        #region FDs

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

        private void buttonRemoveFD_Click(object sender, EventArgs e) {
            // TODO
        }

        #endregion
    }
}
