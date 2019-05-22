using System.Collections.Immutable;

namespace RudderExample.State.Customers
{
    public class CustomersAppState
    {
        public CustomersAppState()
        {
            Items = ImmutableList<CustomerListItem>.Empty;
        }

        public ImmutableList<CustomerListItem> Items { get; set; }

        public bool ShowAddDialog { get; set; }

        public static class Fetching
        {
            public const string List = "Customers_List";
            public const string Add = "Customers_Add";
        }
    }
}
