using Microsoft.AspNetCore.Mvc;
using PeopleRegistrationDatabaseAPI.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace PeopleRegistrationDatabaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult Query()
        {
            try
            {
                var listUser = userRepository.Listar();
                return Ok(listUser);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Query/{id}")]
        public ActionResult Query(int id)
        {
            try
            {
                var listUser = userRepository.Query(id);
                if (listUser.IdUser != 0)
                {
                    return Ok(listUser);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPost]

        public ActionResult Create(Models.UserModel user)
        {
            try
            {
                userRepository.Insert(user);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Edit(Models.UserModel user)
        {
            try
            {
                userRepository.Update(user);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                userRepository.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}