using System.Text;

namespace Domain
{
    public class Movie
    {
        private string Title { get; set; }

        public Movie(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Insert(0, "This movie is called:");
            sb.Insert(1, Title);
            return sb.ToString();
        }
    }
}