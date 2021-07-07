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
        public JsonResult Put(Report report)
        {
            bool success = true;
            var document = Docs.Get(report.id);
            try
            {
                if (document != null)
                {
                    document = Docs.Update(report);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update success {report.id}") : new JsonResult("Error");

        }
        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            bool success = true;
            var document = Docs.Get(id);
            try
            {
                if (document != null)
                {
                    Docs.Delete(document.id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? new JsonResult("Delete success") : new JsonResult("Error");
        }
       
    }
}
