using Microsoft.EntityFrameworkCore;
using ShiftsLogger.WebApi.Data;
using ShiftsLogger.WebApi.Models;

namespace ShiftsLogger.WebApi.Repository;

internal class WorkerShiftRepository
{
    private readonly WorkerShiftContext _context;

    public WorkerShiftRepository(WorkerShiftContext context)
    {
        _context = context;
    }

    internal async Task<List<Shift>> ReadAllWorkersAllShifts()
    {
        List<Shift> allShifts = await _context.Shifts.ToListAsync();

        return allShifts;
    }

    internal async Task<List<Shift>> ReadAllShiftsForWorker(Worker worker)
    {
        List<Shift> workerShifts =  await _context.Shifts.Where(s => s.WorkerId == worker.Id).ToListAsync();

        return workerShifts;
    }

    internal async Task AddWorker(string name)
    {
        await _context.Workers.AddAsync(new Worker { Name = name });
        await _context.SaveChangesAsync();
    }

    internal async Task AddShiftToWorker(int workerId, DateTime startTime, DateTime endTime)
    {
        await _context.Shifts.AddAsync(new Shift
        {
            WorkerId = workerId,
            StartTime = startTime,
            EndTime = endTime
        });
        await _context.SaveChangesAsync();
    }

    internal async Task UpdateWorker(int id, string newName)
    {
        Worker? worker = await _context.Workers.SingleOrDefaultAsync(w => w.Id == id);
        if (worker != null)
        {
            worker.Name = newName;
            await _context.SaveChangesAsync();
        }
    }

    internal async Task UpdateShift(int id, DateTime newStartTime, DateTime newEndTime)
    {
        Shift? shift = await _context.Shifts.SingleOrDefaultAsync(s => s.Id == id);
        if (shift != null)
        {
            shift.StartTime = newStartTime;
            shift.EndTime = newEndTime;
            await _context.SaveChangesAsync();                                           
        }
    }

    internal async Task DeleteWorker(int id)
    {
        Worker? worker = await _context.Workers.SingleOrDefaultAsync(w => w.Id == id);

        if (worker != null)
        {
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
        }
    }

    internal async Task DeleteShift(int id)
    {
        Shift? shift = await _context.Shifts.SingleOrDefaultAsync(s => s.Id == id);
        if (shift != null)
        {
            _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync();
        }
    }

}
