using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Services
{
    public class GoogleAddressService : ICompanyAddressService
    {
        public bool CheckAddress(string address)
        {
            // Google Maps Api kullanarak adress sorgulaması yapılacak.
            return false;
        }
    }
}
