using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagementApi.Models.SupplierMOdel;
using OrderManagementApi.Repositories.Operation;
using OrderManagementApi.Repositories.Registration;
using Microsoft.AspNetCore.Http;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    public class OrderManagementController : Controller
    {
        public SupplierModel Supp = new SupplierModel();
        private readonly IRegistrationRepositories registration;
        private readonly IOperationRepositories _operation;
        private IConfiguration Configuration;
        public OrderManagementController(IRegistrationRepositories _registration, IConfiguration configuration, IOperationRepositories operation)
        {
            registration = _registration;
            Configuration = configuration;
            _operation = operation;
        }

        [HttpPut]
        [Route("/AddUser")]

        public bool AddUser(SupplierModel asd)
        {
            registration.AddUser(asd);
            return true;
        }
        [HttpPut("UpdateUser")]

        public bool UpdateUserModel(SupplierModel model)
        {
                _operation.UpdateUser(model.Id, model);
                return true;
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<SupplierModel> GetAll()
        {
            return _operation.GetAllSuppliers();
        }

        [HttpGet("GetUserById")]
        public SupplierModel GetById(int id)
        {
            return _operation.GetSupplier(id);
        }

        [HttpPut("DeleteUserById")]
        public bool DeleteUserById(SupplierModel model)
        {
            _operation.DeleteSupplier(model.Id);
            return true;
        }
    }
}
