using System.Collections.Immutable;
using Rudder;
using RudderExample.Extensions;
using RudderExample.State;
using RudderExample.State.Customers;

namespace RudderExample.Components.Customers
{
    public class CustomersStateFlow : IStateFlow<AppState>
    {
        public AppState Handle(AppState appState, object actionValue)
        {
            switch (actionValue)
            {
                case CustomersActions.FetchItems.Request _:
                    return appState.With(state =>
                    {
                        state.Fetching = state.Fetching.Add(CustomersAppState.Fetching.List);
                    });

                case CustomersActions.FetchItems.Success action:
                    return appState.With(state =>
                    {
                        state.Fetching = state.Fetching.Remove(CustomersAppState.Fetching.List);
                        state.Customers.Items = action.Items.ToImmutableList();
                    });

                case CustomersActions.Add.Request _:
                    return appState.With(state =>
                    {
                        state.Fetching = state.Fetching.Add(CustomersAppState.Fetching.Add);
                    });

                case CustomersActions.Add.Success action:
                    return appState.With(state =>
                    {
                        state.Fetching = state.Fetching.Remove(CustomersAppState.Fetching.Add);
                        state.Customers.Items = state.Customers.Items.Add(action.Item);
                        state.Customers.ShowAddDialog = false;
                    });

                case CustomersActions.Add.Failure _:
                    return appState.With(state =>
                    {
                        state.Fetching = state.Fetching.Remove(CustomersAppState.Fetching.Add);
                    });

                case CustomersActions.Remove.Request action:
                    return appState.With(state =>
                    {
                        state.Customers.Items = state.Customers.Items.SetItem(
                            predicate: customer => customer.Id == action.Id, 
                            newItem: customer => customer.With(c => c.IsFetching = true));
                    });

                case CustomersActions.Remove.Success action:
                    return appState.With(state =>
                    {
                        state.Customers.Items = state.Customers.Items.RemoveAll(i => i.Id == action.Id);
                    });

                case CustomersActions.AddDialog.Show _:
                    return appState.With(state =>
                    {
                        state.Customers.ShowAddDialog = true;
                    });

                case CustomersActions.AddDialog.Hide _:
                    return appState.With(state =>
                    {
                        state.Customers.ShowAddDialog = false;
                    });

                default:
                    return appState;
            }
        }
    }
}