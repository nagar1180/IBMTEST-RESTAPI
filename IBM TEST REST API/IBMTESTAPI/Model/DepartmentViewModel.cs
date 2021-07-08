using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBMTESTAPI.Model
{
    public class DepartmentViewModel
    {
        [JsonProperty("deptid")]
        public int DeptId { get; set; }

        [JsonProperty("deptname")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Department name is required")]
        [StringLength(maximumLength:100, ErrorMessage = "Department name should between 2 and 100 char", MinimumLength = 2)]
        public string DeptName { get; set; }
    }
}
