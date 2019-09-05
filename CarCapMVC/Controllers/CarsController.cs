using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarCapMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarCapMVC.Controllers
{
    public class CarsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCars()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("Cars/");
            var result = await response.Content.ReadAsAsync<List<CarInfo>>();
            return View(result);
        }
        public async Task<IActionResult> GetCarById(int id)
        {
            
            var client = GetHttpClient();
            var response = await client.GetAsync($"Cars/{id}");
            var result = await response.Content.ReadAsAsync<CarInfo>();
            return View(result);
        }

        public async Task<IActionResult> SearchCars(string make, string model, string year, string color)
        {

            var client = GetHttpClient();

            if (!string.IsNullOrWhiteSpace(make))
            {
                make.Trim().Replace(" ", "+"); 
            }
            if (!string.IsNullOrWhiteSpace(model))
            {
                model.Trim().Replace(" ", "+");
            }
            if (!string.IsNullOrWhiteSpace(year))
            {
                year.Trim().Replace(" ", "");
            }
            if (!string.IsNullOrWhiteSpace(color))
            {
                color.Trim().Replace(" ", "+");
            }
            var response = await client.GetAsync($"search?make={make}&model={model}&year={year}&color={color}");
            var result = await response.Content.ReadAsAsync<IEnumerable<CarInfo>>();
            return View(result);
        }

        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            return client;
        }


    }
}