using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Schmirtz_Royale.Models
{
    public class SpinHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Result { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
