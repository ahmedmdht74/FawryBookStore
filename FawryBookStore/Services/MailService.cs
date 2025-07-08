using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryBookStore.Services
{
    public class MailService
    {
        public bool SendEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return false;
            }
            return true;
        }
    }
}
