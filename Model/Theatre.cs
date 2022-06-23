using System;
using System.Collections.Generic;

namespace Cinema_Dictionary.Model
{
    public partial class Theatre
    {
        public Theatre()
        {
            Cinemas = new HashSet<Cinema>();
        }

        public int IdTeathre { get; set; }
        public string Title { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int NumHome { get; set; }
        public string? Korpus { get; set; }
        public TimeSpan Open { get; set; }
        public TimeSpan End { get; set; }
        public string Number { get; set; } = null!;
        public string? Status { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
