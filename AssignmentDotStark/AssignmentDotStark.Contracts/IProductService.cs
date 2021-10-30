using AssignmentDotStark.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentDotStark.Contracts
{
    public interface IProductService
    {
        List<ProductResultModel> GetAll();
        ProductResultModel GetById(string productId);
        Task<string> Save(ProductAddDataModel model);
        Task<string> Update(ProductUpdateDataModel model);
    }
}
