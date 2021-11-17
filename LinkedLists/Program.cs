using System;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList(new int[] { 0, 1, 2, 3, 5 });
            linkedList.AddByIndex(4, 4);
            linkedList.WriteToConsole();

            linkedList.AddByIndex(6, 6);
            linkedList.WriteToConsole();

            Console.WriteLine(linkedList.GetLength());

        }
    }
}
