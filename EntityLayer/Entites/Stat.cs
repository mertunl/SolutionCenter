using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entites
{
    public class Stat
    {
        public Guid StatID {  get; set; }
        public int? PostOfNumber { get; set; } = 0;
        public int? SentOfOfferNumber { get; set; } = 0;
        public int? ReceivedOfOfferNumber { get; set; } = 0; 
        public string? AppUserID { get; set; }

    }
}
