using GymManager.Core.Members;

namespace GymManager.Web.Models
{
    public class AttendanceViewModel
    {
        public int IdMember {get; set;}

        public string Movement { get; set;}

        public List<Member> MembersInside { get; set;}

        public List<Member> MembersOutside { get; set; }


    }
}
