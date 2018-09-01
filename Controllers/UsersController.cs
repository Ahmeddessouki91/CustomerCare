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
        public async Task<QueryResult<UserUpdateResouce>> GetUsers(UserQueryResource filterResource)
        {
            var filter = mapper.Map<UserQueryResource, UserQuery>(filterResource);

            var queryResult = await userRepo.GetUsers(filter);

            return mapper.Map<QueryResult<User>, QueryResult<UserUpdateResouce>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var vehicle = await userRepo.GetUser(id, true);
            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<User, UserUpdateResouce>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateResouce userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userRepo.GetUser(id, false);

            if (user == null)
                return NotFound();


            mapper.Map<UserUpdateResouce, User>(userResource, user);

            await uow.CompleteAsyn();

            user = await userRepo.GetUser(user.Id);
            var result = mapper.Map<User, UserUpdateResouce>(user);
            return Ok(result);
        }

    }
}