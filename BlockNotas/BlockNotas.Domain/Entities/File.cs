using System;
using System.Collections.Generic;
using System.Text;

namespace BlockNotas.Domain.Entities
{
    public class File
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public readonly string Extention = ".txt";
    }
}
