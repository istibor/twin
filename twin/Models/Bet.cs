using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using twin.CommonInterfaces;

namespace twin.Models
{
    public class Bet : IEntity<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
