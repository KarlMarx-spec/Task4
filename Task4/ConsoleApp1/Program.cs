using System;
using System.Linq;
using ConsoleApp1.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralContext db = new GeneralContext();
            //FillDb(db);

            while (true)
            {
                Console.Write("Введите номер задачи, которую нужно выполнить (1-4): ");

                int taskId = int.Parse(Console.ReadLine());
                if (taskId < 1 || taskId > 4)
                {
                    Console.WriteLine("Попробуйте еще раз (1-4)");
                    continue;
                }
                TaskExecutionFactory(taskId, db);
            }

        }
        public static void FillDb(GeneralContext db)
        {
            db.Faculties.Add(new Faculty
            {
                Id = 1,
                Name = "Faculty of Informatics"
            });
            db.SaveChanges();
            db.Faculties.Add(new Faculty
            {
                Id = 2,
                Name = "Faculty of Physics"
            });
            db.SaveChanges();
            db.Departments.Add(new Department
            {
                Id = 1,
                Name = "Department of Information Security",
                FacultyId = 1
            });
            db.SaveChanges();
            db.Departments.Add(new Department
            {
                Id = 2,
                Name = "Department of Nanomaterials",
                FacultyId = 2
            });
            db.SaveChanges();
            db.Laboratories.Add(new Laboratory
            {
                Id = 1,
                Name = "Laboratory of Information Security",
                DepartmentId = 1
            });
            db.SaveChanges();
            db.Laboratories.Add(new Laboratory
            {
                Id = 2,
                Name = "Laboratory of Nanomaterials",
                DepartmentId = 2
            });
            db.SaveChanges();
            db.Buildings.Add(new Building
            {
                Id = 1,
                Name = "Big"
            });
            db.SaveChanges();
            db.Buildings.Add(new Building
            {
                Id = 2,
                Name = "Small"
            });
            db.SaveChanges();
            db.Floors.Add(new Floor
            {
                Id = 1,
                Number = 4,
                BuildingId = 1,
                Height = 5
            });
            db.SaveChanges();
            db.Floors.Add(new Floor
            {
                Id = 2,
                Number = 4,
                BuildingId = 2,
                Height = 3
            });
            db.SaveChanges();
            db.Positions.Add(new Position
            {
                Id = 1,
                Name = "South"
            });
            db.SaveChanges();
            db.Positions.Add(new Position
            {
                Id = 2,
                Name = "North"
            });
            db.SaveChanges();
            db.RTypes.Add(new RType
            {
                Id = 1,
                Name = "lecture room"
            });
            db.SaveChanges();
            db.RTypes.Add(new RType
            {
                Id = 2,
                Name = "laboratory room"
            });
            db.SaveChanges();
            db.Rooms.Add(new Room
            {
                Id = 1,
                Number = "28",
                FloorId = 1,
                Length = 10,
                Width = 20,
                PositionId = 1,
                RTypeId = 1,
                ForWhat = "for lectures",
                LaboratoryId = 1
            });
            db.SaveChanges();
            db.Rooms.Add(new Room
            {
                Id = 2,
                Number = "35A",
                FloorId = 2,
                Length = 40,
                Width = 50,
                PositionId = 2,
                RTypeId = 1,
                ForWhat = "for lectures",
                LaboratoryId = 2
            });
            db.SaveChanges();
            db.Rooms.Add(new Room
            {
                Id = 3,
                Number = "40A",
                FloorId = 1,
                Length = 40,
                Width = 50,
                PositionId = 2,
                RTypeId = 1,
                ForWhat = "for lectures",
                LaboratoryId = 1
            });

            db.SaveChanges();
            db.Rooms.Add(new Room
            {
                Id = 4,
                Number = "42A",
                FloorId = 1,
                Length = 40,
                Width = 50,
                PositionId = 2,
                RTypeId = 1,
                ForWhat = "for lectures",
                LaboratoryId = 2
            });
            db.SaveChanges();
        }
        public static void TaskExecutionFactory(int taskId, GeneralContext db)
        {
            Console.WriteLine();

            switch (taskId)
            {
                case 1:
                    Task1.Execute(db);
                    break;
                case 2:
                    Task2.Execute(db);
                    break;
                case 3:
                    Task3.Execute(db);
                    break;
                case 4:
                    Task4.Execute();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

}
