using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class Transportation
    {
        [Key]
        public int Id { get; set; }

        public int TransportCount { get; set; }
        public int EtsngId { get; set; }
        [ForeignKey("EtsngId")]
        public virtual Etsng Etsngs { get; set; }

        public int GngId { get; set; }
        [ForeignKey("GngId")]
        public virtual Gng Gngs { get; set; }

        public int SourceStationId { get; set; }
        [ForeignKey("SourceStationId")]
        public virtual Station SourceStation { get; set; }

        public int DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public virtual Station DestinationStation { get; set; }

        public string RegNumber { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Loading> LoadingEntity { get; set; }
    }
}
