using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using System.Collections.Generic;

namespace tuontaAPI.Services
{
    public class VideoSessionService : IVideoSessionService
    {
        private readonly IVideoSessionRepository _videoSessionRepository;

        public VideoSessionService(IVideoSessionRepository videoSessionRepository)
        {
            _videoSessionRepository = videoSessionRepository;
        }

        public List<VideoSession> GetVideoSessions()
        {
            return _videoSessionRepository.GetVideoSessions();
        }

        public VideoSession? GetVideoSessionById(int id)
        {
            return _videoSessionRepository.GetVideoSessionById(id);
        }

        public VideoSession? GetVideoSessionByUserId(int userId)
        {
            return _videoSessionRepository.GetVideoSessionByUserId(userId);
        }

        public int AddVideoSession(VideoSession videoSession)
        {
            return _videoSessionRepository.AddVideoSession(videoSession);
        }
    }
}