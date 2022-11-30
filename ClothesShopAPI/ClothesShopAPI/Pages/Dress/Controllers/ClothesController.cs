using AutoMapper;
using ClothesShop.Logic;
using WebLayer = ClothesShopAPI.Pages.Dress.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BussinessLayer = ClothesShop.Logic.Interfaces.Dress.Models;
using ClothesShop.Logic.Interfaces.Dress.Services;

namespace ClothesShopAPI.Pages.Dress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothesController : ControllerBase
    {
        private readonly IDressService dressService;

        public ClothesController(IDressService dressService)
        {
            this.dressService = dressService;
        }

        [HttpPost, Route("api/dress/create")]
        public async Task<IActionResult> Create(WebLayer.CreateModel model)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<WebLayer.CreateModel, BussinessLayer.CreateModel>()
                );
            var dress = new Mapper(config).Map<WebLayer.CreateModel, BussinessLayer.CreateModel>(model);

            var result = await dressService.CreateDress(dress);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet, Route("api/dress/all")]
        public async Task<List<WebLayer.ViewModel>> All()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<BussinessLayer.Dress, WebLayer.ViewModel>()
                );
            var a = await Task.Run(() => dressService.GetAll().Result
                   .Select(x => new Mapper(config)
                   .Map<BussinessLayer.Dress, WebLayer.ViewModel>(x))
                   .ToList());

            return a;

        }
    }
}
