namespace ProjetoComputador.Models
{
    public class Computador
    {
        //Criando encapsulamento do objeto com get e set
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Preco { get; set; }
        public string? Processador { get; set; }

        public List<Computador>? ListaComputador { get; set; }


    }
}
