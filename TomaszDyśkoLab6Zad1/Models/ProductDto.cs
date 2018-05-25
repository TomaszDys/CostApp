namespace TomaszDyśkoLab6Zad1.Models
{
    /// <summary>
    /// Klasa widoku produktu
    /// </summary>
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfPieces { get; set; }

        public decimal Price { get; set; }
    }
}