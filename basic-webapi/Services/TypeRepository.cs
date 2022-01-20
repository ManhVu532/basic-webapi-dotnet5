using basic_webapi.Datas;
using basic_webapi.Models;
using System.Collections.Generic;
using System.Linq;

namespace basic_webapi.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MyDbContext _context;

        public TypeRepository(MyDbContext context)
        {
            _context = context;
        }

        public TypeResponse Create(TypeRequest request)
        {
            var type = new Type
            {
                Name = request.Name,
            };
            _context.Types.Add(type);
            _context.SaveChanges();

            return new TypeResponse
            {
                Id = type.Id,
                Name = type.Name,
            };
        }

        public void Delete(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.Id == id);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
        }

        public TypeResponse Get(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.Id == id);
            if(type == null)
            {
                return null;
            }
            else
            {
                return new TypeResponse
                {
                    Id = type.Id,
                    Name = type.Name,
                };
            }
        }

        public List<TypeResponse> GetAll()
        {
            var types = _context.Types.Select(t =>
                new TypeResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                }
            );
            return types.ToList();
        }

        public TypeResponse Update(TypeRequest request, int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.Id == id);
            if (type != null)
            {
                type.Name = request.Name;
                _context.SaveChanges();
                return new TypeResponse
                {
                    Id = type.Id,
                    Name = type.Name,
                };
            }
            return null;
        }
    }
}
