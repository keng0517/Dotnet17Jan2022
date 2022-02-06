using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class NoDepartmentException : Exception
    {
        string message;
        public NoDepartmentException()
        {
            message = "No departments available. Try later";
        }
        public override string Message => message;
    }

}
