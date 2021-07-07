using CheckRepair.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Models
{
    public enum Company
    {
        Director,
        Manager,
        Operator,
        Worker
    }
    public class Worker : BaseModel
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public Company position { get; set; }
    }
}
