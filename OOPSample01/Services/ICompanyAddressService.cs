using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Services
{

    public interface ICompanyAddressService
    {
        /// <summary>
        /// Böyle bir adres var mı yok mu kontrolü yapan interface ait method.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool CheckAddress(string address);
    }
}
