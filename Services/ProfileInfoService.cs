using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;

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
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Country = profile.Country,
                    City = profile.City,
                    Province = profile.Province,
                    Street = profile.Street,
                    IsAdmin = profile.IsAdmin,
                    Role = profile.Role,
                    Password = profile.Password,
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
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Country = profile.Country,
                City = profile.City,
                Province = profile.Province,
                Street = profile.Street,
                IsAdmin = profile.IsAdmin,
                Role = profile.Role,
                Password = profile.Password,
                ProfileImages = profile.ProfileImages
            };
        }

        public bool CreateProfile(ProfileDto profileDto)
        {
            var profile = new Profile()
            {
                Username = profileDto.Username,
                Email = profileDto.Email,
                Birthday = profileDto.Birthday,
                Gender = profileDto.Gender,
                School = profileDto.School,
                Course = profileDto.Course,
                FirstName = profileDto.FirstName,
                LastName = profileDto.LastName,
                Country = profileDto.Country,
                City = profileDto.City,
                Province = profileDto.Province,
                Street = profileDto.Street,
                Role = profileDto.Role,
                Password = profileDto.Password
            };

            return _profileInfoRepository.CreateProfile(profile);
        }
    }
}
