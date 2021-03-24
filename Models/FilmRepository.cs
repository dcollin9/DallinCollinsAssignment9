using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment9.Models
{
    public interface FilmRepository
    {
        //creates an iqueryable of type Project, which is what tells it the format of the model

        IQueryable<EnterMoviesModel> Filmes { get; }

    }
}
