using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEExam.Business.Dtos;
using BEExam.Business.Models;
using BEExam.Business.Servies.Abstract;
using BEExam.Core.Entities;
using BEExam.Infrastructure.Abstract;

namespace BEExam.Business.Servies
{
    public class LatestNewsServices : ILatestNewsService
    {

        private IGenericRepository<LatestNews> _latestNewsRepository { get; set; }
        private IMapper _mapper{ get; set; }

        public LatestNewsServices(IGenericRepository<LatestNews> latestNewsRepository,IMapper mapper)
        {
            _latestNewsRepository = latestNewsRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<LatestNewsVM>> GetLastNLatestNewsAsync(int n)
        {
            var entities = await _latestNewsRepository.GetAllAsync(3,false);
            var dtos = _mapper.Map<IEnumerable<LatestNewsVM>>(entities);
            return dtos;
        }

        public async Task Create(LatestNewsCreateVM model)
        {
            var entity = _mapper.Map<LatestNews>(model);
            await _latestNewsRepository.Create(entity);
            await _latestNewsRepository.SaveChangesAsync();
        }

        public async Task<LatestNewsVM> GetLatestNewsById(int id)
        {
            var entity = await _latestNewsRepository.GetById(id,false);
            return _mapper.Map<LatestNewsVM>(entity);
        }

        public async Task Update(int id, LatestNewsUpdateVM model)
        {
            var entity = await _latestNewsRepository.GetById(id, true);
            _mapper.Map(model, entity);
            await _latestNewsRepository.SaveChangesAsync();
        }
    }
}
