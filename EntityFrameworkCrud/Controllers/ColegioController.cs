using EntityFrameworkCrud.Exceptions;
using EntityFrameworkCrud.Models;
using EntityFrameworkCrud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegioController : ControllerBase
    {
        public readonly IGenericRepositoryBase<Colegio> colegioRepository;
        public ColegioController(IGenericRepositoryBase<Colegio> _colegioRepository)
        {
            colegioRepository = _colegioRepository;
        }

        public IActionResult GetAll()
        {
            var all = colegioRepository.GetAll();
            return Ok(all);
        }

        public IActionResult GetById(int idColegio)
        {
            Colegio colegio = colegioRepository.GetById(idColegio);
            return Ok(colegio);
        }

        public IActionResult Update(Colegio colegio)
        {
            Colegio result = new Colegio();
            if (colegio.Id == 0)
            {
                result = colegioRepository.Insert(colegio);
            }
            else
            {
                result = colegioRepository.Update(colegio);
            }
            return Ok(result);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                colegioRepository.Delete(id);
            }
            catch(ApiException ex)
            {
                ApiException.ThrowException(ex);
            }
            return Ok(new { deleted = true});
        }
    }
}
