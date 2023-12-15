using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace finalProject_OOP
{
    class RandomFunction
    {
        static public void PrintBook(List<Book> books)
        {
            foreach (Book book in books)
                book.PrintBookInfo();
        }
        static public List<Customer> readCusInfoCSV(string path,List<Book> book)
        {
            string data = "";
            List<Customer> result = new List<Customer>();
            using (StreamReader reader = new StreamReader(path))
            {
                data = reader.ReadLine();
                do
                {
                    data = reader.ReadLine();
                    if (data != null)
                    {
                        List<string> list = AddData(data);
                        Customer tmp = AddCus(path, list, book);
                        result.Add(tmp);
                    }
                } while (data != null);
                reader.Close();
            }
            return result;
        }

        static public List<string> AddData(string data)
        {
            string content = "";
            List<string> CusInfo = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {

                if (data[i] == ',')
                {
                    CusInfo.Add(content);
                    content = "";
                }
                else
                    content += data[i];
            }
            return CusInfo;
        }

        static public Customer AddCus(string path,List<string> data, List<Book> list)
        {
            Customer tmp = new Customer();
            tmp.ID = Convert.ToInt32(data[0].Trim()); 
            tmp.Name = data[1].Trim();
            tmp.State = Convert.ToBoolean(data[2].Trim());
            if (tmp.State == true)
            {
                Order newOrder = new Order();
                for (int i = 3; i < data.Count; i++)
                {
                    newOrder.addOder(path, data[i], list);
                }
                tmp.BorrowBook(newOrder);
            }
            return tmp;
        }

        static public void AddNewCus(string path, Customer nCus)
        {
            string data = "";
            data = nCus.CusData();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(data);
            }
        }

        static public void RemoveCus(List<Customer> list, int selected)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == selected)
                {
                    for (int j = i; j < list.Count; j++)
                    {
                        int next = j + 1;
                        if (next < list.Count)
                        {
                            list[j] = list[next];
                            list[j].ID--;
                        }
                        else
                        {
                            list.RemoveAt(j);
                        }
                    }                        
                }
            }
        }

        static public void RemoveCusCSV(string path,List<Customer> list, int selected)
        {
            string[] lines_ = File.ReadAllLines(path);
            if (selected <= 0)
            {
                selected = 1;
            }
            for (int i = selected; i < lines_.Length; i++)
            {
                if(i<list.Count)
                    lines_[i] = list[i-1].CusDataToCsv(); 
            }
            lines_[lines_.Length - 1] = "";
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    // Write each line of data to the file
                    for (int i = 0; i < lines_.Length - 1; i++)
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

        static public bool ShowSeletedBook(string title, List<Book> list, int mode)
        {
            bool flag = false;
            if (mode == 0) { return flag;  }
            if (mode == 1)
            {
                foreach (Book book in list)
                {
                    if (String.findSimilarity(book.title.ToLower(), title.ToLower()) >= 0.3)
                    {
                        book.PrintBookInfo();
                        flag = true;
                    }
                }
            }else
            {
                foreach (Book book in list)
                {
                    if (String.findSimilarity(book.catagory.ToLower(), title.ToLower()) >= 0.4)
                    {
                        book.PrintBookInfo();
                        flag = true;
                    }
                }
            }
            return flag;
        }

        static public void UpdateCusToCSV(string path, List<Customer> list)
        {
            string[] lines_ = File.ReadAllLines(path);
            for(int i = 1; i < lines_.Length; i++)
            {
                if (i <= list.Count)
                    lines_[i] = list[i-1].CusDataToCsv();
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    // Write each line of data to the file
                    for (int i = 0; i < lines_.Length; i++)
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
    }
}
