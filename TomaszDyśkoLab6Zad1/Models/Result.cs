namespace TomaszDyśkoLab6Zad1
{
    /// <summary>
    /// Klasa widoku wyniku zapytania
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Właściwość przechowująca informaje o odpowiedzi na zapytanie
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="success"></param>
        public Result(bool success)
        {
            Success = success;
        }
    }
}