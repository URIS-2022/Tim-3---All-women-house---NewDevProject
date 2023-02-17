using Land.Models;

namespace Land.Data
{
    public interface ILandRepository
    {
        List<LandDto> GetLand();

        LandDto CreateLand(LandDto land);

        LandDto? GetLandById(Guid landId);

        void DeleteLand(Guid labelLand);

        LandDto UpdateLand(LandDto land, LandDto newLand);
    }
}
