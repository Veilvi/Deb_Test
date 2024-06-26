using Deb_test.DTO.Employee;
using Deb_test.DTO.WorkShift;
using Deb_test.Exceptions;
using Deb_test.Models;
using Microsoft.EntityFrameworkCore;
using Services.Employee;

namespace Deb_test.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly DbContext _context;

    public EmployeeService(DbContext context)
    {
        _context = context;
    }
    public async Task<List<EmployeeReadDto>> GetAll()
    {
        var r = await _context.Set<Models.Employee>().Include(e=>e.JobTitle).ToListAsync();
        var response = new List<EmployeeReadDto>();
        
        foreach (var e in r)
        {
            response.Add((EmployeeReadDto)e);
        }
        return response;
    }

    public async Task<EmployeeReadDto> GetByID(long id)
    {
        var result = await _context.Set<Models.Employee>()
            .Include(e=>e.JobTitle).FirstOrDefaultAsync(e => e.Id == id);
        if (result == null)
        {
            throw new ItemNotFoundException();
        }

        return (EmployeeReadDto)result;
    }

    public async Task<bool> Add(EmployeeCreateDto employee)
    {
        var emp = (Models.Employee)employee;
        var jt = await _context.Set<JobTitle>().FirstOrDefaultAsync(t => t.Id == employee.JobTitleId);
        emp.JobTitle = jt;
        await _context.Set<Models.Employee>().AddAsync(emp);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(EmployeeCreateDto user, long id)
    {
        var e = await _context.Set<Models.Employee>()
            .Include(e=>e.JobTitle)
            .AsTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (e == null)
        {
            throw new ItemNotFoundException();
        }

        e.LastName = user.LastName;
        e.FirstName = user.FirstName;
        e.MidleName = user.MidleName;
        var jt= await _context.Set<JobTitle>().FirstOrDefaultAsync(jt => jt.Id == user.JobTitleId);
        if (jt == null)
        {
            throw new ItemNotFoundException();
        }

        e.JobTitle = jt;
        e.PassNumber = user.PassNumber;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(long id)
    {
        var e = await _context.Set<Models.Employee>().FirstOrDefaultAsync(e => e.Id == id);
        if (e == null)
        {
            throw new ItemNotFoundException();
        }
        _context.Set<Models.Employee>().Remove(e);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<JobTitlesDto>> GetJobTitles()
    {
        var jt = await _context.Set<JobTitle>().ToListAsync();
        var result = new List<JobTitlesDto>();
        foreach (var t in jt)
        {
            result.Add((JobTitlesDto)t);
        }

        return result;
    }

    public async Task<List<WorkShiftReadDto>> Observation()
    {
        var jt = await _context.Set<WorkShift>()
            .Include(s => s.Employee)
            .ThenInclude(e => e.JobTitle)
            .Where(s => s.Begin != default && s.End != default && s.Employee.JobTitle.Id==3? s.TotalHours<12 : s.TotalHours<9)
            .ToListAsync();
        
        var result = new List<WorkShiftReadDto>();
        
        foreach (var s in jt)
        {
            result.Add((WorkShiftReadDto)s);
        }

        return result;
    }
}