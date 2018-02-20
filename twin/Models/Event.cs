using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using twin.CommonInterfaces;

namespace twin.Models
{
    public class Event : IEntity<int>
    {
        public int Id { get; set; }
        public IEnumerable<Bet> Bets { get; set; }
    }
}
