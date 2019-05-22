using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using RudderExample.Database;
using Rudder;
using RudderExample.State;
using RudderExample.State.Customers;

namespace RudderExample.Components.Customers
{
    public class CustomersLogicFlow : ILogicFlow
    {
        private readonly Store<AppState> _store;
        private readonly ICustomersService _customersService;

        public CustomersLogicFlow(Store<AppState> store, ICustomersService customersService)
        {
            _store = store;
            _customersService = customersService;
        }

        public Task OnNext(object actionValue)
        {
            switch (actionValue)
            {
                case CustomersActions.FetchItems.Invoke _:
                    return FetchItems();

                case CustomersActions.Add.Invoke action:
                    return Add(action);

                case CustomersActions.Remove.Invoke action:
                    return Remove(action);

                default:
                    return Task.CompletedTask;
            }
        }

        private Task Put<T>(T action) => _store.Put(action);

        private async Task FetchItems()
        {
            await Put(new CustomersActions.FetchItems.Request());

            var result = await _customersService.GetCustomers();

            await Put(new CustomersActions.FetchItems.Success
            {
                Items = result.Select(entity => entity.MapToListItem()).ToArray()
            });
        }

        private async Task Add(CustomersActions.Add.Invoke action)
        {
            await Put(new CustomersActions.Add.Request());

            var item = await _customersService.Add(action.Name, action.Email, action.MobileNumber, action.Tags);

            await Put(new CustomersActions.Add.Success { Item = item.MapToListItem() });
        }

        private async Task Remove(CustomersActions.Remove.Invoke action)
        {
            await Put(new CustomersActions.Remove.Request { Id = action.Id });

            await _customersService.Remove(action.Id);

            await Put(new CustomersActions.Remove.Success { Id = action.Id });
        }
    }
}
