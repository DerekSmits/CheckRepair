using CheckRepair.Models.Base;
using CheckRepair.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Repositories.Implimentations
{
    public class Service<DbModel> : IService<DbModel> where DbModel : BaseModel
    {
        private ApplicationContext Context { get; set; }
        public Service(ApplicationContext context)
        {
            Context = context;
        }

        public List<DbModel> GetAll()
        {
            return Context.Set<DbModel>().ToList();
        }

        public DbModel Get(Guid id)
        {
            return Context.Set<DbModel>().FirstOrDefault(m => m.id == id);
        }

        public DbModel Create(DbModel model)
        {
            Context.Set<DbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public DbModel Update(DbModel model)
        {
            var toUpdate = Context.Set<DbModel>().FirstOrDefault(m => m.id == model.id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }

        public void Delete(Guid id)
        {
            var toDel = Context.Set<DbModel>().FirstOrDefault(m => m.id == id);
            Context.Set<DbModel>().Remove(toDel);
            Context.SaveChanges();
        }
    }
}
