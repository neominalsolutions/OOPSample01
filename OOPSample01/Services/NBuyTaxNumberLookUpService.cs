using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample01.Services
{
    public class NBuyTaxNumberLookUpService : ITaxNumberLookupService
    {
        public List<string> _taxNumber
        {
            get
            {
                return new List<string> { 
                    "32324324", 
                    "32498435", 
                    "658752131", 
                    "098098432", 
                    "09032142" 
                };
            }
        }

        public bool LookUp(string taxNumber)
        {
            return _taxNumber.Any(x => x == taxNumber);
        }
    }
}
