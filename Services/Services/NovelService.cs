using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class NovelService:INovelService
    {
        private readonly IGenericRepository<Novel> _iNovelRepository;
        public NovelService(IGenericRepository<Novel> iNovelRepository)
        {
            _iNovelRepository = iNovelRepository;
        }


        public IEnumerable<Novel> GetAll()
        {
            return _iNovelRepository.GetAll();
        }

        public Novel GetById(int id)
        {
            return _iNovelRepository.GetById(id);
        }

        public void Insert(Novel novel)
        {
            _iNovelRepository.Insert(novel);
            _iNovelRepository.Save();
        }

        public void Update(Novel novel)
        {
            _iNovelRepository.Update(novel);
            _iNovelRepository.Save();
        }
        public void Delete(int id)
        {
            _iNovelRepository.Delete(id);
            _iNovelRepository.Save();
        }

        public Novel GetByIdAsNoTracking(int id)
        {

            return _iNovelRepository.GetByIdAsNoTracking(id);

        }
    }
}
