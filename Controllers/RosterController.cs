using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using comp4870_assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace comp4870_assignment_1.Controllers
{
    public class RosterController : Controller
    {
        const string BASE_URL = "https://statsapi.web.nhl.com/api/v1";
        public async Task<IActionResult> Index()
        {
            List<RosterItem> roster = new List<RosterItem>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BASE_URL}/teams/2/roster"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    roster = JsonConvert.DeserializeObject<List<RosterItem>>(apiResponse);
                }
            }
            return View(roster);
        }

        public async Task<IActionResult> PlayerAsync(string link)
        {
            PlayerList playerList = new PlayerList();
            string id = link.Split('/').Last();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BASE_URL}/people/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    playerList = JsonConvert.DeserializeObject<PlayerList>(apiResponse);
                }
            }
            return View(playerList.people);
        }
    }
}