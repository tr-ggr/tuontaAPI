namespace tuontaAPI.Interfaces
{
    using tuontaAPI.DTO;

    public interface IVerifyIdentityService
    {
        bool SubmitVerification(VerifyIdentityDto verifyIdentityDto);
        VerifyIdentityDto GetVerificationStatus(int userId);
        bool UpdateVerificationStatus(VerifyIdentityDto verifyIdentityDto);

        List<VerifyIdentityDto> GetAllVerificationStatuses();

    }
}
