using Microsoft.EntityFrameworkCore;
using WebApiSummeryHW.Data;
using WebApiSummeryHW.DTO;
using WebApiSummeryHW.Models;

namespace WebApiSummeryHW.Repos
{
    public class FlowersRepo : IFlowersRepo
    {
        private ApplicationDbContext _context;

        public FlowersRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<FlowerModel>> GetAllFlowersAsync()
        {
            var list = await _context.Flowers.Select(x => new FlowerModel()
            {
                Id = x.Id,
                Name = x.Name,
                Colors = x.Colors,
                Description = x.Description,
                Price = x.Price,
                Size = x.Size
            }).ToListAsync<FlowerModel>();
            return list;
        }
        public async Task<FlowerModel?> GetSingleFlower(int id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            if (flower != null)
            {

                var model = new FlowerModel()
                {
                    Colors = flower.Colors,
                    Description = flower.Description,
                    Id = flower.Id,
                    Name = flower.Name,
                    Price = flower.Price,
                    Size = flower.Size
                };
            return model;
            }
            return null;
        }
        public async Task<int> AddFlowerAsync(FlowerModel flower)
        {
            var newFlower = new Flower()
            {
                Name = flower.Name,
                Colors = flower.Colors,
                Price = flower.Price,
                Description = flower.Description,
                Size = flower.Size,
            };
            await _context.Flowers.AddAsync(newFlower);
            return newFlower.Id;
        }
        public async Task DeleteFlower(int flowerId)
        {

            var flowerForDelete = await _context.Flowers.FindAsync(flowerId);
            if (flowerForDelete != null)
            {
                _context.Flowers.Remove(flowerForDelete);
            }
            await _context.SaveChangesAsync();

        }
        public async Task<FlowerModel> UpdateFlower(FlowerModel flower)
        {
            var updatedFlower = new Flower()
            {
                Id = flower.Id,
                Colors = flower.Colors,
                Description = flower.Description,
                Name = flower.Name,
                Price = flower.Price,
                Size = flower.Size,
            };

            var flowerToUpdate = await _context.Flowers.FindAsync(updatedFlower.Id);
            if (flowerToUpdate != null)
            {
                flowerToUpdate = updatedFlower;
                await _context.SaveChangesAsync();
            }

            return flower;

        }
    }
}
