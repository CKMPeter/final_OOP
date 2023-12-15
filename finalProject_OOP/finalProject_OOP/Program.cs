using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;

namespace finalProject_OOP
{
    class Program
    {
        static public void Main(string[] args)
        {
            int login = 0;
            int mode = 0;
            int total = 0;
            bool run = true;
            int selectID = -1;
            int totalCus = 0;

            string path = @"D:\oop code\finalProject_OOP\csv file\book_info.csv";
            string path1 = @"D:\oop code\finalProject_OOP\customers\borrower_info.csv";
            string path2 = @"D:\oop code\finalProject_OOP\history\history.txt";
            //constructor.
            //Functions.WriteToCSV(path, content);

            List<Book> books = new List<Book>();
            List<Customer> CusList = new List<Customer>();
            books = Librarian.readFile(path, total++, true);
            total = books.Count;
            CusList = RandomFunction.readCusInfoCSV(path1, books);
            totalCus = CusList.Count;
            totalCus += 1;


            //hardcode for testing==========================
            //Book tmp = new("test", "test", "Minh", "2b3",1, books.Count);

            //books.Add(tmp);
            //Order newOrder = new(books);
            //Customer Minh = new("Minh", 1, null);
            //CusList.Add(Minh);
            //Librarian.WriteToCSV(path, tmp.UpdatBook());
            //==============================================
            login = GUI.LogInMenu();
            
            while (run)
            {
                switch (login)
                {
                    case 1:
                        switch (mode = GUI.LibMenu())
                        {
                            case 1: //Book list
                                RandomFunction.PrintBook(books);
                                GUI.WaitAndClear();
                                break;
                            case 2:
                                Book new1 = GUI.InputNewBook(total++);
                                books.Add(new1);
                                Librarian.WriteToCSV(path, new1.UpdateBookCSV());
                                break;
                            case 3:
                                RandomFunction.PrintBook(books);
                                Console.WriteLine("Select id: "); int select = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (select < books.Count)
                                {
                                    books[select].UpdateBookInfo();
                                    Librarian.UpdateCSV(path, books[select], select + 1);
                                }
                                break;
                            case 4:
                                RandomFunction.PrintBook(books);
                                Console.WriteLine("Select id: "); int select_ = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (select_ <= total)
                                    Librarian.RemoveBook(path, select_, books);
                                break;
                            case 5:
                                Librarian.PrintCustomer(CusList);
                                GUI.WaitAndClear();
                                break;
                            case 6:
                                totalCus++;
                                Customer NewCus = GUI.InputNewCustomer(totalCus);
                                CusList.Add(NewCus);
                                RandomFunction.AddNewCus(path1, NewCus);
                                GUI.WaitAndClear();
                                break;
                            case 7:
                                Librarian.PrintCustomer(CusList);
                                Console.WriteLine("Select: "); int select__ = Convert.ToInt32(Console.ReadLine());
                                totalCus--;
                                RandomFunction.RemoveCus(CusList, select__);
                                RandomFunction.RemoveCusCSV(path1,CusList, select__);
                                Console.Clear();
                                break;
                            default:
                                login = -1;
                                login = GUI.LogInMenu();
                                break;
                        }
                        mode = -1;
                        break;
                    case 2:
                        if (selectID == -1)
                        {
                            Librarian.PrintCustomer(CusList);
                            Console.WriteLine("Select id: ");
                            try
                            {
                                selectID = Convert.ToInt32(Console.ReadLine());
                            }catch(Exception)
                            {
                                Console.Clear() ;
                                login = -1;
                                login = GUI.LogInMenu();
                                break;
                            }
                            Console.Clear();
                            if (selectID <= 0) 
                            {
                                Console.Clear();
                                login = -1;
                                login = GUI.LogInMenu();
                                break;
                            }
                        }
                        switch (mode = GUI.CusMenu())
                        {
                            case 1:
                                CusList[selectID - 1].PrintOrderInfo();
                                GUI.WaitAndClear();
                                break;
                            case 2:
                                int chosing = 1;
                                int selectBook = -1;
                                bool flag = false;
                                List<Book> books1 = new List<Book>();
                                if (CusList[selectID - 1].StateReturn() == false)
                                {
                                    switch (GUI.BookMode()) {
                                        case 1:
                                            RandomFunction.PrintBook(books);
                                            chosing = 1;
                                            Console.WriteLine("Select id: ");
                                            selectBook = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            break;
                                        case 2:
                                            int method;
                                            string searchTitle;
                                            switch (method = GUI.BookModeVia())
                                            {
                                                case 1:
                                                    searchTitle = GUI.BookSearch();
                                                    flag = RandomFunction.ShowSeletedBook(searchTitle, books, method);
                                                    if (method != 0 && flag)
                                                    {
                                                        chosing = 1;
                                                        Console.WriteLine("Select id: ");
                                                        selectBook = Convert.ToInt32(Console.ReadLine());
                                                    }
                                                    else chosing = -1;
                                                    break;
                                                case 2:
                                                    searchTitle = GUI.BookSearch();
                                                    flag = RandomFunction.ShowSeletedBook(searchTitle, books, method);
                                                    if (method != 0 && flag)
                                                    {
                                                        chosing = 1;
                                                        Console.WriteLine("Select id: ");
                                                        selectBook = Convert.ToInt32(Console.ReadLine());
                                                    }else chosing = -1;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            Console.Clear();
                                            break;
                                        default:
                                            break;
                                    }
                                    if (selectBook >= 0)
                                        books1.Add(books[selectBook]);
                                    else
                                        Console.WriteLine("You haven't selected any book yet!");
                                    while (chosing == 1)
                                    {
                                        switch (chosing = GUI.BookConfirmation())
                                        {
                                            case 0:
                                                chosing = 0;
                                                break;
                                            case 1:
                                                switch (GUI.BookMode())
                                                {
                                                    case 1:
                                                        RandomFunction.PrintBook(books);
                                                        chosing = 1;
                                                        Console.WriteLine("Select id: ");
                                                        selectBook = Convert.ToInt32(Console.ReadLine());
                                                        books1.Add(books[selectBook]);
                                                        Console.Clear();
                                                        break;
                                                    case 2:
                                                        int method;
                                                        string searchTitle;
                                                        switch (method = GUI.BookModeVia())
                                                        {
                                                            case 1:
                                                                searchTitle = GUI.BookSearch();
                                                                RandomFunction.ShowSeletedBook(searchTitle, books, method);
                                                                chosing = 1;
                                                                Console.WriteLine("Select id: ");
                                                                selectBook = Convert.ToInt32(Console.ReadLine());
                                                                break;
                                                            case 2:
                                                                searchTitle = GUI.BookSearch();
                                                                RandomFunction.ShowSeletedBook(searchTitle, books, method);
                                                                chosing = 1;
                                                                Console.WriteLine("Select id: ");
                                                                selectBook = Convert.ToInt32(Console.ReadLine());
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        books1.Add(books[selectBook]);
                                                        Console.Clear();
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    if (books1.Count != 0)
                                    {
                                        Order tmpOrder = new(path, books1);
                                        CusList[selectID - 1].BorrowBook(tmpOrder);
                                        CusList[selectID - 1].HistoryToFile(path2, "Borrow");
                                        RandomFunction.UpdateCusToCSV(path1, CusList);
                                    }
                                    GUI.WaitAndClear();
                                }
                                else
                                {
                                    Console.WriteLine("You already Borrowed some books!");
                                }
                                break;
                            case 3:
                                CusList[selectID - 1].HistoryToFile(path2, "Return");
                                if (CusList[selectID - 1].StateReturn() != false)
                                {
                                    CusList[selectID - 1].ReturntOrders(path);
                                    Console.WriteLine("Return Successfully!");
                                }
                                RandomFunction.UpdateCusToCSV(path1, CusList);
                                GUI.WaitAndClear();
                                break;
                            default:
                                selectID = -1;
                                break;
                        }
                        break;
                    default:
                        run = false;
                        break;
                }
            }
        }
        
    }
}