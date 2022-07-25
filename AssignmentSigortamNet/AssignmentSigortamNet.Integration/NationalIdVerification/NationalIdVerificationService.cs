using System;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Integration
{
    public class NationalIdVerificationService : INationalIdVerificationService
    {
        public async Task<bool> IsNationalIdVerified(long id, string firstName, string lastName, int yearOfBirth)
        {
            try
            {
                Mernis.Verify.TcKimlikNo.KPSPublicSoapClient service =
                new Mernis.Verify.TcKimlikNo.KPSPublicSoapClient("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx", TimeSpan.MaxValue);
                return (await service.TCKimlikNoDogrulaAsync(id, firstName, lastName, yearOfBirth)).Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
