using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Controllers
{
    [Route("api/v1/persons")]
    [ApiController]
    public class PersonsController : ControllerBase //TODO: Сделать тесты!!!
    {
        private readonly ILoggerService<PersonsController> _logger;
        private readonly IPersonService _personService;


        public PersonsController(ILoggerService<PersonsController> logger, IPersonService service)
        {
            _logger = logger;
            _personService = service;
        }

        /// <summary>
        /// Получение человека по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns>IEnumerable<Person></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult <IEnumerable<User>> > GetPersonById([FromRoute] int id, CancellationToken token)
        {
            _logger.LogTrace("GetPersonById id: {0}", id);
            IEnumerable<User> persons =  await _personService.GetPersonByIdAsync(id, token);
            return new ActionResult<IEnumerable<User>>(persons);
        }

        /// <summary>
        /// Поиск человека по имени
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="token"></param>
        /// <returns>IEnumerable<Person></returns>
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<User>>> SearchPersonByName([FromQuery] string searchTerm, CancellationToken token)
        {
            _logger.LogTrace("SearchPersonByName searchTerm: {0}", searchTerm);

            IEnumerable<User> persons = await _personService.SearchPersonByNameAsync(searchTerm, token);
            return new ActionResult<IEnumerable<User>>(persons);
        }

        /// <summary>
        /// Получение списка людей с пагинацией
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="token"></param>
        /// <returns>IEnumerable<Person></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetPersonsFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        {
            _logger.LogTrace("GetPersonsFromPagination skip: {0}, take: " + take, skip);

            IEnumerable<User> persons = await _personService.GetPersonsFromPaginationAsync(skip, take, token);
            return new ActionResult<IEnumerable<User>>(persons);  
        }

        /// <summary>
        /// Добавление новой персоны в коллекцию
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="token"></param>
        /// <returns>200-OK</returns>
        [HttpPost]     
        public async Task<ActionResult> CreatePerson([FromBody] User entity, CancellationToken token)
        {
            _logger.LogTrace("CreatePerson");

            await _personService.CreateAsync(entity, token);
            return new OkResult();
        }

        /// <summary>
        /// Обновление существующей персоны в коллекции
        /// </summary>
        /// <param name="person"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] User person, CancellationToken token)
        {
            _logger.LogTrace("CreatePerson");

            await _personService.UpdateAsync(person, token);
            return new OkResult();
        }

        /// <summary>
        /// Удаление персоны из коллекции
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletePersonById([FromRoute]int id, CancellationToken token)
        {
            _logger.LogTrace("DeletePersonById id: {0}", id);

            await _personService.DeletePersonByIdAsync(id, token);
            return new OkResult();
        }
    }
}
