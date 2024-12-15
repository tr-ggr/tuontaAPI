using tuontaAPI.Models;

namespace tuontaAPI.Interfaces
{
    using tuontaAPI.DTO;

    public interface IVerifyIdentityRepository
    {
        bool SubmitVerification(VerifyIdentityDto verifyIdentityDto);
        VerifyIdentity GetVerificationStatus(int userId);
        bool UpdateVerificationStatus(VerifyIdentityDto verifyIdentityDto);

        List<VerifyIdentity> GetAllVerificationStatuses();

    }
}
