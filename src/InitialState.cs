using System.Linq;
using System.Threading.Tasks;
using Rudder;
using RudderExample.Components.Customers.State;
using RudderExample.Database;

namespace RudderExample;

public class InitialState : IStateInitializer<AppState>
{
    private readonly ICustomersService _customersService;

    public InitialState(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    public async Task<AppState> GetInitialStateAsync()
    {
        var customers = await _customersService.GetCustomers();

        return new AppState(
            Customers: new CustomersState(
                Items: customers.Select(entity => entity.MapToListItem()).ToList()
            )
        );
    }
}