using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface INovelService
    {
        IEnumerable<Novel> GetAll();
        Novel GetById(int id);
        Novel GetByIdAsNoTracking(int id);
        void Insert(Novel novel);
        void Update(Novel novel);
        void Delete(int id);

    }

}
