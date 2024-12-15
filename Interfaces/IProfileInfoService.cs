using tuontaAPI.DTO;
using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    public interface IProfileInfoService
    {
        public List<ProfileDto> GetProfiles();
        public ProfileDto? GetProfileById(int id);

        public bool CreateProfile(ProfileDto profileDto);
    }

}
