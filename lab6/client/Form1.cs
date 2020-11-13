using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private List<Student> Student { get; set; }
        private List<Note> Note { get; set; }
        private ServiceReference1.WSYNSEntities wcf;
        private int studentId;
        private string studentName;
        public Form1()
        {
            wcf = new ServiceReference1.WSYNSEntities(new Uri("http://localhost:62938/Service.svc/"));
            Student = new List<Student>();
            Note = new List<Note>();
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int position = e.RowIndex;
                studentId= Student.ElementAt(position).Id;                
                richTextBox3.Text = Student.ElementAt(position).Name;              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Some error required:" + ex.Message + "-" + ex.Source +"\n"+e.RowIndex.ToString());
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student.Clear();
            //dataGridView1.Columns.Clear();
            foreach (var student in wcf.Students.OrderByDescending(n => n.Name).AsEnumerable())
            {
                Student.Add(new Student()
                {
                    Id = student.Id,
                    Name = student.Name
                });

            }
            dataGridView1.DataSource = Student.GetRange(0, Student.Count);
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student.Clear();
            //dataGridView1.Columns.Clear();
            foreach (var student in wcf.Students.OrderBy(n => n.Name).AsEnumerable())
            {
                Student.Add(new Student()
                {
                    Id = student.Id,
                    Name = student.Name
                });

            }
            dataGridView1.DataSource = Student.GetRange(0, Student.Count);
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                var student = new ServiceReference1.Student();
                student.Name = richTextBox1.Text.ToString();
                wcf.AddToStudents(student);
                wcf.SaveChanges();

            }
            else
            {
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Notes_Click(object sender, EventArgs e)
        {
            Note.Clear();
            if (richTextBox2.Text != "")
            {
                foreach (var note in wcf.Notes.Where(n => n.Subj.Equals(richTextBox2.Text)).AsEnumerable())
                {
                    Note.Add(new Note()
                    {
                        Id = note.Id,
                        StudentName = wcf.Students.Where(n => n.Id.Equals(note.StudentId)).Select(s => s.Name).First(),
                        Subj = note.Subj,
                        Notes = note.Note1,
                        StudentId = note.StudentId

                    });
                }
                dataGridView1.DataSource = Note.GetRange(0, Note.Count);
                dataGridView1.Refresh();
            }
            else
            {
                foreach (var note in wcf.Notes.AsEnumerable())
                {
                    Note.Add(new Note()
                    {
                        Id = note.Id,
                        StudentName = wcf.Students.Where(n => n.Id.Equals(note.StudentId)).Select(s => s.Name).First(),
                        Subj = note.Subj,
                        Notes = note.Note1,
                        StudentId = note.StudentId

                    });
                }
                dataGridView1.DataSource = Note.GetRange(0, Note.Count);
                dataGridView1.Refresh();
            }
        }

        private void Students_Click(object sender, EventArgs e)
        {
            Student.Clear();
            if (richTextBox1.Text != "")
            {
                foreach (var student in wcf.Students.Where(n => n.Name.Equals(richTextBox1.Text)).AsEnumerable())
                {
                    Student.Add(new Student()
                    {
                        Id = student.Id,
                        Name = student.Name
                    });
                }
                dataGridView1.DataSource = Student.GetRange(0, Student.Count);
                dataGridView1.Refresh();
            }
            else
            {
                foreach (var student in wcf.Students.AsEnumerable())
                {
                    Student.Add(new Student()
                    {
                        Id = student.Id,
                        Name = student.Name
                    });
                }
                dataGridView1.DataSource = Student.GetRange(0, Student.Count);
                dataGridView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(studentId!=0 && !richTextBox3.Text.Equals(""))
            {
                var student = wcf.Students.Where(s => s.Id == studentId).FirstOrDefault();
                student.Name = richTextBox3.Text;
                wcf.UpdateObject(student);
                wcf.SaveChanges();
                richTextBox3.Clear();
                MessageBox.Show("Succesfully update");
            }
            else
            {
                MessageBox.Show("Some error required");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (studentId != 0 )
            {
                var student = wcf.Students.Where(s => s.Id == studentId).FirstOrDefault();
                wcf.DeleteObject(student);
                wcf.SaveChanges();
                richTextBox3.Clear();
                MessageBox.Show("Succesfully delete");
            }
            else
            {
                MessageBox.Show("Some error required");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Note.Clear();
            foreach (var note in wcf.Notes.OrderByDescending(n => n.Note1).AsEnumerable())
            {
                Note.Add(new Note()
                {
                    Id = note.Id,
                    StudentName = wcf.Students.Where(n => n.Id.Equals(note.StudentId)).Select(s => s.Name).First(),
                    Subj = note.Subj,
                    Notes = note.Note1,
                    StudentId = note.StudentId
                });

            }
            dataGridView1.DataSource = Note.GetRange(0, Note.Count);
            dataGridView1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Note.Clear();
            foreach (var note in wcf.Notes.OrderBy(n => n.Note1).AsEnumerable())
            {
                Note.Add(new Note()
                {
                    Id = note.Id,
                    StudentName = wcf.Students.Where(n => n.Id.Equals(note.StudentId)).Select(s => s.Name).First(),
                    Subj = note.Subj,
                    Notes = note.Note1,
                    StudentId = note.StudentId
                });

            }
            dataGridView1.DataSource = Note.GetRange(0,Note.Count);
            dataGridView1.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
