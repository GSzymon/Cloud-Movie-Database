namespace WebAPI.Models
{
    public class ActorMovie
    {
        public int ActorId { get; set; } = 1;
        public int MovieId { get; set; } = 1;

        public Actor Actor { get; set; } 
        public Movie Movie { get; set; }
    }
}
