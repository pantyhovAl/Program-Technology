namespace HomeWork
{
    internal class Guest
    {
        /// <summary>
        /// Идентификатор гостя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Полное имя гостя
        /// </summary>
        public string FullName { get; set; }=string.Empty;
        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public int RoomId { get; set; }
        /// <summary>
        /// Паспорт гостя
        /// </summary>
        public string Passport { get; set; } = string.Empty;
        /// <summary>
        /// Дата заезда
        /// </summary>
        public DateTime CheckIn { get; set; }
        /// <summary>
        /// Дата выезда
        /// </summary>
        public DateTime CheckOut { get; set; }
        /// <summary>
        /// количество дней проживания
        /// </summary>
        public int StayDays
        {
            get 
            {
                int days = (CheckOut - CheckIn).Days;
                return days < 0 ? 0 : days;
            }
        }
        /// <summary>
        /// Вывод информации о госте
        /// </summary>
        public string GetInfo()
        {
            /// <summary>
            /// Имя гостя(количество дней проживания)
            /// </summary>
            return ($"{FullName} ({StayDays} дня(ей))");
        }
    }
}
