using System;
using System.Collections.Generic;
using System.Text;

namespace Yess_Express___Desktop_App
{
    class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EmployeeModel(int id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
