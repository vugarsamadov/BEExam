using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEExam.Business.Dtos;
using BEExam.Business.Models;
using BEExam.Core.Entities;

namespace BEExam.Business.Profiles
{
    public class LatestNewsProfile : Profile
    {
        public LatestNewsProfile()
        {
            CreateMap<LatestNews, LatestNewsVM>();


            CreateMap<LatestNewsCreateVM, LatestNews>();

            CreateMap<LatestNewsUpdateVM, LatestNews>();


        }

    }
}
