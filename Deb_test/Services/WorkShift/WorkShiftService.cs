using System.ComponentModel;
using Deb_test.DTO.WorkShift;
using Deb_test.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Services.WorkShift;

public class WorkShiftService : IWorkShiftService
{
    private readonly DbContext _context;

    public WorkShiftService(DbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> StartShift(KppDataDto data)
    {
        var employee = await _context.Set<Deb_test.Models.Employee>().Include(e=>e.WorkShifts)
            .FirstOrDefaultAsync(e => e.PassNumber == data.PassNumber);
        if (employee == null)
        {
            throw new ItemNotFoundException();
        }

        if (employee.WorkShifts.Count!=0 && employee.WorkShifts.Last().End==default)
        {
            throw new WorkShiftException();
        }
        var ws = new Deb_test.Models.WorkShift();
        ws.Begin = data.DateTime;
        employee.WorkShifts.Add(ws);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EndShift(KppDataDto data)
    {
        var employee = await _context.Set<Deb_test.Models.Employee>().Include(e=>e.WorkShifts)
            .FirstOrDefaultAsync(e => e.PassNumber == data.PassNumber);
        if (employee == null)
        {
            throw new ItemNotFoundException();
        }

        if (employee.WorkShifts.Last().Begin==default)
        {
            throw new WarningException();
        }

        employee.WorkShifts.Last().End = data.DateTime;
        employee.WorkShifts.Last().TotalHours =
            (decimal)(employee.WorkShifts.Last().End - employee.WorkShifts.Last().Begin).TotalHours;
        await _context.SaveChangesAsync();
        return true;
    }
}