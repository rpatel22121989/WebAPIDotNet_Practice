using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Net;

namespace WebAPI_Practice.Handlers
{
    public class HttpMethodRestrictionHandler : DelegatingHandler
    {

        private readonly string[] _allowedVerbs;
        public HttpMethodRestrictionHandler(params string[] allowedVerbs)
        {
            _allowedVerbs = allowedVerbs;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var method = request.Method.Method;

            if (!_allowedVerbs.Contains(method))
            {
                var response = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed)
                {
                    Content = new StringContent("Method Not Allowed")
                };
                var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
                taskCompletionSource.SetResult(response);
                return taskCompletionSource.Task;
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}