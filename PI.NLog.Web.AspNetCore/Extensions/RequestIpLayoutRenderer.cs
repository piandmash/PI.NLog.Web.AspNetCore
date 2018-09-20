using Microsoft.AspNetCore.Http;
using NLog;
using NLog.LayoutRenderers;
using NLog.Web.LayoutRenderers;
using System.Text;

// With thanks to Ian Williams from Takka Productions for this Extension from his TurboDash

namespace PI.Core.NLog.Extensions
{
    /// <summary>
    /// Render the request IP for ASP.NET Core
    /// </summary>
    /// <example>
    /// <code lang="NLog Layout Renderer">
    /// ${aspnet-request-ip}
    /// </code>
    /// </example>
    [LayoutRenderer("aspnet-request-ip")]
    public class RequestIpLayoutRenderer : AspNetLayoutRendererBase
    {
        protected override void DoAppend(StringBuilder builder, LogEventInfo logEvent)
        {
            var httpContext = HttpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return;
            }
            builder.Append(httpContext.Connection.RemoteIpAddress);
        }
    }
}
