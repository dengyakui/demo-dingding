using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Login(string authCode)
        {
            var baseUrl = "https://oapi.dingtalk.com";
            // fetch access token
            var client = new HttpClient();
            var response =
                await client.GetStringAsync(
                    $"{baseUrl}/gettoken?appkey={Constant.APP_KEY}&appsecret={Constant.APP_SECRET}");
            var resObj = JsonConvert.DeserializeObject<GetAccessTokenResponse>(response);
            if (resObj.errcode != 0)
            {
                return Json(resObj);
            }

            // fetch user id by access_token
            var responseStr =
                await client.GetStringAsync(
                    $"{baseUrl}/user/getuserinfo?access_token={resObj.access_token}&code={authCode}");
            var userIdResponse = JsonConvert.DeserializeObject<GetUserIdResponse>(responseStr);
            if (userIdResponse.errcode != 0)
            {
                return Json(userIdResponse);
            }

            // fetch user info by userId and token
            var getUserRes = await client.GetStringAsync(
                $"{baseUrl}/user/get?access_token={resObj.access_token}&userid={userIdResponse.userid}");

            var userInfoRes = JsonConvert.DeserializeObject<UserDetail>(getUserRes);
            if (userInfoRes.errcode != 0)
            {
                return Json(userInfoRes.errmsg);
            }


            return Ok(new
            {
                Result = new
                {
                    userId = userInfoRes.userid,
                    userName = userInfoRes.name
                }
            });

        }
    }
}
