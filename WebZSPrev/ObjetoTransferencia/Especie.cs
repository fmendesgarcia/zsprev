using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Especie
    {

        public int id { get; set; }
        public string nome { get; set; }
        public int apagado { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);


                acesso.AdicionarParametros("@metodo", metodo);


                return acesso.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, procedure).ToString();
            }
            catch (Exception ex)
            {
                //Mensagem de erro.
                throw new Exception("Erro ao ao chamar a " + procedure + " para o método: " + metodo + ". Motivo: " + ex.Message);
            }
        }

        public List<TipoCli> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<TipoCli> listaTipoCli = new List<TipoCli>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        TipoCli novoTipoCli = new TipoCli();


                        novoTipoCli.id = Convert.ToInt32("id");
                        novoTipoCli.nome = Convert.ToString("nome");
                        novoTipoCli.apagado = Convert.ToInt32("apagado");





                        listaTipoCli.Add(novoTipoCli);
                    }

                return listaTipoCli;

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
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar");

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

        public DataTable consultar_cod_esp(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@nome", this.nome);
                acesso.AdicionarParametros("@apagado", this.apagado);
                acesso.AdicionarParametros("@metodo", "consultar_cod_esp");

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

        public List<Especie> ComboEspecie(int id_user, string valor_aps, string valor_status, string valor_responsavel,  string procedure)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@obj", "especie");
                acesso.AdicionarParametros("@id_user", id_user);
                acesso.AdicionarParametros("@valor_aps", valor_aps);
                acesso.AdicionarParametros("@valor_status", valor_status);
                acesso.AdicionarParametros("@valor_responsavel", valor_responsavel);


                DataTable dt;
                List<Especie> listaEspecie = new List<Especie>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Especie novaEspecie = new Especie();


                        novaEspecie.id = Convert.ToInt32(dr["id"]);
                        novaEspecie.nome = Convert.ToString(dr["nome"]);


                        listaEspecie.Add(novaEspecie);
                    }

                return listaEspecie;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar consultar, motivo: " + ex.Message);
            }
        }
    }
}