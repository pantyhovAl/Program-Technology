namespace Bank;
/// <summary>
/// Тип данных, который запрещает менять состояние обьекта
/// </summary>
/// <param name="Amount"> сумма транзакции</param>
/// <param name="Date"> дата транзакции</param>
/// <param name="Note"> Заметка транзакции</param>
internal record Transaction(decimal Amount, DateTime Date, string Note);

