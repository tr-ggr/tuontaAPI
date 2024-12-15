using tuontaAPI.Interfaces;
using tuontaAPI.DTO;
using tuontaAPI.Models;
using System.Linq;
using System.Collections.Generic; // Add this for List<>

namespace tuontaAPI.Repositories
{
    public class VerifyIdentityRepository : IVerifyIdentityRepository
    {
        private readonly TuontaDbContext _context;

        public VerifyIdentityRepository(TuontaDbContext context)
        {
            _context = context;
        }

        // Retrieve verification status for a specific user by UserID
        public VerifyIdentity GetVerificationStatus(int userId)
        {
            return _context.VerifyIdentity.FirstOrDefault(record => record.UserID == userId);
        }

        // Submit a new verification request, by adding a new record to the database
        public bool SubmitVerification(VerifyIdentityDto verifyIdentityDto)
        {
            // Create a new VerifyIdentity entity from the DTO
            var verifyIdentity = new VerifyIdentity
            {
                UserID = verifyIdentityDto.UserID,
            };

            // Add the new record to the database
            _context.VerifyIdentity.Add(verifyIdentity);

            // Save changes to the database
            var rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }

        // Update an existing verification status based on the UserID
        public bool UpdateVerificationStatus(VerifyIdentityDto verifyIdentityDto)
        {
            // Find the existing verification record for the user
            var existingRecord = _context.VerifyIdentity.FirstOrDefault(record => record.UserID == verifyIdentityDto.UserID);
            if (existingRecord == null)
            {
                return false; // Record not found
            }

            // Update the properties of the existing record
            existingRecord.IsApproved = true; // Example of updating verification status

            // Save changes to the database
            var rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }

        // Get all verification records
        public List<VerifyIdentity> GetAllVerificationStatuses()
        {
            return _context.VerifyIdentity.ToList(); // Retrieves all records from the VerifyIdentity table
        }
    }
}
