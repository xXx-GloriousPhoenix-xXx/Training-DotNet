using Basics.Classes;
namespace Basics.Services;

public static class AddressHandler
{
    public static Address GenerateTemplateAddress(int identifier)
    {
        var postfix = $"{identifier}";
        var address = new Address(
            $"Country_{postfix}",
            $"City_{postfix}",
            $"Street_{postfix}",
            (ushort)(identifier + 1)
        );
        return address;
    }
}
