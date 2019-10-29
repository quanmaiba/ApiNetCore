using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        private readonly CampContext campContext;

        public CampsController(ICampRepository campRepository, IMapper mapper, CampContext campContext)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
            this.campContext = campContext;
        }

        [Route("api/Camps/GetCampsAll/{includeTalks?}")]
        [HttpGet]

        public async Task<ActionResult<CampModels[]>> GetCamp(bool includeTalks = false)
        {
            try
            {
                var ListCapms = await campRepository.GetAllCampsAsync(includeTalks);
                CampModels[] campModels = mapper.Map<CampModels[]>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }


        [Route("api/Camps/Create")]
        [HttpPost]
        public async Task<ActionResult<Camp>> CreateCamp(Camp model)
        {
            if (ModelState.IsValid)
            {
                campRepository.Add(model);
                if (await campRepository.SaveChangesAsync())
                {
                    return CreatedAtAction(nameof(GetCamp), false);
                }

                //campContext.Add(model);
                //await campContext.SaveChangesAsync();

            }

            //return CreatedAtAction("GetStudent", new { id = model.CampId }, model);
            return BadRequest("yOOU BAD");

        }

        [Route("api/Camps/GetCamp/{moniker}")]
        [HttpGet]
        public async Task<ActionResult<CampModels>> GetByMoniker(string moniker)
        {
            try
            {
                var result = await campRepository.GetCampAsync(moniker);
                CampModels campModels = mapper.Map<CampModels>(result);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }
        }

        [Route("api/Camps/GetCampById/{id}/{includeTalks?}")]
        [HttpGet]
        public async Task<ActionResult<CampModels>> GetById(int id, bool includeTalks = false)
        {
            try
            {
                var result = await campRepository.GetCampById(id, includeTalks);

                CampModels campModels = mapper.Map<CampModels>(result);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }
        }

        [Route("api/Camps/SearchByDate/{theDate}")]
        [HttpGet]
        public async Task<ActionResult<CampModels>> SearchByDate(DateTime theDate)
        {
            try
            {
                var result = await campRepository.GetAllCampsByEventDate(theDate);
                if (!result.Any())
                {
                    return NotFound();
                }
                CampModels campModels = mapper.Map<CampModels>(result);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }
        }


        //[Route("api/Camps/Create")]
        //[HttpPost]
        //public async Task<ActionResult<Camp>> Post(Camp model)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
