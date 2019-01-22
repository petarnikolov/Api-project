using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Students;

namespace StudentsRegistrationSystem
{
    public partial class ListOfStudents : Form
    {
        public ListOfStudents()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStudent fs = new frmStudent();
            fs.ls = this;
            fs.ShowDialog();
        }

        private void ListOfStudents_Load(object sender, EventArgs e)
        {
            Student_reg sr = new Student_reg();
            sr.LoadStudents(lsvStudList);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(lsvStudList.SelectedItems[0].Text);
            //MessageBox.Show(selectedId.ToString());
            frmStudent fs = new frmStudent();
            fs.received_selected_id = selectedId;
            fs.ls = this;
            fs.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(lsvStudList.SelectedItems[0].Text);
            Student_reg sr = new Student_reg();
            sr.LoadStudent(selectedId);
            sr.DeleteStudent();
            sr.LoadStudents(this.lsvStudList);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Student_reg sr = new Student_reg();
            sr.SearchStudent(txtSearch.Text, this.lsvStudList);
        }
    }
}
