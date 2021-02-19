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
        public async Task<IActionResult> Index()
        {
            Roster roster = new Roster();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://statsapi.web.nhl.com/api/v1/teams/2/roster"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    roster = JsonConvert.DeserializeObject<Roster>(apiResponse);
                }
            }
            return View(roster.roster);
        }

        public async Task<IActionResult> PlayerAsync(string link)
        {
            PlayerList playerList = new PlayerList();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://statsapi.web.nhl.com" + link))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    playerList = JsonConvert.DeserializeObject<PlayerList>(apiResponse);
                }
            }
            return View(playerList.people);
        }
    }
}