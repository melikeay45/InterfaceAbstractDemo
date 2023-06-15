using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MernisServiceReference.KPSPublicSoapClient;

namespace InterfaceAbstractDemo.Adapters
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            //GetAwaiter().GetResult(); assenkron fonksiyonun çağrı sonucunu almadan diğer işlemleri yapmasına engel olur. yani metodun döndürdüğü cevabı bekler
            KPSPublicSoapClient client = new KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
            var sonuc = client.TCKimlikNoDogrulaAsync(
                long.Parse(customer.NationalityId),
                customer.FirstName.ToUpper(),
                customer.LastName.ToUpper(),
                customer.DateOfBirth.Year
            ).GetAwaiter().GetResult();

            var dogrulamaSonucu = sonuc.Body.TCKimlikNoDogrulaResult;
            return dogrulamaSonucu;

        }
    }
}
