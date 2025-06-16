using SurveyBasket.API.Models;

namespace SurveyBasket.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
       return Ok(_pollService.GetAll());
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return _pollService.GetPoll(id) is Poll poll ? Ok(poll) : NotFound();
    }
    [HttpPost("")]
    public IActionResult Add(Poll poll)
    {
        var newpoll = _pollService.Add(poll);

        return CreatedAtAction(nameof(GetById),new {id = newpoll.Id },newpoll);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id , Poll poll)
    {
       var isUpdated = _pollService.Update(id, poll);

        if (!isUpdated)
            return NotFound();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pollService.Delete(id);

        if (!isDeleted)
            return NotFound();

        return NoContent();
    }

}


