using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class UserPostViewModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public Guid OfferID { get; set; }
        public OfferStatus OfferStatus { get; set; }
    }
}
