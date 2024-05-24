using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entites
{
    public class Offer
    {
        public Guid OfferID { get; set; }
        public int Price { get; set; }
        public string? AppUserId { get; set; }
        public Guid PostID { get; set; }
        public Post Post { get; set; }
        public AppUser AppUser { get; set; }
        public string? Offeree {  get; set; }
        public OfferStatus OfferStatus { get; set; } = OfferStatus.Pending;
        public Offer()
        {
            OfferID = Guid.NewGuid();
        }

    }
}
