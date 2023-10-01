using Microsoft.AspNetCore.Mvc;
using Pierwszy.Models;
using System.Diagnostics;

namespace Pierwszy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About ()
        {
            ViewBag.Name = "Dawid";
            ViewBag.Time = DateTime.Now.Hour;
            ViewBag.Welcome = ViewBag.Time < 17 ? "Dzień Dobry":"Dobry Wieczór";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Nowak"},
                new Dane {Name = "Dawid", Surname = "Pietruszka"},
                new Dane {Name = "Mateusz", Surname = "Kowalski"}
            };

            return View(osoby);
        }

        public IActionResult UrodzinyForm()
        {
            return View();

        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.welcomeYear = $"Witaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok}";
            return View(urodziny);
        }

        public IActionResult CalculatorForm()
        {
            return View();

        }

        public IActionResult Calculator(Number numbers, string dzialanie)
        {
            double wynik = 0;

            switch (dzialanie)
            {
                case "Dodawanie":
                    wynik = numbers.xValue + numbers.yValue;
                    break;
                case "Odejmowanie":
                    wynik = numbers.xValue - numbers.yValue;
                    break;
                case "Mnożenie":
                    wynik = numbers.xValue * numbers.xValue;
                    break;
                case "Dzielenie":
                    if (numbers.yValue != 0)
                    {
                        wynik = numbers.xValue / numbers.yValue;
                    }
                    else
                    {
                        ViewBag.Wynik = "Nie można dzielić przez zero";
                        return View();
                    }
                    break;
                default:
                    ViewBag.Wynik = "0";
                    return View();
            }
            ViewBag.Wynik = wynik;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}