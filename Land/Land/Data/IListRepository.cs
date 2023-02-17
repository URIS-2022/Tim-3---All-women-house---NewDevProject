using Land.Models;

namespace Land.Data
{
    public interface IListRepository
    {
        List<ListDto> GetList();

        ListDto CreateList(ListDto list);

        ListDto? GetListById(Guid idList);

        void DeleteList(Guid idList);

        ListDto UpdateList(ListDto list, ListDto newList);

        Guid? GetLandId(Guid idLandPart);

        string GetLandParts(Guid idLand);

        bool? GetStatus(Guid idLandPart);

        ListDto? GetListByLandId(Guid idLand);
    }
}
