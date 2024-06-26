using Deb_test.DTO.WorkShift;

namespace Services.WorkShift;

public interface IWorkShiftService
{
    Task<bool> StartShift(KppDataDto data);
    Task<bool> EndShift(KppDataDto data);
}