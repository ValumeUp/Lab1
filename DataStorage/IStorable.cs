using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage
{
   public interface IStorable
    {
        public Guid Guid { get;  }
    }
}
