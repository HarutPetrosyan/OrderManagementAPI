using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementApi.Models.SupplierMOdel;

namespace OrderManagementApi.Repositories.Operation
{
    public  interface IOperationRepositories
    {
        void  UpdateUser(int id, SupplierModel model);
        IEnumerable<SupplierModel> GetAllSuppliers();
        SupplierModel GetSupplier(int id);
        void DeleteSupplier(int id);
    }
}
