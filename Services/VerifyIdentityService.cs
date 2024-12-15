using tuontaAPI.Interfaces;
using tuontaAPI.DTO;
using System.Collections.Generic;

namespace tuontaAPI.Services
{
    public class VerifyIdentityService : IVerifyIdentityService
    {
        private readonly IVerifyIdentityRepository _verifyIdentityRepository;

        public VerifyIdentityService(IVerifyIdentityRepository verifyIdentityRepository)
        {
            _verifyIdentityRepository = verifyIdentityRepository;
        }

        public bool SubmitVerification(VerifyIdentityDto verifyIdentityDto)
        {
            return _verifyIdentityRepository.SubmitVerification(verifyIdentityDto);
        }

        public VerifyIdentityDto GetVerificationStatus(int userId)
        {
            // Retrieve the VerifyIdentity entity from the repository
            var verifyIdentity = _verifyIdentityRepository.GetVerificationStatus(userId);

            // If the entity is null, return null or handle it appropriately
            if (verifyIdentity == null)
            {
                return null;
            }

            // Convert the VerifyIdentity entity to VerifyIdentityDto
            var verifyIdentityDto = new VerifyIdentityDto
            {
                Id = verifyIdentity.Id,
                UserID = verifyIdentity.UserID,
                isApproved = verifyIdentity.IsApproved
                // Add other properties as necessary, such as IsVerified
            };

            return verifyIdentityDto;
        }

        public bool UpdateVerificationStatus(VerifyIdentityDto verifyIdentityDto)
        {
            return _verifyIdentityRepository.UpdateVerificationStatus(verifyIdentityDto);
        }

        // New method to get all verification statuses
        public List<VerifyIdentityDto> GetAllVerificationStatuses()
        {
            // Retrieve the list of verification entities from the repository
            var verificationRecords = _verifyIdentityRepository.GetAllVerificationStatuses();

            // Convert the list of entities to a list of DTOs
            var verificationDtos = new List<VerifyIdentityDto>();
            foreach (var record in verificationRecords)
            {
                var verifyIdentityDto = new VerifyIdentityDto
                {
                    Id = record.Id,
                    UserID = record.UserID,
                    isApproved = record.IsApproved
                    // Add other properties as necessary
                };
                verificationDtos.Add(verifyIdentityDto);
            }

            return verificationDtos;
        }
    }
}
