using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementApi.Models.SupplierMOdel;

namespace OrderManagementApi.Repositories.Registration
{
    public  interface IRegistrationRepositories
    {
        void AddUser(SupplierModel supplier);
    }
}
