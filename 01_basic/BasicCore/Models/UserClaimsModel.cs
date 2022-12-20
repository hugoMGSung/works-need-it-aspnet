namespace BasicCore.Models
{
    public class UserClaimsModel
    {
        public string UserId { get; set; }
        public List<UserClaim> Cliams { get; set; }

        public UserClaimsModel()
        {
            Cliams = new List<UserClaim>();
        }
    }
}
