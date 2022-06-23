using System;

namespace Cinema_Dictionary.Model
{
    public partial class Session
    {
        public int IdSession { get; set; }
        public DateTime DateSession { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
    }
}
