using tuontaAPI.Models;
namespace tuontaAPI.Interfaces
{
    public interface IProfileInfoRepository
    {
        public List<Profile> GetProfiles();
        public Profile? GetProfileById(int id);

    }
}
