using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.Models
{
    public class Activity : Entity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime FromHour { get; set; }
        public DateTime ToHour { get; set; }
        public string Region { get; set; }
        public int UniqueCode { get; set; }
    }
}
