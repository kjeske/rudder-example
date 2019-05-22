using System.Collections.Generic;

namespace RudderExample.Database
{
    public class CustomerEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}