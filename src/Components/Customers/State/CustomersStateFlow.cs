using System.Linq;
using Rudder;
using RudderExample.Extensions;
using static RudderExample.Components.Customers.State.CustomersActions;

namespace RudderExample.Components.Customers.State;

public class CustomersStateFlow : IStateFlow<AppState>
{
    public AppState Handle(AppState state, object actionValue) =>
        state with { Customers = Handle(state.Customers, actionValue) };

    private CustomersState Handle(CustomersState state, object actionValue) => actionValue switch
    {
        FetchItems.Request => state with
        {
            IsFetching = true
        },

        FetchItems.Success action => state with
        {
            IsFetching = false,
            Items = action.Items.ToList()
        },

        Add.Request _ => state with
        {
            IsSaving = true
        },

        Add.Success action => state with
        {
            IsSaving = false,
            Items = state.Items.Append(action.Item).ToList(),
            ShowAddDialog = false
        },

        Add.Failure _ => state with
        {
            IsSaving = false
        },

        Remove.Request action => state with
        {
            Items = state.Items
                .Replace(customer => customer.Id == action.Id, customer => customer with { IsFetching = true })
                .ToList()
        },

        Remove.Success action => state with
        {
            Items = state.Items.Where(i => i.Id != action.Id).ToList()
        },

        AddDialog.Show => state with
        {
            ShowAddDialog = true
        },

        AddDialog.Hide => state with
        {
            ShowAddDialog = false
        },

        _ => state
    };
}