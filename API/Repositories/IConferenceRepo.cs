using System.Collections.Generic;
using Shared.Models;

namespace API.Repositories
{
    public interface IConferenceRepo
    {
        ConferenceModel Add(ConferenceModel model);
        IEnumerable<ConferenceModel> GetAll();
        ConferenceModel GetById(int id);
    }
}