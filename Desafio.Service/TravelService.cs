using Desafio.Models.Models;
using Desafio.Models.Repository;
using Desafio.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Desafio.Service
{
    public class TravelService
    {
        private readonly RickRepository rickRepository;
        private readonly DimensionRepository dimensionRepository;
        private readonly TravelRepository travelRepository;

        public TravelService(DbContext dBContext)
        {
            rickRepository = new RickRepository(dBContext);
            dimensionRepository = new DimensionRepository(dBContext);
            travelRepository = new TravelRepository(dBContext);

        }
        public async Task<Travel> Create(int rickId, int dimensionId) {

            var rick = await rickRepository.Find(rickId);
            var dimension = await dimensionRepository.Find(dimensionId);


            if (rick == null) throw new ArgumentException("Rick não cadastrado");
            if (dimension == null) throw new ArgumentException("Dimensão não encontrada");

           var travel = await travelRepository.Create(new Travel() { RickId = rickId, DimensionId = dimensionId, DateTravel = DateTime.Now });

            travel.Rick = rick;
            travel.Dimension = dimension;

            return travel;
        }

    }
}
