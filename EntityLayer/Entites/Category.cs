using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Entites
{
	public class Category
	{
        public int CategoryID { get; set; }
		public string? Name { get; set; }
		[JsonIgnore]
		public List<Post>? Posts { get; set; } = new List<Post>();
    }
}
