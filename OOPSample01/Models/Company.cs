using OOPSample01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Models
{
    public class Company
    {
     

        public string Name { get; private set; }
        public string Address { get; private  set; }

        // Vergi No
        public string TaxNumber { get; private  set; }

        // Şirket hattı
        public string PhoneNumber { get; private set; }


        // adresleri sisteme company olarak girmeden önce bu servis ile adres sorgulaması yapacağız.
        // private bir field.
        private ICompanyAddressService _companyAddressService;
        private ITaxNumberLookupService _taxNumberLookUpService;

        public Company(string name, string address, string taxNumber, ICompanyAddressService companyAddressService, ITaxNumberLookupService taxNumberLookupService)
        {
            _companyAddressService = companyAddressService;
            _taxNumberLookUpService = taxNumberLookupService;
            SetCompanyName(name);
            SetAddress(address);
            SetTaxNumber(taxNumber);
        }


        //private NBuyCompanyAddressService _nbuyCompanyService;
        //private NBuyTaxNumberLookUpService _nbuyTaxService;
        //public Company(string name, string address, string taxNumber, NBuyCompanyAddressService companyAddressService, NBuyTaxNumberLookUpService taxNumberLookupService)
        //{
        //    _nbuyCompanyService = companyAddressService;
        //    _nbuyTaxService = taxNumberLookupService;
        //    SetCompanyName(name);
        //    SetAddress(address);
        //    SetTaxNumber(taxNumber);
        //}

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new Exception("Telefon numarası boş geçilemez");
            }

            PhoneNumber = phoneNumber;
        }

        private void SetTaxNumber(string taxNumber)
        {
            var result = _taxNumberLookUpService.LookUp(taxNumber);

            if (!result)
            {
                throw new Exception("Böyle bir vergi numarası sistemde mevcut değildir.");
            }

            TaxNumber = taxNumber;
        }

        // string alanları sisteme kaydederken her zaman içintrim kontrolü yapalım.
        private void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("Adres alanı boş geçilemez");
            }

            if(address.Length < 20)
            {
                throw new Exception("Minimum 20 karakterden oluşmalıdır");
            }

            // AddressService ile bu adresin gerçekte oluş olmadığını teyit etmemiz gerekebilir.

           var result = _companyAddressService.CheckAddress(address);
            // adres onaylanmadıysa hata ver.
            if(result == false)
            {
                throw new Exception("Böyle bir adress sistemde bulunamamıştır.");
            }

            Address = address.Trim();
        }

        private void SetCompanyName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Şirket adı boş geçilemez");
            }
            // kullanıcı input içerisinden Name alanını ön arkasında boşluklu girebilir bu boşlukları sisteme girmeden önce kaldırıyoruz.
            //    ali        => "ali"
            Name = name.Trim();
        }

    }
}
