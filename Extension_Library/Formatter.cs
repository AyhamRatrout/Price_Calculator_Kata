using System;

namespace Extension_Library
{
    //This class represents a Formatter extension which contains a number of methods that are useful when formatting/displaying a Receipt instance.
    public class Formatter
    {
        //Aligns a String object to the center of the Console Window.
        public static void AlignCenter(String word)
        {
            var alignment = ((Console.WindowWidth / 2) + (word.Length / 2));
            Console.WriteLine(String.Format("{0," + alignment + "}", word));
        }

        //Aligns the first String object to the left of the Console Window and the second String object to the right of the Console Window.
        public static void AlignLeftRight(String left, String right)
        {
            Console.Write(left);
            AlignRight(right);
        }

        //Adds an empty line after the current line when called.
        public static void AddLine()
        {
            Console.WriteLine();
        }

        //Aligns a String object to the right of the Console Window.
        private static void AlignRight(String word)
        {
            Console.CursorLeft = Console.WindowWidth - word.Length;
            Console.Write(word);
        }
    }
}