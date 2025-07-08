using FawryBookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryBookStore.Services
{
    public class ShippingService
    {
        public bool ShippingBook(string Address)
        {
            if(string.IsNullOrEmpty(Address))
            {
                return false;
            }
            return true;
        }
    }
}
