using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Cliente
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string nb { get; set; }
        public DateTime? data_nascimento { get; set; }
        public string data_nascimento_aux { get; set; }
        public string cpf { get; set; }
        public DateTime? datacad { get; set; }
        public DateTime? dataalt { get; set; }
        public int? id_status { get; set; }
        public int? id_status_pasta { get; set; }
        public int? id_responsavel { get; set; }
        public int? id_tipo { get; set; }
        public int? id_motivo { get; set; }
        public int? id_comarca { get; set; }
        public DateTime? der { get; set; }
        public string der_aux { get; set; }
        public int apagado { get; set; }
        public int? id_especie { get; set; }
        public int? id_aps { get; set; }
        public int? id_situacao_beneficio { get; set; }





        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@nb", this.nb);
                acesso.AdicionarParametros("@data_nascimento", this.data_nascimento);
                acesso.AdicionarParametros("@cpf", this.cpf);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
                acesso.AdicionarParametros("@id_status", this.id_status);
                acesso.AdicionarParametros("@id_status_pasta", this.id_status_pasta);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_motivo", this.id_motivo);
                acesso.AdicionarParametros("@id_comarca", this.id_comarca);
                acesso.AdicionarParametros("@der", this.der);
                acesso.AdicionarParametros("@apagado", this.apagado);

                acesso.AdicionarParametros("@id_especie", this.id_especie);
                acesso.AdicionarParametros("@id_aps", this.id_aps);
                acesso.AdicionarParametros("@id_situacao_beneficio", this.id_situacao_beneficio);


                acesso.AdicionarParametros("@metodo", metodo);


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, procedure).ToString();
            }
            catch (Exception ex)
            {
                //Mensagem de erro.
                throw new Exception("Erro ao ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }

        public List<Cliente> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@nb", this.nb);
                acesso.AdicionarParametros("@data_nascimento", this.data_nascimento);
                acesso.AdicionarParametros("@cpf", this.cpf);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
                acesso.AdicionarParametros("@id_status", this.id_status);
                acesso.AdicionarParametros("@id_status_pasta", this.id_status_pasta);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@id_tipo", this.id_tipo);
                acesso.AdicionarParametros("@id_motivo", this.id_motivo);
                acesso.AdicionarParametros("@id_comarca", this.id_comarca);
                acesso.AdicionarParametros("@der", this.der);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                acesso.AdicionarParametros("@id_especie", this.id_especie);
                acesso.AdicionarParametros("@id_aps", this.id_aps);
                acesso.AdicionarParametros("@id_situacao_beneficio", this.id_situacao_beneficio);

                DataTable dt;

                List<Cliente> listaCliente = new List<Cliente>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Cliente novoCliente = new Cliente();


                        novoCliente.id = Convert.ToInt32("id");
                        novoCliente.nome = Convert.ToString("nome");
                        novoCliente.nb = Convert.ToString("nb");
                        novoCliente.data_nascimento = Convert.ToDateTime("data_nascimento");
                        novoCliente.cpf = Convert.ToString("cpf");
                        novoCliente.datacad = Convert.ToDateTime("datacad");
                        novoCliente.dataalt = Convert.ToDateTime("dataalt");
                        novoCliente.id_status = Convert.ToInt32("id_status");
                        novoCliente.id_status_pasta = Convert.ToInt32("id_status_pasta");
                        novoCliente.id_responsavel = Convert.ToInt32("id_responsavel");
                        novoCliente.id_tipo = Convert.ToInt32("id_tipo");
                        novoCliente.id_motivo = Convert.ToInt32("id_motivo");
                        novoCliente.id_comarca = Convert.ToInt32("id_comarca");
                        novoCliente.der = Convert.ToDateTime("der");
                        novoCliente.apagado = Convert.ToInt32("apagado");

                        novoCliente.id_especie = Convert.ToInt32("id_especie");
                        novoCliente.id_aps = Convert.ToInt32("id_aps");
                        novoCliente.id_situacao_beneficio = Convert.ToInt32("id_situacao_beneficio");



                        listaCliente.Add(novoCliente);
                    }

                return listaCliente;

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
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", metodo);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
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


        public string alterar_em_massa(string id_status, string id_responsavel, string ids_clientes)
        {
            try
            {
                
                acesso.LimpaParametros();
                acesso.AdicionarParametros("@id_status", id_status);
                acesso.AdicionarParametros("@id_responsavel", id_responsavel);
                acesso.AdicionarParametros("@ids", ids_clientes);
                acesso.AdicionarParametros("@apagado", "0");
                acesso.AdicionarParametros("@metodo", "alterar_em_massa");


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_cliente").ToString();



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}