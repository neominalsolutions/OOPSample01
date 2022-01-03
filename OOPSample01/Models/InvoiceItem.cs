using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Models
{
   

    public enum InvoiceUnitType
    {
        Monthly = 100,
        Daily = 200,
        Hourly = 300,
        Quantity = 400
    }

    public class InvoiceItem
    {
      
        public string Description { get; private set; }
        
        // Birim Fiyat 10 TL 
        public decimal UnitPrice { get; private set; }

        // 3 quantity
        public int  UnitType { get; private set; }

        // hizmet tutarı 30 TL

        private decimal _listPrice = 1;
        public decimal ListPrice { get {

                return _listPrice;
            
            } 
        }

        // Sıra No  olarak kullanacağız (1,2,3,4,5)
        // ilk sıra no 1 olduğu sequence default değer 1 olarak ayarlarız.
        public int SequenceNo { get; private set; } = 0;
        public string Id { get; private set; }

        // Miktar // adet yada miktar bilgisi 3 saat 1 ay 10 adet vs
        public int Amount { get; private set; }

        public InvoiceItem(string description,decimal unitPrice, InvoiceUnitType unitType, int amount)
        {
            Id = Guid.NewGuid().ToString();
            UnitType = (int)unitType; // class enum alıp int olarak işaretledik.
            SetAmount(amount);
            SetDescription(description);
            SetUnitPrice(unitPrice);
            // amount ve unitprice değerleri alındıktan sonra list price hesaplıyoruz.
            SetListPrice();
        }

        // ListPrice değerinin setter yazmadık veri tabanında bu alanı tutmaya gerek yok. fakat program tarafında invoice bir item eklendiğinde toplam fatura tutarını bulmak için tek bir item ait toplam maliyetin hesaplanmış olması gerekiyor bu sebep ile kullandık.
        private void SetListPrice()
        {
            _listPrice = Amount * UnitPrice;
        }
        private void SetAmount(int amount)
        {
            if(amount <= 0)
            {
                throw new Exception("Miktar sıfırdan küçük girilemez");
            }

            Amount = amount;
        }
       
        private void SetUnitPrice(decimal unitPrice)
        {
            if(unitPrice <= 0)
            {
                throw new Exception("Birim fiyat 0 ve daha küçük olamaz");
            }

            UnitPrice = unitPrice;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("Mal Hizmet alanı boş geçilemez");
            }

            Description = description.Trim();
        }

        // Invoice Numarasını 1 artırırız.
        public void SetSequenceNumber(int sequenceNumber)
        {
            SequenceNo = sequenceNumber;
        }



    }
}
