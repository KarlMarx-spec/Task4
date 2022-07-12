using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tasks
{
    class Task3
    {

        public static void Execute(GeneralContext db)
        {
            Console.WriteLine("Задание 3: Предоставить возможность добавления и изменения информации о корпусах в университете, при этом предусмотреть " +
                "курсоры, срабатывающие на некоторые пользовательские исключительные ситуации");
            Console.WriteLine("----------------------------------------------------------------");
            try
            {
                var data = from buildings in db.Buildings
                           select new
                           {
                               buildings.Name,
                               buildings.Id
                           };
                Console.WriteLine("Сущетсвующие корпуса:");
                Console.WriteLine("Номер корпуса - его название");
                foreach (var item in data)
                {
                    Console.WriteLine(
                        $"{item.Id}  -  {item.Name}");
                }
                Console.WriteLine(data.GetType());
                string name;
                int number;
                Console.WriteLine("Вы хотите изменить название корпуса или добавить новый корпус? Введите new или update");
                string command = Console.ReadLine();
                if (command == "new")
                {
                    while (true)
                    {
                        Console.WriteLine("Введите желаемый номер корпуса:");
                        number = int.Parse(Console.ReadLine());
                        if (number < 0)
                        {
                            Console.WriteLine("Некорректный номер");
                            continue;
                        }
                        if (number == 0)
                            Console.WriteLine("При выборе этого номера, он будет автоматически измнен на следующий после посленего");
                        if (data.Any(u => u.Id == number))
                        {
                            Console.WriteLine("Корпус с таким номером уже существует");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите желаемое название корпуса:");
                        name = Console.ReadLine();
                        if (name == null)
                        {
                            Console.WriteLine("Некорректное название");
                            continue;
                        }
                        if (data.Any(u => u.Name == name))
                        {
                            Console.WriteLine("Корпус с таким названием уже существует");
                            continue;
                        }
                        break;
                    }
                    try
                    {
                        db.Buildings.Add(new Building
                        {
                            Id = number,
                            Name = name
                        });
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else if (command == "update")
                {
                    while (true)
                    {
                        Console.WriteLine("Введите номер корпуса, у которого собираетесь сменить название:");
                        number = int.Parse(Console.ReadLine());
                        if (number <= 0)
                        {
                            Console.WriteLine("Некорректный номер");
                            continue;
                        }
                        else if (data.Any(u => u.Id == number))
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
                        Console.WriteLine("Введите желаемое название корпуса:");
                        name = Console.ReadLine();
                        if (name == null)
                        {
                            Console.WriteLine("Некорректное название");
                            continue;
                        }
                        break;
                    }
                    try
                    {
                        var query =
                        from buildings in db.Buildings
                        where buildings.Id == number
                        select buildings;
                        foreach (Building bild in query)
                        {
                            bild.Name = name;
                        }
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect command");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
