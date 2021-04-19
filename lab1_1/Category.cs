using DataStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using DataStorage;

namespace lab1_1
{
    public class Category : EntityBase, IStorable
    {


        private Guid _guid;
        private string _name;
        private string _description;
        private ColorWrapper _colorWrapper;
        private FileStream _image;
        private Guid _userGuid;


        public Guid Guid { get => _guid; private set => _guid = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public Guid UserGuid { get => _userGuid; private set => _userGuid = value; }

        public ColorWrapper ColorWrapper { get => _colorWrapper; set => _colorWrapper = value; }
        public FileStream Image { get => _image; set => _image = value; }

        public Category(Guid userGuid, string name, string description, ColorWrapper colorWrapper, FileStream image, Guid guid)
        {
            _guid = guid;
            _userGuid = userGuid;
            _name = name;
            _description = description;
            _colorWrapper = colorWrapper;
            _image = image;
        }

        public override bool Validate()
        {
            var result = true;

            if (UserGuid == Guid.Empty)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;

            return result;
        }

    }
}
