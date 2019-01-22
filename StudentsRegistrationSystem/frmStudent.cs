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
    public partial class frmStudent : Form
    {
        public ListOfStudents ls = new ListOfStudents();
        public int received_selected_id;
        Student_reg sr = new Student_reg();

        public frmStudent()
        {
            InitializeComponent();
            this.received_selected_id = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Text == "Update")
            {

                sr.first_name = txtFirstName.Text;
                sr.last_name = txtLastName.Text;
                sr.age = Convert.ToInt32(txtAge.Text);
                sr.gender = cboGender.Text;
                sr.address = txtAddress.Text;
                sr.UpdateStudent();
            }
            else {
                sr.first_name = txtFirstName.Text;
                sr.last_name = txtLastName.Text;
                sr.age = Convert.ToInt32(txtAge.Text);
                sr.gender = cboGender.Text;
                sr.address = txtAddress.Text;
                sr.Save();
            }
            sr.LoadStudents(ls.lsvStudList);
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            if(this.received_selected_id!=0){
                sr.LoadStudent(this.received_selected_id);
                this.txtFirstName.Text = sr.first_name;
                this.txtLastName.Text = sr.last_name;
                this.txtAge.Text = sr.age.ToString();
                this.cboGender.Text = sr.gender;
                this.txtAddress.Text = sr.address;
                this.btnSave.Text = "Update";
            }
        }
    }
}
