using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Models
{
    /// <summary>
    /// Fatura bilgilerini tutarız
    /// </summary>
    public class Invoice
    {

        public DateTime InvoiceDate { get; private set; }

        // faturayı kesen firma
        public Company Exporter { get; private set; }

        //  mal hizmet alan firma
        public Company Consignee { get; private set; }
        public decimal TotalPrice { get; private set; }

        private List<InvoiceItem> _items = new List<InvoiceItem>();

        // list item readonly olarak işatretleyip sadece bu alanın get edilebileceğini söylemiş olduk.
        public IReadOnlyList<InvoiceItem> Items => _items;
        // ReadOnly olan koleksiyonların add methodu yoktur.
        // yukarıdaki kod aynı kod.
        //public IReadOnlyList<InvoiceItem> Items2   {
            
        //    get
        //    {
        //        return _items;
        //    }
        //}

        public string Id { get; private set; }

        /// <summary>
        /// Fatura kesmek için faturayı kesen ve fatura kesinlen firma bilgilerini bilmemiz yeterlidir.
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="consignee"></param>
        public Invoice(Company exporter, Company consignee)
        {
            // fatura kesim tarihi işlem yapılan bir tarih olmalıdır.
            // dışardan bu bilgiyi almıyoruz.
            Id = Guid.NewGuid().ToString();
            InvoiceDate = DateTime.Now;
            Exporter = exporter;
            Consignee = consignee;
        }
        
  
        /// <summary>
        /// Faturaya fatura ile alakalı hizmetlerin listesini eklediğimiz method
        /// </summary>
        /// <param name="item"></param>
        public void AddInvoiceItem(InvoiceItem item)
        {
            // item eklemeden önce elimizdeki invoice item count üzerinden kaçıncı sırada olduğumuzu bildiğimiz için +1 artırarak sequence number güncelledik.
            item.SetSequenceNumber(Items.Count + 1);
            _items.Add(item);
            // her bir item eklendiğinde bu item ait list pricelerın toplamı
            TotalPrice += item.ListPrice;
          


        }

    }
}
