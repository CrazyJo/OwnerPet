using OwnerPet.Model;
using OwnerPet.Service.Interfaces;
using OwnerPet.Web.Models;

namespace OwnerPet.Web.Controllers
{
    public class UsersController : BaseController<User, UserViewModel, int>
    {
        public UsersController(IUserService userService) : base(userService)
        {
        }
    }
}
