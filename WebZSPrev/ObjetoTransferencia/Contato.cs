using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Contato
    {

        public int id { get; set; }
        public int id_cliente { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public int principal { get; set; }
        public DateTime datacad { get; set; }
        public DateTime dataalt { get; set; }
        public int apagado { get; set; }
        public int id_obs { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@ddd", this.ddd);
                acesso.AdicionarParametros("@telefone", this.telefone);
                acesso.AdicionarParametros("@principal", this.principal);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@id_obs", this.id_obs);


                acesso.AdicionarParametros("@metodo", metodo);


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, procedure).ToString();
            }
            catch (Exception ex)
            {
                //Mensagem de erro.
                throw new Exception("Erro ao ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }




        public List<Contato> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@ddd", this.ddd);
                acesso.AdicionarParametros("@telefone", this.telefone);
                acesso.AdicionarParametros("@principal", this.principal);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@id_obs", this.id_obs);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Contato> listaContato = new List<Contato>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Contato novoContato = new Contato();


                        novoContato.id = Convert.ToInt32("id");
                        novoContato.id_cliente = Convert.ToInt32("id_cliente");
                        novoContato.ddd = Convert.ToString("ddd");
                        novoContato.telefone = Convert.ToString("telefone");
                        novoContato.principal = Convert.ToInt32("principal");
                        novoContato.datacad = Convert.ToDateTime("datacad");
                        novoContato.dataalt = Convert.ToDateTime("dataalt");
                        novoContato.apagado = Convert.ToInt32("apagado");
                        novoContato.id_obs = Convert.ToInt32("id_obs");





                        listaContato.Add(novoContato);
                    }

                return listaContato;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }

        public DataTable consultadt(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@ddd", this.ddd);
                acesso.AdicionarParametros("@telefone", this.telefone);
                acesso.AdicionarParametros("@principal", this.principal);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", metodo);
                acesso.AdicionarParametros("@id_obs", this.id_obs);


                using (DataTable dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                {
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }


        public string Apagar(int id)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", id);
                acesso.AdicionarParametros("@metodo", "apagar");
                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_contato").ToString();
            }
            catch (Exception ex)
            {

                return "Falha ao apagar registro, motivo: " + ex.Message;
            }
        }
    }
}