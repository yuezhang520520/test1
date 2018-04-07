using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Group
{
    public class SignalRException:HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            base.OnIncomingError(exceptionContext, invokerContext);
            //todo:记录到Log4Net或分布式日志服务器中


            dynamic caller = invokerContext.Hub.Clients.Caller;
            caller.onServerError(exceptionContext.Error.Message);
        }
    }
}