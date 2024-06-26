namespace Deb_test.DTO.WorkShift;

public class WorkShiftReadDto
{
    public string Fio { get; set; }
    public string Date { get; set; }
    public string Hours { get; set; }

    public static explicit operator WorkShiftReadDto(Models.WorkShift s) => new WorkShiftReadDto
    {
        Fio = s.Employee.LastName + " " + s.Employee.FirstName + " " + s.Employee.MidleName,
        Date = s.Begin.ToString("dd:MM:yyyy"),
        Hours = s.TotalHours.ToString()
    };
}