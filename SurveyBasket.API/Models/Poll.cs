namespace SurveyBasket.API.Models
{
    public class Poll
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public List<string> Options { get; set; } = new List<string>();
        //public Dictionary<string, int> Votes { get; set; } = new Dictionary<string, int>();
    }
}
