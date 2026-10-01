namespace HomeWork;

/// <summary>
/// Сервис с логикой гостиницы
/// </summary>
internal static class HotelService
{
    /// <summary>
    /// Поиск гостя по номеру комнаты
    /// </summary>
    /// <param name="guests">Список гостей.</param>
    /// <param name="rooms">Список номеров.</param>
    /// <param name="roomNumber">Номер комнаты.</param>
    /// <returns>Найденный гость или null.</returns>
    public static Guest FindGuest(List<Guest> guests, List<Room> rooms, string roomNumber)
    {
        if( roomNumber == null ) return null;
        int targetRoomId = -1;
        foreach (var room in rooms)
        {
            if (room.Number == roomNumber)
            {
                targetRoomId = room.Id;
                break;
                
            }
        }
        if (targetRoomId == -1) return null;
        
        foreach (var guest in guests)
        {
            if (guest.RoomId == targetRoomId)
            {
                return guest;
                
            }
        }
        return null;
    }

    /// <summary>
    /// Поиск этажа комнаты
    /// </summary>
    public static Floor FindFloor(List<Room> rooms, List<Floor> floors, string roomNumber)
    {
        if (rooms == null || floors == null || roomNumber == null) return null;

        Room targetRoom = null;
        foreach (var room in rooms)
        {
            if (room.Number == roomNumber)
            {
                targetRoom = room;
                break;
            }
        }
        if (targetRoom == null) return null;

        
        foreach (var floor in floors)
        {
            if (floor.Id == targetRoom.FloorId)
            {
                return floor;
            }
        }
        return null;
    }

    /// <summary>
    /// Суммарная стоимость номеров в сутки
    /// </summary>
    public static decimal? GetTotalPrice(List<Room> rooms)
    {
        if (rooms == null || rooms.Count == 0) return null;
        
        decimal sum = 0;
        foreach (var room in rooms)
        {
            sum += room.Price;
        
        }
        return sum;
    }

    /// <summary>
    /// Количество гостей в каждом номере
    /// </summary>
    /// <returns>Словарь: ключ — номер комнаты, значение — количество гостей.</returns>
    public static Dictionary<string, int> GetRoomsWithGuests(List<Room> rooms, List<Guest> guests)
    {    if (rooms == null || guests == null )
        {
            return null;
        }
        Dictionary<string, int> result = new Dictionary<string, int>();
    
        foreach (var room in rooms)
        {
            result[room.Number] = 0;
        }
        foreach (var guest in guests)
        {
            foreach (var room in rooms)
            {
                if (room.Id == guest.RoomId)
                {
                    if (result.ContainsKey(room.Number))
                    {
                        result[room.Number]++;
                    }
                    break;
                }
            }
        }

        List<string> keysToRemove = new List<string>();
        foreach (var kvp in result)
        {
            if (kvp.Value == 0)
            {
                keysToRemove.Add(kvp.Key);
            }
        }
        foreach (var key in keysToRemove)
        {
            result.Remove(key);
        }

        return result;
    }

    /// <summary>
    /// Вывод всех номеров
    /// </summary>
    public static void PrintAllRooms(List<Room> rooms, List<Floor> floors, List<Guest> guests)
    {
        if (rooms == null || rooms.Count == 0)
        {
            Console.WriteLine("null");
            
            return;
        }

        Dictionary<string, int> guestCounts = GetRoomsWithGuests(rooms, guests);

        foreach (var room in rooms)
        {
            
            Floor floor = null;
            foreach (var f in floors)
            {
                if (f.Id == room.FloorId)
                {
                    floor = f;
                    break;
                }
            }

            string floorInfo = floor != null ? $"этаж {floor.Number}" : "этаж неизвестен";
            
            int count = guestCounts.ContainsKey(room.Number) ? guestCounts[room.Number] : 0;
            

            Console.WriteLine($"\"{room.GetInfo()}\" — {floorInfo}, гостей: {count}");
        }
    }
}