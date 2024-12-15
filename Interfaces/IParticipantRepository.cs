using System.Collections.Generic;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface IParticipantRepository
    {
        List<Participant> GetParticipants();
        Participant? GetParticipantById(int id);
        Participant? GetParticipantByUserId(int userId);
        bool AddParticipant(Participant participant);
    }
}
