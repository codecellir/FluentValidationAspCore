using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRazorValidation.Models;
using System.Text.Json;

namespace MVCRazorValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IValidator<User> _validator;

        public UserController(IValidator<User> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public IActionResult CreateUser(User dto)
        {
            try
            {
                // _validator.ValidateAndThrow(dto);
                var result = _validator.Validate(dto);
                if (!result.IsValid)
                {
                    var errorGroups = result.Errors.GroupBy(x => x.PropertyName).ToList();
                    var errors = errorGroups.Select(x => new
                    {
                        ProppertyName = x.Key,
                        Errors = x.Select(c => c.ErrorMessage).ToArray()
                    });
                    return BadRequest(errors);
                }
                return Ok();
            }
            catch(ValidationException ex)
            {
                var errors = ex.Errors.GroupBy(x => x.PropertyName).ToList();
                var message = errors.Select(x => new
                {
                    PropertName = x.Key,
                    Errros = x.Select(c => c.ErrorMessage).ToArray()
                });
                return BadRequest($"validation error with message:\r\n{JsonSerializer.Serialize(message, options: new JsonSerializerOptions
                {
                    WriteIndented = true
                })}");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
