using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebZSPrev.ObjetoTransferencia;

namespace WebZSPrev.Apresentacao
{
    public partial class cadCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                string id = Session["id_usuario"].ToString();
                if (string.IsNullOrEmpty(id))
                {
                    //Response.Redirect("login.aspx");
                }

            }
            catch
            {

                //Response.Redirect("login.aspx");
            }

            string permissao = null;

            try
            {
                permissao = Session["permissao"].ToString();
            }
            catch
            {

            }

            if(permissao != null)
            {
                if(permissao == "p1")
                {
                    btnArquivarCliente.Visible = false;
                    mspanResponsavel.Disabled = true;
                    //mspanResponsavel.Attributes.Add("readonly", "readonly");
                    //mspanNome.Attributes.Add()
                    mspanNome.Attributes.Add("readonly", "readonly");
                    mspanEspecie.Disabled = true;
                    mspanAps.Disabled = true;
                }
            }


            if (!IsPostBack)
            {
                ObjetoTransferencia.Comarca comarca = new Comarca();


                ObjetoTransferencia.TipoMovimentacao tm = new TipoMovimentacao();
                ddlTipoMovimentacao.DataSource = tm.consulta("usp_manutencao_tipo_movimentcao", "consultar");
                ddlTipoMovimentacao.DataTextField = "nome";
                ddlTipoMovimentacao.DataValueField = "id";
                ddlTipoMovimentacao.DataBind();
                ddlTipoMovimentacao.Items.Insert(0, new ListItem("Selecione...", "0"));

                ObjetoTransferencia.Obs obs = new Obs();
                obs_contato.DataSource = obs.consulta("usp_manutencao_obs_contato", "consultar");
                obs_contato.DataTextField = "nome";
                obs_contato.DataValueField = "id";
                obs_contato.DataBind();
                obs_contato.Items.Insert(0, new ListItem("Selecione...", "0"));

                

            }




        }

        [WebMethod]
        public static string inserir_cliente(Cliente cliente)
        {


            try
            {
                Cliente _cliente = new Cliente();
                _cliente.nome = cliente.nome;
                _cliente.nb = cliente.nb;
                _cliente.id_tipo = cliente.id_tipo;
                _cliente.id_responsavel = cliente.id_responsavel;
                _cliente.id_motivo = cliente.id_motivo;
                _cliente.id_especie = cliente.id_especie;
                _cliente.id_aps = cliente.id_aps;
                _cliente.id_situacao_beneficio = cliente.id_situacao_beneficio;
                _cliente.id_status = cliente.id_status;
                _cliente.id_status_pasta = cliente.id_status_pasta; // cliente.id_status_pasta;
                _cliente.cpf = cliente.cpf;
                _cliente.apagado = 0;
                try
                {
                    _cliente.data_nascimento = Convert.ToDateTime(cliente.data_nascimento_aux);
                }
                catch
                {
                    _cliente.data_nascimento = null;
                }

                try
                {
                    _cliente.der = Convert.ToDateTime(cliente.der_aux);
                }
                catch
                {
                    _cliente.der = null;
                }


                _cliente.dataalt = DateTime.Now;
                _cliente.datacad = DateTime.Now;

                return _cliente.manutencao("usp_manutencao_cliente", "inserir").ToString();

            }
            catch (Exception ex)
            {

                return "Falha, motivo: " + ex.ToString();
            }


        }


       

        [WebMethod]
        public static string alterar_cliente(Cliente cliente)
        {

            string retorno = null;


            try
            {
                Cliente _cliente = new Cliente();
                _cliente.id = cliente.id;
                _cliente.nome = cliente.nome;
                _cliente.nb = cliente.nb;
                _cliente.id_tipo = cliente.id_tipo;
                _cliente.id_responsavel = cliente.id_responsavel;
                _cliente.id_motivo = cliente.id_motivo;
                _cliente.id_especie = cliente.id_especie;
                _cliente.id_aps = cliente.id_aps;
                _cliente.id_situacao_beneficio = cliente.id_situacao_beneficio;
                _cliente.id_status = cliente.id_status;
                _cliente.id_status_pasta = cliente.id_status_pasta; // cliente.id_status_pasta;
                _cliente.cpf = cliente.cpf;
                _cliente.apagado = 0;
                try
                {
                    _cliente.data_nascimento = Convert.ToDateTime(cliente.data_nascimento_aux);
                }
                catch
                {

                    _cliente.data_nascimento = null;
                }


                try
                {
                    _cliente.der = Convert.ToDateTime(cliente.der_aux);
                }
                catch
                {

                    _cliente.der = null;
                }

                _cliente.dataalt = DateTime.Now;
                return _cliente.manutencao("usp_manutencao_cliente", "alterar").ToString();

            }
            catch (Exception ex)
            {

                retorno = "Falha, motivo: " + ex.ToString();
            }



            return retorno;
        }

        [WebMethod]
        public static string excluir_cliente(Cliente cliente)
        {

            string retorno = null;


            try
            {
                Cliente _cliente = new Cliente();
                _cliente.id = cliente.id;
                _cliente.apagado = 1;
                _cliente.dataalt = DateTime.Now;

                _cliente.manutencao("usp_manutencao_cliente", "alterar");
                retorno = "Alterado com sucesso";

            }
            catch (Exception ex)
            {

                retorno = "Falha, motivo: " + ex.ToString();
            }


            return retorno;
        }


        [WebMethod]
        public static string ExcluirIdContato(int id)
        {

            string retorno = null;


            try
            {
                Contato contato = new Contato();
                retorno = contato.Apagar(id);
            }
            catch (Exception ex)
            {

                retorno = "Falha, motivo: " + ex.ToString();
            }


            return retorno;
        }

        [WebMethod]
        public static string ExcluirIdEndereco(int id)
        {

            string retorno = null;


            try
            {
                Endereco endereco = new Endereco();
                retorno = endereco.Apagar(id);
            }
            catch (Exception ex)
            {

                retorno = "Falha, motivo: " + ex.ToString();
            }


            return retorno;
        }

        [WebMethod]
        public static string ExcluirIdMovimentacao(int id)
        {

            string retorno = null;


            try
            {
                Movimentacao movimentacao = new Movimentacao();
                retorno = movimentacao.Apagar(id);
            }
            catch (Exception ex)
            {

                retorno = "Falha, motivo: " + ex.ToString();
            }


            return retorno;
        }

        

        protected void btnGravaEnd_Click(object sender, EventArgs e)
        {
            try
            {
                ObjetoTransferencia.Endereco endereco = new Endereco();

                endereco.id_cliente = Convert.ToInt32(hidcliente.Value);
                //endereco.id_comarca = Convert.ToInt32(ddl_cidade.SelectedValue.ToString());
                endereco.logradouro = txtLogradouro.Text;
                endereco.bairro = txtBairro.Text;
                endereco.complemento = txtComplemento.Text;
                endereco.numero = txtNumero.Text;
                endereco.principal = 1;
                endereco.cep = txtCep.Text;
                endereco.comarca = txtComarca.Text;
                endereco.uf = txtUF.Text;

                string comando = "";

                if (!string.IsNullOrEmpty(hidendereco.Value))
                {
                    comando = "alterar";
                    endereco.id = Convert.ToInt32(hidendereco.Value);
                }
                else
                {
                    comando = "inserir";
                }


                endereco.manutencao("usp_manutencao_endereco", comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar inserir, motivo: " + ex.ToString());
            }


        }

        protected void btnGravaContato_Click(object sender, EventArgs e)
        {
            try
            {
                ObjetoTransferencia.Contato contato = new Contato();

                contato.id_cliente = Convert.ToInt32(hidcliente.Value);
                contato.ddd = txtDDD.Text;
                contato.telefone = txtTelefone.Text;
                contato.apagado = 0;
                contato.principal = checkPrincipal.Checked ? 1 : 0;
                contato.id_obs = Convert.ToInt32(obs_contato.SelectedValue.ToString());

                string comando = "";

                if (!string.IsNullOrEmpty(hidContato.Value))
                {
                    comando = "alterar";
                    contato.id = Convert.ToInt32(hidContato.Value);
                }
                else
                {
                    comando = "inserir";
                }


                contato.manutencao("usp_manutencao_contato", comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar inserir, motivo: " + ex.ToString());
            }


        }

        protected void btnGravaMovimentacao_Click(object sender, EventArgs e)
        {

            try
            {
                //string valor = Request["__EVENTARGUMENT"];
                //int id;
                //bool alteracao = int.TryParse(valor, out id);


                ObjetoTransferencia.Movimentacao movimentacao = new Movimentacao();
                movimentacao.id_cliente = Convert.ToInt32(hidcliente.Value);


                DateTime dt;
                if (DateTime.TryParse(txtDataMovimentacao.Text, out dt))
                    movimentacao.data = dt;

                movimentacao.dataalt = null;
                movimentacao.datacad = null;
                movimentacao.id_tipo = Convert.ToInt32(ddlTipoMovimentacao.SelectedValue.ToString());
                movimentacao.texto = txtTextoMovimentacao.Text;


                string comando = "";

                if (!string.IsNullOrEmpty(hidMovimentacao.Value))
                {
                    comando = "alterar";
                    movimentacao.id = Convert.ToInt32(hidMovimentacao.Value);
                }
                else
                {
                    comando = "inserir";
                }



                movimentacao.manutencao("usp_manutencao_movimentacao", comando);

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar gravar movimentação, motivo: " + ex.Message);
            }



        }
    }
}