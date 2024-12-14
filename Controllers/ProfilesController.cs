using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;

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


    }
}
