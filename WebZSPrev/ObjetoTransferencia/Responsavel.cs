using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Responsavel
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string permissao { get; set; }
        public DateTime? datacad { get; set; }
        public DateTime? dataalt { get; set; }
        public int apagado { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@usuario", this.usuario);
                acesso.AdicionarParametros("@senha", this.senha);
                acesso.AdicionarParametros("@email", this.email);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@permissao", this.permissao);


                acesso.AdicionarParametros("@metodo", metodo);


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, procedure).ToString();
            }
            catch (Exception ex)
            {
                //Mensagem de erro.
                throw new Exception("Erro ao ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }

        public List<Responsavel> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@usuario", this.usuario);
                acesso.AdicionarParametros("@senha", this.senha);
                acesso.AdicionarParametros("@email", this.email);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Responsavel> listaResponsavel = new List<Responsavel>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Responsavel novoResponsavel = new Responsavel();


                        novoResponsavel.id = Convert.ToInt32( dr["id"]);
                        novoResponsavel.nome = Convert.ToString(dr["nome"]);
                        novoResponsavel.usuario = Convert.ToString( dr["usuario"]);
                        novoResponsavel.senha = Convert.ToString(dr["senha"]);
                        novoResponsavel.email = Convert.ToString(dr["email"]);





                        listaResponsavel.Add(novoResponsavel);
                    }

                return listaResponsavel;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }


        public List<Responsavel> consulta_session(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@usuario", this.usuario);
                acesso.AdicionarParametros("@senha", this.senha);
                acesso.AdicionarParametros("@email", this.email);
                acesso.AdicionarParametros("@datacad", this.datacad);
                acesso.AdicionarParametros("@dataalt", this.dataalt);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", metodo);
                DataTable dt;

                List<Responsavel> listaResponsavel = new List<Responsavel>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Responsavel novoResponsavel = new Responsavel();


                        novoResponsavel.id = Convert.ToInt32(dr["id"]);
                        novoResponsavel.nome = Convert.ToString(dr["nome"]);
                        novoResponsavel.usuario = Convert.ToString(dr["usuario"]);
                        novoResponsavel.senha = Convert.ToString(dr["senha"]);
                        novoResponsavel.email = Convert.ToString(dr["email"]);
                        novoResponsavel.permissao = Convert.ToString(dr["permissao"]);





                        listaResponsavel.Add(novoResponsavel);
                    }

                return listaResponsavel;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }


        public List<Responsavel> ComboResponsavel(int id_user, string valor_aps, string valor_especie, string valor_status, string procedure)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@obj", "responsavel");
                acesso.AdicionarParametros("@id_user", id_user);

                acesso.AdicionarParametros("@valor_aps", valor_aps);
                acesso.AdicionarParametros("@valor_especie", valor_especie);
                acesso.AdicionarParametros("@valor_status", valor_status);


                DataTable dt;

                List<Responsavel> listaResp = new List<Responsavel>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Responsavel novoResp = new Responsavel();


                        novoResp.id = Convert.ToInt32(dr["id"]);
                        novoResp.nome = Convert.ToString(dr["nome"]);


                        listaResp.Add(novoResp);
                    }

                return listaResp;

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
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@usuario", this.usuario);
                acesso.AdicionarParametros("@email", this.email);
       
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", metodo);


                using (DataTable dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    return dt;



            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }

        }
    }
}