using System.ComponentModel.DataAnnotations;

namespace Deb_test.Models;

public class Employee : EntityBase
{
    // Номер пропуска
    public long PassNumber { get; set; }
    
    // Фамилия
    [MaxLength(100)]
    public string LastName { get; set; }
    
    // Имя
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    // Отчество
    [MaxLength(100)]
    public string MidleName { get; set; }
    
    //Должность
    [MaxLength(50)]
    public JobTitle JobTitle { get; set; }
    
    public List<WorkShift> WorkShifts { get; set; }
    
}