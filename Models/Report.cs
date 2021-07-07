using CheckRepair.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Models
{
    public class Report : BaseModel
    {
        public Guid DeviceID { get; set; }
        public Guid WorkerID { get; set; }
        public virtual Device Device { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
