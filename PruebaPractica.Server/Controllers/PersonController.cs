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
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseApi<List<PersonDto>>();
            var listPerson = new List<PersonDto>();

            try
            {
                foreach (var item in await _context.Person.ToListAsync())
                {
                    listPerson.Add(new PersonDto { 
                        Id = item.Id,
                        Name = item.Name,
                        LastName = item.lastName,
                        Email = item.Email,
                        IdType = item.IdType,
                        IdentificationNumber = item.IdentificationNumber,
                        ConcatenateName = item.ConcatenateName,
                        ConcatenateID = item.ConcatenateID,
                        CreationDate = item.CreationDate
                    });
                }

                responseApi.Success = true;
                responseApi.Value = listPerson;

            }catch (Exception ex)
            {
                responseApi.Success = false;
            }

            return Ok(responseApi); 
        }

        [HttpGet]
        [Route("Buscar/{id}")]

        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseApi<PersonDto>();
            responseApi.Success = false;
            var person = new PersonDto();

            try
            {

               var dbPerson = await _context.Person.FirstOrDefaultAsync(x=> x.Id == id);
               if (dbPerson != null)
                {
                    person.Id = dbPerson.Id;
                    person.Name = dbPerson.Name;
                    person.LastName = dbPerson.lastName;
                    person.Email = dbPerson.Email;
                    person.CreationDate = dbPerson.CreationDate;
                    person.IdType = dbPerson.IdType;
                    person.IdentificationNumber = dbPerson.IdentificationNumber;
                    responseApi.Success = true;
                    responseApi.Value = person;
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

        public async Task<IActionResult> Guardar(PersonDto person)
        {
            var responseApi = new ResponseApi<int>();
            responseApi.Success = false;
            try
            {
                var dbPerson = new Person
                {
                    Name = person.Name,
                    lastName = person.LastName,
                    Email = person.Email,
                    IdType = person.IdType,
                    IdentificationNumber = person.IdentificationNumber,
                    ConcatenateName = person.concatenate(person.Name, person.LastName),
                    ConcatenateID = person.concatenate(person.IdentificationNumber, person.IdType),
                    CreationDate = person.CreationDate
                };

                _context.Person.Add(dbPerson);
                await _context.SaveChangesAsync();

                if (dbPerson.Id != 0)
                {
                    responseApi.Success = true;
                    responseApi.Value = dbPerson.Id;
                }
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Edita/{id}")]

        public async Task<IActionResult> Guardar(PersonDto person,int id)
        {
            var responseApi = new ResponseApi<int>();
            responseApi.Success = false;
            try
            {

                var dbPerson = await _context.Person.FirstOrDefaultAsync(x => x.Id == id);
                

                if (dbPerson != null)
                {
                    dbPerson.Name = person.Name;
                    dbPerson.lastName = person.LastName;
                    dbPerson.Email = person.Email;
                    dbPerson.CreationDate = person.CreationDate;
                    dbPerson.ConcatenateName = person.concatenate(person.Name, person.LastName);
                    dbPerson.ConcatenateID = person.concatenate(person.IdentificationNumber, person.IdType);
                    _context.Person.Update(dbPerson);
                    await _context.SaveChangesAsync();

                    responseApi.Success = true;
                    responseApi.Value = dbPerson.Id;
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
