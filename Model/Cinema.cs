using System.Collections.Generic;

namespace Cinema_Dictionary.Model
{
    public partial class Cinema
    {
        public Cinema()
        {
            Sessions = new HashSet<Session>();
        }

        public int IdCinema { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public decimal Duraction { get; set; }
        public int TheatreId { get; set; }

        public virtual Theatre Theatre { get; set; } = null!;
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
