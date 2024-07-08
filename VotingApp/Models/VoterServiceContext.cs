using Microsoft.EntityFrameworkCore;

namespace VotingApp.Models
{
    public class VoterServiceContext : DbContext
    {
        public DbSet<Voter> Voters { get; set; }
        public VoterServiceContext(DbContextOptions<VoterServiceContext> options)
            : base(options)
        {
        }
    }
}
