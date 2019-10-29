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
    public class SpeakerController : ControllerBase
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;

        public SpeakerController(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }
        //Talk
        [Route("api/Speaker/GetSpeakerByMoniker/{moniker}")]
        [HttpGet]
        public async Task<ActionResult<SpeakerModel[]>> GetSpeakerByMonikerAsync(string moniker)
        {
            try
            {
                var ListCapms = await campRepository.GetSpeakersByMonikerAsync(moniker);
                SpeakerModel[] campModels = mapper.Map<SpeakerModel[]>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }

        }


        [Route("api/Speaker/GetSpeaker/{id}")]
        [HttpGet]
        public async Task<ActionResult<SpeakerModel>> GetTalksByMonikerAsync(int id)
        {
            try
            {
                var ListCapms = await campRepository.GetSpeakerAsync(id);
                SpeakerModel campModels = mapper.Map<SpeakerModel>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }

        }

        [Route("api/Speaker/GetSpeaker")]
        [HttpGet]
        public async Task<ActionResult<SpeakerModel[]>> GetAllSpeakersAsync()
        {
            try
            {
                var ListCapms = await campRepository.GetAllSpeakersAsync();
                SpeakerModel[] campModels = mapper.Map<SpeakerModel[]>(ListCapms);
                return campModels;
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }

        }
    }
}
