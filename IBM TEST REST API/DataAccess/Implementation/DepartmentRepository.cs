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
    public class DepartmentRepository : IRepository<Department>, IDepartmentRepository
    {
        private readonly IDBManager dbManager;

        public DepartmentRepository(IDBManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public async Task Add(Department entity)
        {
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@Name", entity.Name);               
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_AddDepartment");
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

        public async Task<IEnumerable<Department>> GetAll()
        {
            var result = new List<Department>();
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetAllDepartments");
                while (dbManager.DataReader.Read())
                {
                    var obj = new Department();
                    obj.Id = DbHelper.CheckDbNullInt(dbManager.DataReader["DeptId"]);
                    obj.Name = DbHelper.CheckDbNullString(dbManager.DataReader["DeptName"]);                    
                    result.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.CloseReader();
                dbManager.Dispose();
            }
            return await Task.FromResult(result);
        }

        public Task<IEnumerable<Department>> GetAll(string procedureName)
        {
            throw new NotImplementedException();
        }

        public async Task<Department> GetById(int id)
        {
            var result = new Department();
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@Id", id);
                dbManager.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetDepartmentById");
                while (dbManager.DataReader.Read())
                {                   
                    result.Id = DbHelper.CheckDbNullInt(dbManager.DataReader["DeptId"]);
                    result.Name = DbHelper.CheckDbNullString(dbManager.DataReader["DeptName"]);                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.CloseReader();
                dbManager.Dispose();
            }
            return await Task.FromResult(result);
        }

        public async Task Update(Department entity)
        {
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@Id", entity.Id);
                dbManager.AddParameters(1, "@Name", entity.Name);               
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_UpdateDepartment");
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
                dbManager.AddParameters(0, "@Id", id);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_DeleteDepartment");
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
