using Microsoft.EntityFrameworkCore;
using ShiftsLogger.WebApi.Data;
using ShiftsLogger.WebApi.Models;

namespace ShiftsLogger.WebApi.Repository;

public class WorkerShiftRepository
{
    private readonly WorkerShiftContext _context;

    public WorkerShiftRepository(WorkerShiftContext context)
    {
        _context = context;
    }

    public async Task<List<Shift>> ReadAllWorkersAllShifts()
    {
        List<Shift> allShifts = await _context.Shifts.ToListAsync();

        return allShifts;
    }
}
