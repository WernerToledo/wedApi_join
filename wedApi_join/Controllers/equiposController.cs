using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wedApi_join.Model;

namespace wedApi_join.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equipoContext;
        public equiposController(equiposContext equiposContext)
        {
            _equipoContext  = equiposContext;
        }

        [HttpGet]
        [Route("GetAll1")]
        public IActionResult Get()
        {
            /*Con where clause*/
            /*
                         var equipos = (from e in _equipoContext.equipos 
                           join t in _equipoContext.tipo_equipo
                           on e.tipo_equipo_id equals t.id_tipo_equipo
                           where e.id_equipos == 1
                           select new
                           {
                               e.id_equipos
                           }). ToList();
             */
            var equipos = (from e in _equipoContext.equipos 
                           join t in _equipoContext.tipo_equipo
                           on e.tipo_equipo_id equals t.id_tipo_equipo
                           join m in _equipoContext.marcas
                           on e.marca_id  equals m.id_marca
                           join es in _equipoContext.estados_equipo
                           on e.estado_equipo_id equals es.id_estados_equipo

                           select new
                           {
                               e.id_equipos,
                               e.nombre,
                               e.descripcion,
                               e.tipo_equipo_id,
                               descripcin =t.descripcion,
                               e.marca_id,
                               marca = m.nombre_marca,
                               e.estado_equipo_id,
                               estado_descrip = es.descripcion,
                               /*Se puede crear un campo en base a los datos que se tiene*/
                               /*nombre del campo = valor del campo*/
                               detalle = $"Tipo = {t.descripcion}, Marca = {m.nombre_marca}, estado Equipo = {es.descripcion}",
                               e.estado
                           }).Take(1).ToList();
                            /*Para solo tomar una cantidad especica se usa el metodo TAKE(numero de los que se tomaran)*/
            if (equipos.Any())
            {
                return Ok(equipos);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllskip")]
        public IActionResult GetSkip()
        {
            var equipos = (from e in _equipoContext.equipos
                           join t in _equipoContext.tipo_equipo
                           on e.tipo_equipo_id equals t.id_tipo_equipo
                           join m in _equipoContext.marcas
                           on e.marca_id equals m.id_marca
                           join es in _equipoContext.estados_equipo
                           on e.estado_equipo_id equals es.id_estados_equipo

                           select new
                           {
                               e.id_equipos,
                               e.nombre,
                               e.descripcion,
                               e.tipo_equipo_id,
                               descripcin = t.descripcion,
                               e.marca_id,
                               marca = m.nombre_marca,
                               e.estado_equipo_id,
                               estado_descrip = es.descripcion,
                               /*Se puede crear un campo en base a los datos que se tiene*/
                               /*nombre del campo = valor del campo*/
                               detalle = $"Tipo = {t.descripcion}, Marca = {m.nombre_marca}, estado Equipo = {es.descripcion}",
                               e.estado
                           }).Skip(1).ToList();
                            /*Para saltar registros se usa el metodo SKIP()*/
            if (equipos.Any())
            {
                return Ok(equipos);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Getid/{id}")]
        public IActionResult Getbyid(int id)
        {
            var equipos = (from e in _equipoContext.equipos
                           join t in _equipoContext.tipo_equipo
                           on e.tipo_equipo_id equals t.id_tipo_equipo
                           join m in _equipoContext.marcas
                           on e.marca_id equals m.id_marca
                           join es in _equipoContext.estados_equipo
                           on e.estado_equipo_id equals es.id_estados_equipo
                           where e.id_equipos == id
                           select new
                           {
                               e.id_equipos,
                               e.nombre,
                               e.descripcion,
                               e.tipo_equipo_id,
                               descripcin = t.descripcion,
                               e.marca_id,
                               marca = m.nombre_marca,
                               e.estado_equipo_id,
                               estado_descrip = es.descripcion,
                               /*Se puede crear un campo en base a los datos que se tiene*/
                               /*nombre del campo = valor del campo*/
                               detalle = $"Tipo = {t.descripcion}, Marca = {m.nombre_marca}, estado Equipo = {es.descripcion}",
                               e.estado
                           }).ToList();
            /*Para saltar registros se usa el metodo SKIP()*/
            if (equipos.Any())
            {
                return Ok(equipos);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Getorder")]
        public IActionResult Getorder()
        {
            var equipos = (from e in _equipoContext.equipos
                           join t in _equipoContext.tipo_equipo
                           on e.tipo_equipo_id equals t.id_tipo_equipo
                           join m in _equipoContext.marcas
                           on e.marca_id equals m.id_marca
                           join es in _equipoContext.estados_equipo
                           on e.estado_equipo_id equals es.id_estados_equipo
                           select new
                           {
                               e.id_equipos,
                               e.nombre,
                               e.descripcion,
                               e.tipo_equipo_id,
                               descripcin = t.descripcion,
                               e.marca_id,
                               marca = m.nombre_marca,
                               e.estado_equipo_id,
                               estado_descrip = es.descripcion,
                               /*Se puede crear un campo en base a los datos que se tiene*/
                               /*nombre del campo = valor del campo*/
                               detalle = $"Tipo = {t.descripcion}, Marca = {m.nombre_marca}, estado Equipo = {es.descripcion}",
                               e.estado
                           }).OrderBy(resultado => resultado.estado_equipo_id)
                             .ThenBy(resultado => resultado.marca_id)
                             .ThenByDescending(resultado => resultado.tipo_equipo_id)
                             .ToList();
            /*Para saltar registros se usa el metodo SKIP()*/
            if (equipos.Any())
            {
                return Ok(equipos);
            }
            return BadRequest();
        }

    }
}
