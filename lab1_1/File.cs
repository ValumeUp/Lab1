using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_1
{
    public class File
    {
        private string _textPath;
        private string _imagePath;

        public string TextPath { get => _textPath; set => _textPath = value; }
        public string ImagePath { get => _imagePath; set => _imagePath = value; }
    }
}
