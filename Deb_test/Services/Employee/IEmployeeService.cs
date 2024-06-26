using Deb_test.DTO.Employee;
using Deb_test.DTO.WorkShift;

namespace Services.Employee;

public interface IEmployeeService
{
    Task<List<EmployeeReadDto>> GetAll();
    Task<EmployeeReadDto> GetByID(long id);
    Task<bool> Add(EmployeeCreateDto employee);
    Task<bool> Update(EmployeeCreateDto user, long id);
    Task<bool> Delete(long id);
    Task<List<JobTitlesDto>> GetJobTitles();
    Task<List<WorkShiftReadDto>> Observation();
}