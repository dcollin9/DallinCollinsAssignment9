using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment9.Models.ViewModels.FilmListViewModel
{
    public class FilmListViewModel
    {

        //makes it so the program can enumerate through all of the EnterMoviesModel objects
        public IEnumerable<EnterMoviesModel> Filmes { get; set; }
    }
}
