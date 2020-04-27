using System;
using IDDQD.Data;
using IDDQD.Services;
using IDDQD.Areas.Identity;
using IDDQD.Areas.Identity.Data;
using IDDQD.Areas.Identity.Pages;

namespace EmailVer
{
    public class EmailVer
    {
        private readonly EmailVer _emailver;

        public EmailVerTest()
        {
            _emailver = new EmailVer();
        }   
        [Fact]
        public void IsValid_ValidEmail_ReturnsTrue()
        {
            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{2,6}$");
            return regex.IsMatch(emailAddress);
        }
    }
}
