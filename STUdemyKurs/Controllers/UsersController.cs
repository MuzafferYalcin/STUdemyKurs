using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STUdemyKurs.Data;
using STUdemyKurs.DTOs;

namespace STUdemyKurs.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IGenericRepository _repository;
        readonly IMapper _mapper;

        public UsersController(IGenericRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repository.GetUsers();

            var result = _mapper.Map<List<UserForListDto>>(users);
            
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);

            var result = _mapper.Map<UserForDetailsDto>(user);
            
            return Ok(result);
        }
    }
}

