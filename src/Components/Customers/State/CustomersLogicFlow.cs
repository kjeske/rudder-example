using System.Linq;
using System.Threading.Tasks;
using Rudder;
using RudderExample.Database;

namespace RudderExample.Components.Customers.State;

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
            case CustomersActions.FetchItems:
                return FetchItems();

            case CustomersActions.Add action:
                return Add(action);

            case CustomersActions.Remove action:
                return Remove(action);

            default:
                return Task.CompletedTask;
        }
    }

    private async Task FetchItems()
    {
        _store.Put(new CustomersActions.FetchItems.Request());
        await Task.Delay(1000);
        var result = await _customersService.GetCustomers();

        _store.Put(new CustomersActions.FetchItems.Success(
            Items: result.Select(entity => entity.MapToListItem()).ToArray()
        ));
    }

    private async Task Add(CustomersActions.Add action)
    {
        _store.Put(new CustomersActions.Add.Request());
        var item = await _customersService.Add(action.Name, action.Email, action.MobileNumber, action.Tags);
        _store.Put(new CustomersActions.Add.Success(item.MapToListItem()));
    }

    private async Task Remove(CustomersActions.Remove action)
    {
        _store.Put(new CustomersActions.Remove.Request(action.Id));
        await _customersService.Remove(action.Id);
        _store.Put(new CustomersActions.Remove.Success(action.Id));
    }
}