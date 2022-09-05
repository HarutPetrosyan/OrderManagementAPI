using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrderManagementApi.Models.SupplierMOdel
{
    public class SupplierModel
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string EMail { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string State { get; set; }
        public Boolean Disable { get; set; }=true;
    }

}
