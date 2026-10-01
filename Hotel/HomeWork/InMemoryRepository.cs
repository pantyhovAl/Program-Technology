namespace HomeWork
{
    internal class InMemoryRepository
    {
        private List<Floor> _floors;
        private List<Room> _rooms;
        private List<Guest> _guests;
        public InMemoryRepository()
        {
            _floors = new List<Floor>()
            {
                new Floor{Id = 1, Number = 1, Description = "Стандарт"},
                new Floor{Id = 2, Number = 2, Description = "Стандарт"},
                new Floor{Id = 3, Number = 3, Description = "Стандарт"},
                new Floor{Id = 4, Number = 4, Description = "Стандарт"},
                new Floor{Id = 5, Number = 5, Description = "Люкс"},
                new Floor{Id = 6, Number = 6, Description = "Люкс"},
                new Floor{Id = 7, Number = 7, Description = "Люкс"},
                new Floor{Id = 8, Number = 8, Description = "Люкс"}
            };
            _rooms = new List<Room>()
            {   
                new Room{Id = 11, Number ="101", FloorId =1, Type ="Стандарт", Price=3500, Capacity= 3},
                new Room{Id = 12, Number ="102", FloorId =1, Type ="Стандарт", Price=3000, Capacity= 2},
                new Room{Id = 21, Number ="201", FloorId =2, Type ="Стандарт", Price=4000, Capacity= 2},
                new Room{Id = 22, Number ="202", FloorId =2, Type ="Стандарт", Price=4500, Capacity= 3},
                new Room{Id = 31, Number ="301", FloorId =3, Type ="Стандарт", Price=4000, Capacity= 2},
                new Room{Id = 32, Number ="302", FloorId =3, Type ="Стандарт", Price=4500, Capacity= 3},
                new Room{Id = 41, Number ="401", FloorId =4, Type ="Стандарт", Price=5000, Capacity= 4},
                new Room{Id = 42, Number ="402", FloorId =4, Type ="Стандарт", Price=5500, Capacity= 5},
                new Room{Id = 51, Number ="501", FloorId =5, Type ="Люкс", Price=6000, Capacity= 2},
                new Room{Id = 52, Number ="502", FloorId =5, Type ="Люкс", Price=6500, Capacity= 3},
                new Room{Id = 61, Number ="601", FloorId =6, Type ="Люкс", Price=7000, Capacity= 2},
                new Room{Id = 62, Number ="602", FloorId =6, Type ="Люкс", Price=7500, Capacity= 3},
                new Room{Id = 71, Number ="701", FloorId =7, Type ="Люкс", Price=7500, Capacity= 2},
                new Room{Id = 72, Number ="702", FloorId =7, Type ="Люкс", Price=8000, Capacity= 3},
                new Room{Id = 81, Number ="801", FloorId =8, Type ="Люкс", Price=9000, Capacity= 2},
                new Room{Id = 82, Number ="802", FloorId =8, Type ="Люкс", Price=9000, Capacity= 2}
            };

            _guests = new List<Guest>
            {
                new Guest { Id = 1, FullName = "Иванов И.И.",    RoomId = 10, Passport = "1234 567890", CheckIn = new DateTime(2023, 10, 1), CheckOut = new DateTime(2023, 10, 4) },
                new Guest { Id = 2, FullName = "Петров П.П.",    RoomId = 11, Passport = "1234 567891", CheckIn = new DateTime(2023, 10, 2), CheckOut = new DateTime(2023, 10, 5) },
                new Guest { Id = 3, FullName = "Сидоров С.С.",   RoomId = 12, Passport = "1234 567892", CheckIn = new DateTime(2023, 10, 3), CheckOut = new DateTime(2023, 10, 6) },
                new Guest { Id = 4, FullName = "Кузнецова А.А.", RoomId = 21, Passport = "1234 567893", CheckIn = new DateTime(2023, 10, 1), CheckOut = new DateTime(2023, 10, 8) },
                new Guest { Id = 5, FullName = "Смирнов С.С.",   RoomId = 22, Passport = "1234 567894", CheckIn = new DateTime(2023, 10, 2), CheckOut = new DateTime(2023, 10, 7) },
                new Guest { Id = 6, FullName = "Волкова В.В.",   RoomId = 22, Passport = "1234 567895", CheckIn = new DateTime(2023, 10, 3), CheckOut = new DateTime(2023, 10, 9) },
                new Guest { Id = 7, FullName = "Морозов М.М.",   RoomId = 31, Passport = "1234 567896", CheckIn = new DateTime(2023, 10, 5), CheckOut = new DateTime(2023, 10, 10) },
                new Guest { Id = 8, FullName = "Новиков Н.Н.",   RoomId = 41, Passport = "1234 567897", CheckIn = new DateTime(2023, 10, 1), CheckOut = new DateTime(2023, 10, 3) },
                new Guest { Id = 9, FullName = "Фёдоров Ф.Ф.",   RoomId = 51, Passport = "1234 567898", CheckIn = new DateTime(2023, 10, 4), CheckOut = new DateTime(2023, 10, 9) },
                new Guest { Id = 10, FullName = "Егоров Е.Е.",   RoomId = 61, Passport = "1234 567899", CheckIn = new DateTime(2023, 10, 2), CheckOut = new DateTime(2023, 10, 6) },
                new Guest { Id = 11, FullName = "Павлов П.П.",   RoomId = 61, Passport = "1234 567900", CheckIn = new DateTime(2023, 10, 3), CheckOut = new DateTime(2023, 10, 7) },
                new Guest { Id = 12, FullName = "Романов Р.Р.",  RoomId = 81, Passport = "1234 567901", CheckIn = new DateTime(2023, 10, 1), CheckOut = new DateTime(2023, 10, 12) }
            };
        }
        public List<Floor> GetFloors() { return _floors; }
        public List<Room> GetRooms() { return _rooms; }
        public List<Guest> GetGuest() { return _guests; }
        }
    }

