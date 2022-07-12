using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tasks
{
    class Task2
    {
        public static void Execute(GeneralContext db)
        {
            Console.WriteLine("Задание 2. Для указанного корпуса получить количество " +
                "факультетов, их названия и структуру, находящиеся в этом корпусе; ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Введите номер корпуса:");
            int number = 0;
            while (true)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number <= 0 || number > db.Buildings.Max(x => x.Id))
                    {
                        throw new NotImplementedException();
                    }
                    break;
                }
                catch
                {
                    Console.Write("Повторите ввод: ");
                    continue;
                }
            }
            var data = from building in db.Buildings
                       join floor in db.Floors on building.Id equals floor.BuildingId
                       join room in db.Rooms on floor.Id equals room.FloorId
                       join laboratory in db.Laboratories on room.LaboratoryId equals laboratory.Id
                       join department in db.Departments on laboratory.DepartmentId equals department.Id
                       join faculty in db.Faculties on department.FacultyId equals faculty.Id
                       where (building.Id == number)
                       select new
                       {
                           bname = building.Name,
                           fname = faculty.Name,
                           dname = department.Name,
                           lname = laboratory.Name
                       };
            data = data.Distinct();
            int count = data.GroupBy(u => u.fname).Count();
            if (count > 0)
            {
                Console.WriteLine($"Для корпуса: {data.FirstOrDefault().bname}" +
                   $" количество факультетов: {count}");
                Console.WriteLine("Структура:");
                foreach (var item in data)
                {
                    Console.WriteLine($"Факультет: { item.fname}, Кафедра: {item.dname}, Лаборатория: {item.lname}");
                }
            }
            else
            {
                Console.WriteLine("Для данного корпуса нет факультетов");
            }
            

            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
