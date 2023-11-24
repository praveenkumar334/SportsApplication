using Microsoft.AspNetCore.Mvc;
using SportsApplication.Models;
using System.Data;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace SportsApplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginModel loginModel)
        {
            string apiUrl = "http://localhost:5128/api/User/CheckUser";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl + "?email=" + loginModel.Email + "&pwd=" + loginModel.Password);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User list = await response.Content.ReadFromJsonAsync<User>();
                    if (list.RoleId == 1 || list.RoleId == 2)
                        return RedirectToAction("Coach");
                    else
                        return RedirectToAction("CoachCaption");
                }
                response = client.GetAsync(client.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  

                    return RedirectToAction("Coach");

                }

            }
            ViewBag.Message = "Incorrect user name or password.";
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel e)
        {
            string apiUrl = "http://localhost:5128/api/User/AddUser";
            User user = GetUser(e);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, user);
                if (response.IsSuccessStatusCode)
                {
                    RedirectToAction("Coach");

                }

            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(RegisterViewModel userModel)
        {
            string apiUrl = "http://localhost:5128/api/User/AddUser";
            User user = GetUser(userModel, 3);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, user);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Coach");

                }

            }
            return View();
        }

        public async Task<IActionResult> Coach()
        {
            string apiUrl = "http://localhost:5128/api/User/GetUsers";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    List<User> list = await response.Content.ReadFromJsonAsync<List<User>>();

                    return View("Coach", list);

                }

            }
            return View();
        }

        public async Task<IActionResult> CoachCaption()
        {
            string apiUrl = "http://localhost:5128/api/User/GetCoachCaption";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    List<User> list = await response.Content.ReadFromJsonAsync<List<User>>();

                    return View("CoachCaption", list);

                }

            }
            return View();
        }

        public User GetUser(RegisterViewModel registerViewModel, int roleId = 1)
        {
            User user = new User();
            user.Id = 0;
            user.RoleId = roleId;
            user.FirstName = registerViewModel.FirstName;
            user.LastName = registerViewModel.LastName;
            user.TotalMatchesPlayed = registerViewModel.TotalMatchesPlayed;
            user.Email = registerViewModel.Email;
            user.Password = registerViewModel.Password;
            user.Contactnumber = registerViewModel.Contactnumber;
            user.DateOfBirth = Convert.ToDateTime(registerViewModel.DateOfBirth);
            user.Height = registerViewModel.Height;
            user.Weight = registerViewModel.Weight;

            return user;

        }
    }
}
