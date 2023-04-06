namespace WindowsFormsApp1.Models
{
    public class MarksVm
    {
        public short DB { get; set; }
        public short MS { get; set; }
        public short TIMS { get; set; }
        public short OOPR { get; set; }
        public short English { get; set; }

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
    }
}
