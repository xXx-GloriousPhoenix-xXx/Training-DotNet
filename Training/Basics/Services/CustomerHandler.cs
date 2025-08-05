using Basics.Classes;
namespace Basics.Services;

public static class CustomerHandler
{
    public static Customer GeneratePatternCustomer(int index_1, int index_2)
    {
        var postfix = $"{index_1}_{index_2}";
        var address = AddressHandler.GeneratePatternAddress(index_1, index_2);
        var customer = new Customer(
            $"Name_{postfix}",
            $"{postfix}@gmail.com",
            address
        );
        return customer;
    }
}
