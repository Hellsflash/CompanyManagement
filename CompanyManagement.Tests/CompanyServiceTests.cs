namespace CompanyManagement.Tests
{
    using System.Collections.Generic;
    using Common.ViewModels;
    using Moq;
    using NUnit.Framework;
    using Service.Contracts;

    [TestFixture]
    public class CompanyServiceTests
    {
        private Mock<ICompanyService> service;

        [SetUp]
        public void Initialize()
        {
            service = new Mock<ICompanyService>();
            service.Setup(x => x.GetAllCompanies()).Returns(new List<CompanyViewModel>());
            service.Setup(x => x.GetCompanyById(It.IsAny<int>())).Returns(new CompanyEditViewModel() { Id = 1 });
            service.Setup(x => x.CreateCompany(It.IsAny<CompanyViewModel>()));
        }

        [Test]
        public void Test_GetAllCompanies_To_Retrun_List()
        {
            var companies = service.Object.GetAllCompanies();

            Assert.IsNotNull(companies);
        }

        [Test]
        public void Test_GetCompanyById_To_Return_Company_With()
        {
            var company = service.Object.GetCompanyById(1);

            Assert.AreEqual(company.Id, 1);
        }

        [Test]
        public void Test_GetCompanyById_To_Return_Company_With_Diffrent_Id()
        {
            var company = service.Object.GetCompanyById(0);

            Assert.AreNotEqual(company.Id, 0);
        }
    }
}