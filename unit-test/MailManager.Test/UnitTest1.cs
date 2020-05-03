using System;
using Xunit;
using System.Text.RegularExpressions;

namespace MailManager.Test
{
    public class MailManagerTest
    {
        [Fact]
        public void ValidEmail()
        {
            //Arrange
            var mailManager = new MailManagers();
            const string mailAddress = "john.smith@company.com";
        
            //Act
            bool isValid = mailManager.IsValidAddress(mailAddress);
        
            //Assert
            Assert.True(isValid, $"The email {mailAddress} is not valid");
        }

        [Fact]
        public void NotValidEmail()
        {
            //Arrange
            var mailManager = new MailManagers();
            const string mailAddress = "john.smith.company.com";
        
            //Act
            bool isValid = mailManager.IsValidAddress(mailAddress);
        
            //Assert
            Assert.False(isValid, $"The email {mailAddress} is valid, but it shouldn’t");
        }

        [Theory]
        [InlineData("john.smith@company.com", true)]
        [InlineData("johnsmith@company.com", true)]
        [InlineData("john.smith@company.comma", true)]
        [InlineData("john.smith@company.it", true)]
        [InlineData("john.smith.company.com", false)]
        [InlineData("john@smith@company.com", false)]
        [InlineData("john", false)]
        [InlineData("", false)]
        public void CheckEmail(string mailAddress, bool expectedTestResult)
        {
            var mailManager = new MailManagers();
            
            Assert.Equal(expectedTestResult, mailManager.IsValidAddress(mailAddress));
        }
    }
}
