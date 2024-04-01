using Microsoft.AspNetCore.Components.Forms;

namespace TestAchieveClubApi.RepositoryItems
{
    public class RegisterParams
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int ClubRefId { get; set; }

        public User ToUser()
        {
            return new User
            {
                Id = 0,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Avatar = Avatar,
                ClubRefId = ClubRefId,
                Password = Password
            };
        }
    }
}
