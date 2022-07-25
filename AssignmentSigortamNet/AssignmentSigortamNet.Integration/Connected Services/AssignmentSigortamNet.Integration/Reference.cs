using System;
using System.ServiceModel;

namespace Mernis.Verify.TcKimlikNo
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://tckimlik.nvi.gov.tr/WS", ConfigurationName = "Mernis.Verify.TcKimlikNo.KPSPublicSoap")]
    public interface KPSPublicSoap
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula", ReplyAction = "*")]
        System.Threading.Tasks.Task<Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaResponse> TCKimlikNoDogrulaAsync(Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class TCKimlikNoDogrulaRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "TCKimlikNoDogrula", Namespace = "http://tckimlik.nvi.gov.tr/WS", Order = 0)]
        public Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequestBody Body;

        public TCKimlikNoDogrulaRequest()
        {
        }

        public TCKimlikNoDogrulaRequest(Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://tckimlik.nvi.gov.tr/WS")]
    public partial class TCKimlikNoDogrulaRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public long TCKimlikNo;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Ad;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string Soyad;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public int DogumYili;

        public TCKimlikNoDogrulaRequestBody()
        {
        }

        public TCKimlikNoDogrulaRequestBody(long TCKimlikNo, string Ad, string Soyad, int DogumYili)
        {
            this.TCKimlikNo = TCKimlikNo;
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.DogumYili = DogumYili;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class TCKimlikNoDogrulaResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "TCKimlikNoDogrulaResponse", Namespace = "http://tckimlik.nvi.gov.tr/WS", Order = 0)]
        public Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaResponseBody Body;

        public TCKimlikNoDogrulaResponse()
        {
        }

        public TCKimlikNoDogrulaResponse(Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://tckimlik.nvi.gov.tr/WS")]
    public partial class TCKimlikNoDogrulaResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public bool TCKimlikNoDogrulaResult;

        public TCKimlikNoDogrulaResponseBody()
        {
        }

        public TCKimlikNoDogrulaResponseBody(bool TCKimlikNoDogrulaResult)
        {
            this.TCKimlikNoDogrulaResult = TCKimlikNoDogrulaResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface KPSPublicSoapChannel : Mernis.Verify.TcKimlikNo.KPSPublicSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class KPSPublicSoapClient : System.ServiceModel.ClientBase<Mernis.Verify.TcKimlikNo.KPSPublicSoap>, Mernis.Verify.TcKimlikNo.KPSPublicSoap
    {

        /// <summary>
        /// Hizmet uç noktasını yapılandırmak için bu kısmi metodu uygulayın.
        /// </summary>
        /// <param name="serviceEndpoint">Yapılandırılacak uç nokta</param>
        /// <param name="clientCredentials">İstemci kimlik bilgileri</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);


        public KPSPublicSoapClient(string endpointUrl, TimeSpan timeout) :
 base(KPSPublicSoapClient.GetBindingForEndpoint(timeout), KPSPublicSoapClient.GetEndpointAddress(endpointUrl))
        {
            this.ChannelFactory.Credentials.UserName.UserName = "abc";//never mind. web service does not check. Only needs for clientCredentials
            this.ChannelFactory.Credentials.UserName.Password = "def";
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public KPSPublicSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
         base(binding, remoteAddress)
        {

        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaResponse> Mernis.Verify.TcKimlikNo.KPSPublicSoap.TCKimlikNoDogrulaAsync(Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequest request)
        {
            return base.Channel.TCKimlikNoDogrulaAsync(request);
        }

        public System.Threading.Tasks.Task<Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaResponse> TCKimlikNoDogrulaAsync(long TCKimlikNo, string Ad, string Soyad, int DogumYili)
        {
            Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequest inValue = new Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequest();
            inValue.Body = new Mernis.Verify.TcKimlikNo.TCKimlikNoDogrulaRequestBody();
            inValue.Body.TCKimlikNo = TCKimlikNo;
            inValue.Body.Ad = Ad;
            inValue.Body.Soyad = Soyad;
            inValue.Body.DogumYili = DogumYili;
            return ((Mernis.Verify.TcKimlikNo.KPSPublicSoap)(this)).TCKimlikNoDogrulaAsync(inValue);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(TimeSpan timeout)
        {
            var httpsBinding = new BasicHttpsBinding();
            httpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            httpsBinding.Security.Mode = BasicHttpsSecurityMode.Transport;

            var integerMaxValue = int.MaxValue;
            httpsBinding.MaxBufferSize = integerMaxValue;
            httpsBinding.MaxReceivedMessageSize = integerMaxValue;
            httpsBinding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            httpsBinding.AllowCookies = true;

            httpsBinding.ReceiveTimeout = timeout;
            httpsBinding.SendTimeout = timeout;
            httpsBinding.OpenTimeout = timeout;
            httpsBinding.CloseTimeout = timeout;

            return httpsBinding;
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(string endpointUrl)
        {
            return new System.ServiceModel.EndpointAddress(endpointUrl);
        }

        public enum EndpointConfiguration
        {

            KPSPublicSoap,

            KPSPublicSoap12,
        }
    }
}