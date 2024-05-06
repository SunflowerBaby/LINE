using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_LINE.Controllers
{
    public class LineNotifyController : Controller
    {

        // GET: LineNotify
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SendNotify()
        {
            // 請將YOUR_ACCESS_TOKEN替換為您的存取權杖
            string accessToken = "Gw7zvjqaOdHCiRtzZUuLpxE7zArdfLP8XPNZZ56f4sp";

            // 訊息內容
            string message = "這是來自ASP.NET Core的LINE Notify訊息！";

            // LINE Notify的API端點
            string apiEndpoint = "https://notify-api.line.me/api/notify";

            // 使用HttpClient發送POST請求
            using (HttpClient client = new HttpClient())
            {
                // 設置請求標頭
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // 準備要發送的訊息
                var content = new StringContent($"message={message}", Encoding.UTF8, "application/x-www-form-urlencoded");

                // 發送POST請求
                HttpResponseMessage response = await client.PostAsync(apiEndpoint, content);

                // 檢查回應是否成功
                //if (response.IsSuccessStatusCode)
                //{
                //    ViewBag.Message = "訊息已成功發送到LINE Notify！";
                //}
                //else
                //{
                //    ViewBag.Message = $"發送訊息到LINE Notify失敗，狀態碼：{response.StatusCode}";
                //}

                if (response.IsSuccessStatusCode)
                {
                    return Content("訊息已成功發送到LINE Notify！");
                }
                else
                {
                    return Content($"發送訊息到LINE Notify失敗，狀態碼：{response.StatusCode}");
                }
            }

            //return View();
        }
    }
}