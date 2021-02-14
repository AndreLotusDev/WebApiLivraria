using System;
using System.Collections.Generic;

namespace ModelsShared.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public List<string> Categories{ get; set; }
        public int Pages { get; set; }
        public Int16 Year { get; set; }
        public string FileUrl { get; set; }
        public string ImageUrl { get; set; }

        //Loggins -> Quem postou (Futuramente)
    }
}
