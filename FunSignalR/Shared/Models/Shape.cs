using FunSignalR.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSignalR.Shared.Models
{
    public class Shape
    {
        public string Id { get; set; }
        public string Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ShapeType ShapeType { get; set; }

    }
}
