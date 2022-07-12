using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tasks
{
    public class Task1
    {
        public static void Execute(GeneralContext db)
        {
            Console.WriteLine("Задание 1. Рассчитать данные о площадях и объемах каждого помещения.");
            Console.WriteLine("----------------------------------------------------------------");

            var data = from room in db.Rooms
                       join floor in db.Floors on room.FloorId equals floor.Id
                       select new
                       {
                           room.Number,
                           room.Length,
                           room.Width,
                           floor.Height
                       };
            foreach (var item in data)
            {

                Console.WriteLine($"Номер комнаты: {item.Number}, площадь: {item.Length * item.Width}, " +
                    $"объем: {item.Length * item.Width * item.Height}");
            }

            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}