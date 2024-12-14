using tuontaAPI.DTO;

namespace tuontaAPI.Interfaces
{
    public interface IProfileInfoService
    {
        public List<ProfileDto> GetProfiles();
        public ProfileDto? GetProfileById(int id);
    }

}
