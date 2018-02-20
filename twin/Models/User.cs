using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

using twin.CommonInterfaces;

namespace twin.Models
{
    public class User : IdentityUser<int>, IEntity<int>
    {
        public UserData UserData { get; set; }
        public IEnumerable<Bet> Bets { get; set; }
    }

    public class UserData
    {
        public int UserDataId { get; set; }
        public string Picture { get; set; }
        public decimal Score { get; set; }

        public int UserForeignKey { get; set; }
        public User User { get; set; }
    }
}
