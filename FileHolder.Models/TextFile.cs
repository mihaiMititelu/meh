namespace FileHolder.Models
{
    public class TextFile : File
    {
        public TextFile(string name) : base(name)
        {
            Extension = ".txt";
        }
    }
}
