using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.Models
{
    public class MemberActivity : Entity
    {
        [ForeignKey("Members")]
        public int MemberID { get; set; }
        [ForeignKey("Activity")]
        public int ActivityID { get; set; }
    }
}
