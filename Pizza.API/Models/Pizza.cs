namespace Pizza.API.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Sabor { get; set; } = null!;
        public int TempoPreparo { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public decimal Preco {  get; set; }

    }
}
