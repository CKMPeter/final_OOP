using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace finalProject_OOP
{
    class Librarian
    {
        static public List<Book> readFile(string filePath, int total, bool flag)
        {
            string data = "";
            List<Book> result = new List<Book>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    data = reader.ReadLine();
                    do 
                    {
                        data = reader.ReadLine();
                        if (data != null)
                        {
                            List<string> list = AddContent(data);
                            Book tmp = new Book(list, total);
                            result.Add(tmp);
                            if (flag == true)
                                total++;
                        }
                    }while (data  != null);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        static public void WriteToCSV(string filePath, string book)
        {
            try
            {
                // Create a StreamWriter and open the file
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    // Write each line of data to the file
                    sw.Write(book + "\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static public void UpdateCSV(string filePath, Book book, int no)
        {
            string[] lines = File.ReadAllLines(filePath);
            try
            {
                // Create a StreamWriter and open the file
                lines[no] = book.UpdateBookCSV();
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Write each line of data to the file
                    foreach (string line in lines)
                        sw.WriteLine(line) ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static public void RemoveBook(string filePath, int no, List<Book> list)
        {
            string[] lines_ = File.ReadAllLines(filePath);
            if (no <= 0)
            {
                no = 1;
            }
            list.RemoveAt(no);
            for(int i = no; i <= lines_.Length; i++)
            {
                int j = i + 1;

                if (j < lines_.Length)
                {
                    lines_[i] = lines_[j];
                    if (i < list.Count)
                        list[i].id--;
                }
            }
            lines_[lines_.Length - 1] = "";
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Write each line of data to the file
                    for(int i=0; i< lines_.Length - 1; i++)
                    {
                        sw.WriteLine(lines_[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        static public List<string> AddContent(string data)
        {
            string content = "";
            List<string> bookInfo= new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                
                if (data[i] == ',')
                {
                    bookInfo.Add(content.Trim());
                    content = "";
                }else
                    content += data[i];
            }
            return bookInfo;
        }

        static public void PrintCustomer(List<Customer> list)
        {
            foreach(Customer customer in list)
            {
                customer.OutputCustomer();
            }
        }
    }
}
