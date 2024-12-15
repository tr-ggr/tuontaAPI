using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using tuontaAPI.DTO;

namespace tuontaAPI.Controllers
{
    [Route("api/profiles")]

    
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileInfoService _profileInfoService;

        public ProfilesController(IProfileInfoService profileInfoService)
        {
            _profileInfoService = profileInfoService;
        }

        [HttpGet]
        public ActionResult<List<Profile>> GetProfiles()
        {
            return Ok(_profileInfoService.GetProfiles());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Profile> GetProfile(int id)
        {
            var result = _profileInfoService.GetProfileById(id);


            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost("register/")]
        public ActionResult<Profile> CreateUser(ProfileDto profileDto)
        {
            bool res = _profileInfoService.CreateProfile(profileDto);

            if (res)
            {
                return Ok(); // 200  
            } else
            {
                return BadRequest(); // 400
            }
        }



    }
}
