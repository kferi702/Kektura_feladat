namespace kektura
{
    public class Szakaszok
    {
        public string indul{get;set;}
        public string vege { get; set; }
        public int hossz { get; set; }
        public int emel { get; set; }
        public int lejt { get; set; }
        public string pecset { get; set; }

        public Szakaszok(string ind, string veg, string hossz, string emel, string lejt, string pecset)
        {
            this.indul = ind;
            this.vege = veg;
            char[] c = {','};
            this.hossz = int.Parse(hossz.Remove(1,1));
            this.emel = int.Parse(emel);
            this.lejt = int.Parse(lejt);
            this.pecset = pecset;
        }
        public override string ToString()
        {
            return indul +";"+vege+";"+hossz+";"+emel+";"+lejt+";"+pecset;
        }
    }
}