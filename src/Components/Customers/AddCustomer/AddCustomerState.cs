using Rudder;
using RudderExample.State;
using RudderExample.State.Customers;

namespace RudderExample.Components.Customers.AddCustomer
{
    public struct AddCustomerState : IStateMap<AppState, AddCustomerState>
    {
        public string ItemToAddError { get; set; }

        public bool IsFetching { get; private set; }

        public AddCustomerState MapState(AppState state) => new AddCustomerState
        {
            IsFetching = state.Fetching.Contains(CustomersAppState.Fetching.Add)
        };
    }
}