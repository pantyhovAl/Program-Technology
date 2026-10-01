using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork
{
    /// <summary>
    /// Гостинечный номер
    /// </summary>
    internal class Room
    {
        /// <summary>
        /// Идентификатор номера
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public int FloorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }= string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLux => Type == "Люкс";
        /// <summary>
        /// Полная стоимость номера за промежуток проживания
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public decimal GetTotalPrise(int days)
        {
            if (days <= 0) return 0;
            return Price * days;
        }
        /// <summary>
        /// Полноя информация про номер
        /// </summary>
        /// <returns>Номер(тип номера, цена за сутки</returns>
        public string GetInfo()
        {
            return ($"{Number} ({Type}, {Price} руб./сутки)");
        }

    }
}
