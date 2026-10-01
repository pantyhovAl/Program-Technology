namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - InMemoryRepository");
            Console.WriteLine("2 - CsvRepository");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine() ?? string.Empty;

            List<Floor> floors;
            List<Room> rooms;
            List<Guest> guests;

            switch (choice)
            {
                case "1":
                    var memRepo = new InMemoryRepository();
                    floors = memRepo.GetFloors();
                    rooms = memRepo.GetRooms();
                    guests = memRepo.GetGuest();
                    break;

                case "2":
                    var csvRepo = new CsvRepository("data");
                    floors = csvRepo.GetFloors();
                    rooms = csvRepo.GetRooms();
                    guests = csvRepo.GetGuests();
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }

            Console.WriteLine("\n1. Поиск гостя по номеру комнаты:");
            Guest foundGuest = HotelService.FindGuest(guests, rooms, "202");
        
            Console.WriteLine(foundGuest != null ? foundGuest.GetInfo() : "null");

       
            Console.WriteLine("\n2. Поиск этажа комнаты:");
            Floor foundFloor = HotelService.FindFloor(rooms, floors, "302");
            Console.WriteLine(foundFloor != null ? foundFloor.GetInfo() : "null");

            Console.WriteLine("\n3. Суммарная стоимость номеров в сутки:");
            decimal? totalPrice = HotelService.GetTotalPrice(rooms);
            Console.WriteLine(totalPrice==null ? "null" : (totalPrice + " руб./сутки"));

            Console.WriteLine("\n4. Количество гостей в каждом номере:");
            Dictionary<string, int> roomsWithGuests = HotelService.GetRoomsWithGuests(rooms, guests);
            if (roomsWithGuests == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                foreach (var kvp in roomsWithGuests)
                {
                    Console.WriteLine($"{kvp.Key} — {kvp.Value}");
                }
            }

            Console.WriteLine("\n5. Вывод всех номеров:");
            HotelService.PrintAllRooms(rooms, floors, guests);

            Console.WriteLine("\nПроверка 'Не найдено':");
            Guest notFound = HotelService.FindGuest(guests, rooms, "999");
            Console.WriteLine($"FindGuest(\"999\") -> {(notFound == null ? "null" : notFound.GetInfo())}");
        }
    }
}

