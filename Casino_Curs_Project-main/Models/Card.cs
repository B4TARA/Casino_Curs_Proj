using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Schmirtz_Royale.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public int Cvv { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
