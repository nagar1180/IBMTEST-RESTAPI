using AutoMapper;
using DomainModel;
using IBMTESTAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMTESTAPI.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Employee, EmployeeViewModel>().AfterMap(AfterEmployeeMap);
            CreateMap<EmployeeViewModel,Employee>().AfterMap(ReverseEmployeeMap);
            CreateMap<Department, DepartmentViewModel>().AfterMap(AfterDepartmentMap);
            CreateMap<DepartmentViewModel, Department>().AfterMap(ReverseDeptMap);
        }

        private void AfterDepartmentMap(Department source, DepartmentViewModel dest)
        {
            dest.DeptId = source.Id;
            dest.DeptName = source.Name;
        }

        private void ReverseDeptMap(DepartmentViewModel source, Department dest)
        {
            dest.Id = source.DeptId;
            dest.Name = source.DeptName;
        }

        private void ReverseEmployeeMap(EmployeeViewModel source, Employee dest)
        {
            dest.Id = source.EmpId;
            dest.Name = source.EmpName;
            dest.Department.Id = source.DeptId;
            dest.Department.Name = source.DeptName;
        }

        private void AfterEmployeeMap(Employee source, EmployeeViewModel dest)
        {
            dest.EmpId = source.Id;
            dest.EmpName = source.Name;
            dest.DeptId = source.Department.Id;
            dest.DeptName = source.Department.Name;
        }

        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DtoMapper>();
            });
        }
    }
}
