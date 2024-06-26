namespace Deb_test.DTO.Employee;

public class EmployeeReadDto : EmployeeBaseDto
{
    public long Id { get; set; }
    public string JobTitle { get; set; }
    public long PassNumber { get; set; }

    public static explicit operator EmployeeReadDto(Models.Employee e) => new EmployeeReadDto
    {
        Id = e.Id,
        FirstName = e.FirstName,
        LastName = e.LastName,
        MidleName = e.MidleName,
        JobTitle = e.JobTitle.Name,
        PassNumber = e.PassNumber
    };
}