using AutoMapper;
using BEExam.Business.Models;
using BEExam.Business.Servies.Abstract;
using BEExam.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BEExam.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LatestNewsController : Controller
    {
        public IMapper Mapper { get; }
        public ILatestNewsService LatestNewsService { get; }

        public LatestNewsController(IMapper mapper,ILatestNewsService latestNewsService)
        {
            Mapper = mapper;
            LatestNewsService = latestNewsService;
        }


        public IActionResult Index()
        {
            var model = new LatestNewsIndexVM();

            model.LatestNews = new List<LatestNewsVM>()
            { 
                new LatestNewsVM()
                { 
                    AuthorName ="Vugar",
                    Title = "Salam123",
                    Id = 1,
                    Description = "asdfsadfsadfsadf",
                    ImageUrl = "asfasdfasdf",
                    IsDeleted = true
                },
                new LatestNewsVM()
                {
                    AuthorName ="Vugar",
                    Id = 2,
                    Title = "Salam123",
                    Description = "asdfsadfsadfsadf",
                    ImageUrl = "asfasdfasdf",
                    IsDeleted = false
                }
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new LatestNewsCreateVM();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LatestNewsCreateVM model)
        {
            if(!ModelState.IsValid) return View(model);
            
            await LatestNewsService.Create(model);

            return View(model);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Update(int id)
        {
            var model = await LatestNewsService.GetLatestNewsById(id);
            return View(model);
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Update(int id,LatestNewsUpdateVM model)
        {
            if (!ModelState.IsValid) return View(model);
            await LatestNewsService.Update(id, model);

            return View(model);
        }


    }
}
