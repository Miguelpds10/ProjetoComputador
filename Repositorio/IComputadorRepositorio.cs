using ProjetoComputador.Models;
namespace ProjetoComputador.Repositorio
{
    public interface IComputadorRepositorio
    {
        IEnumerable<Computador> TodosComputadores();
        void Cadastrar(Computador computador);
    }
}
