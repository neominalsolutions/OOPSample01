using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Services
{
    // şirketin kayıt işlemleri register işlemleri sırasında böyle bir adresin olup olmadığını teyit etmek için sorgulama yapan servis.
    // bu sorgulama servisi şuan için bir liste üzerinden kontrol edilecek olup ilerleyen zamanlarda e-devlet adres sorgulama sistemine bağlanabilir. 
    public class NBuyCompanyAddressService : ICompanyAddressService
    {
        List<string> companyAddress = new List<string>();

        public NBuyCompanyAddressService()
        {
            companyAddress.Add("Gülbahar, no:2, Avni Dilligil Sk. No:13, 34394 Şişli/İstanbul");
            companyAddress.Add("Cihannüma, Hasfırın Cd. No:26, 34353 Beşiktaş/İstanbul");
            companyAddress.Add("Cihannüma, Akdoğan Sk. No:35, 34353 Beşiktaş/İstanbul");
            companyAddress.Add("Yıldız Teknik Üniversitesi, Merkez Yerleşim, A Blok, D:210, 34349 Beşiktaş/İstanbul");
        }

        public bool CheckAddress(string address)
        {
            // any true false döner
            return companyAddress.Any(cAddress => cAddress == address);

        }
    }
}
