namespace CompanyManagement.Tests
{
    using System.Collections.Generic;
    using Common.ViewModels;
    using Moq;
    using NUnit.Framework;
    using Service.Contracts;

    public class EmployeeServiceTests
    {
        private Mock<IEmployeeService> service;

        [SetUp]
        public void Initialize()
        {
            service = new Mock<IEmployeeService>();
            service.Setup(x => x.GetAllEmployeesByCompanyId(It.IsAny<int>())).Returns(new List<EmployeeViewModel>());
            service.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(new EmployeeEditViewModel() { Id = 1 });
            service.Setup(x => x.GetEmployeeForDeletion(It.IsAny<int>())).Returns(new EmployeeDeleteViewModel() { Id = 1 });
        }

        [Test]
        public void Test_GetAllEmployeesByCompanyId_To_Retrun_List()
        {
            var employee = service.Object.GetAllEmployeesByCompanyId(1);

            Assert.IsNotNull(employee);
            Assert.IsEmpty(employee);
        }

        [Test]
        public void Test_GetEmployeeById_To_Return_Company_With()
        {
            var employee = service.Object.GetEmployeeById(1);

            Assert.AreEqual(employee.Id, 1);
        }

        [Test]
        public void Test_GetCompanyById_To_Return_Company_With_Diffrent_Id()
        {
            var employee = service.Object.GetEmployeeById(0);
            Assert.AreNotEqual(employee.Id, 0);
        }
    }
}