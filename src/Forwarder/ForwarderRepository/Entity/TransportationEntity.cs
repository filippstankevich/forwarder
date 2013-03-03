using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ForwarderDAL.Entity
{
    public class TransportationEntity
    {
        [Key]
        public int ID { get; set; }

        public string RegNumber { get; set; }
        public string Comment { get; set; }
        public int Volume { get; set; }
        public int TransportCount { get; set; }

        [ForeignKey("EtsngId")]
        public int EtsngId { get; set; }
        public virtual ETSNG_Entity ETSNGs { get; set; }

        [ForeignKey("GngId")]
        public int GngId { get; set; }
        public virtual GNG_Entity GNGs { get; set; }

        [ForeignKey("SourceStationId")]
        public int SourceStationId { get; set; }
        public virtual StationEntity SourceStations { get; set; }
                
        public int DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public virtual StationEntity DestinationStations { get; set; }


    }
}
