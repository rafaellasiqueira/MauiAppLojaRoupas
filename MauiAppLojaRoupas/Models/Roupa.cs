using SQLite;


namespace MauiAppLojaRoupas.Models
{
    public class Roupa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Tamanho { get; set; }  
        public string Cor { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public double Total { get => Quantidade * Preco; }
    }
}
