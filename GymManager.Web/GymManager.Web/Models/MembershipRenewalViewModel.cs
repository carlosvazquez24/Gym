using GymManager.Core.MembershipsTypes;

namespace GymManager.Web.Models
{
    public class MembershipRenewalViewModel
    {

        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public string MemberLastName { get; set; }

        public string MembershipName { get; set; }

        public int MembershipId { get; set; }

        public int MembershipDuration { get; set; }


        public DateTime RenewalDate { get; set; }

        public DateTime MembershipExpirationDate {  get ; set;  }
        public List<MembershipType> MembershipTypes { get; set; }

    }
}
