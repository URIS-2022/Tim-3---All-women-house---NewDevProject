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

        public ListDto? GetListById(Guid idList)
        {
            return context.List.FirstOrDefault(e => e.IdList == idList);
        }

        public void DeleteList(Guid idList)
        {
            var list = GetListById(idList);
            
            if (list != null)
            {
                context.Remove(list);
                context.SaveChanges();
            }
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
            HttpResponseMessage response = client.GetAsync(Environment.GetEnvironmentVariable("PART_OF_LAND") + "partofland/" + idLandPart).Result;
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
            HttpResponseMessage response = client.GetAsync(Environment.GetEnvironmentVariable("PART_OF_LAND") + "partofland/byLand/" + idLand).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return "";
        }

        public bool? GetStatus(Guid idLandPart)
        {
            bool? status;
            HttpResponseMessage response = client.GetAsync(Environment.GetEnvironmentVariable("LICITACION") + "licitacion/" + idLandPart).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic data = JObject.Parse(responseData);
                status = data.status;
                return status;
            }
            return null;
        }

        public ListDto? GetListByLandId(Guid idLand)
        {
            return context.List.FirstOrDefault(e => e.LabelLand == idLand);
        }
    }
}
