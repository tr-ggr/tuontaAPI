using System.Collections.Generic;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface IParticipantService
    {
        List<Participant> GetParticipants();
        Participant GetParticipantByUserId(int userId);
        Participant GetParticipantById(int id);
    }
}