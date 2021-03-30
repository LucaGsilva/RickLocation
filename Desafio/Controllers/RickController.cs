using Desafio.Dto;
using Desafio.Models.Models;
using Desafio.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RickController : ControllerBase
    {
        private readonly RickService rickService;
        public RickController(DesafioContext context)
        {
            rickService = new RickService(context);
        }


        [HttpPost]
        public async Task<ApplicationResult> Create(RickDto rickDto)
        {

            return await RickLocationUtil.CallService<Rick>("sucess",
                String.Format("Erro inesperado ao Cadastrar Rick na Dimensão {0}", rickDto.Dimension),
                async () => { return await rickService.Create(rickDto.Dimension); });

        }

        [HttpGet("{id?}")]
        public async Task<ApplicationResult> Index(int? id)
        {

            if (id != null)
            {

                return await RickLocationUtil.CallService<Rick>("sucess",
               String.Format("Erro ao obter o Rick {0} ", id),
                async () => { return await rickService.GetRick((int)id); });
            }

            return await RickLocationUtil.CallService<IEnumerable<Rick>>("sucess",
                "Erro os Listar os Ricks",
                async () => { return await rickService.GetAllRicks(); });
        }



        [HttpGet("travels/{id}")]
        public async Task<ApplicationResult> Travels(int id)
        {

            return await RickLocationUtil.CallService<IEnumerable<Travel>>("sucess",
                "Erro os Listar os Ricks",
                async () => { return await rickService.GetRicksTravels(id); });
        }
    }
}
