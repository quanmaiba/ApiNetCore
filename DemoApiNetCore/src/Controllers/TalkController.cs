using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TalkController : ControllerBase
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;

        public TalkController(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }
        //Talk
        [Route("api/Talk/GetTalk/{moniker}/{includeTalks?}")]
        [HttpGet]
        public async Task<ActionResult<TalkModels[]>> GetTalksByMonikerAsync(string moniker, bool includeTalks = false)
        {
            try
            {
                var ListCapms = await campRepository.GetTalksByMonikerAsync(moniker, includeTalks);
                TalkModels[] campModels = mapper.Map<TalkModels[]>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }

        }
        [Route("api/Talk/GetTalkById/{id}/{includeTalks?}")]
        [HttpGet]
        public async Task<ActionResult<TalkModels>> GetTalksByIdAsync(int id, bool includeTalks = false)
        {
            try
            {
                var ListCapms = await campRepository.GetTalkByIdAsync(id, includeTalks);
                TalkModels campModels = mapper.Map<TalkModels>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }

        }

        [Route("api/Talk/GetTalk/{moniker}/{id}/{includeTalks?}")]
        [HttpGet]
        public async Task<ActionResult<TalkModels>> GetTalksByMonikerAsync(string moniker, int id, bool includeTalks = false)
        {
            try
            {
                var ListCapms = await campRepository.GetTalkByMonikerAsync(moniker, id, includeTalks);
                TalkModels campModels = mapper.Map<TalkModels>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }

        }


    }
}
