using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Students;

namespace Students
{
    public class Student_reg
    {
        //properties or attributes
        public int id;
        public string first_name;
        public string last_name;
        public int age;
        public string gender;
        public string address;
        //constructor
        public Student_reg() {
            this.id = 0;
            this.first_name = "";
            this.last_name = "";
            this.age = 0;
            this.gender = "";
            this.address = "";
        }

        //save method
        public void Save() {
            string sql = "";
            sql = "Insert into registered_students Values ('null','" + this.first_name + "','" + this.last_name +
                   "'," + this.age + ",'" + this.gender + "','" + this.address + "')";
            try {
            Db.d.ExecuteNonReader(sql);
            }
            catch(Exception e){
                throw e;
            }
        }

        public void LoadStudents(ListView lsv) {
            lsv.Items.Clear();
            string sql = "SELECT * FROM registered_students;";
            Db.d.Execute(sql);
            if(Db.d.reader.HasRows){
                while(Db.d.reader.Read()){
                    int i = lsv.Items.Count;
                    lsv.Items.Add(Db.d.reader["id"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["first_name"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["last_name"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["age"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["gender"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["address"].ToString());
                }
            }
            Db.d.reader.Close();
        }

        public void LoadStudent(int id) {
            string sql = "SELECT * FROM `students`.`registered_students` "+
                         "WHERE id="+id+";";
            try
            {
                Db.d.Execute(sql);
                if (Db.d.reader.HasRows)
                {
                    Db.d.reader.Read();
                    this.id = Convert.ToInt32(Db.d.reader["id"].ToString());
                    this.first_name = Db.d.reader["first_name"].ToString();
                    this.last_name = Db.d.reader["last_name"].ToString();
                    this.age = Convert.ToInt32(Db.d.reader["age"].ToString());
                    this.gender = Db.d.reader["gender"].ToString();
                    this.address = Db.d.reader["address"].ToString();
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally{
                Db.d.reader.Close();
            }
        }

        public void UpdateStudent() {
            string sql = "UPDATE `students`.`registered_students` "+
                         "SET first_name='"+this.first_name+"', "+
                         "last_name='"+this.last_name+"', "+
                         "age="+this.age+", "+
                         "gender='"+this.gender+"', "+
                         "address='"+this.address+"' "+
                         "WHERE id="+this.id+";";
            Db.d.ExecuteNonReader(sql);
        }

        public void DeleteStudent() {
            string sql = "DELETE FROM registered_students "+
                         "WHERE id="+this.id+";";
            Db.d.ExecuteNonReader(sql);
        }

        public void SearchStudent(string keyword, ListView lsv) {
            lsv.Items.Clear();
            string sql = "SELECT * FROM `students`.`registered_students` "+
                         "where first_name like '"+keyword+"%' OR "+
                         "last_name like '" + keyword + "%' OR "+
                         "address like '" + keyword + "%';";
            Db.d.Execute(sql);

            if (Db.d.reader.HasRows)
            {
                while (Db.d.reader.Read())
                {
                    int i = lsv.Items.Count;
                    lsv.Items.Add(Db.d.reader["id"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["first_name"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["last_name"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["age"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["gender"].ToString());
                    lsv.Items[i].SubItems.Add(Db.d.reader["address"].ToString());
                }
            }
            Db.d.reader.Close();
        }
    }
}
