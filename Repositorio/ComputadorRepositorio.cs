using MySql.Data.MySqlClient;
using System.Data;
using ProjetoComputador.Models;

namespace ProjetoComputador.Repositorio
{
    public class ComputadorRepositorio: IComputadorRepositorio
    {

        private readonly string _conexaoMySQL;

        public ComputadorRepositorio(IConfiguration conf) => _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");


        public IEnumerable<Computador> TodosComputadores()

        {
            List<Computador> Computadorlist = new List<Computador>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from tbComputador", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Computadorlist.Add(
                            new Computador
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nome = (string)dr["nome"],
                                Preco = (string)dr["preco"],
                                Processador = (string)dr["Processador"],

                            });
                }
                return Computadorlist;

            }
        }

        public void Cadastrar(Computador computador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))

            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbComputador (Id,Nome,Preco,Processador) values (@Id,@Nome, @Preco, @Processador)", conexao); // @: PARAMETRO

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = computador.Id;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = computador.Nome;
                cmd.Parameters.Add("@Preco", MySqlDbType.VarChar).Value = computador.Preco;
                cmd.Parameters.Add("@Processador", MySqlDbType.VarChar).Value = computador.Processador;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }

        }
    }
}

