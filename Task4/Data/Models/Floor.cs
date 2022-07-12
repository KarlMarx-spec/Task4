using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public int Height { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
