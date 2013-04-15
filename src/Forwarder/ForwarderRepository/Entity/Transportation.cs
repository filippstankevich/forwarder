﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class Transportation
    {
        [Key]
        public int ID { get; set; }

        public string RegNumber { get; set; }
        public string Comment { get; set; }
        public int Volume { get; set; }
        public int TransportCount { get; set; }
        
        public int EtsngId { get; set; }
        [ForeignKey("EtsngId")]
        public virtual ETSNG ETSNGs { get; set; }

        public int GngId { get; set; }
        [ForeignKey("GngId")]
        public virtual GNG GNGs { get; set; }

        public int SourceStationId { get; set; }
        [ForeignKey("SourceStationId")]
        public virtual Station SourceStations { get; set; }
<<<<<<< HEAD
=======
                
        public int DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public virtual Station DestinationStations { get; set; }

>>>>>>> 5591935c24c8c971e0f4e49382a802d56c00c50b

        public int DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public virtual Station DestinationStations { get; set; }
    }
}
