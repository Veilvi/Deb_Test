namespace Deb_test.Exceptions;

public class ItemNotFoundException:Exception
{
    public ItemNotFoundException() : base($"Объект не найден.")
    {
    }
}