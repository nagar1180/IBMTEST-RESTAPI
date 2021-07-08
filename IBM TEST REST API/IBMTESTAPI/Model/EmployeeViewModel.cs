using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBMTESTAPI.Model
{
    public class EmployeeViewModel
    {
        [JsonProperty("empid")]
        public int EmpId { get; set; }
        [JsonProperty("empname")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Employee name is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "Employee name should between 2 and 100 char", MinimumLength = 3)]
        public string EmpName { get; set; }
        [JsonProperty("deptid")]

        [Range(1,999,ErrorMessage ="Department is required")]
        public int DeptId { get; set; }
        [JsonProperty("deptname")]
        public string DeptName { get; set; }
    }
}
