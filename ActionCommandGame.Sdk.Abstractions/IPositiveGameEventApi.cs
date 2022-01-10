using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Sdk.Abstractions
{
    public interface IPositiveGameEventApi
    {
        Task<ServiceResult<PositiveGameEventResult>> GetAsync(int id);
        Task<ServiceResult<IList<PositiveGameEventResult>>> Find();
        Task<ServiceResult<PositiveGameEventResult>> Create(PositiveGameEventResult playerResult);
        Task<ServiceResult<PositiveGameEventResult>> Update(int id, PositiveGameEventResult playerResult);
        Task<ServiceResult<PositiveGameEventResult>> DeleteAsync(int id);
    }
}
