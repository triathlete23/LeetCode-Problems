using System;
using System.Threading.Tasks;
using static System.Console;

namespace TestTemplateConsoleApp
{
    internal class Program
    {
        private static async Task Task1()
        {
            await Task.Delay(millisecondsDelay: 1000);
            WriteLine("A");
        }

        private static async Task Task2()
        {
            await Task.Delay(millisecondsDelay: 1000);
            WriteLine("B");
        }

        private static async Task Task3()
        {
            await Task.Delay(millisecondsDelay: 1000);
            WriteLine("C");
        }

        private static async void SomeMethod()
        {
            var task1 = Task1();
            var task2 = Task2();
            var task3 = Task3();

            await task1;
            await task2;
            await task3;
        }

        public static void Main(string[] args)
        {
            SomeMethod();

            Console.ReadKey();
        }
    }
}
