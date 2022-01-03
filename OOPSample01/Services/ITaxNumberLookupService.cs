using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Services
{
    // vergi numarası sorgulama servisi
    // gerçekten böyle bir vergi numarası olup olmadığını sorgulamak için yazdık.
    public interface ITaxNumberLookupService
    {
        // bizim bir veri numarası sorgulama sistemiz olsun.
        // nbu sorgulama sisteminin nasıl çalıştığı bilmiyoruz yada farklı şekillerde sorgula olabilir sistemde bu sebeple işin özetini yazıp. Detayını ise ilgili servislerde yazacağız. Abstraction
        bool LookUp(string taxNumber);
    }
}
