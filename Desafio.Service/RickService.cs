
using Desafio.Models.Models;
using Desafio.Models.Repository;
using Desafio.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Service
{
    public class RickService
    {

        private readonly RickRepository rickRepository;
        private readonly DimensionRepository dimensionRepository;
        private readonly TravelRepository travelRepository;


        public RickService(DbContext dBContext)
        {
            rickRepository = new RickRepository(dBContext);
            dimensionRepository = new DimensionRepository(dBContext);
            travelRepository = new TravelRepository(dBContext);
        }

        public async Task<Rick> Create(String dimension)
        {

            var d = await this.CreateDimension(dimension);
            var rick = new Rick();
            rick.DimensionId = d.Id;
            rick = await rickRepository.Create(rick);
            rick.Dimension = d;

            return rick;
        }

        public async Task<Dimension> CreateDimension(String dimension)
        {

            if (String.IsNullOrEmpty(dimension) || String.IsNullOrWhiteSpace(dimension))
            {
                throw new ArgumentException("Informe o nome da dimensão", nameof(Dimension.Name));
            }
            dimension = dimension.Trim();

            var dime = await dimensionRepository.GetByName(dimension.ToUpper());

            if (dime != null)
            {
                throw new RickLocationException("Dimensão já existe");
            }


            return await dimensionRepository.Create(new Dimension() { Name = dimension.ToUpper() });
        }


        public async Task<IEnumerable<Travel>> GetRicksTravels(int rickId)
        {
            return await this.travelRepository.GetByRick(rickId);
        }

        public Task<IEnumerable<Rick>> GetAllRicks()
        {
            return this.rickRepository.GetRicks();
        }

        public async Task<Rick> GetRick(int rickId)
        {
            var rick = await rickRepository.Find(rickId);

            rick.Dimension = await dimensionRepository.Find(rick.DimensionId);

            rick.Travels = await travelRepository.GetByRick(rickId);


            return rick;
        }


    }
}
