using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Entites
{
    public class AppUser: IdentityUser
    {
        
       
        public string? Name { get; set; }
        public string? Surname { get; set; }     
        //public bool? IsAuthorized { get; set; } = false;
		[JsonIgnore]
		public ICollection<Post>? Posts { get; set; } = new HashSet<Post>();
        public ICollection<Offer>? Offers { get; set; } = new HashSet<Offer>();
        public Stat Stat { get; set; } = new Stat();

    }
}
