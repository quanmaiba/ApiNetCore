using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeCampMVC.Models;
using CodeCampMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CodeCampMVC.Controllers
{
    public class CampController : Controller
    {
        public IActionResult Index()
        {
            var todo = new List<CampViewModel>();
            var url = $"{Common.Common.ApiUrl}/Camps/GetCampsAll";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";

            var response = httpWebRequest.GetResponse();
            {
                string responseData;

                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)stream).Dispose();
                }
                todo = JsonConvert.DeserializeObject<List<CampViewModel>>(responseData);
            }
            return View(todo);
        }
         
        public IActionResult Create()
        {
            //var todo = new CampViewModel();
            //var url = $"{Common.Common.ApiUrl}/Camps/Create";
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.Method = "GET";

            //var response = httpWebRequest.GetResponse();
            //{
            //    string responseData;

            //    Stream stream = response.GetResponseStream();
            //    try
            //    {
            //        StreamReader streamReader = new StreamReader(stream);
            //        try
            //        {
            //            responseData = streamReader.ReadToEnd();
            //        }
            //        finally
            //        {
            //            ((IDisposable)streamReader).Dispose();
            //        }
            //    }
            //    finally
            //    {
            //        ((IDisposable)stream).Dispose();
            //    }
            //    todo = JsonConvert.DeserializeObject<CampViewModel>(responseData);

            //}
            //ViewBag.Location = new SelectList(todo.Location,)

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CampCreateView model)
        {
            var url = $"{Common.Common.ApiUrl}/Camps/Create";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var sw = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                sw.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                return View();
        }
    }
}