using Microsoft.EntityFrameworkCore;

namespace VotingApp.Models
{
    public class Voter
    {
        
        [System.ComponentModel.DataAnnotations.Required] 
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        private static int _countOfId;

        public Voter(string firstName, string lastName, byte age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = (++_countOfId).ToString();
        }
    }
}
