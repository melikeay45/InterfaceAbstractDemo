using InterfaceAbstractDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo.Abstract
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        //  virtual yazdık çünkü Starbucks override ediyor.
        public virtual void Save(Customer customer)
        {
            Console.WriteLine("Saved to db:" + customer.FirstName);
        }
    }
}
