using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAchieveClubApi.RepositoryItems
{
    public class Achievement
    {
        public int Id { get; set; }
        public int Xp { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LogoURL { get; set; }
        public bool IsMultiple { get; set; }
        public string XpString
        {
            get => Xp.ToString();
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Xp = 0;
                    return;
                }

                if (int.TryParse(value, out int result))
                {
                    Xp = result;
                }
            }
        }
    }
}