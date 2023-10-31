using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_11
{
    internal class Book
    {
        public string Title {  get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, string year, string genre) {
            this.Title = title;
            this.Author = author;
            if (int.TryParse(year, out var y)) { this.Year = y; } else { this.Year = 0; }
            this.Genre = genre;
        }

        public override string ToString()
        {
            return "Название криги: " + this.Title + ", Автор: " + this.Author + ", Год издания: " 
                + Year + ", Жанр: " + this.Genre;
        }

    }
}
