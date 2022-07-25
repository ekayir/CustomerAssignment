using System.Threading.Tasks;

namespace AssignmentSigortamNet.Integration
{
    public interface INationalIdVerificationService
    {
        Task<bool> IsNationalIdVerified(long id, string firstName, string lastName, int yearOfBirth);
    }
}
