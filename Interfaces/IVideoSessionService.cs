using System.Collections.Generic;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface IVideoSessionService
    {
        List<VideoSession> GetVideoSessions();
        VideoSession GetVideoSessionByUserId(int userId);
        VideoSession GetVideoSessionById(int id);
        public int AddVideoSession(VideoSession videoSession);
    }
}