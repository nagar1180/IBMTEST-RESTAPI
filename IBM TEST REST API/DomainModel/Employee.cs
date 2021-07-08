using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
   public class Employee : Entity
    {
        public Employee()
        {
            this.Department = new Department();
        }
        public string Name { get; set; }
        public Department Department { get; set; }
    }
}
