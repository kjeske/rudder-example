using System.Collections.Immutable;
using RudderExample.State.Customers;

namespace RudderExample.State
{
    public class AppState
    {
        public AppState()
        {
            Customers = new CustomersAppState();
            Fetching = ImmutableHashSet<string>.Empty;
        }

        public CustomersAppState Customers { get; set; }

        public ImmutableHashSet<string> Fetching { get; set; }
    }
}
