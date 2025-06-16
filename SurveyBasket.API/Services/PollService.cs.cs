
using SurveyBasket.API.Models;

namespace SurveyBasket.API.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
            new Poll
            {
                Id = 1,
                Title = "Favorite Programming Language",
                Description = "What is your favorite programming language?"
            }
        ];

        public IEnumerable<Poll> GetAll() => _polls;


        public Poll? GetPoll(int id)=> _polls.SingleOrDefault(p => p.Id == id);
        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1; // Simple ID generation logic
            _polls.Add(poll);
            return poll;
        }

        public bool Update(int id, Poll poll)
        {
            var currentPoll = GetPoll(id);

            if(currentPoll is null)
                return false; 

            currentPoll.Title = poll.Title;
            currentPoll.Description = poll.Description;

            return true;
        }

        public bool Delete(int id)
        {
            var poll = GetPoll(id);

            if (poll is null)
                return false;

            _polls.Remove(poll);

            return true;
        }
    }
}
 