using System.Collections.Generic;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface IVideoSessionRepository
    {
        List<VideoSession> GetVideoSessions();
        VideoSession? GetVideoSessionById(int id);
        VideoSession? GetVideoSessionByUserId(int userId);
        int AddVideoSession(VideoSession videoSession);
    }
}