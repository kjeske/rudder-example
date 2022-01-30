using System.Collections.Generic;

namespace RudderExample.Components.Customers.State;

public record CustomersState(
    IReadOnlyList<CustomerListItem> Items,
    bool ShowAddDialog = false, 
    bool IsFetching = false,
    bool IsSaving = false
);
