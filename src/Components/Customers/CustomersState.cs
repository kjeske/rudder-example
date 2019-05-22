using System.Collections.Immutable;
using Rudder;
using RudderExample.State;
using RudderExample.State.Customers;

namespace RudderExample.Components.Customers
{
    public struct CustomersState : IStateMap<AppState, CustomersState>
    {
        public bool ShowAddDialog { get; private set; }

        public ImmutableList<CustomerListItem> Items { get; private set; }

        public bool IsFetching { get; private set; }

        public CustomersState MapState(AppState state) => new CustomersState
        {
            Items = state.Customers.Items,
            IsFetching = state.Fetching.Contains(CustomersAppState.Fetching.List),
            ShowAddDialog = state.Customers.ShowAddDialog
        };
    }
}