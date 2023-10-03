using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace csharp_web_exam_api.Controllers
{
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string _insternalserverError, _statusOk;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
            _insternalserverError = HttpStatusCode.InternalServerError.ToString();
            _statusOk = HttpStatusCode.OK.ToString();
        }
        #region GET
        // GET api/values
        [HttpGet]
        public ActionResult<GetBirdTypeResponseModel> Get()
        {
            List<BirdsAndTypeModel> birds = null;
            GetBirdTypeResponseModel response = null;
            try
            {
                birds = _context.Birds
                .Include(b => b.TypeBirds)
                .Select(b => new BirdsAndTypeModel
                 {
                  Id = b.Id,
                  Name = b.Name,
                  Feeding = b.Feeding,
                  TypeId = b.TypeBirds.TypeId,
                  TypeName = b.TypeBirds.TypeName
                 })
                  .ToList();
                response = new GetBirdTypeResponseModel
                {
                    ListBirds = birds,
                    GeneralResponseModel = new GeneralResponseModel { status = HttpStatusCode.OK.ToString(), message = "Ok" }
                };

            }
            catch (Exception e)
            {
                response = new GetBirdTypeResponseModel
                {
                    ListBirds = birds,
                    GeneralResponseModel = new GeneralResponseModel { status = _insternalserverError, message = "Ok" }
                };

            }
            return response;
        }

        [HttpGet]
        [Route("get-listTypeBird")]
        public ActionResult<IEnumerable<TypeBirdModel>> ListTypeBird()
        {
            List<TypeBirdModel> types = _context.TypeBirds.ToList();
            return types;
        }

        // GET api/values/5

        [HttpGet("{id}")]
        public ActionResult<BirdsAndTypeModel> Get(int id)
        {
            BirdsAndTypeModel bird = _context.Birds
             .Include(b => b.TypeBirds)
             .Where(b => b.Id == id)
             .Select(b => new BirdsAndTypeModel
             {
                 Id = b.Id,
                 Name = b.Name,
                 Feeding = b.Feeding,
                 TypeId = b.TypeBirds.TypeId,
                 TypeName = b.TypeBirds.TypeName
             }).FirstOrDefault();
            return bird;
        }
        #endregion

        #region Post
        // POST api/values
        [HttpPost]
        public GeneralResponseModel Post([FromBody] BirdsModel bird)
        {
            GeneralResponseModel response= null;
            BirdsModel newBird = new BirdsModel
            {
                Name = bird.Name,
                Feeding = bird.Feeding,
                TypeId = bird.TypeId
            };

            _context.Birds.Add(newBird);
            try
            {
                int inserts = _context.SaveChanges();
                if (inserts > 0)
                {
                    response = new GeneralResponseModel { status = _statusOk, message = "Se inserto correctamente" };
                }
                else
                {
                    response = new GeneralResponseModel { status = _insternalserverError, message = "Error al insertar" };
                }                

            }
            catch (Exception e)
            {

                response = new GeneralResponseModel { status = _insternalserverError, message = e.InnerException.Message };
            }

            return response;
        }
        #endregion

        #region Put
        // PUT api/values/5
        [HttpPut()]
        public GeneralResponseModel Put( [FromBody] BirdsModel birdUpdate)
        {
            BirdsModel bird = _context.Birds.Find(birdUpdate.Id);
            GeneralResponseModel response = null;
           
            try
            {
                if (bird != null)
                {
                    bird.Name = birdUpdate.Name;
                    bird.Feeding = birdUpdate.Feeding;
                    bird.TypeId = birdUpdate.TypeId;
                    int inserts = _context.SaveChanges();
                    if (inserts > 0)
                    {
                        response = new GeneralResponseModel { status = _statusOk, message = "Se actualizo correctamente" };
                    }
                    else
                    {
                        response = new GeneralResponseModel { status = _insternalserverError, message = "Error al actualizar" };
                    }
                }
            }
            catch (Exception e)
            {

                response = new GeneralResponseModel { status = _insternalserverError, message = e.InnerException.Message };
            }
            return response;
        }
        #endregion

        #region Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BirdsModel bird = _context.Birds.Find(id);
            GeneralResponseModel response = null;
            try
            {
                if (bird != null)
                {
                    _context.Birds.Remove(bird);

                    int deletes = _context.SaveChanges();
                    if (deletes > 0)
                    {
                        response = new GeneralResponseModel { status = _statusOk, message = "Se elimino correctamente" };
                    }
                    else
                    {
                        response = new GeneralResponseModel { status = _insternalserverError, message = "Error al eliminar" };
                    }
                }
            }
            catch (Exception e)
            {
                response = new GeneralResponseModel { status = _insternalserverError, message = e.InnerException.Message };
            }

        }
        #endregion
    }
}
