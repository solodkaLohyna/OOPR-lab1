namespace WindowsFormsApp1.Models
{
    public class StudentVm
    {
        public string LastName { get; set; }
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
            LastName = copyStudent.LastName;
            Marks = copyMarks;
        }

        public StudentVm() { }
        public const string FilePath = "info.txt ";



        public void ToFile()
        {
            using (System.IO.StreamWriter StreamStudent = new System.IO.StreamWriter(FilePath, true))
            {
                StreamStudent.WriteLine(LastName + " " + Marks.English + " " + Marks.OOPR + " " + Marks.TIMS + " " + Marks.MS + " " + Marks.DB);
            }

        }
    }
}
