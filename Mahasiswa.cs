namespace tpmodul10_103022300014
{
    public class Mahasiswa
    {
        public string mahasiswa { get; set; }
        public string NIM { get; set; }

        public Mahasiswa(string mahasiswa, string nIM)
        {
            this.mahasiswa = mahasiswa;
            NIM = nIM;
        }
    }
}
