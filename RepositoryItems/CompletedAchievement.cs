using System;

namespace TestAchieveClubApi.RepositoryItems
{
    public class CompletedAchievement
    {
        public int Id { get; set; }
        public int SupervisorId { get; set; }       
        public int UserId { get; set; }  
        public int AchieveId { get; set; }
        public DateTime DateOfCompletion { get; set; }
    }
}
