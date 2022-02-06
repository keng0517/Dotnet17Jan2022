using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class NoEmployeeException : Exception
    {
        string message;
        public NoEmployeeException()
        {
            message = "No employees available. Try later";
        }
        public override string Message => message;
    }
}
