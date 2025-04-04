﻿using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.WebApi.Filters;
using ShiftsLogger.WebApi.Models;
using ShiftsLogger.WebApi.Repository;

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

    // GET api/Shifts/Workers
    [HttpGet("workers")]
    public async Task<IActionResult> GetAllWorkers()
    {
        List<Worker> workers = await _repository.ReadAllWorkers();
        return Ok(workers);
    }

    // GET api/Shifts/5
    [HttpGet("{workerId}")]
    public async Task<IActionResult> GetWorkerShifts(int workerId)
    {
        List<Shift> workerShifts = await _repository.ReadAllShiftsForWorker(workerId);
        if (workerShifts == null) return NotFound(); //  404 Not Found

        return Ok(workerShifts);
    }

    // POST api/Shifts
    [HttpPost]
    public async Task<IActionResult> CreateWorker([FromBody] Worker worker)
    {
        if (worker == null) return BadRequest();  // code 400 Bad Request
        Worker newWorker = await _repository.AddWorker(worker.Name);

        return CreatedAtAction(nameof(GetWorkerShifts), new { workerId = newWorker.Id }, worker);
    }

    // POST api/Shifts/{shiftId}
    [HttpPost("{workerId}")]
    public async Task<IActionResult> CreateShift([FromRoute] int workerId, [FromBody] CreateShiftDto shiftDto)
    {
        if (shiftDto.WorkerId < 1 || shiftDto.StartTime <= DateTime.Now.AddYears(-10) || shiftDto.EndTime == DateTime.Now.AddYears(-10) || shiftDto.WorkerId != workerId) 
        {
            return BadRequest(); // Code  400 Bad Request
        }
        Worker? relevantWorker = _repository.ReadWorker(workerId);
        if (relevantWorker == null)
        {
            return NotFound();
        }

        Shift newShift = await _repository.AddShiftToWorker(shiftDto.WorkerId, shiftDto.StartTime, shiftDto.EndTime);
        return CreatedAtAction(nameof(GetWorkerShifts), new { workerId = newShift.WorkerId}, relevantWorker);
    }

    // PUT api/Shifts/5
    [HttpPut("{workerId}")]
    [ServiceFilter(typeof(ManagerAuthorizationFilter))]
    public async Task<IActionResult> UpdateWorker(int workerId, [FromBody] Worker worker)
    {
        if (worker == null || worker.Id != workerId) return BadRequest();

        bool wasUpdated = await _repository.UpdateWorker(workerId, worker.Name);

        if (!wasUpdated) return NotFound(); // code 404 Not Found

        return NoContent(); // code 204 No Content -> successful update
    }

    // TODO
    //Put api/Shifts/5/{shiftId}
    [HttpPut("{workerId}/{shiftId}")]
    [ServiceFilter(typeof(ManagerAuthorizationFilter))]
    public async Task<IActionResult> UpdateShift(int shiftId, [FromBody] Shift shift)
    {
        if (shift == null || shift.WorkerId != shiftId) return BadRequest();

        bool updated = await _repository.UpdateShift(shiftId, shift.StartTime, shift.EndTime);
        if (!updated) return NotFound();

        return NoContent();   // code 204 No Content -> Successful update
    }

    // TODO
    // DELETE api/Shifts/5
    [HttpDelete("{workerId}")]
    [ServiceFilter(typeof(ManagerAuthorizationFilter))]
    public async Task<IActionResult> DeleteWorker(int workerId)
    {
        bool deleted = await _repository.DeleteWorker(workerId);
        if (!deleted) return NotFound();

        return NoContent(); // code 204 No Content -> Successful delete
    }

    // TODO
    // DELETE api/Shifts/5/{shiftId}
    [HttpDelete("{workerId}/{shiftId}")]
    [ServiceFilter(typeof(ManagerAuthorizationFilter))]
    public async Task<IActionResult> DeleteShift(int shiftId)
    {
        bool deleted = await _repository.DeleteShift(shiftId);
        if (!deleted) return NotFound();

        return NoContent();    // code 204 No Content -> Successful delete
    }
}
