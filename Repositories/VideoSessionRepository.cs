using tuontaAPI.Models;
using tuontaAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace tuontaAPI.Repositories
{
    public class VideoSessionRepository : IVideoSessionRepository
    {
        private readonly TuontaDbContext _context;

        public VideoSessionRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<VideoSession> GetVideoSessions()
        {
            return _context.VideoSessions.ToList();
        }

        public VideoSession? GetVideoSessionById(int id)
        {
            return _context.VideoSessions.FirstOrDefault(vs => vs.Id == id);
        }

        public VideoSession? GetVideoSessionByUserId(int userId)
        {
            return _context.VideoSessions.FirstOrDefault(vs => vs.Id == userId);
        }

        public int AddVideoSession(VideoSession videoSession)
        {
            _context.VideoSessions.Add(videoSession);
            _context.SaveChanges();
            return videoSession.Id;
        }
    }
}

