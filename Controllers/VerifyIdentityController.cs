using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.Interfaces;
using tuontaAPI.DTO;

namespace tuontaAPI.Controllers
{
    [Route("api/verifyidentity")]
    [ApiController]
    public class VerifyIdentityController : ControllerBase
    {
        private readonly IVerifyIdentityService _verifyIdentityService;

        public VerifyIdentityController(IVerifyIdentityService verifyIdentityService)
        {
            _verifyIdentityService = verifyIdentityService;
        }

        // Endpoint to submit identity verification
        [HttpPost("submit")]
        public ActionResult SubmitVerification([FromBody] VerifyIdentityDto verifyIdentityDto)
        {
            var result = _verifyIdentityService.SubmitVerification(verifyIdentityDto);
            if (result)
            {
                return Ok("Verification submitted successfully.");
            }
            return BadRequest("Failed to submit verification.");
        }

        // Endpoint to get verification status by UserID
        [HttpGet("{userId}")]
        public ActionResult<VerifyIdentityDto> GetVerificationStatus(int userId)
        {
            var result = _verifyIdentityService.GetVerificationStatus(userId);
            if (result == null)
            {
                return NotFound("Verification status not found.");
            }
            return Ok(result);
        }

        // Endpoint to update verification status
        [HttpPut("update")]
        public ActionResult UpdateVerificationStatus([FromBody] VerifyIdentityDto verifyIdentityDto)
        {
            var result = _verifyIdentityService.UpdateVerificationStatus(verifyIdentityDto);
            if (result)
            {
                return Ok("Verification status updated successfully.");
            }
            return BadRequest("Failed to update verification status.");
        }
        // New endpoint to get all verification statuses
        [HttpGet]
        public ActionResult<List<VerifyIdentityDto>> GetAllVerificationStatuses()
        {
            var result = _verifyIdentityService.GetAllVerificationStatuses();
            if (result == null || result.Count == 0)
            {
                return NotFound("No verification statuses found.");
            }
            return Ok(result);
        }
        }
}
