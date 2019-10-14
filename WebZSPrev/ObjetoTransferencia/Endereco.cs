using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Endereco
    {

        public int id { get; set; }
        public int id_cliente { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public int id_comarca { get; set; }
        public string cep { get; set; }
        public int principal { get; set; }
        public DateTime datacad { get; set; }
        public DateTime dataalt { get; set; }
        public int apagado { get; set; }
        public string comarca { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }




        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@logradouro", this.logradouro);
                acesso.AdicionarParametros("@numero", this.numero);
                acesso.AdicionarParametros("@bairro", this.bairro);
                acesso.AdicionarParametros("@id_comarca", this.id_comarca);
                acesso.AdicionarParametros("@cep", this.cep);
                acesso.AdicionarParametros("@principal", this.principal);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@comarca", this.comarca);
                acesso.AdicionarParametros("@uf", this.uf);
                acesso.AdicionarParametros("@complemento", this.complemento);


                acesso.AdicionarParametros("@metodo", metodo);


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, procedure).ToString();
            }
            catch (Exception ex)
            {
                //Mensagem de erro.
                throw new Exception("Erro ao ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }


        public DataTable consultadt(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_cliente", this.id_cliente);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", metodo);

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
                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_endereco").ToString();
            }
            catch (Exception ex)
            {

                return "Falha ao apagar registro, motivo: " + ex.Message;
            }
        }
    }
}