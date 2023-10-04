using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces.Helpers
{
    public class MovieWCount
    {
        public Movie? movie {  get; set; }
        public int availableCopyCount { get; set; }
    }
}
