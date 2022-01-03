using OOPSample01.Models;
using OOPSample01.Services;
using System;

namespace OOPSample01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Not: Company Adress Service ve TaxNumberLookUpService farklı şekillerde sorgulama yapabilme kabiliyetine sahip olsunlar diye company constructor içerisinde interfaceler üzerinden bağlantı kuruldıu bu sayede company constructor içerisine gönderilen classlara ile adapte bir şekilde çalışması sağlandı. Polymophism interface vasıtası ile uygulanadı. 

            // contructor with interfaces
            var company = new Company(
                name: "NBUY LTD ŞTİ",
                address: "Cihannüma, Hasfırın Cd. No:26, 34353 Beşiktaş/İstanbul",
                taxNumber: "32324324",
                companyAddressService: new EDevletCompanyAddressService(),
                taxNumberLookupService: new NBuyTaxNumberLookUpService()
                );

            //company.SetPhoneNumber("0(212) 346 1010");


            // contructor2
            //var company2 = new Company(
            //  name: "NBUY LTD ŞTİ",
            //  address: "Cihannüma, Hasfırın Cd. No:26, 34353 Beşiktaş/İstanbul",
            //  taxNumber: "32324324",
            //  companyAddressService: new GoogleAddressService(),
            //  taxNumberLookupService: new NBuyTaxNumberLookUpService()
            //  );
            //company.SetPhoneNumber("0(212) 346 1010");


            //company.Name = "asdasdasd";
            //company.TaxNumber = "34214324";

            // Encapsulation yerince uygulanamadığında yaptığımız işlemler.

            //var company2 = new Company();
            //company2.Name = "   GOP LTD   ";
            //company2.Address = "  Cihannüma, Hasfırın Cd. No:26, 34353 Beşiktaş/İstanbul  ";
            //company2.TaxNumber = "  32324324 ";


            //var companyAddressService = new NBuyCompanyAddressService();
            //var isExistAddress = companyAddressService.CheckAddress(company2.Address);

            //if(!isExistAddress)
            //{
            //    throw new Exception("Böyle bir adres bulunamadı");
            //}

            //var taxNumberLookUpService = new NBuyTaxNumberLookUpService();
            // var result2 =  taxNumberLookUpService.LookUp(company2.TaxNumber);

            //if (result2 == false)
            //    throw new Exception("Böyle bir vergi numarası bulunamadı!");


            var company1 = new Company(
              name: "NBUY LTD ŞTİ",
              address: "Cihannüma, Hasfırın Cd. No:26, 34353 Beşiktaş/İstanbul",
              taxNumber: "32324324",
              companyAddressService: new NBuyCompanyAddressService(),
              taxNumberLookupService: new NBuyTaxNumberLookUpService()
              );

            var company2 = new Company(
             name: "NBUY İzmir LTD ŞTİ",
             address: "Yıldız Teknik Üniversitesi, Merkez Yerleşim, A Blok, D:210, 34349 Beşiktaş/İstanbul",
             taxNumber: "09032142",
             companyAddressService: new NBuyCompanyAddressService(),
             taxNumberLookupService: new NBuyTaxNumberLookUpService()
             );

            var invoice = new Invoice(exporter:company1,consignee:company2);

            //var invoice2 = new Invoice(exporter: company1, consignee: company2);
            //invoice2.Items.Add()
            // yukarıdakş kullanımı kapatarak sadece AddInvoiceItem methodu ile invoice'a item ekleme işlemi yaptık.

            invoice.AddInvoiceItem(
                new InvoiceItem(
                    description: "Tasarım Bedeli", 
                    unitPrice: 1000, 
                    unitType: InvoiceUnitType.Daily,
                    amount:5));
            invoice.AddInvoiceItem(
               new InvoiceItem(
                   description: "Yazalım Bedeli",
                   unitPrice: 300,
                   unitType: InvoiceUnitType.Hourly,
                   amount: 8));
            invoice.AddInvoiceItem(
              new InvoiceItem(
                  description: "Sosyal Medya Hizmet Bedeli",
                  unitPrice: 5000,
                  unitType: InvoiceUnitType.Monthly,
                  amount: 1));
            









            Console.WriteLine("Hello World!");
        }
    }
}
