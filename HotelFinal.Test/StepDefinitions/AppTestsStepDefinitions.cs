using Castle.Core.Logging;
using FluentAssertions;
using HotelFinal.Services;
using HotelFinal.Shared;
using HotelMobileApp.ViewModel;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using HotelMobileApp.ViewModel;

namespace HotelFinal.Test.StepDefinitions
{
    [Binding]
    public class AppTestsStepDefinitions
    {
        private ScenarioContext _context;
        private HttpClient _http;
        private PublicClient _client;
        private ILogger<HotelService> _logger;
        private MainViewModel _vm;

        public AppTestsStepDefinitions(ScenarioContext context, HttpClient http, PublicClient client, ILogger<HotelService> logger, MainViewModel vm)
        {
            _context = context;
            _http = http;
            _client = client;
            _logger = logger;
            _vm = vm;
        }

        [Given(@"the user picks (.*) for the first date")]
        public void GivenTheUserPicksForTheFirstDate(DateTime startdate)
        {
            _context.Add("start",startdate);
        }

        [Given(@"the user picks (.*) for the second date")]
        public void GivenTheUserPicksForTheSecondDate(DateTime enddate)
        {

            _context.Add("end",enddate);
        }

        [When(@"the See All Room Types button is clicked")]
        public void WhenTheSeeAllRoomTypesButtonIsClicked()
        {
            /*var start = _context.Get<DateTime>("start");
            var end = _context.Get<DateTime>("end");*/
            var rooms =  _vm.GetAllRoomTypes();
            _context.Add("rooms", rooms);

   
            /*var service = new HotelService(_http, _client, _logger);
            var rooms = await service.GetAvailableRoomTypesAsync(start, end);
            _context.Add("rooms",rooms); */ 
          
        }

        [Then(@"the number of rooms available is (.*)")]
        public void ThenTheNumberOfRoomsAvailableIs(int available)
        {
            var rooms = _context.Get<List<RoomType>>("rooms");
            var roomCount = rooms.Count;
            roomCount.Should().Be(available);   
         
        }

    }
}
