using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_1
{
    public enum EntityState
    {
        Active,
        Deleted
    }
    public abstract class BooleansBase
    {
        public bool IsNew { get; protected set; }
        public bool HasChanges { get; protected set; }
       
        public EntityState State { get; set; }

        
    }
}

