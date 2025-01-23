using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace NorthwindWCFService
{
    public class CustomCorsBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CorsMessageInspector());
        }

        public void Validate(ServiceEndpoint endpoint) { }
    }

    public class CorsMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var httpRequest = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            if (httpRequest.Method == "OPTIONS")
            {
                var reply = Message.CreateMessage(MessageVersion.None, null);
                var httpResponse = new HttpResponseMessageProperty
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    SuppressEntityBody = true
                };
                httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                httpResponse.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                httpResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, SOAPAction");
                reply.Properties[HttpResponseMessageProperty.Name] = httpResponse;
                return reply;
            }
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (reply != null && reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                var httpResponse = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            }
        }
    }

}