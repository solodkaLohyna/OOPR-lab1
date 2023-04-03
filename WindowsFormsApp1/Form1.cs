using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const string FilePath = "H:/віжуалка/WindowsFormsApp1/WindowsFormsApp1/info.txt ";

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;


            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = false;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "") != true)
            {
                label8.Visible = false;

                MarksVm SomeMarks = new MarksVm(Convert.ToInt16(textBox2.Text),
                    Convert.ToInt16(textBox3.Text),
                    Convert.ToInt16(textBox4.Text),
                    Convert.ToInt16(textBox5.Text),
                    Convert.ToInt16(textBox6.Text));

                StudentVm SomeStudent = new StudentVm(textBox1.Text, SomeMarks);
                SomeStudent.ToFile();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
                label8.Visible = true;
        }

        static  bool IsNumber(string Word)
        {
            short temp;
            return short.TryParse(Word, out temp);
        }

        static string ToCheckMarks(StudentVm Students)
        {
            if (Students.marks.Eng == 4 &&
                   Students.marks._OOPR == 4 &&
                   Students.marks._TIMS == 4 &&
                   Students.marks._MS == 4 &&
                   Students.marks._DB == 4)
            {
                return Students.lastName;
            }
            else return null;
        }
        static MarksVm ArrayItemsToField(ref StudentVm stud, List<short> InputArray, ref int i)
        {
            i = 0;
            return new MarksVm(InputArray[0], InputArray[1]
                 , InputArray[2], InputArray[3], InputArray[4]);
        }

        void FromFile(ref List<StudentVm> studs)
        {
            using (StreamReader StreamStudent = new StreamReader(FilePath))
            {
                StudentVm TempStudent = new StudentVm();
                string line;
                int i = 0;
                List<short> Marks = new List<short>();
                while ((line = StreamStudent.ReadLine()) != null)
                {
                    string[] temp = line.Split(' ');
                    foreach (string word in temp)
                    {
                        if (IsNumber(word) == true)
                        {
                            Marks.Add(Convert.ToInt16(word));
                            i++;
                            if (i == 5)
                            {

                                studs.Add(new StudentVm(TempStudent, ArrayItemsToField(ref TempStudent, Marks, ref i)));
                                Marks.Clear();
                            }
                        }
                        else
                        {
                            TempStudent.lastName = word;
                        }

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;


            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            richTextBox1.Visible = true;

            List<StudentVm> Students = new List<StudentVm>();
            FromFile(ref Students);

            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine(Students[i].lastName + " " +
                    "english: " + Students[i].marks.Eng +
                " OOPR: " + Students[i].marks._OOPR +
                    " TIMS: " + Students[i].marks._TIMS +
                    " MS: " + Students[i].marks._MS +
                    " DB: " + Students[i].marks._DB);

            }
            for (int i = 0; i < Students.Count; i++)
            {
                if(ToCheckMarks(Students[i]) !=null) { 
                    richTextBox1.AppendText( ToCheckMarks(Students[i])+"\n");
                }
            }
       
        }

    }
}
