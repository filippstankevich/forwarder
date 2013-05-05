using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Transportations")]
    public class Transportation
    {
        [Key]
        public int Id { get; set; }

        public string RegNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public string Comment { get; set; }

        public int? EtsngId { get; set; }
        [ForeignKey("EtsngId")]
        public virtual Etsng Etsng { get; set; }

        public int? GngId { get; set; }
        [ForeignKey("GngId")]
        public virtual Gng Gng { get; set; }

        public int? SourceStationId { get; set; }
        [ForeignKey("SourceStationId")]
        public virtual Station SourceStation { get; set; }

        public int? DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public virtual Station DestinationStation { get; set; }

        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public virtual ICollection<Load> Loads { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
