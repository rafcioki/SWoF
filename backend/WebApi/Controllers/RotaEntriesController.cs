using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RotaEntriesController : Controller
    {
        private readonly IRotaBuilder _rotaBuilder;
        private readonly IRotaEntriesRepository _rotaEntriesRepository;
        private readonly IMapper _mapper;

        public RotaEntriesController(IRotaBuilder rotaBuilder,
            IRotaEntriesRepository rotaEntriesRepository,
            IMapper mapper)
        {
            _rotaBuilder = rotaBuilder;
            _rotaEntriesRepository = rotaEntriesRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns curent rota.
        /// Status codes:
        /// 200 - OK
        /// 404 - no rota entries
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rota = await _rotaEntriesRepository.GetRotaEntries(DateTime.Now);

            if (rota == null || rota.Count == 0)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<RotaEntryViewModel>>(rota));
        }

        /// <summary>
        /// Triggers creating a new rota.
        /// </summary>
        /// <param name="to">Date up to which rota will be generated.</param>
        [HttpPost]
        public async Task<IActionResult> Post(DateTime to)
        {
            if (to <= DateTime.Now)
            {
                return BadRequest();
            }

            var newRota = await _rotaBuilder.BuildRota(to);
            await _rotaEntriesRepository.SaveRota(newRota);

            return new StatusCodeResult((int)HttpStatusCode.Created);
        }

        /// <summary>
        /// Triggers deleting all rota entries.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _rotaEntriesRepository.DeleteRota();

            return new StatusCodeResult((int) HttpStatusCode.Accepted);
        }
    }
}
