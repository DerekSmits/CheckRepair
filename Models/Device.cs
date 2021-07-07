using CheckRepair.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Models
{
     public enum TypeOfCrash
    { 
        PhysicalProblem,
        PowerProblem,
        RomProblem
    }
    public class Device : BaseModel
    {
        public string Model { get; set; }
        public TypeOfCrash CrashID { get; set; }
        public string Desc { get; set; }
    }
}
