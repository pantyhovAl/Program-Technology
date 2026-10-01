namespace HomeWork
{
    /// <summary>
    /// Этаж гостиницы
    /// </summary>
    internal class Floor
    {
        /// <summary>
        /// Идентификатор этажа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Номер этажа
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Описание этажжа(класс)
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Свойство этажа
        /// </summary>
        public bool IsUpper => Number > 5;
        /// <summary>
        /// Информация о этаже
        /// </summary>
        /// <returns>Пример вывода "3 этаж (стандарт)"</returns>
        public string GetInfo()
        {
            return ($"{Number} этаж ({Description})");
        }
    }
}
