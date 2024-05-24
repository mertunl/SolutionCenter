using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entites
{
    public class Application
    {
        public Guid ApplicationID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Experience { get; set; }
        public byte[]? CV { get; set; }
        public string? Degree { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Waiting;
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public Application()
        {
            ApplicationID = Guid.NewGuid();
        }
    }

}
