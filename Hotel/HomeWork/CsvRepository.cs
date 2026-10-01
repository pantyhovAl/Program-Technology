namespace HomeWork
{
    internal class CsvRepository
    {
        private readonly string _basePath;
        public CsvRepository(string besePath)
        {
            _basePath = besePath;
        }
        public List<Floor> GetFloors()
        {
            List<Floor> result = new List<Floor>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "floors.csv"));
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(";");
                if (parts.Length < 3) continue;
                Floor f = new Floor();
                f.Id = int.Parse(parts[0]);
                f.Number = int.Parse(parts[1]);
                f.Description = parts[2];
                result.Add(f);
            }
            return result;
        }
        public List<Room> GetRooms()
        {
            List<Room> result = new List<Room>();
            string path = Path.Combine(_basePath, "rooms.csv");
            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 6) continue;
                
                Room r = new Room();
                r.Id = int.Parse(parts[0]);
                
                r.Number = parts[1];
                
                r.FloorId = int.Parse(parts[2]);
                
                r.Type = parts[3];
                
                r.Price = decimal.Parse(parts[4]);
                
                r.Capacity = int.Parse(parts[5]);
                
                result.Add(r);
            }
            return result;
        }

        /// <summary>
        /// Загружает гостей из файла guests.csv (GetGuests — ПолучитьГостей).
        /// </summary>
        public List<Guest> GetGuests()
        {
            List<Guest> result = new List<Guest>();
            string path = Path.Combine(_basePath, "guests.csv");
            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 6) continue;

                Guest g = new Guest();
                g.Id = int.Parse(parts[0]);

                g.FullName = parts[1];
                
                g.RoomId = int.Parse(parts[2]);
                
                g.Passport = parts[3];
                
                g.CheckIn = DateTime.ParseExact(parts[4], "dd.MM.yyyy", null);
                
                g.CheckOut = DateTime.ParseExact(parts[5], "dd.MM.yyyy", null);
                

                result.Add(g);
            }
            return result;
        }
    }
}
