using Deb_test.Models;

namespace Deb_test.DTO.Employee;

public class JobTitlesDto
{
    public ushort Id { get; set; }
    public string Name { get; set; }

    public static explicit operator JobTitlesDto(JobTitle jt) => new JobTitlesDto()
    {
        Id = jt.Id,
        Name = jt.Name
    };
}