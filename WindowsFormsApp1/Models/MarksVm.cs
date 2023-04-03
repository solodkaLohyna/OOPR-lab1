namespace WindowsFormsApp1.Models
{
    public class MarksVm
    {
        public short DB;
        public short MS;
        public short TIMS;
        public short OOPR;
        public short English;

        public MarksVm(short English,
                       short OOPR,
                       short TIMS,
                       short MS,
                       short DB)
        {
            this.English = English;
            this.OOPR = OOPR;
            this.TIMS = TIMS;
            this.MS = MS;
            this.DB = DB;

        }
        public MarksVm() { }

        public const string FilePath = "H:/віжуалка/WindowsFormsApp1/WindowsFormsApp1/info.txt ";

        public short Eng
        {
            get;
            set;
        }
        public short _OOPR
        {
            get;
            set;
        }
        public short _TIMS
        {
            get;
            set;
        }
        public short _MS
        {
            get;
            set;
        }
        public short _DB
        {
            get;
            set;
        }

        public void ToFile()
        {
            using (System.IO.StreamWriter StreamMarks = new System.IO.StreamWriter(FilePath, true))
            {
                StreamMarks.Write(English + " " + OOPR + " " + TIMS + " " + MS + " " + DB + "\t" + "\n");
            }
        }
    }
}
