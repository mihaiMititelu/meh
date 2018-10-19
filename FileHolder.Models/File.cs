using System;

namespace FileHolder.Models
{
    public class File
    {
        protected File(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
            LastModified = DateTime.Now;
        }

        protected File()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public DateTime LastModified { get; set; }

        public string Extension { get; set; }
    }
}