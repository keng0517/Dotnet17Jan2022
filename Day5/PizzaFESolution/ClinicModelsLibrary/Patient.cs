using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelsLibrary
{
    internal class Patient
    {
        private string remarks;
        private string status;


        //get set methods
        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }

        }
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }

        }
    }
}
