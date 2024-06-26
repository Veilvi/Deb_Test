namespace Deb_test.Exceptions;

public class WorkShiftException : Exception
{
    public WorkShiftException() : base($"Ошибка смены")
    {
    }
}