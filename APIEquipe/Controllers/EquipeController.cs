using Mapper;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;

namespace APIEquipe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeService _equipeService;
        
        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }


        [HttpGet(Name = "GetAllEquipe")]
        [ProducesResponseType(typeof(List<object>), 200)]
        public ActionResult Index()
        {
            int pageNumber = 1;
            int pageSize = 10;
            var equipes = _equipeService.GetAll();
            var totalCount = _equipeService.GetAll().Count();
            var items = equipes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var result = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = items
            };
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var equipe = _equipeService.GetById(id);
            if (equipe == null)
            {
                return NotFound();
            }
            return Ok(equipe);
        }

        [HttpGet("Equipe/{id}/Joueur/{idJoueur}")]
        public IActionResult GetJoueurByEquipe(int id, int idJoueur)
        {
            var equipe = _equipeService.GetJoueurByEquipe(id, idJoueur);

            if (equipe == null)
            {
                return NotFound();
            }
            return Ok(equipe);
        }

        [HttpPost]
        public async Task<ActionResult<EquipeDTO.EquipeDTO>> Create([FromBody] EquipeDTO.EquipeDTO equipeDTO)
        {
            _equipeService.Create(equipeDTO);
            return CreatedAtAction(nameof(GetById), new { id = equipeDTO.Id }, equipeDTO);
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] EquipeDTO.EquipeDTO equipeDTO)
        {
            var equipeExistant = _equipeService.GetById(id);
            if (equipeExistant == null)
            {
                return NotFound();
            }
 
            if(equipeExistant.Id==id)
            _equipeService.Update(equipeDTO,id);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var equipeExistant = _equipeService.GetById(id);
            if (equipeExistant == null)
            {
                return NotFound();
            }
            _equipeService.Delete(equipeExistant);
            return NoContent();
        }
    }
}
