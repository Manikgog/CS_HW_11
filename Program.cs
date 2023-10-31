using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_1();
        }

        public static void Task_1()
        {
            /*
             Требуется написать C#-код, используя LINQ и XML, для выполнения следующих задач:

            Вывести все названия книг, отсортированные по названию в алфавитном порядке.
            Посчитать количество книг каждого жанра.
            Получить список авторов, у которых есть книги с годом издания до 1900
            Получить список авторов у которых не менее 2х книг в списке
            Посчитать количество книг в названиях которых больше одного слова и получить данные об этих книгах
            Получить имена авторов и книг, которые были написаны между 1940 и 2000 годами.
             */
            string file_path = "C:\\Users\\Maksim\\source\\repos\\CS_HW_11\\books.xml";
            XDocument xdoc = XDocument.Load(file_path);
            XElement library = xdoc.Element("Library");
            List<Book> bookList = new List<Book>();
            
            if (library != null )
            {
                
                foreach ( XElement element in library.Elements("book"))
                {
                    
                    string title = element.Element("title")?.Value;
                    string author = element.Element("author")?.Value;
                    string year = element.Element("year")?.Value;
                    string genre = element.Element("genre")?.Value;

                    Book book = new Book(title, author, year, genre);
                    bookList.Add(book);
                    
                }
                
            }

            

            var listOfbook = bookList.OrderBy(t => t.Title);
            SortedSet<string> genres = new SortedSet<string>();
            
            foreach (Book book in listOfbook)
            {
                Console.WriteLine(book.ToString());
                genres.Add(book.Genre);
            }
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("Количество книг по жанрам:");
            foreach(string genre in genres)
            {
                Console.WriteLine("Количество книг в жанре " + genre + " равно " +
                    (from i in listOfbook where i.Genre == genre select i).Count());
            }
            Console.WriteLine("********************************************************************************************");
            var oldAuthors = from b in bookList where b.Year < 1900 select b;
            Console.WriteLine("Список авторов с годом издания книг до 1900:");
            foreach (var author in oldAuthors)
            {
                Console.WriteLine(author.Author);
            }

            Console.WriteLine("********************************************************************************************");
            var twoBooksAuthors = from b in bookList group b by b.Author into res where res.Count() >= 2 select res;
            Console.WriteLine("Список авторов у которых не менее 2-х книг:");
            foreach (var author in twoBooksAuthors)
            {
                Console.WriteLine(author.First().Author);
            }

            Console.WriteLine("********************************************************************************************");
            var longTitle = from b in bookList where b.Title.Contains(" ") select b;
            Console.WriteLine("Количество книг с названиями, состоящими более чем из одного слова:" + longTitle.Count() + ", список этих книг:");
            foreach(var author in longTitle)
            {
                Console.WriteLine(author);
            }
            Console.WriteLine("********************************************************************************************");
            var newAuthors = from b in bookList where (b.Year > 1940 && b.Year < 2000)  select b;
            Console.WriteLine("Список авторов с годом издания книг между 1940 и 2000 годами:");
            foreach (var author in newAuthors)
            {
                Console.WriteLine(author.Author + " " + author.Year);
            }
        }

       
    }
}
