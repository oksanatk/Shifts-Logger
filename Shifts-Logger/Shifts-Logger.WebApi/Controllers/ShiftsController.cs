using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.WebApi.Models;
using ShiftsLogger.WebApi.Repository;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shifts_Logger.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftsController(WorkerShiftRepository repository) : ControllerBase
{
    private readonly WorkerShiftRepository _repository = repository;

    // GET: api/Shifts
    [HttpGet]
    public async Task<IActionResult> GetAllShifts()
    {
        List<Shift> workersShifts = await _repository.ReadAllWorkersAllShifts();
        return Ok(workersShifts);  // 200 OK response
    }

    // GET api/Shifts/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkerShifts(int id)
    {
        List<Shift> workerShifts = await _repository.ReadAllShiftsForWorker(id);
        if (workerShifts == null) return NotFound(); //404 Not Found

        return Ok(workerShifts);
    }

    // POST api/Shifts
    [HttpPost]
    public async Task<IActionResult> CreateWorker([FromBody] Worker worker)
    {
        if (worker == null) return BadRequest();  // code 400 Bad Request
        await _repository.AddWorker(worker.Name);

        return CreatedAtAction(nameof(GetWorkerShifts), new { id = worker.Id }, worker);
    }

    // POST api/Shifts/{id}
    [HttpPost]
    public async Task<IActionResult> CreateShift([FromBody] Shift shift)
    {
        if (shift.WorkerId < 1 || shift.StartTime == DateTime.MinValue || shift.EndTime == DateTime.MinValue)
        {
            return BadRequest(); // Code  400 Bad Request
        }

        await _repository.AddShiftToWorker(shift.WorkerId, shift.StartTime, shift.EndTime);
        return CreatedAtAction(nameof(GetWorkerShifts), new { id = shift.Id }, shift);
    }

    // PUT api/Shifts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorker(int id, [FromBody] Worker worker)
    {
        if (worker == null || worker.Id != id) return BadRequest();

        bool wasUpdated = await _repository.UpdateWorker(id, worker.Name);

        if (!wasUpdated) return NotFound(); // code 404 Not Found

        return NoContent(); // code 204 No Content -> successful update
    }

    // TODO
    //Put api/Shifts/5/{shiftId}
    [HttpPut]
    public async Task<IActionResult> UpdateShift(int id, [FromBody] Shift shift)
    {
    }

    // TODO
    // DELETE api/Shifts/5
    [HttpDelete("{id}")]
    public void DeleteWorker(int id)
    {
    }

    // TODO
    // DELETE api/Shifts/5/{shiftId}
    public async Task<IActionResult> DeleteShift(int id)
    {

    }
}
