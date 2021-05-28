using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Schmirtz_Royale.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Is_admin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }
        public bool IsBlocked { get; set; }

        public List<SpinHistory> Spins { get; set; }
        public List<TopUpHistory> TopUps { get; set; }
        public List<Card> Cards { get; set; }
        public User()
        {
            Spins = new List<SpinHistory>();
            TopUps = new List<TopUpHistory>();
            Cards = new List<Card>();
        }
    }
}
