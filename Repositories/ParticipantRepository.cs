using tuontaAPI.Models;
using tuontaAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace tuontaAPI.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly TuontaDbContext _context;

        public ParticipantRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<Participant> GetParticipants()
        {
            return _context.Participants.ToList();
        }

        public Participant? GetParticipantById(int id)
        {
            return _context.Participants.FirstOrDefault(p => p.Id == id);
        }

        public Participant? GetParticipantByUserId(int userId)
        {
return _context.Participants.FirstOrDefault(p => p.userId == userId);
        }

        public bool AddParticipant(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
            return true;
        }
    }
}
