using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetScreenlock
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string screenlockFa = null;
            Console.WriteLine("###Author Co1In");
            Console.WriteLine(@"###File Path: C:\Background");
            Console.WriteLine(@"###User: {0}", System.Environment.UserName);
            DirectoryInfo screenlockRoot = new DirectoryInfo(@"C:\Users\" + System.Environment.UserName + @"\AppData\Local\Packages");
            foreach (DirectoryInfo item in screenlockRoot.GetDirectories())
            {
                if (item.Name.Contains("Microsoft.Windows.ContentDeliveryManager"))
                {
                    screenlockFa = item.FullName;
                }
            }

            DirectoryInfo screenlockDI = new DirectoryInfo(screenlockFa + @"\LocalState\Assets");
            foreach (FileInfo item in screenlockDI.GetFiles())
            {
                if (item.Length > 102400)
                {
                    if (!Directory.Exists(@"C:\Background"))
                    {
                        Directory.CreateDirectory(@"C:\Background");
                    }
                    try {
                        item.CopyTo(@"C:\Background\" + DateTime.Now.ToString("yyyy-MM-dd") + "-" + i + ".jpg");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Copy {0} -> C:\\Background\\", item.Name);
                    i++;
                }
            }
            Console.WriteLine("#Press any key to exit");
            Console.ReadLine();
        }
    }
}
