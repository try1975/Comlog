using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class NewFormTypesController : TypedController<NewFormTypeDto,int>
    {
        public NewFormTypesController(INewFormTypeApi api) : base(api)
        {
        }
    }
}