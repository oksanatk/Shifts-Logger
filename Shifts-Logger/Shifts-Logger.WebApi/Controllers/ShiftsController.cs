using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.WebApi.Models;
using ShiftsLogger.WebApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shifts_Logger.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftsController : ControllerBase
{
    private readonly WorkerShiftRepository _repository;
    public ShiftsController(WorkerShiftRepository repository)
    {
        _repository = repository;
    }
    // GET: api/Shifts
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Shift> workersShifts = await _repository.ReadAllWorkersAllShifts();
        return Ok(workersShifts);
    }

    // GET api/Shifts/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return $"value {id}";
    }

    // POST api/Shifts
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/Shifts/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/Shifts/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
