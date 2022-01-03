using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Services
{

    // EDevletin Address sorgulama API'si kullanılarak yazılabilir. 
   public class EDevletCompanyAddressService : ICompanyAddressService
    {
        public bool CheckAddress(string address)
        {
            return false;
        }
    }
}
