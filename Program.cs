using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BST\n");
            Console.WriteLine("The Current Boxes in Inventory are: \n");

            Manager Mng = new Manager();

            Mng.Supply(4, 5, 24);
            Mng.Supply(4, 5, 45);
            Mng.Supply(4, 9, 34);
            Mng.Supply(22, 6, 8);
            Mng.Supply(22, 9, 2);
            Mng.Supply(22, 6, 12);

            Mng.storage.InOrder();

            //foreach (DataX i in res)
            //{
            //    Console.Write($" {i}, {i.SubTree.Root}, {i.SubTree.Root.Data.Count}\n");
            //    Console.Write($" {i}, {i.SubTree.Root.Right}, {i.SubTree.Root.Right.Data.Count}\n");
            //}
        }
    }
}
