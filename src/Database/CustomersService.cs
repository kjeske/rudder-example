using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RudderExample.Database
{
    public interface ICustomersService
    {
        Task<IReadOnlyCollection<CustomerEntity>> GetCustomers();

        Task<CustomerEntity> Add(string name, string email, string mobileNumber, string tags);

        Task Remove(string id);
    }

    public class CustomersService : ICustomersService
    {
        private readonly List<CustomerEntity> _items; 

        public CustomersService()
        {
            _items = new List<CustomerEntity>
            {
                CreateItem("Chris", "chris@test-1.com", "+48 123", "vip"),
                CreateItem("Anna", "anna@test-1.com", "+48 456", "new,vip")
            };
        }

        public async Task<CustomerEntity> Add(string name, string email, string mobileNumber, string tags)
        {
            await Task.Delay(1000);
            var entity = CreateItem(name, email, mobileNumber, tags);
            _items.Add(entity);
            return entity;
        }

        public async Task Remove(string id)
        {
            await Task.Delay(1000);
            var customer = _items.Find(entity => entity.Id == id);
            if (customer != null)
            {
                _items.Remove(customer);
            }
        }

        public async Task<IReadOnlyCollection<CustomerEntity>> GetCustomers()
        {
            await Task.Delay(1000);

            return new ReadOnlyCollection<CustomerEntity>(_items);
        }

        private static CustomerEntity CreateItem(string name, string email, string mobileNumber, string tags) => new CustomerEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Email = email,
            MobileNumber = mobileNumber,
            Tags = tags.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim().ToUpper()).ToArray()
        };
    }
}
