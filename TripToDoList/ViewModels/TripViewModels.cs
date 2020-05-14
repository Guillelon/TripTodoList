using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripToDoList.ViewModels
{
    public class TripViewModels
    {
        public IList<Trip> Trips { get; set; }
        public Trip NewTrip { get; set; }
    }
}