using basic_webapi.Models;
using System.Collections.Generic;
using System.Linq;

namespace basic_webapi.Services
{
    public class InMemTypeRepository : ITypeRepository
    {
        static List<TypeResponse> types = new List<TypeResponse>
        {
            new TypeResponse{Id = 1, Name = "Tivi"},
            new TypeResponse{Id = 2, Name = "Laptop"},
            new TypeResponse{Id = 3, Name = "Pc"},
            new TypeResponse{Id = 4, Name = "Light"},
            new TypeResponse{Id = 5, Name = "Mobile"},
        };

        public TypeResponse Create(TypeRequest request)
        {
            var type = new TypeResponse
            {
                Id = types.Max(t => t.Id) + 1,
                Name = request.Name,
            };
            types.Add(type);
            return type;
        }

        public void Delete(int id)
        {
            var type = types.SingleOrDefault(t => t.Id == id);
            types.Remove(type);
        }

        public TypeResponse Get(int id)
        {
            return types.SingleOrDefault(t => t.Id == id);
        }

        public List<TypeResponse> GetAll()
        {
            return types;
        }

        public TypeResponse Update(TypeRequest request, int id)
        {
            var type = types.SingleOrDefault(t => t.Id == id);
            if(type == null) return null;
            type.Name = request.Name;
            return type;
        }
    }
}
