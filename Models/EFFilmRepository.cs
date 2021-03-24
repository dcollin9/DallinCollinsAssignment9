using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment9.Models
{
    public class EFFilmRepository : FilmRepository
    {

        private FilmDBContext _context;

        //constructor to give the private variable a value
        public EFFilmRepository(FilmDBContext context)
        {
            _context = context;
        }

        public IQueryable<EnterMoviesModel> Filmes => _context.Filmes;
    }
}
