using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                if (rd.Next(1) == 0)
                {
                    Console.WriteLine("用着");
                }
            }


            MyVector my = new MyVector(new [] {"a","b","c","d"});
            var Enum = my.GetEnumerator();
            while (Enum.MoveNext())
            {
                Console.WriteLine(Enum.Current as string);
            }

            Console.WriteLine("-----------------------------------------------");
            foreach (var item in my)
            {
                Console.WriteLine(item as string);
            }
        }
    }
}
