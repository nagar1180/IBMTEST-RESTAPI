using DataAccess.Common;
using DataAccess.Contract;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class EmployeeRepository : IRepository<Employee>, IEmployeeRepository
    {
        private readonly IDBManager dbManager;

        public EmployeeRepository(IDBManager dbManager)
        {
            this.dbManager = dbManager;
        }
        public async Task Add(Employee entity)
        {
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@Name", entity.Name);
                dbManager.AddParameters(1, "@DeptId", entity.Department.Id);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_AddEmployee");               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {                
                dbManager.Dispose();
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = new List<Employee>();
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetAllEmployee");
                while (dbManager.DataReader.Read())
                {
                    var obj = new Employee();
                    obj.Id = DbHelper.CheckDbNullInt(dbManager.DataReader["ID"]);
                    obj.Name = DbHelper.CheckDbNullString(dbManager.DataReader["Name"]);
                    obj.Department.Id = DbHelper.CheckDbNullInt(dbManager.DataReader["DeptId"]);
                    obj.Department.Name = DbHelper.CheckDbNullString(dbManager.DataReader["DeptName"]);
                    result.Add(obj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(result);
        }

        public Task<IEnumerable<Employee>> GetAll(string procedureName)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetById(int id)
        {
            var result = new Employee();
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@Id", id);
                dbManager.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetEmployeeById");
                while (dbManager.DataReader.Read())
                {                   
                    result.Id = DbHelper.CheckDbNullInt(dbManager.DataReader["ID"]);
                    result.Name = DbHelper.CheckDbNullString(dbManager.DataReader["Name"]);
                    result.Department.Id = DbHelper.CheckDbNullInt(dbManager.DataReader["DeptId"]);
                    result.Department.Name = DbHelper.CheckDbNullString(dbManager.DataReader["DeptName"]);                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(result);
        }

        public async Task Update(Employee entity)
        {
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "@Id", entity.Id);
                dbManager.AddParameters(1, "@Name", entity.Name);
                dbManager.AddParameters(2, "@DeptId", entity.Department.Id);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_UpdateEmployee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@Id",id);               
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_DeleteEmployee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
    }
}
