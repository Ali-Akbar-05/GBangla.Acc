using Application.Common.CommonModels;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
   public interface ISupplierDetailRepository:IGenericRepository<SupplierDetail>
    {
      //  Task<SupplierDetail> SaveSupplierDetails(SupplierDetail model);
    }
}
