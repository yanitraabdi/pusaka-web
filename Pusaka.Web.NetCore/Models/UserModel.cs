using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Models
{
    public class UserModel : BaseModel
    {
        public string UserID { get; set; }
        public int? AvatarID { get; set; }
        public int? SchoolID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public int? MissionTaken { get; set; }
        public int? MissionSuccess { get; set; }
        public int? MissionFailed { get; set; }
        public string ClassOfYear { get; set; }
        public int? IsOsis { get; set; }
        public byte? RoleType { get; set; }
        public byte? UserStatus { get; set; }
    }
}
