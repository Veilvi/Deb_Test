using System.ComponentModel.DataAnnotations;

namespace Deb_test.DTO.Employee;

public class EmployeeCreateDto 
{
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string MidleName { get; set; }
    
    public ushort JobTitleId { get; set; }
    
    public long PassNumber { get; set; }

    public static explicit operator Models.Employee(EmployeeCreateDto e) => new Models.Employee
    {
        FirstName = e.FirstName,
        MidleName = e.MidleName,
        LastName = e.LastName,
        PassNumber = e.PassNumber
    };
}