using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TodoRESTS
{
    public interface IHttpClientHandlerService
    {        HttpClientHandler GetInsecureHandler();
    }
}
