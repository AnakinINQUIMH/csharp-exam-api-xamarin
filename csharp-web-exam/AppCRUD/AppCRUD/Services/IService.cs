
using AppCRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCRUD.Services
{
    public interface IService
    {
       // Task<GeneralResponseModel> CreateBirdAsync(string nameBird, string feeding, int type);

        Task<GeneralResponseModel> DeleteBirdAsync(int Id);

        Task<IEnumerable<ListBirdsModel>> GetListBirdAsync();

        //Task<GeneralResponseModel> UpdateBirdAsync(int id, string nameBird, string feeding, int type);
        Task<GeneralResponseModel> CreateOrUpdateBirdAsync(byte typeQuery,BirdsModel birds);
    }
}
