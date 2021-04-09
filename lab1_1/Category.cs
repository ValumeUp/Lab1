using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab1_1
{
    public class Category
    {
        private static int InstanceCount;
        private int _id;
        private string _name;
        private string _description;
        private string _color;
        private FileStream _icon;

        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public FileStream Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        public string Description { get => _description; set => _description = value; }

        public Category()
        {
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Category(int id, string name, string color, FileStream icon)
        {
            _id = id;
            _name = name;
            _color = color;
            _icon = icon;
        }

        public bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (String.IsNullOrWhiteSpace(Color))
                result = false;
            if (Icon == null)
                result = false;

            return result;
        }
    }
}
