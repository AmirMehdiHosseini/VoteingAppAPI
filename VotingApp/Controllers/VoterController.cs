using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotingApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

public record CreateVoterDTO(string FirstName, string LastName, byte Age);

public record UpdateVoterDTO(string FirstName, string LastName, byte Age);


namespace VotingApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        // added this for DbContext
        // start
        private VoterServiceContext _dbContext;
        public VoterController(VoterServiceContext dbContext)
        {
            _dbContext = dbContext;
        }
        // end

        // GET: api/<VoterController>
        [HttpGet]
        public IEnumerable<Voter> GetAllVoters()
        {
            return _dbContext.Voters;
        }


        // GET api/<VoterController>/5
        [HttpGet("{id}")]
        public Voter? GetVoterById(int id)
        {
            return _dbContext.Voters.Find(Convert.ToString(id));
        }

        // POST api/<VoterController>
        [HttpPost]
        public void CreateVoter([FromBody] CreateVoterDTO Model)
        {
            Voter voter = new Voter(Model.FirstName, Model.LastName, Model.Age);
            _dbContext.Voters.Add(voter);
            _dbContext.SaveChanges();
        }

        // PUT api/<VoterController>/5
        [HttpPut("{id}")]
        public void UpdateVoter(int id, [FromBody] UpdateVoterDTO Model)
        {
            Voter? voter = _dbContext.Voters.Find(Convert.ToString(id));
            voter!.Age = Model.Age;
            voter.FirstName = Model.FirstName;
            voter.LastName = Model.LastName;
            _dbContext.SaveChanges();
        }

        // DELETE api/<VoterController>/5
        [HttpDelete("{id}")]
        public void DeleteVoter(int id)
        {
            Voter? voter = _dbContext.Voters.Find( Convert.ToString( id ) );
            _dbContext.Voters.Remove(entity: voter!);
            _dbContext.SaveChanges();
        }
    }
}
