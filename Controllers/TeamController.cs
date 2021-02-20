using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comp4870_assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using comp4870_assignment_1.DS;

namespace comp4870_assignment_1.Controllers
{
    public class TeamController : Controller
    {

        const string BASE_URL = "https://statsapi.web.nhl.com/api/v1";
        private readonly ILogger<TeamController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public TeamResponseDS TeamRes { get; set; }
        public PlayerResponseDS RosterRes { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<RosterItem> Players { get; set; }


        public TeamController(ILogger<TeamController> logger, IHttpClientFactory clientFactory) 
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult>  Index()
        {
            var getTeams = new HttpRequestMessage();
            getTeams.Method = HttpMethod.Get;
            getTeams.RequestUri = new Uri($"{BASE_URL}/teams");
            getTeams.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(getTeams);

            if (response.IsSuccessStatusCode) 
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                TeamRes = await JsonSerializer.DeserializeAsync<TeamResponseDS>(responseStream);
                Teams = TeamRes.teams;
            } else 
            {
                Teams = Array.Empty<Team>();
            }

            return View(Teams);
        }

        public async Task<IActionResult> Details(int id)
        {
            var getTeamWithID = new HttpRequestMessage();
            getTeamWithID.Method = HttpMethod.Get;
            getTeamWithID.RequestUri = new Uri($"{BASE_URL}/teams/{id}/roster");
            getTeamWithID.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(getTeamWithID);

            if (response.IsSuccessStatusCode) {
                var responseStream = await response.Content.ReadAsStreamAsync();
                RosterRes = await JsonSerializer.DeserializeAsync<PlayerResponseDS>(responseStream);
                Players = RosterRes.roster;
                
            } 
            
            return View(Players);
        }
    }
}