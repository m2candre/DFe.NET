﻿/********************************************************************************/
/* Projeto: Biblioteca ZeusNFe                                                  */
/* Biblioteca C# para emissão de Nota Fiscal Eletrônica - NFe e Nota Fiscal de  */
/* Consumidor Eletrônica - NFC-e (http://www.nfe.fazenda.gov.br)                */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/

using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NFe.Wsdl.DistribuicaoDFe
{
    public class NfeDistDFeInteresse : NFeDistribuicaoDFeSoapClient, INfeServico
    {
        public NfeDistDFeInteresse(string url, X509Certificate certificado, int timeOut) : base(url)
        {
            base.ClientCredentials.ClientCertificate.Certificate = (X509Certificate2)certificado;
        }

        public nfeCabecMsg nfeCabecMsg { get; set; }

       
        public XmlNode Execute(XmlNode nfeDadosMsg)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(nfeDadosMsg.InnerXml);
            var result = base.nfeDistDFeInteresseAsync(doc.DocumentElement).Result;
            return result.Body.nfeDistDFeInteresseResult;
        }

    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class nfeDistDFeInteresseRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "nfeDistDFeInteresse", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", Order = 0)]
        public nfeDistDFeInteresseRequestBody Body;

        public nfeDistDFeInteresseRequest()
        {
        }

        public nfeDistDFeInteresseRequest(nfeDistDFeInteresseRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe")]
    public partial class nfeDistDFeInteresseRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.XmlElement nfeDadosMsg;

        public nfeDistDFeInteresseRequestBody()
        {
        }

        public nfeDistDFeInteresseRequestBody(System.Xml.XmlElement nfeDadosMsg)
        {
            this.nfeDadosMsg = nfeDadosMsg;
        }
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class nfeDistDFeInteresseResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "nfeDistDFeInteresseResponse", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", Order = 0)]
        public nfeDistDFeInteresseResponseBody Body;

        public nfeDistDFeInteresseResponse()
        {
        }

        public nfeDistDFeInteresseResponse(nfeDistDFeInteresseResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe")]
    public partial class nfeDistDFeInteresseResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.XmlElement nfeDistDFeInteresseResult;

        public nfeDistDFeInteresseResponseBody()
        {
        }

        public nfeDistDFeInteresseResponseBody(System.Xml.XmlElement nfeDistDFeInteresseResult)
        {
            this.nfeDistDFeInteresseResult = nfeDistDFeInteresseResult;
        }
    }

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe", ConfigurationName = "NFeDistribuicaoDFeSoap")]
    public interface NFeDistribuicaoDFeSoap : IChannel
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeDistribuicaoDFe/nfeDistDFeInteresse", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        System.Threading.Tasks.Task<nfeDistDFeInteresseResponse> nfeDistDFeInteresseAsync(nfeDistDFeInteresseRequest request);
    }
    

    public partial class NFeDistribuicaoDFeSoapClient : SoapBindingClient<NFeDistribuicaoDFeSoap>
    {
        public NFeDistribuicaoDFeSoapClient(string endpointAddressUri) : base(endpointAddressUri)
        {
        }

        public System.Threading.Tasks.Task<nfeDistDFeInteresseResponse> nfeDistDFeInteresseAsync(System.Xml.XmlElement nfeDadosMsg)
        {
            nfeDistDFeInteresseRequest inValue = new nfeDistDFeInteresseRequest();
            inValue.Body = new nfeDistDFeInteresseRequestBody();
            inValue.Body.nfeDadosMsg = nfeDadosMsg;
            return ((NFeDistribuicaoDFeSoap)(this.Channel)).nfeDistDFeInteresseAsync(inValue);
        }
    }
}
