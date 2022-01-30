using RudderExample.Components.Customers.State;

namespace RudderExample;

public record AppState(
    CustomersState Customers
);