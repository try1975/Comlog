using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class NewFormTypeApi : TypedApi<NewFormTypeDto, NewFormTypeEntity, int>, INewFormTypeApi
    {
        public NewFormTypeApi(INewFormTypeQuery query) : base(query)
        {
        }
    }
}