using tuontaAPI.Interfaces;
using tuontaAPI.Models;
namespace tuontaAPI.Repositories
{
    public class ProfileInfoRepository : IProfileInfoRepository
    {

        private readonly TuontaDbContext _context;

        public ProfileInfoRepository(TuontaDbContext context)
        {
            _context = context;
        }

        public List<Profile> GetProfiles()
        {
            return _context.Profiles.ToList();
        }

        public Profile? GetProfileById(int id)
        {
            return _context.Profiles.Find(id);
        }
    }
}
