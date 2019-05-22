using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Rudder;
using RudderExample.Database;
using RudderExample.State.Customers;

namespace RudderExample.State
{
    public class InitialState : IInitialState<AppState>
    {
        private readonly ICustomersService _customersService;

        public InitialState(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public async Task<AppState> GetInitialState()
        {
            var customers = await _customersService.GetCustomers();

            return new AppState
            {
                Customers =
                {
                    Items = customers.Select(entity => entity.MapToListItem()).ToImmutableList()
                }
            };
        }
    }
}
