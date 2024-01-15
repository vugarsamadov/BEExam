using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using BEExam.Business.Dtos;
using BEExam.Business.Models;

namespace BEExam.Business.Servies.Abstract
{
    public interface ILatestNewsService
    {

        public Task<IEnumerable<LatestNewsVM>> GetLastNLatestNewsAsync(int n);

        public Task Create(LatestNewsCreateVM model);

        public Task<LatestNewsVM> GetLatestNewsById(int id);

        public Task Update(int id, LatestNewsUpdateVM model);

    }
}
