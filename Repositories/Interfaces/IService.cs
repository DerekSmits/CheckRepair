using CheckRepair.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckRepair.Repositories.Interfaces
{
    public interface IService<DbModel> where DbModel : BaseModel
    {
        public List<DbModel> GetAll();
        public DbModel Get(Guid id);
        public DbModel Create(DbModel model);
        public DbModel Update(DbModel model);
        public void Delete(Guid id);
    }
}
