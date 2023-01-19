// See https://aka.ms/new-console-template for more information
using DatalagrinWPF_App.Models;
using DatalagrinWPF_App.Service;


Customer customer = new Customer
{
    FirstName = "Test",
    LastName = "Testson",
    Email = "test@domain.se",
    Phone ="073111222333",
    Adress = new Adress
    {
        StreetName = "Testgatan 1",
        PostalCode = "12345",
        City = "Tester Haninge",
        Country = "Testholm"
    }
};





SqlService sql = new SqlService();

var customerId = sql.CreateCustomer(customer);


var read_customer = sql.GetCustomer(customerId);
Console.WriteLine($"{read_customer.FirstName} {read_customer.LastName}");