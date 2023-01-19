using DatalagrinWPF_App.Data;
using DatalagrinWPF_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DatalagrinWPF_App.Service
{
    internal class SqlService
    {
        private readonly SqlContext _context = new SqlContext();

        #region Create 
        public int CreateAdress(Adress adress)
        {

            var _adress = _context.Adresses.Where(x => x.StreetName == adress.StreetName && x.PostalCode == adress.PostalCode && x.City == adress.City && x.Country == adress.Country).FirstOrDefault();

            if (_adress == null)
            {
                var adressEntity = new AdressEntity { StreetName = adress.StreetName, PostalCode = adress.PostalCode, City = adress.City, Country = adress.Country };

                _context.Adresses.Add(adressEntity);
                _context.SaveChanges();
                return adressEntity.Id;
            }

            return _adress.Id;

        }

        public int CreateCustomer(Customer customer)
        {
            
            var _customer = _context.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();

            if(_customer == null)
            {
                var customerEntity = new CustomerEntity();

                customerEntity.FirstName = customer.FirstName;
                customerEntity.LastName = customer.LastName;
                customerEntity.Email = customer.Email;
                customerEntity.Phone = customer.Phone;
                customerEntity.AdressId = CreateAdress(customer.Adress);

                _context.Customers.Add(customerEntity);
                _context.SaveChanges();
                

                return customerEntity.Id;
            }

            return _customer.Id;

        }

        #endregion

        #region Read

        public AdressEntity GetAdress(int id)
        {
            return _context.Adresses.SingleOrDefault(x => x.Id == id);
        }

        public CustomerEntity GetCustomer(int id)
        {
            return _context.Customers.Include(x => x.Adress).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<AdressEntity> GetAdresses ()
        {
            return _context.Adresses;
        }

        public IEnumerable<CustomerEntity> GetCustomers ()
        {
            return _context.Customers.Include(x => x.Adress).ToList();
        }



        #endregion

        #region Updates

        public void UppdateAdress(int id, AdressEntity adress)
        {
            var item = _context.Adresses.Find(id);
            if(item != null && item.Id == id)
            {
                item.StreetName= adress.StreetName;
                item.PostalCode= adress.PostalCode;
                item.City= adress.City;
                item.Country= adress.Country;

                _context.Update(item);
                _context.SaveChanges();
            }
        }

        public void UppdateCustomer(int id, CustomerEntity customer)
        {
            var item = _context.Customers.Find(id);

            if (item != null && item.Id == id)
            {
               item.FirstName = customer.FirstName;
               item.LastName = customer.LastName;
               item.Phone = customer.Phone;
               item.AdressId = customer.AdressId;

                _context.Update(item);
                _context.SaveChanges();
            }
        }

        #endregion

        #region Delete

        public void DeleteAdress(int id)
        {
            var item = _context.Adresses.Find(id);
            if(item != null && item.Id == id)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
            
        }


        public void DeleteCustomer(int id)
        {
            var item = _context.Customers.Find(id);
            if (item != null && item.Id == id)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

        }


        #endregion


    }
}
