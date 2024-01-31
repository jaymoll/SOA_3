using Newtonsoft.Json;
using System.Text;

namespace Domain
{
    public class Movie
    {
        [JsonProperty]
        private string Title { get; set; }

        private List<MovieScreening> Screenings { get; set; } = new List<MovieScreening>();

        public Movie(string title)
        {
            Title = title;
        }

        public void AddScreening(MovieScreening movieScreening)
        {
            Screenings.Add(movieScreening);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This movie is called:");
            sb.AppendLine(Title);
            return sb.ToString();
        }
    }
}