using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_1
{
    public abstract class EntityBase
    {
        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        public abstract bool Validate();

    }

}


