using basic_webapi.Models;
using System.Collections.Generic;

namespace basic_webapi.Services
{
    public interface ITypeRepository
    {
        List<TypeResponse> GetAll();
        TypeResponse Get(int id);
        TypeResponse Update(TypeRequest request, int id);
        TypeResponse Create(TypeRequest request);
        void Delete(int id);
    }
}
