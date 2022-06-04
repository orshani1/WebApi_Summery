using WebApiSummeryHW.DTO;

namespace WebApiSummeryHW.Repos
{
    public interface IFlowersRepo
    {
        Task<List<FlowerModel>> GetAllFlowersAsync();
        Task<int> AddFlowerAsync(FlowerModel flower);
        Task DeleteFlower(int flowerId);
        Task<FlowerModel> UpdateFlower(FlowerModel flower);
        Task<FlowerModel?> GetSingleFlower(int id);
    }
}