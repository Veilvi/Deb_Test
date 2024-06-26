using System.ComponentModel.DataAnnotations;

namespace Deb_test.Models;

public class JobTitle
{
    // Id должности
    public ushort Id { get; set; }
    
    // Наименование должности
    [MaxLength(50)]
    public string Name { get; set; }
    
    public List<Employee> Employee { get; set; }
}