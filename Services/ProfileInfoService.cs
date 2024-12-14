using tuontaAPI.DTO;
using tuontaAPI.Interfaces;

namespace tuontaAPI.Services
{
    public class ProfileInfoService : IProfileInfoService
    {
        private readonly IProfileInfoRepository _profileInfoRepository;

        public ProfileInfoService(IProfileInfoRepository profileInfoRepository)
        {
            _profileInfoRepository = profileInfoRepository;
        }
        public List<ProfileDto> GetProfiles()
        {
            List<ProfileDto> profiles = new List<ProfileDto>();
            foreach(var profile in _profileInfoRepository.GetProfiles())
            {
                profiles.Add(new ProfileDto()
                {
                    Id = profile.Id,
                    Username = profile.Username,
                    Email = profile.Email,
                    Birthday = profile.Birthday,
                    Gender = profile.Gender,
                    Bio = profile.Bio,
                    School = profile.School,
                    Course = profile.Course,
                    Distance = profile.Distance,
                    Hobbies = profile.Hobbies,
                    ProfileImages = profile.ProfileImages
                });
            }

            return profiles;
        }
        public ProfileDto? GetProfileById(int id)
        {
            var profile = _profileInfoRepository.GetProfileById(id);
            if (profile == null)
            {
                return null;
            }
            return new ProfileDto()
            {
                Username = profile.Username,
                Email = profile.Email,
                Birthday = profile.Birthday,
                Gender = profile.Gender,
                Bio = profile.Bio,
                School = profile.School,
                Course = profile.Course,
                Distance = profile.Distance,
                Hobbies = profile.Hobbies,
                ProfileImages = profile.ProfileImages
            };
        }
    }
}
