using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Web.Controllers
{
    public class Tasks : Controller
    {
        readonly GeneralContext _context;

        public Tasks(GeneralContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var result = new List<string>();
            //var data = from room in _context.Rooms
            //           join floor in _context.Floors on room.FloorId equals floor.Id
            //           select new
            //           {
            //               room.Number,
            //               room.Length,
            //               room.Width,
            //               floor.Height
            //           };
            //foreach (var item in data)
            //{
            //    result.Add($"Номер комнаты: {item.Number}, площадь: {item.Length * item.Width}, " +
            //    $"объем: {item.Length * item.Width * item.Height}");
            //}
            return View();
        }

        public IActionResult Task1()
        {
            var result = new List<string>();
            var data = from room in _context.Rooms
                       join floor in _context.Floors on room.FloorId equals floor.Id
                       select new
                       {
                           room.Number,
                           room.Length,
                           room.Width,
                           floor.Height
                       };
            foreach (var item in data)
            {
                result.Add($"Номер комнаты: {item.Number}, площадь: {item.Length * item.Width}, " +
                $"объем: {item.Length * item.Width* item.Height}");
            }
            return View(result);
        }
    }
}
