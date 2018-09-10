using System.Threading.Tasks;
using AutoMapper;
using CustomerCare.Controllers.Resources;
using CustomerCare.Controllers.Resources.UserResouce;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCare.Controllers
{
    [Route("/api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        public UsersController(IUserRepository userRepo, IMapper mapper, IUnitOfWork uow)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<QueryResult<UserResource>> GetUsers(UserQueryResource filterResource)
        {
            var filter = mapper.Map<UserQueryResource, UserQuery>(filterResource);

            var queryResult = await userRepo.GetUsers(filter);

            return mapper.Map<QueryResult<User>, QueryResult<UserResource>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await userRepo.GetUser(id);
            if (user == null)
                return NotFound();

            var userResource = mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserSaveResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userRepo.GetUser(id, false);

            if (user == null)
                return NotFound();


            mapper.Map<UserSaveResource, User>(userResource, user);

            await uow.CompleteAsyn();

            user = await userRepo.GetUser(user.Id);
            var result = mapper.Map<User, UserSaveResource>(user);
            return Ok(result);
        }

    }
}