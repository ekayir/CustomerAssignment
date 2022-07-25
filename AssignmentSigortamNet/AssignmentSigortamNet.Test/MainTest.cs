using AssignmentSigortamNet.Data;
using AssignmentSigortamNet.Integration;
using AssignmentSigortamNet.Service;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;

namespace AssignmentSigortamNet.Test
{
    public class MainTest
    {
        ICustomerService _customerService;
        public MainTest()
        {
            var services = new ServiceCollection();

            services.AddTransient<INationalIdVerificationService, NationalIdVerificationService>();
            services.AddTransient<ICustomerInfoVerificationService, CustomerInfoVerificationService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<AssignmentSigortamNetDBContext, AssignmentSigortamNetDBContext>();

            var serviceProvider = services.BuildServiceProvider();

            _customerService = serviceProvider.GetService<ICustomerService>();

            _customerService.DeleteAllCustomers();//just before running test, old records should be deleted.
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AA_AddSuccessfulCustomer()
        {
            var actualResult = _customerService.AddCustomer(new CustomerDTO { NationalIdNumber = 12345678910, FirstName = "TEST", LastName = "TEST", BirthDate = new DateTime(2020, 1, 1) });

            Assert.IsTrue(actualResult.IsSuccess == true && actualResult.Message == ActionMessage.AddCustomerSuccess);
        }

        [Test]
        public void BB_AddCustomerWithAlreadyAdded()
        {
            var actualResult = _customerService.AddCustomer(new CustomerDTO { NationalIdNumber = 12345678910, FirstName = "TEST 1", LastName = "TEST 1", BirthDate = new DateTime(2022, 1, 1) });

            Assert.IsTrue(actualResult.IsSuccess == false && actualResult.Message == ActionMessage.AlreadyAddedCustomer);
        }

        [Test]
        public void CC_AddCustomerWithNotVerifiedNationalId()
        {
            var actualResult = _customerService.AddCustomer(new CustomerDTO { NationalIdNumber = 10987654321, FirstName = "TEST 1", LastName = "TEST 1", BirthDate = new DateTime(2022, 1, 1) });

            Assert.IsTrue(actualResult.IsSuccess == false && actualResult.Message == ActionMessage.NationalIdVerificationFalse);
        }

        [Test]
        public void DD_SearchCustomerWithNoParams()
        {
            var actualResult = _customerService.GetCustomers("", "", null);

            Assert.IsTrue(actualResult.IsSuccess == false && actualResult.Message == ActionMessage.FillAtLeastNameOrNationalId);
        }
        [Test]
        public void EE_SearchCustomerWithMissingNames()
        {
            var actualResult = _customerService.GetCustomers("TEST", "", null);

            Assert.IsTrue(actualResult.IsSuccess == false && actualResult.Message == ActionMessage.FillBothNames);
        }
        [Test]
        public void FF_SearchCustomerWithBothNames()
        {
            var actualResult = _customerService.GetCustomers("TEST", "TEST", null);
            var record = actualResult.Data.FirstOrDefault();

            Assert.IsTrue(actualResult.IsSuccess == true && record.FirstName == "TE*****" && record.LastName == "TE*****" && record.NationalIdNumber == "*******8910");
        }
        [Test]
        public void GG_SearchCustomerWithNationalIdNumber()
        {
            var actualResult = _customerService.GetCustomers(null, null, 12345678910);
            var record = actualResult.Data.FirstOrDefault();

            Assert.IsTrue(actualResult.IsSuccess == true && record.FirstName == "TE*****" && record.LastName == "TE*****" && record.NationalIdNumber == "*******8910");
        }
        [Test]
        public void HH_GetCustomer()
        {
            var searchResult = _customerService.GetCustomers(null, null, 12345678910);
            var searchRecord = searchResult.Data.FirstOrDefault();

            var getResult = _customerService.GetCustomer(searchRecord.Id);


            Assert.IsTrue(getResult.IsSuccess == true && getResult.Data.FirstName == "TEST" && getResult.Data.LastName == "TEST" &&
                          getResult.Data.NationalIdNumber == 12345678910);
        }
        [Test]
        public void II_DeleteCustomerWithWrongId()
        {
            var id = Guid.NewGuid();
            var actualResult = _customerService.DeleteCustomer(id);


            Assert.IsTrue(actualResult.IsSuccess == false && actualResult.Message == string.Format(ActionMessage.NoCustomerRelatedToId, id));
        }
        [Test]
        public void KK_GetCustomerWithWrongId()
        {
            var id = Guid.NewGuid();
            var actualResult = _customerService.GetCustomer(id);

            Assert.IsTrue(actualResult.IsSuccess == true && actualResult.Data == null);
        }
    }
}