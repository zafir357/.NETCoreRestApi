using System;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.Xml.Linq;

namespace APIEquipe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoueurController : ControllerBase
    {
        private readonly IJoueurService _joueurService;

        public JoueurController(IJoueurService joueurService)
        {
            _joueurService = joueurService;
        }


        [HttpGet(Name = "GetAllJoueurs")]
        public ActionResult Index()
        {
            int pageNumber = 1;
            int pageSize = 10;
            var joueurs = _joueurService.GetAll();
            var totalCount = joueurs.Count();
            var items = joueurs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
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
            var joueur = _joueurService.GetById(id);
            if (joueur == null)
            {
                return NotFound();
            }
            return Ok(joueur);
        }

        [HttpPost]
        public async Task<ActionResult<EquipeDTO.JoueurDTO>> Create([FromBody] EquipeDTO.JoueurDTO joueurDTO)
        {
           _joueurService.Create(joueurDTO);
            return joueurDTO;
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EquipeDTO.JoueurDTO joueurDTO)
        {
            var joueurExistant = _joueurService.GetById(id);
            if (joueurExistant == null)
            {
                return NotFound();
            }
            _joueurService.Update(joueurDTO,id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var joueurExistant = _joueurService.GetById(id);
            if (joueurExistant == null)
            {
                return NotFound();
            }
            _joueurService.Delete(joueurExistant);
            return NoContent();
        }
    }
}

