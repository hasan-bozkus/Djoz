using Djoz.WebUI.Dtos.ContactDtos;

namespace Djoz.WebUI.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetListContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(int id);
        Task<UpdateContactDto> GetContactAsync(int id);
    }
}