namespace WindowsFormsApp1.Models
{
    public class StudentVm
    {
        public string LastName;
        public MarksVm Marks = new MarksVm();

        public MarksVm marks
        {
            get; set;
           
        }

        public StudentVm(string lastName, MarksVm marks)
        {
            this.LastName = lastName;
            Marks = marks;
        }
        public StudentVm(StudentVm copyStudent, MarksVm copyMarks)
        {
            LastName = copyStudent.lastName;
            Marks = copyMarks;
        }

        public StudentVm() { }
        public const string FilePath = "H:/віжуалка/WindowsFormsApp1/WindowsFormsApp1/info.txt ";

        public string lastName
        {
            get; set;
            
        }


        public void ToFile()
        {
            using (System.IO.StreamWriter StreamStudent = new System.IO.StreamWriter(FilePath, true))
            {
                StreamStudent.WriteLine(LastName + " " + Marks.Eng + " " + Marks._OOPR + " " + Marks._TIMS + " " + Marks._MS + " " + Marks._DB);
            }

        }
    }
}
