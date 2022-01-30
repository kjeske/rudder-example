using RudderExample.Components.Customers.State;
using RudderExample.Tools;

namespace RudderExample.Components.Customers;

public class AddCustomerForm : Form
{
    public AddCustomerForm()
    {
        Name = Field("", NotEmpty);

        Email = Field("", NotEmpty, CorrectEmail);

        MobileNumber = Field("", NotEmpty);

        Tags = Field("");
    }

    public string Id { get; set; }

    public Field<string> Name { get; }

    public Field<string> Email { get; }

    public Field<string> MobileNumber { get; }

    public Field<string> Tags { get; }

    public CustomersActions.Add MapToAddAction() => new(
        Name: Name.Value,
        Email: Email.Value,
        MobileNumber: MobileNumber.Value,
        Tags: Tags.Value ?? ""
    );
}