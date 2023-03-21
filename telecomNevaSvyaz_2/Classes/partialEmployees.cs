using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace telecomNevaSvyaz_2
{
    public partial class Employee
    {
        public string FIO
        {
            get
            {
                return "" + Surname + " " + Name + " " + Patronymic;
            }
        }
    }
}
