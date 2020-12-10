namespace Cinema.DAL.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        public int TicketId { get; set; }

        public int VisitorId { get; set; }

        public int SeanceId { get; set; }

        public int line { get; set; }

        public int Sead { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Seance Seance { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
