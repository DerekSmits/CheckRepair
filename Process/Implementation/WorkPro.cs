using CheckRepair.Models;
using CheckRepair.Process.Interfaces;
using CheckRepair.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Process.Implementation
{
    public class WorkPro : IWorkPro
    {
        private IService<Device> Devices { get; set; }
        private IService<Report> Docs { get; set; }
        private IService<Worker> Staff { get; set; }
        public void Work()
        {
            var rand = new Random();
            var DevID = Guid.NewGuid();
            var WorkID = Guid.NewGuid();
            Devices.Create(new Device
            {
                id = DevID,
                Model= String.Format($"Device{rand.Next()}"),
                Desc = String.Format($"Device{rand.Next()}")
            });
            Staff.Create(new Worker
            {
                id = WorkID,
                Name = String.Format($"Worker{rand.Next()}"),
                Telephone = String.Format($"8916{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}")
            });
            var dev = Devices.Get(DevID);
            var worker = Staff.Get(WorkID);
            Docs.Create(new Report 
            { 
                DeviceID = DevID,
                WorkerID = WorkID,
                Device =  dev,
                Worker = worker
            });
        }
    }
}
