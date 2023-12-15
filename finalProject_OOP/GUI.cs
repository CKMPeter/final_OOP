using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace finalProject_OOP
{
    class GUI
    {
        static public int LibMenu()
        {
            Console.Write("==================================\n");
            Console.Write("||\t1. Book list\t\t||\n" +
                "||\t2. Add Book\t\t||\n" +
                "||\t3. Update Book\t\t||\n" +
                "||\t4. Delete Book\t\t||\n" +
                "||\t5. View Customer List\t||\n" +
                "||\t6. Add Customer\t\t||\n" +
                "||\t7. Remove Customer\t||\n" +
                "||\t0. Log Out\t\t||\n" +
                "");
            Console.WriteLine ("==================================\n");
            Console.Write("Select: ");
            int mode = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return mode;
        }


        static public int LogInMenu() 
        {
            Console.Write("==========================\n");
            Console.Write("||\t1. Librarian\t||\n" +
                "||\t2. Customer\t||\n" +
                "");
            Console.WriteLine("==========================\n");
            Console.Write("Select: ");
            int mode = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return mode;
        }

        static public Book InputNewBook(int num)
        {
            Console.Write("Catagory: "); string catagory = Console.ReadLine();
            Console.Write("Title: "); string title = Console.ReadLine();
            Console.Write("Author: "); string author = Console.ReadLine();
            Console.Write("ISBN: "); string isbn = Console.ReadLine();
            Console.Write("Availability: "); int availablity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Content: "); string content = Console.ReadLine();
            Book tmp = new(catagory, title, author, isbn, availablity,num, content);
            return tmp;
        }

        static public Customer InputNewCustomer(int id)
        {
            Console.Write("Name: "); string name = Console.ReadLine();
            Customer tmp = new(name, id, null);
            return tmp;
        }
        static public void WaitAndClear()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static public int UpdateBookMenu()
        {
            Console.Write("==========================\n");
            Console.Write("||\t1. Catagory\t||\n" +
                "||\t2. Title\t||\n" +
                "||\t3. Author\t||\n" +
                "||\t4. ISBN\t\t||\n" +
                "||\t5. Availability\t||\n" +
                "||\t6. Content\t\t||\n");
            Console.WriteLine("==========================\n");
            Console.Write("Select: ");
            int mode = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return mode;
        }

        static public int CusMenu()
        {
            Console.Write("==========================================\n");
            Console.Write("||\t1. List of Borrowed Books\t||\n" +
                "||\t2. Borrow\t\t\t||\n" +
                "||\t3. Return\t\t\t||\n" +
                "||\t0. Log Out\t\t\t||\n");
            Console.WriteLine("==========================================\n");
            Console.Write("Select: ");
            int mode = Convert.ToInt32(Console.ReadLine());
            return mode;
        }

        static public int BookConfirmation()
        {
            Console.Write("==================================\n");
            Console.Write("||\t1. Continue Chosing\t||\n" +
                "||\t0. Done\t\t\t||\n");
            Console.WriteLine("==================================\n");
            Console.Write("Select: ");
            int mode = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return mode;
        }

        static public int BookMode()
        {
            Console.Write ("==========================\n");
            Console.Write("||\t1. View All\t||\n" +
                "||\t2. Search\t||\n" +
                "||\t0. Exit\t\t||\n");
            Console.WriteLine("==========================\n");
            int mode = Convert.ToInt32(Console.ReadLine());
            return mode;
        }

        static public int BookModeVia()
        {
            Console.Write("==========================\n");
            Console.Write("||\t1. Title\t||\n" +
                "||\t2. Catagory\t||\n" +
                "||\t0. Exit\t\t||\n");
            Console.WriteLine("==========================\n");
            int mode = Convert.ToInt32(Console.ReadLine());
            return mode;
        }

        static public string BookSearch()
        {
            Console.Write("==================================\n");
            Console.Write("Search: "); string select = Console.ReadLine();
            return select.Trim().ToLower();
        }
    }
}
