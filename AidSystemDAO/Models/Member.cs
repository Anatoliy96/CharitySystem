using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.Models
{
    public class Member : Entity
    {
        public string FirstName{ get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Code { get; set; }
        public DateTime AppointedDate { get; set; }
        public DateTime DateLeft { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationID { get; set; }
    }
}
