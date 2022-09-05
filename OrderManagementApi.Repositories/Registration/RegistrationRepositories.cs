using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementApi.Models.SupplierMOdel;
using OrderManagementApi.Repositories.Connection;

namespace OrderManagementApi.Repositories.Registration
{
    public   class RegistrationRepositories:IRegistrationRepositories
    {
        public readonly BaseRepositories _BaseRepositories;
        public RegistrationRepositories(BaseRepositories baseRepositories)
        {
            _BaseRepositories=baseRepositories;
        }
        public void AddUser(SupplierModel supplier)
        {
            using (SqlConnection connection = new SqlConnection(_BaseRepositories.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddUserSupplier", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "FirstName", Value = supplier.FirstName, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "Lastname", Value = supplier.LastName, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "AddressLine1", Value = supplier.AddressLine1, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "AddressLine2", Value = supplier.AddressLine2, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "EMail", Value = supplier.EMail, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "City", Value = supplier.City, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "PostalCode", Value = supplier.PostalCode, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "State", Value = supplier.State, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "Disable", Value =(supplier.Disable), SqlDbType = SqlDbType.Bit });
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
