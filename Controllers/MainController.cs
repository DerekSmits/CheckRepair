using CheckRepair.Models;
using CheckRepair.Process.Interfaces;
using CheckRepair.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IWorkPro Process { get; set; }
        private IService<Report> Docs { get; set; }
        public MainController(IWorkPro process, IService<Report> docs) {
            Process = process;
            Docs = docs;
        }
        [HttpGet]
        public JsonResult Get() {
            return new JsonResult(Docs.GetAll());
        }
        [HttpPost]
        public JsonResult Post() {
            Process.Work();
            return new JsonResult("Work was completed");
        }
        [HttpPut]
       /* public JsonResult Put()
        {
            
        }
       */
    }
}
