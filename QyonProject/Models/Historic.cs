using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QyonProject.Models
{
    public class Historic
    {
        public int Id { get; set; }
        public int CompetidorId { get; set; }
        public Register Competidor { get; set; }
        public int PistaId { get; set; }
        public Speedway Pista { get; set; }
        public DateTime DataCorrida { get; set; }
        public double TempoGasto { get; set; }
    }
}
