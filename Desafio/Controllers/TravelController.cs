using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Dto;
using Desafio.Models.Models;
using Desafio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly TravelService travelService;

        public TravelController(DesafioContext context)
        {
            travelService = new TravelService(context);
        }

        [HttpPost]
        public async Task<ApplicationResult> Create(TravelDto travelDto)
        {
       
            return await RickLocationUtil.CallService<Travel>("sucess",
                String.Format("Erro inesperado ao Realizar viagem para o rick {0}", travelDto.RickId),
                async () => { return await travelService.Create(travelDto.RickId, travelDto.DimensionId); });
            


        }
    }
}
