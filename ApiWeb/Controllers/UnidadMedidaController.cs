using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.DTO;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [Route("api/UnidadMedida")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IUnidadMedidaRepository _UnidadMedidaRepository;
        private readonly IMapper _Mapper;

        public UnidadMedidaController(IUnidadMedidaRepository UnidadMedidaRepository, IMapper Mapper)
        {
            _UnidadMedidaRepository = UnidadMedidaRepository;
            _Mapper = Mapper;
        }

        [HttpGet]
        public ActionResult GetUnidadMedida()
        {
            var LstUniades = _UnidadMedidaRepository.GetUnidadMedidas();
            var LstUnidadesDTO = new List<UnidadMedidaDTO>();
            foreach (var lst in LstUniades)
            {
                LstUnidadesDTO.Add(_Mapper.Map<UnidadMedidaDTO>(lst));
            }
            //return Ok(LstUnidadesDTO.Select(e => new { e.IdUnidadMedida, e.Descripcion, e.FechaModifico }).ToList()); //opcion para quitar campos no deseados al serealizar
            return Ok(LstUnidadesDTO);
        }

        [HttpGet("{IdUnidadMedida}", Name = "GetUnidadMedida")]
        public ActionResult GetUnidadMedida(string IdUnidadMedida)
        {
            var item = _UnidadMedidaRepository.GetUnidadMedida(IdUnidadMedida);
            if (item == null)
            {
                return NotFound();
            }
            var itemDTO = _Mapper.Map<UnidadMedidaDTO>(item);

            return Ok(itemDTO);
        }
        [HttpPost]
        public IActionResult CreateUnidadMedida([FromBody] UnidadMedidaDTO UnidadMedidaDTO)
        {
            if (UnidadMedidaDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_UnidadMedidaRepository.ExisteUnidadMedida(UnidadMedidaDTO.Descripcion) || _UnidadMedidaRepository.GetUnidadMedida(UnidadMedidaDTO.IdUnidadMedida) != null)
            {
                ModelState.AddModelError("", $"La unidad de medida { UnidadMedidaDTO.Descripcion }, ya existe");
                return StatusCode(404, ModelState);
            }
            var unidadMedida = _Mapper.Map<UnidadMedida>(UnidadMedidaDTO);
            string idCategoria = _UnidadMedidaRepository.CreateUnidadMedida(unidadMedida);
            if (idCategoria == "")
            {
                ModelState.AddModelError("", $"La Unidad de medida { UnidadMedidaDTO.Descripcion }, no se pudo crear.");
                return StatusCode(500, ModelState);
            }
            return Ok(idCategoria);
        }

        [HttpPatch("{IdUnidadMedida}", Name = "UpdateUnidadMedida")]
        public IActionResult UpdateUnidadMedida(string IdUnidadMedida, [FromBody] UnidadMedidaDTO UnidadMedidaDTO)
        {
            if (UnidadMedidaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var unidadMedida = _Mapper.Map<UnidadMedida>(UnidadMedidaDTO);

            var item = _UnidadMedidaRepository.UpdateUnidadMedida(unidadMedida);

            if (item == null)
            {
                ModelState.AddModelError("", $"La unidad de medida no se puede actualizar");
                return StatusCode(500, ModelState);
            }

            return Ok(item);
        }

        [HttpDelete("{IdUnidadMedida}", Name = "DeleteUnidadMedida")]
        public IActionResult DeleteUnidadMedida(string IdUnidadMedida)
        {
            if (_UnidadMedidaRepository.GetUnidadMedida(IdUnidadMedida) == null)
            {
                return NotFound();
            }

            if (!_UnidadMedidaRepository.DeleteUnidadMedida(IdUnidadMedida))
            {
                ModelState.AddModelError("", $"La categoria no se pudó eliminar");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
