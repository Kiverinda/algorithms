using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class FirstValueInFile
    {
        public string Path { get; set; }
        public int Value { get; set; }
        public int NumberString { get; set; }

        public FirstValueInFile(string path)
        {
            Path = path;
            Value = 0;
            NumberString = 0;
        }

    }
}
