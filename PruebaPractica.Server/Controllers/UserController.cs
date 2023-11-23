using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaPractica.Server.Data;
using PruebaPractica.Server.Models;
using PruebaPractica.Shared;

namespace PruebaPractica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseApi<List<UserDto>>();
            var listPerson = new List<UserDto>();

            try
            {
                foreach (var item in await _context.Users.ToListAsync())
                {
                    listPerson.Add(new UserDto
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Pass = item.Pass,
                        CreationDate = item.CreationDate
                    });
                }

                responseApi.Success = true;
                responseApi.Value = listPerson;

            }
            catch (Exception ex)
            {
                responseApi.Success = false;
            }

            return Ok(responseApi);
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDto user)
        {
            var responseApi = new ResponseApi<int>();
            responseApi.Success = false;
            try
            {
                
                var dbUsers = await _context.Users.Where(x => x.UserName == user.UserName && x.Pass == user.Pass).FirstOrDefaultAsync();

                if (dbUsers != null)
                {
                    responseApi.Success = true;
                    responseApi.Value = dbUsers.Id;
                }
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
        
        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar(UserDto user)
        {
            var responseApi = new ResponseApi<int>();
            responseApi.Success = false;
            try
            {
                var dbUser = new User
                {
                    UserName = user.UserName,
                    Pass = user.Pass,
                    CreationDate = user.CreationDate
                };

                _context.Users.Add(dbUser);
                await _context.SaveChangesAsync();

                if (dbUser.Id != 0)
                {
                    responseApi.Success = true;
                    responseApi.Value = dbUser.Id;
                }
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
