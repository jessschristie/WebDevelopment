using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysProject5.Services
{
    interface IMovieService<MovieViewModel>
    {
        void CreateData(MovieViewModel obj);
        List<MovieViewModel> GetData();
        IEnumerable<MovieViewModel> Read();
        MovieViewModel FindData(int id);
        void EditData(MovieViewModel obj);
        void DeleteData(int id);
        void DestroyData(MovieViewModel obj);
    }
}
