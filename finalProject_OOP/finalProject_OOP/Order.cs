using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace finalProject_OOP
{
    class Order
    {
        
        List<Book> books = new List<Book>();
        
        //constructor.
        public Order(string path, List<Book> books)
        {
            this.books = books;
            foreach(Book book in this.books)
            {
                if (book.availability > 0)
                {
                    book.availability--;
                }
                Librarian.UpdateCSV(path, book, book.id + 1);
            }
        }
        public Order() { }

        //function.
        public void ReturnOrder(string path)
        {
            foreach(Book book_ in books)
            {
                book_.availability++;
                Librarian.UpdateCSV(path, book_, book_.id + 1);
            }
        }

        public void Print()
        {
            for(int i = 0; i<books.Count; i++)
            {
                books[i].PrintBookInfo();
            }
        }

        public void fHistory(string path, string name, string action)
        {
            foreach(Book s in books)
            {
                s.BookFHistory(path, name, action);
            }
        }

        public void addOder(string path, string name, List<Book> books) //add order for customer
        {
            foreach(Book book in books)
            {
                if (book.title == name)
                {
                    this.books.Add(book);
                    book.availability--;
                    Librarian.UpdateCSV(path, book, book.id + 1);
                }
            }
        }

        public string OrderCsv()
        {
            string tmp = "";
            if (this.books.Count > 0)
            {
                foreach (Book book in this.books)
                {
                    tmp += $"{book.title},";
                }
            }
            return tmp;
        }
    }
}
