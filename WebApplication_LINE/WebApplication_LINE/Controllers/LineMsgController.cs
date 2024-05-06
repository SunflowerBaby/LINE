using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication_LINE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineMsgController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> ReceiveMessage()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                // 在這裡處理收到的訊息，根據您的應用程式需求進行相應的處理
                // body變數中包含了收到的LINE Notify訊息內容
                // 例如，您可以解析JSON訊息，並執行相應的業務邏輯
            }

            return Ok();
        }

        private object Ok()
        {
            throw new NotImplementedException();
        }
    }
}