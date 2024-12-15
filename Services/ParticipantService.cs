using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using System.Collections.Generic;

namespace tuontaAPI.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public List<Participant> GetParticipants()
        {
            return _participantRepository.GetParticipants();
        }

        public Participant? GetParticipantById(int id)
        {
            return _participantRepository.GetParticipantById(id);
        }

        public Participant? GetParticipantByUserId(int userId)
        {
            return _participantRepository.GetParticipantByUserId(userId);
        }

        public bool AddParticipant(Participant participant)
        {
            return _participantRepository.AddParticipant(participant);
        }
    }
}
