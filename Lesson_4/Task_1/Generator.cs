using System;

namespace Task_1
{
    static public class Generator
    {
        static public string GeneratorString(int lengthString)
        {
            string source = "1234567890!@#$%^&*()_+?qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            Random random = new Random();
            char[] arrayChar = new char[lengthString];
            for (int i = 0; i < lengthString; i++)
            {
                arrayChar[i] = source[random.Next(75)];
            }
            return new string(arrayChar);
        }
    }
}
