using System.Collections.Generic;
using The7_Backend.Models;

namespace The7_Backend.View_Models
{
    public class HomeVM
    {
        public Intro intro { get; set; }
        public IEnumerable<Service> service { get; set; }
        public IEnumerable<Blog> blogs { get; set; }
        public IEnumerable<Team> teams { get; set; }
    }
}
