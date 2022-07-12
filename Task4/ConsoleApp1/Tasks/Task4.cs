using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tasks
{
    class Task4
    {
        public static void Execute()
        {
            GeneralContext db = new GeneralContext();
            Console.WriteLine("Задание 4: Предоставить возможность добавления и изменения информации о комнатах в корпусах университета, при этом" +
                " предусмотреть курсоры, срабатывающие на некоторые пользовательские исключительные ситуации. ");
            Console.WriteLine("----------------------------------------------------------------");
            try
            {
                var data = from building in db.Buildings
                           join floor in db.Floors on building.Id equals floor.BuildingId
                           join room in db.Rooms on floor.Id equals room.FloorId
                           join laboratory in db.Laboratories on room.LaboratoryId equals laboratory.Id
                           select new
                           {
                               room.Id,
                               room.Number,
                               bname = building.Name,
                               fname = floor.Number,
                               lname = laboratory.Name,
                               room.ForWhat
                           };
                Console.WriteLine("Сущетсвующие аудитории:");
                //Console.WriteLine("Номер - Этаж - Корпус ");
                foreach (var item in data)
                {
                    Console.WriteLine($"id {item.Id} Комната {item.Number} в лаборатории {item.lname} на этаже {item.fname} в корпусе {item.bname} {item.ForWhat}");
                    
                }
                
                int rid;
                string rnumber;
                int floorId;
                int length;
                int width;
                int posid;
                int rtypeId;
                string forWhat;
                int laboratoryId;
                int number;
                string command;
                Console.WriteLine("Вы хотите изменить данные о комнате или добавить новую комнату? Введите new или update");
                while (true)
                {
                    command = Console.ReadLine();
                    if (command != "new" && command != "update")
                    {
                        Console.WriteLine("Повторите ввод");
                        continue;
                    }
                    break;
                }
                if (command == "new")
                {
                    //id
                    while (true)
                    {
                        Console.WriteLine("Введите id аудитории:");
                        rid = int.Parse(Console.ReadLine());
                        if (rid < 0)
                        {
                            Console.WriteLine("Некорректный id");
                            continue;
                        }
                        if (rid == 0)
                            Console.WriteLine("При выборе этого id, он будет автоматически измнен на следующий после посленего");
                        if (data.Any(u => u.Id == rid))
                        {
                            Console.WriteLine("Аудитория с таким id уже существует");
                            continue;
                        }
                        break;
                    }
                    //номер
                    while (true)
                    {
                        Console.WriteLine("Введите желаемый номер аудитории:");
                        rnumber = Console.ReadLine();
                        if (rnumber == null)
                        {
                            Console.WriteLine("Некорректное название");
                            continue;
                        }
                        if (data.Any(u => u.Number == rnumber))
                        {
                            Console.WriteLine("аудитория с таким номером уже существует");
                            continue;
                        }
                        break;
                    }
                    //этаж
                    GeneralContext db1 = new GeneralContext();
                    int bid;
                    var fquery =
                        from building in db1.Buildings
                        join floor in db1.Floors on building.Id equals floor.BuildingId
                        select new
                        {
                            bid = building.Id,
                            fname = floor.Number,
                            bname = building.Name
                        };
                    bid = fquery.FirstOrDefault().bid;
                    Console.WriteLine("Доступные этажи в корпусах");
                    fquery = fquery.Distinct();
                    foreach (var item in fquery.ToList())
                    {
                        Console.WriteLine($"Корпус {fquery.FirstOrDefault().bname} Этаж {item.fname}");
                    }
                    string bname;
                    while (true)
                    {
                        Console.WriteLine("Введите название нужного корпуса");
                        bname = Console.ReadLine();
                        if (bname != null && fquery.Any(u => u.bname == bname))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Повторите ввод");
                            continue;
                        }
                    }
                    var bquery =
                    from building in db.Buildings
                    where building.Name == bname
                    select new { building.Id };
                    bid = bquery.FirstOrDefault().Id;
                    int fnum;
                    while (true)
                    {
                        Console.WriteLine("Введите номер нужного этажа");
                        fnum = int.Parse(Console.ReadLine());
                        if (fquery.Any(u => u.fname == fnum))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Повторите ввод");
                            continue;
                        }
                    }
                    GeneralContext db2 = new GeneralContext();
                    var query =
                    from floor in db2.Floors
                    join building in db2.Buildings on floor.BuildingId equals building.Id
                    where floor.Number == fnum && building.Id == bid
                    select new { floor.Id };
                    floorId = query.FirstOrDefault().Id;
                    //длина
                    while (true)
                    {
                        Console.WriteLine("Введите длину аудитории:");
                        length = int.Parse(Console.ReadLine());
                        if (length < 1 || length > 50)
                        {
                            Console.WriteLine("Некорректный id");
                            continue;
                        }
                        break;
                    }
                    //ширина
                    while (true)
                    {
                        Console.WriteLine("Введите ширину аудитории:");
                        width = int.Parse(Console.ReadLine());
                        if (width < 1 || width > 50)
                        {
                            Console.WriteLine("Некорректный id");
                            continue;
                        }
                        break;
                    }
                    //позиция
                    var pos =
                        from position in db2.Positions
                        select new
                        {
                            position.Id,
                            position.Name
                        };
                    Console.WriteLine($"Доступные позиции:");
                    pos = pos.Distinct();
                    foreach (var item in pos.ToList())
                    {
                        Console.WriteLine($"id {item.Id} название {item.Name}");
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите id нужной позиции");
                        posid = int.Parse(Console.ReadLine());
                        if (pos.Any(u => u.Id == posid))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Повторите ввод");
                            continue;
                        }
                    }
                    GeneralContext db3 = new GeneralContext();
                    //тип
                    var tquery =
                    from type in db3.RTypes
                    select new { type.Name, type.Id  };
                    Console.WriteLine("Доступные типы аудиторий:");
                    foreach (var item in tquery.ToList())
                    {
                        Console.WriteLine($"{item.Id}) {item.Name}");
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите номер позиции:");
                        rtypeId = int.Parse(Console.ReadLine());
                        if (rtypeId < 0)
                        {
                            Console.WriteLine("Некорректный номер");
                            continue;
                        }
                        if (tquery.Any(u => u.Id == rtypeId))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Повторите ввод");
                            continue;
                        }
                    }
                    //назначение
                    while (true)
                    {
                        Console.WriteLine("Введите желаемое назначение аудитории:");
                        forWhat = Console.ReadLine();
                        if (forWhat == null)
                        {
                            Console.WriteLine("Некорректное назначение");
                            continue;
                        }
                        break;
                    }
                    //лаборатория
                    var lquery = 
                       from laboratory in db3.Laboratories
                       join department in db3.Departments on laboratory.DepartmentId equals department.Id
                       join faculty in db3.Faculties on department.FacultyId equals faculty.Id
                       select new
                       {
                           fname = faculty.Name,
                           dname = department.Name,
                           lname = laboratory.Name,
                           laboratory.Id
                       };
                    lquery = lquery.Distinct();
                    Console.WriteLine("Введите номер лабортатории из представленных ниже");
                    foreach (var item in lquery.ToList())
                    {
                        Console.WriteLine($"{item.Id}) {item.lname} на кафедре: {item.dname} факультете: { item.fname}");
                    }
                    while (true)
                    {
                        laboratoryId = int.Parse(Console.ReadLine());
                        if (rtypeId < 0)
                        {
                            Console.WriteLine("Некорректный номер");
                            continue;
                        }
                        if (lquery.Any(u => u.Id == laboratoryId))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Повторите ввод");
                            continue;
                        }
                    }
                    //добавление аудитории
                    try
                    {
                        db3.Rooms.Add(new Room
                        {
                            Id = rid,
                            Number = rnumber,
                            FloorId = floorId,
                            Length = length,
                            Width = width,
                            PositionId = posid,
                            RTypeId = rtypeId,
                            ForWhat = forWhat,
                            LaboratoryId = laboratoryId
                        });
                        db3.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else if (command == "update")
                {
                    int id;
                    int command_number;
                    while (true)
                    {
                        Console.WriteLine("Введите id аудитории, у которой собираетесь сменить данные:");
                        id = int.Parse(Console.ReadLine());
                        if (id <= 0)
                        {
                            Console.WriteLine("Некорректный номер");
                            continue;
                        }
                        else if (data.Any(u => u.Id == id))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Несущствующий номер");
                            continue;
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите цифру того, что хотите изменить:");
                        Console.WriteLine("1 - номер, 2 - этаж, 3 - предназначение");
                        command_number = int.Parse(Console.ReadLine());
                        if (command_number < 1 || command_number > 3)
                        {
                            Console.WriteLine("Некорректная команда");
                            continue;
                        }
                        else
                            break;
                    }
                    try
                    {
                        if (command_number == 1)
                        {
                            
                            while (true)
                            {
                                Console.WriteLine("Введите желаемый номер аудитории");
                                rnumber = Console.ReadLine();
                                if (rnumber == null)
                                {
                                    Console.WriteLine("Некорректный номер");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var query = 
                            from rooms in db.Rooms
                            where rooms.Id == id
                            select rooms;
                            foreach (Room room in query)
                            {
                                room.Number = rnumber;
                            }
                            db.SaveChanges();
                        }
                        else if (command_number == 2)
                        {
                            int bid;
                            var fquery =
                                from building in db.Buildings
                                join floor in db.Floors on building.Id equals floor.BuildingId
                                join room in db.Rooms on floor.Id equals room.FloorId
                            select new
                            {
                                bid = building.Id,
                                fname = floor.Number,
                                bname = building.Name
                            };
                            bid = fquery.FirstOrDefault().bid;
                            Console.WriteLine($"Доступные этажи в корпусе {fquery.FirstOrDefault().bname}:");
                            fquery = fquery.Distinct();
                            foreach (var item in fquery)
                            {
                                Console.WriteLine($"{item.fname} Этаж");
                            }
                            int fnum;
                            while (true)
                            {
                                Console.WriteLine("Введите номер нужного этажа");
                                fnum = int.Parse(Console.ReadLine());
                                if (fquery.Any(u => u.fname == fnum))
                                {
                                   break;
                                }
                                else
                                {
                                    Console.WriteLine("Повторите ввод");
                                    continue;
                                }
                            }
                            var query =
                            from floor in db.Floors
                            join building in db.Buildings on floor.BuildingId equals building.Id
                            where floor.Number == fnum && building.Id == bid
                            select new { floor.Id };
                            

                            var result =
                            from rooms in db.Rooms
                            where rooms.Id == id
                            select rooms;
                            foreach (Room room in result)
                            {
                                room.FloorId = query.FirstOrDefault().Id;
                            }
                            db.SaveChanges();
                            
                        }
                        else if (command_number == 3)
                        {
                            string Forwhat;
                            while (true)
                            {
                                Console.WriteLine("Введите желаемое предназначение аудитории");
                                Forwhat = Console.ReadLine();
                                if (Forwhat == null)
                                {
                                    Console.WriteLine("Некорректный ввод");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var query =
                            from rooms in db.Rooms
                            where rooms.Id == id
                            select rooms;
                            foreach (Room room in query)
                            {
                                room.ForWhat = Forwhat;
                            }
                            db.SaveChanges();
                        }
                        else
                            Console.WriteLine("Incorrect command");
                        //from buildings in db.Buildings
                        //where buildings.Id == number
                        //select buildings;
                        //foreach (Building bild in query)
                        //{
                        //    bild.Name = name;
                        //}
                        //db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
