using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }
}
