using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace WebZSPrev.ObjetoTransferencia
{
    public class WsInfoqualy
    {

        // parametros:
        public string _cliente { get; set; }
        public string _usuario { get; set; }
        public string _senha { get; set; }
        public string _url { get; set; }






        public WsInfoqualy()
        {
            _cliente = "Zamarioli Advocacia";
            _usuario = "zamarioliadv@gmail.com";
            _senha = "ro0708";
            _url = "http://199.119.103.31/localizacao.asmx/";
        }

        private string RequestInfoqualy(string url)
        {
            string retorno = "";

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    retorno =
                        client.DownloadString(url);
                    retorno = retorno.Replace("&#13", "");
                }
                catch (Exception ex)
                {
                    retorno = "Erro.: " + ex.Message;
                }
            }

            return retorno;
        }


        private string ExtrairAtributo(XmlNode node, string nodeName)
        {
            var obj = node.SelectSingleNode(nodeName);
            if (obj != null)
            {
                return obj.InnerText.Trim();
            }
            else
            {
                return null;
            }
        }


        XmlDocument doc;

        int qtd_novo;

        public string Start(string id)
        {
            try
             {
                ClienteListaWs lista = Trata(id);

                ClienteListaWs listaCliente = ConsultaPorCpf(lista);
                qtd_novo = 0;

                foreach (ClienteWs cliente in listaCliente)
                {




                    string strNovo = cliente.Update();

                    // contador dos casos novos

                    int novo = 0;
                    if (int.TryParse(strNovo, out novo))
                    {
                        qtd_novo = qtd_novo + novo;
                    }
                    

                    foreach (TelefoneWs tel in cliente.listaTelefone)
                    {
                        string _temp = tel.numero;

                        tel.Inserir(cliente.id);
                    }

                    foreach (EnderecoWs endereco in cliente.listaEndereco)
                    {
                        endereco.inserir(cliente.id);
                    }

                }


                return "Sucesso! Número de novos clientes atualizados.: " + qtd_novo.ToString();

            }

            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public ClienteListaWs Trata(string id)
        {
            ClienteWs cliente = new ClienteWs();
            ClienteListaWs lista = cliente.Consulta_por_id(id);
            ClienteListaWs novaLista = new ClienteListaWs();

            foreach (ClienteWs item in lista)
            {
                string cpf;
                doc = new XmlDocument();

                // Montando a url
                string url_por_nome = _url + "ConsultaNome?Cliente=" + _cliente + "&Usuario=" + _usuario + "&Senha=" + _senha + "&Nome=" + item.nome + "&DataNasc=&NomeMae=&Cidade=&UF=";

                // Fazer requisicao por nome, verificar se existem apenas 1 item e copiar o cpf.
                if (item.cpf == null || item.cpf == "" || item.cpf == " ")
                {
                    try
                    {
                        var xml = RequestInfoqualy(url_por_nome);
                        doc.LoadXml(xml);
                        XmlNodeList Pessoas = doc.DocumentElement.SelectNodes("/CONSULTANOME/DADOS/PESSOA");




                        List<XmlNode> listaDePessoasComMesmoNome = new List<XmlNode>();


                        // Obtem CPF
                        int cont = 0;
                        foreach (XmlNode Pessoa in Pessoas)
                        {

                            if (item.nome.Trim() == ExtrairAtributo(Pessoa, "NOME"))
                            {
                                listaDePessoasComMesmoNome.Add(Pessoa);
                            }
                        }

                        List<string> listaCpfsPessoasComMesmoNome = new List<string>();

                        foreach (XmlNode pessoa in listaDePessoasComMesmoNome)
                        {
                            listaCpfsPessoasComMesmoNome.Add(ExtrairAtributo(pessoa, "DOCUMENTO"));
                        }

                




                        if (listaDePessoasComMesmoNome.Count == 1)
                        {
                            XmlNode pessoa1 = listaDePessoasComMesmoNome[0];
                            item.cpf = ExtrairAtributo(pessoa1, "DOCUMENTO"); // obter o cpf
                        }
                        else if(listaDePessoasComMesmoNome.Count > 1)
                        {
                            // verificar se todos os cpfs são iguais...:

                            int qtd_duplicada = listaCpfsPessoasComMesmoNome.Distinct().Count();



                            // se for 1, ou seja, nao exite outro cpf para a mesma lista de nomes!
                            if(1 == qtd_duplicada)
                            {
                                item.cpf = listaCpfsPessoasComMesmoNome[0];
                            }

                        }
                        else
                        {
                            item.cpf = null;
                        }

                   





                    }
                    catch
                    {

                    }
                }


                novaLista.Add(item);

            }



            return novaLista;
        }



        public string formataCPF(string cpf)
        {
            try
            {
                return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");

            }
            catch
            {
                return cpf;
            }
        }


        int qtd_com_retorno_ws = 0;

        public ClienteListaWs ConsultaPorCpf(ClienteListaWs lista)
        {
            qtd_com_retorno_ws = 0;

            ClienteListaWs novaLista = new ClienteListaWs();

            foreach (ClienteWs cliente in lista)
            {

                cliente.listaEndereco = new EnderecoListaWs();
                cliente.listaTelefone = new TelefoneListaWs();

                if (cliente.cpf != null && cliente.cpf != "" && cliente.cpf != " ")
                {

              



                    doc = new XmlDocument();

                    
                    string url_por_cpf = _url + "ConsultaCPFCompleta?Cliente=" + _cliente + "&Usuario=" + _usuario + "&Senha=" + _senha + "&CPF=" + cliente.cpf.Replace("-", "").Replace(".", "");

                    var xml = RequestInfoqualy(url_por_cpf);
                    doc.LoadXml(xml);

                    cliente.find_infoqualy = 1;



                    XmlNode Pessoa = doc.DocumentElement.SelectNodes("/ConsultaCPFCompleta/DADOS")[0];

                    // Incrementa qtd de registros localizados no infoqualy
                    qtd_com_retorno_ws++;

                    // Dados Pessoa
                    cliente.cpf = formataCPF(ExtrairAtributo(Pessoa, "CPF"));
                    cliente.data_nascimento = ExtrairAtributo(Pessoa, "DATA_NASC");
                    cliente.rg = ExtrairAtributo(Pessoa, "RG");
                    cliente.escolaridade = ExtrairAtributo(Pessoa, "ESCOLARIDADE");



                    // Dados Telefones
                    XmlNodeList TelefonesComerciais = Pessoa.SelectNodes("TELEFONES_COMERCIAIS/TELEFONE");
                    foreach (XmlNode TelefoneComercial in TelefonesComerciais)
                    {


                        string strTelefone = null;

                        if (TelefoneComercial != null) strTelefone = TelefoneComercial.InnerText;

                        TelefoneWs tel = new TelefoneWs()
                        {
                            numero = strTelefone,
                            tipo = "COMERCIAL"
                        };

                        cliente.listaTelefone.Add(tel);

                    }

                    XmlNodeList TelefonesMoveis = Pessoa.SelectNodes("TELEFONES_MOVEIS/TELEFONE");
                    foreach (XmlNode TelefoneMovel in TelefonesMoveis)
                    {


                        string strTelefone = null;

                        if (TelefoneMovel != null) strTelefone = TelefoneMovel.InnerText;

                        TelefoneWs tel = new TelefoneWs()
                        {
                            numero = strTelefone,
                            tipo = "MOVEL"
                        };

                        cliente.listaTelefone.Add(tel);

                    }

                    XmlNodeList TelefonesFixo = Pessoa.SelectNodes("TELEFONES_FIXOS/TELEFONE");
                    foreach (XmlNode TelefoneFixo in TelefonesFixo)
                    {


                        string strTelefone = null;

                        if (TelefoneFixo != null) strTelefone = TelefoneFixo.InnerText;

                        TelefoneWs tel = new TelefoneWs()
                        {
                            numero = strTelefone,
                            tipo = "FIXO"
                        };

                        cliente.listaTelefone.Add(tel);

                    }


                    // Dados endereco
                    XmlNodeList Enderecos = Pessoa.SelectNodes("ENDERECOS/ENDERECO");
                    foreach (XmlNode Endereco in Enderecos)
                    {

                        EnderecoWs endereco = new EnderecoWs();

                        endereco.tipoLogradouro = ExtrairAtributo(Endereco, "TIPO_LOGRADOURO");
                        endereco.logradouro = ExtrairAtributo(Endereco, "LOGRADOURO");
                        endereco.numero = ExtrairAtributo(Endereco, "NUMERO");
                        endereco.bairro = ExtrairAtributo(Endereco, "BAIRRO");
                        endereco.cidade = ExtrairAtributo(Endereco, "CIDADE");
                        endereco.uf = ExtrairAtributo(Endereco, "UF");
                        endereco.cep = ExtrairAtributo(Endereco, "CEP");

                        cliente.listaEndereco.Add(endereco);
                    }
                }
                else
                {
                    cliente.find_infoqualy = 0;
                }


                novaLista.Add(cliente);
            }


            return novaLista;
        }



        public class ClienteWs
        {
            public string id { get; set; }
            public string nome { get; set; }
            public string cpf { get; set; }
            public string sexo { get; set; }
            public string data_nascimento { get; set; }
            public string rg { get; set; }
            public string escolaridade { get; set; }
            public int find_infoqualy { get; set; }

            public TelefoneListaWs listaTelefone { get; set; }
            public EnderecoListaWs listaEndereco { get; set; }
            public EmailListaWb listaEmail { get; set; }


            public string Update()
            {
                AcessaDados.AcessaDadosSqlServer acessa = new AcessaDados.AcessaDadosSqlServer();


                try
                {

                    string retorno = null;



                    acessa.LimpaParametros();

                    acessa.AdicionarParametros("@id", this.id);
                    acessa.AdicionarParametros("@nome", this.nome);
                    acessa.AdicionarParametros("@cpf", this.cpf);
                    acessa.AdicionarParametros("@sexo", this.sexo);
                    acessa.AdicionarParametros("@find_infoqualy", this.find_infoqualy);


                    if (this.data_nascimento != null)
                    {
                        DateTime data;
                        if (DateTime.TryParse(this.data_nascimento, out data))
                        {
                            acessa.AdicionarParametros("@data_nascimento", this.data_nascimento);
                        }
                    }


                    acessa.AdicionarParametros("@rg", this.rg);
                    acessa.AdicionarParametros("@escolaridade", this.escolaridade);


                    acessa.AdicionarParametros("@metodo", "update_cliente");



                    retorno = acessa.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_ws").ToString();


                    return retorno;


                }
                catch (Exception erro)
                {

                    throw new Exception(erro.Message);
                }

            }


            public ClienteListaWs Consulta_por_id(string id)
            {

                try
                {
                    AcessaDados.AcessaDadosSqlServer acessa = new AcessaDados.AcessaDadosSqlServer();

                    acessa.AdicionarParametros("@id", id);
                    acessa.AdicionarParametros("@metodo", "consultar");

                    DataTable dt;
                    ClienteListaWs clienteLista = new ClienteListaWs();

                    using (dt = acessa.ExecutaConsulta(CommandType.StoredProcedure, "usp_manutencao_ws"))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            ClienteWs novoClienteWs = new ClienteWs();


                            novoClienteWs.nome = dr["nome"].ToString();
                            novoClienteWs.id = dr["id"].ToString();
                            novoClienteWs.cpf = dr["cpf"].ToString();


                            clienteLista.Add(novoClienteWs);
                        }
                    }


                    return clienteLista;

                }
                catch (Exception erro)
                {

                    throw new Exception(erro.Message);
                }

            }


        }

        public class ClienteListaWs : List<ClienteWs>
        {

        }

        public class TelefoneWs
        {
            public string numero { get; set; }
            public string tipo { get; set; }
            public string ddd { get; set; }


            AcessaDados.AcessaDadosSqlServer acessa = new AcessaDados.AcessaDadosSqlServer();

            public string Inserir(string id_cliente)
            {
                try
                {

                    string retorno = null;
                    acessa.LimpaParametros();


                    string strDDD = null;
                    string strNumero = null;

                    try
                    {
                        strDDD = this.numero.Substring(0, 2);
                        strNumero = this.numero.Substring(2, (this.numero.Length - 2));
                    }
                    catch
                    {



                    }

                    string id_obs = null;

                    if (this.tipo == "FIXO")
                    {
                        id_obs = "13";
                    }
                    else if (this.tipo == "COMERCIAL")
                    {
                        id_obs = "6";
                    }
                    else if (this.tipo == "RESIDENCIAL")
                    {
                        id_obs = "5";
                    }
                    else if (this.tipo == "MOVEL")
                    {
                        id_obs = "11";

                    }

                    acessa.AdicionarParametros("@numero_tel", strNumero);
                    acessa.AdicionarParametros("@ddd", strDDD);
                    acessa.AdicionarParametros("@id_obs", id_obs);
                    acessa.AdicionarParametros("@id", id_cliente);


                    acessa.AdicionarParametros("@metodo", "inserir_telefone");


                    retorno = acessa.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_ws").ToString();
                    return retorno;

                }
                catch (Exception erro)
                {

                    throw new Exception(erro.Message);
                }
            }
        }

        public class TelefoneListaWs : List<TelefoneWs>
        {

        }

        public class EnderecoWs
        {
            public string tipoLogradouro { get; set; }
            public string logradouro { get; set; }
            public string numero { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
            public string cep { get; set; }


            public string inserir(string id)
            {
                try
                {

                    AcessaDados.AcessaDadosSqlServer acessa = new AcessaDados.AcessaDadosSqlServer();
                    acessa.LimpaParametros();
                    acessa.AdicionarParametros("@id", id);
                    acessa.AdicionarParametros("@tipo_logradouro", this.tipoLogradouro);
                    acessa.AdicionarParametros("@logradouro", this.logradouro);
                    acessa.AdicionarParametros("@numero", this.numero);
                    acessa.AdicionarParametros("@bairro", this.bairro);
                    acessa.AdicionarParametros("@cidade", this.cidade);
                    acessa.AdicionarParametros("@uf", this.uf);
                    acessa.AdicionarParametros("@cep", this.cep);

                    acessa.AdicionarParametros("@metodo", "inserir_endereco");

                    return acessa.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_ws").ToString();

                }
                catch (Exception erro)
                {

                    throw new Exception(erro.Message);
                }
            }
        }

        public class EnderecoListaWs : List<EnderecoWs>
        {

        }

        public class EmailWb
        {
            public string email { get; set; }

            public string inserir(EmailWb email, string id)
            {
                AcessaDados.AcessaDadosSqlServer acessa = new AcessaDados.AcessaDadosSqlServer();

                try
                {
                    acessa.LimpaParametros();
                    acessa.AdicionarParametros("@email", email.email);
                    acessa.AdicionarParametros("@id", id);

                    acessa.AdicionarParametros("@metodo", "inserir_email");


                    return acessa.ExecutaManipulacao(System.Data.CommandType.StoredProcedure, "usp_manutencao_ws").ToString();
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }
        }

        public class EmailListaWb : List<EmailWb>
        {

        }
    }

}