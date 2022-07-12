using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int FloorId { get; set; }
        public Floor Floor { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int RTypeId { get; set; }
        public RType RType { get; set; }
        public string ForWhat { get; set; }
        public int LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }

    }
}
