using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace finalProject_OOP
{
    public class Book
    {
        string Category { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string ISBN { get; set; }
        int Availability { get; set; }
        string Content { get; set; }

        int ID { get; set; }

        public string catagory
        {
            get { return Category; }
            set { Category = value; }
        }

        public int availability
        {
            get { return Availability; }
            set { Availability = value; }
        }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }
        //public string category {  get { return Category; } set { Category = value;} }

        // Constructor that accepts a List<string> parameter
        public Book(List<string> info, int num)
        {
            if (info.Count != 0)

            {
                this.Category = info[0];
                this.Title = info[1];
                this.Author = info[2];
                this.ISBN = info[3];
                this.Availability = Convert.ToInt32(info[4]);
                this.Content = info[5];
                this.ID = num;
            }
            // Handle the case where info doesn't have enough elements.
        }

        public Book(string catagory, string title, string author, string isbn, int availability, int num, string content)
        {
            this.Category = catagory;
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.availability = availability;
            this.id = num;
            this.Content = content;
        }

        public void PrintBookInfo()
        {
            Console.WriteLine($"Catagory: {Category}\n" +
                    $"Title: {Title}\n" +
                    $"Author: {Author}\n" +
                    $"ISBN: {ISBN}\n" +
                    $"Availability: {Availability}\n" +
                    $"Content: {Content}\n" +
                    $"ID: {ID}\n");
        }

        public string UpdateBookCSV()
        {
            string tmp;
            return tmp = $"{this.Category.Trim()},{this.Title.Trim()},{this.Author.Trim()},{this.ISBN.Trim()},{this.Availability},{this.Content.Trim()},";
        }

        public void UpdateBookInfo()
        {
            int mode;
            switch (mode = GUI.UpdateBookMenu())
            {
                case 1:
                    Console.Write("Catagory: ");
                    this.Category = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Title: ");
                    this.Title = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Author: ");
                    this.Author = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("ISBN: ");
                    this.ISBN = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Availability: ");
                    this.Availability = Convert.ToInt32(Console.ReadLine());
                    break;
                case 6:
                    Console.Write("Content: ");
                    this.Content = Console.ReadLine();
                    break;
                default:
                    break;
            }
            Console.Clear();
        }

        public void BookFHistory(string path, string name, string action)
        {
            string history = $"Info: {name}, Title: {title}, Action: {action}";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(history);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

