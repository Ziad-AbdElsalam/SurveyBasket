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

        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);

    }
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var poll = _pollService.GetPoll(id);

        if (poll is null)
            return NotFound();
        var response = poll.Adapt<PollResponse>();

        return Ok(response);
    }
    [HttpPost("")]
    public IActionResult Add([FromBody] CreatePollRequest request)
    {
        var newpoll = _pollService.Add(request.Adapt<Poll>());

        return CreatedAtAction(nameof(GetById), new { id = newpoll.Id }, newpoll.Adapt<PollResponse>());
    }
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id ,[FromBody] CreatePollRequest request)
    {
       var isUpdated = _pollService.Update(id, request.Adapt<Poll>());

        if (!isUpdated)
            return NotFound();

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


