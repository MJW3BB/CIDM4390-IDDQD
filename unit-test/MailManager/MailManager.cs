using System;
using System.Text.RegularExpressions;

namespace MailManager
{
    public class MailManagers
    {
        public bool IsValidAddress(string emailAddress)
        {
            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{2,6}$");
            return regex.IsMatch(emailAddress);
        }
    }
}
