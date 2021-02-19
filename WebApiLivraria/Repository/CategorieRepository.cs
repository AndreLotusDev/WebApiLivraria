using ModelsShared.Models;
using WebApiLivraria.Data;

namespace WebApiLivraria.Repository
{
    public class CategorieRepository : Repository<Categories>, ICategories
    {
        public CategorieRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
