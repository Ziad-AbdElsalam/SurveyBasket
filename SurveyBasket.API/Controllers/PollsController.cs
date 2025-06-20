using SurveyBasket.API.Contracts.Requests;

namespace SurveyBasket.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        var polls = _pollService.GetAll();

        return Ok(polls);

    }
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]int id)
    {
        //return _pollService.GetPoll(id) is Poll poll ? Ok(poll.MapToResponse()) : NotFound();
        return Ok();
    }
    [HttpPost("")]
    public IActionResult Add([FromBody] CreatePollRequest poll)
    {
        //var newpoll = _pollService.Add(poll.MapToPoll());

        //return CreatedAtAction(nameof(GetById),new {id = newpoll.Id },newpoll);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id ,[FromBody] CreatePollRequest poll)
    {
       //var isUpdated = _pollService.Update(id, poll.MapToPoll());

       // if (!isUpdated)
       //     return NotFound();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _pollService.Delete(id);

        if (!isDeleted)
            return NotFound();

        return NoContent();
    }

}


