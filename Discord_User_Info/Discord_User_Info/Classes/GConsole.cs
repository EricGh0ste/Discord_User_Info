using System;

namespace Discord_User_Info.Classes
{
    class GConsole
    {
        public static void clear()
        {
            Console.Clear();
        }

        public static void get_key()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static void print(string content)
        {
            Console.Write(content.ToString());
        }

        public static void print_ok(string content)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {content.ToString()}");
        }

        public static void print_err(string content)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {content.ToString()}");
        }

        public static void print_success(string content)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {content.ToString()}");
        }

        public static void print_opt(string prefix, string content)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prefix);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"] {content.ToString()}");
        }

        public static string get_input()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("--> ");
            Console.ForegroundColor = ConsoleColor.White;
            string inp = Console.ReadLine();
            return inp.ToString();
        }
    }
}