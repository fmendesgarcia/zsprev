using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebZSPrev.ObjetoTransferencia
{
    public class Permissao
    {

        public int id { get; set; }
        public int id_responsavel { get; set; }
        public string permissao { get; set; }



        AcessaDados.AcessaDadosSqlServer acesso = new AcessaDados.AcessaDadosSqlServer();

        public string manutencao(string procedure, string metodo)
        {
            try
            {

                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
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


        public List<Permissao> consulta(string procedure, string metodo)
        {
            try
            {
                acesso.LimpaParametros();

                acesso.AdicionarParametros("@id", this.id);
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@permissao", this.permissao);
                acesso.AdicionarParametros("@metodo", "consultar");
                DataTable dt;

                List<Permissao> listaPermissao = new List<Permissao>();
                using (dt = acesso.ExecutaConsulta(CommandType.StoredProcedure, procedure))
                    foreach (DataRow dr in dt.Rows)
                    {

                        Permissao novoPermissao = new Permissao();


                        novoPermissao.id = Convert.ToInt32("id");
                        novoPermissao.id_responsavel = Convert.ToInt32("id_responsavel");
                        //novoPermissao.permissao = Convert.ToInt32("adm");





                        listaPermissao.Add(novoPermissao);
                    }

                return listaPermissao;

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
                acesso.AdicionarParametros("@id_responsavel", this.id_responsavel);
                acesso.AdicionarParametros("@permissao", this.permissao);
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
    }
}