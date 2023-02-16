using Land.Models;
using Land.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Land.Data
{
    public class ListRepository : IListRepository
    {
        private readonly ListContext context;
        static HttpClient client = new HttpClient();

        public ListRepository(ListContext context)
        {
            this.context = context;
        }

        public List<ListDto> GetList()
        {
            Console.WriteLine(context.List.ToList());
            return context.List.ToList();
        }

        public ListDto CreateList(ListDto list)
        {
            var createdEntity = context.Add(list);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ListDto GetListById(Guid idList)
        {
            return context.List.FirstOrDefault(e => e.IdList == idList);
        }

        public void DeleteList(Guid idList)
        {
            var list = GetListById(idList);
            context.Remove(list);
            context.SaveChanges();
        }

        public ListDto UpdateList(ListDto list, ListDto newList)
        {
            list.SumSurface = newList.SumSurface;
            list.LabelLand = newList.LabelLand;
            context.SaveChanges();
            return list;
        }

        public Guid? GetLandId(Guid idLandPart)
        {
            Guid landId;
            HttpResponseMessage response = client.GetAsync("https://0277b28e-2929-41ab-8c2e-b6fcfe4d51e9.mock.pstmn.io/partofland/" + idLandPart).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic data = JObject.Parse(responseData);
                landId = data.landId;
                return landId;
            }
            return null;
        }

        public string GetLandParts(Guid idLand)
        {
            HttpResponseMessage response = client.GetAsync("https://0277b28e-2929-41ab-8c2e-b6fcfe4d51e9.mock.pstmn.io/partofland/byLand/" + idLand).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return "";
        }

        public bool? GetStatus(Guid idLandPart)
        {
            bool? status;
            HttpResponseMessage response = client.GetAsync("https://bd5d0877-868a-48de-89e0-0eb7c3b5cd47.mock.pstmn.io/licitacion/" + idLandPart).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic data = JObject.Parse(responseData);
                status = data.status;
                return status;
            }
            return null;
        }

        public ListDto GetListByLandId(Guid idLand)
        {
            return context.List.FirstOrDefault(e => e.LabelLand == idLand);
        }
    }
}
