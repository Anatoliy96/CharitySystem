using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.Models
{
    public class Organization : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Activity { get; set; }
        public string CoverageOfAreas { get; set; }
    }
}
