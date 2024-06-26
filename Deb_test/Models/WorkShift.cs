using System.Diagnostics.CodeAnalysis;

namespace Deb_test.Models;

public class WorkShift : EntityBase
{
    public DateTime Begin { get; set; }
    
    [MaybeNull]
    public DateTime End { get; set; }
    [MaybeNull]
    public decimal TotalHours { get; set; }
    
    public Employee Employee { get; set; }
}