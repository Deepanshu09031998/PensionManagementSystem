using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PensionDisbursement;
using PensionDisbursement.Controllers;
using System.IO;

namespace PensionDisbursementTesting
{
    public class Tests
    {
        public static IConfiguration configuration;
        PensionDisbursementController controller;
        ProcessPensionInput pensionInput = new ProcessPensionInput();
        //Result result = new Result();

        [SetUp]
        public void Setup()
        {
            configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            controller = new PensionDisbursementController(configuration);


            pensionInput.AadharNumber = "111122223333";
            pensionInput.PensionAmount = 25550;
            pensionInput.BankType = 2;

        }

        [Test]
        public void ProcessDisbursement_Pension_IsNotNull()
        {
            var result = controller.GetDisbursePension(pensionInput);
            var type1 = result;
            Assert.IsNotNull(type1);
        }

        [Test]
        public void ProcessDisbursement_Pension_IsPositive()
        {
            var result = controller.GetDisbursePension(pensionInput);
            var type1 = result;
            Assert.Positive(type1);
        }

        [Test]
        public void ProcessPension_Person_Valid()
        {
            var result = controller.GetDisbursePension(pensionInput);
            var type = result;
            var status = 10;
            Assert.AreEqual(type, status);
        }

        [Test]
        public void ProcessPension_Person_Invalid()
        {
            var result = controller.GetDisbursePension(pensionInput);
            var type = result;
            var status = 21;
            Assert.AreNotEqual(type, status);
        }

    }
}