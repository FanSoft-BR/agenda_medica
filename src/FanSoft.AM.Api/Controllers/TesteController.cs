using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.AM.Api.Controllers
{
    public class TesteController
    {

        [HttpGet("api/v1/ping"), AllowAnonymous]
        public string Ping() => "Pong";
    }
}
