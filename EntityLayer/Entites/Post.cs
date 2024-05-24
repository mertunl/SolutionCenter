
using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Entites
{
    public class Post
    {
        public Guid PostID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Price { get; set; }
        public PostStatus postStatus { get; set; }
        public string? AppUserId { get; set; }
		public AppUser? AppUser { get; set; }
		public List<Category>? Categories { get; set; }= new List<Category>();
        public ICollection<Offer>? Offers { get; set; } = new HashSet<Offer>();
		public List<int> CategoryIDs { get; set; }= new List<int>();
        public Post()
        {
            PostID = Guid.NewGuid();
        }
    }
}
