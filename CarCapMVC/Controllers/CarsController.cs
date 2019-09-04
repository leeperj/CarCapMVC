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
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            var response = await client.GetAsync("GetCars/");
            var result = await response.Content.ReadAsAsync<List<CarInfo>>();
            return View(result);
        }
        public async Task<IActionResult> GetCarById(int id)
        {
             
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            var response = await client.GetAsync($"GetCars/{id}");
            var result = await response.Content.ReadAsAsync<CarInfo>();
            return View(result);

        }

        public async Task<IActionResult> GetCarByMake(string make)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            var response = await client.GetAsync($"GetCars/{make}");
            var result = await response.Content.ReadAsAsync<CarInfo>();
            return View(result);
        }

        public async Task<IActionResult> GetCarByModel(string model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            var response = await client.GetAsync($"GetCars/{model}");
            var result = await response.Content.ReadAsAsync<CarInfo>();
            return View(result);
        }

        public async Task<IActionResult> GetCarByYear(string year)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            var response = await client.GetAsync($"GetCars/{year}");
            var result = await response.Content.ReadAsAsync<CarInfo>();
            return View(result);
        }
        public async Task<IActionResult> GetCarByColor(string color)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/api/");
            var response = await client.GetAsync($"GetCars/{color}");
            var result = await response.Content.ReadAsAsync<CarInfo>();
            return View(result);
        }


    }
}