using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using OrderManagementApi.Models.SupplierMOdel;
using OrderManagementApi.Repositories.Connection;

namespace OrderManagementApi.Repositories.Operation
{

    public  class OperationRepositories:IOperationRepositories
    {
        public readonly BaseRepositories _BaseRepositories;

        public OperationRepositories(BaseRepositories repositories)
        {
            _BaseRepositories=repositories;
        }

        public void   UpdateUser(int id, SupplierModel model)
        {
            using (SqlConnection connection = new SqlConnection(_BaseRepositories.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateSupplier", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "Id", Value = model.Id, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "FirstName", Value = model.FirstName, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "Lastname", Value = model.LastName, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "AddressLine1", Value = model.AddressLine1, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "AddressLine2", Value = model.AddressLine2, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "EMail", Value = model.EMail, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "City", Value = model.City, SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "PostalCode", Value = model.PostalCode, SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "State", Value = model.State, SqlDbType = SqlDbType.NVarChar });
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            using (SqlConnection connection = new SqlConnection(_BaseRepositories.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllSuppliers", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                List<SupplierModel> model = new List<SupplierModel>();
                while (reader.Read())
                {
                    SupplierModel Sup=new SupplierModel();
                    Sup.Id = (int)reader["Id"];
                    Sup.FirstName = (string)reader["FirstName"];
                    Sup.LastName = (string)reader["LastName"];
                    Sup.AddressLine1 = (string)reader["AddressLine1"];
                    Sup.AddressLine2 = (string)reader["AddressLine2"];
                    Sup.EMail = (string)reader["EMail"];
                    Sup.City = (string)reader["City"];
                    Sup.PostalCode = (int)reader["PostalCode"];
                    Sup.State = (string)reader["State"];
                    Sup.Disable = (Boolean)reader["Disable"];
                    model.Add(Sup);
                }
                return model;

            }
        }

        public SupplierModel GetSupplier(int id)
        {
            using (SqlConnection connection =new SqlConnection(_BaseRepositories.ConnectionString))
            { 
                connection.Open();
                SqlCommand command = new SqlCommand("GetSupplierById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "Id", Value = id, SqlDbType = SqlDbType.Int });
                SupplierModel Sup=new SupplierModel();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Sup.Id = (int)reader["Id"];
                    Sup.FirstName = (string)reader["FirstName"];
                    Sup.LastName = (string)reader["LastName"];
                    Sup.AddressLine1 = (string)reader["AddressLine1"];
                    Sup.AddressLine2 = (string)reader["AddressLine2"];
                    Sup.EMail = (string)reader["EMail"];
                    Sup.City = (string)reader["City"];
                    Sup.PostalCode = (int)reader["PostalCode"];
                    Sup.State = (string)reader["State"];
                }
               
                return Sup;
            }
        }

        public void DeleteSupplier(int id)
        {
            using (SqlConnection connection=new SqlConnection(_BaseRepositories.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteSupplierById", connection);
                command.CommandType=CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter()
                    { ParameterName = "Id", Value = id, SqlDbType = SqlDbType.Int });
                SqlDataReader reader = command.ExecuteReader();
                
            }
        }
    }
}
 