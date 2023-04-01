using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wedApi_join.Model;

namespace wedApi_join.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //rama secundaria
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equipoContext;
        public equiposController(equiposContext equiposContext)
        {
            _equipoContext  = equiposContext;
        }

        [HttpGet]
        [Route("GetAllFills")]
        public IActionResult Get()
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
                               m.nombre_marca,
                               t.id_tipo_equipo,

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
        [Route("GetAllOnly1")]
        public IActionResult Getone()
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


        //equipos

        //insert
        [HttpPost]
        [Route("AddEquipos")]
        public IActionResult AddEquipos([FromBody] equipos equipo)
        {
            try
            {
                _equipoContext.equipos.Add(equipo);
                _equipoContext.SaveChanges();
                return Ok(equipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //update equipos
        [HttpPut]
        [Route("UpdateEquipo/{id}")]

        public IActionResult update(int id, [FromBody] equipos equipo)
        {
            equipos? equipoActual = (from e in _equipoContext.equipos
                                       where e.id_equipos == id
                                       select e).FirstOrDefault();

            if (equipoActual == null)
            {
                return BadRequest();
            }

            equipoActual.nombre = equipo.nombre;
            equipoActual.descripcion = equipo.descripcion;
            equipoActual.modelo = equipo.modelo;
            equipoActual.anio_compra = equipo.anio_compra;
            equipoActual.costo= equipo.costo;
            equipoActual.vida_util = equipo.vida_util; 
            equipoActual.estado = equipo.estado;

            _equipoContext.Entry(equipoActual).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(equipoActual);
        }

        //delete
        [HttpDelete]
        [Route("DeleteEquipo/{id}")]
        public IActionResult deleteEqui(int id)
        {
            //? para decirle que puede ser nulleable
            equipos? equipos = (from e in _equipoContext.equipos
                                  where e.id_equipos == id
                                  select e).FirstOrDefault();

            if (equipos == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.equipos.Attach(equipos);
            _equipoContext.equipos.Remove(equipos);
            _equipoContext.SaveChanges();
            return Ok(equipos);
        }
        //equipos

        //estado equipos

        //insert
        [HttpPost]
        [Route("AddEstado")]
        public IActionResult AddEstado([FromBody] estados_equipo estado_Equipo)
        {
            try
            {
                _equipoContext.estados_equipo.Add(estado_Equipo);
                _equipoContext.SaveChanges();
                return Ok(estado_Equipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateEstado/{id}")]

        public IActionResult updateEst(int id, [FromBody] estados_equipo estados_Equipo)
        {
            estados_equipo? estados_equipoAct = (from e in _equipoContext.estados_equipo
                                     where e.id_estados_equipo == id
                                     select e).FirstOrDefault();

            if (estados_equipoAct == null)
            {
                return BadRequest();
            }
            estados_equipoAct.descripcion = estados_Equipo.descripcion;
            estados_equipoAct.estado = estados_Equipo.estado;

            _equipoContext.Entry(estados_equipoAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(estados_equipoAct);
        }
        //delete
        [HttpDelete]
        [Route("DeleteEstado/{id}")]
        public IActionResult deleteEst(int id)
        {
            //? para decirle que puede ser nulleable
            estados_equipo? estado_equipo = (from e in _equipoContext.estados_equipo
                                where e.id_estados_equipo == id
                                select e).FirstOrDefault();

            if (estado_equipo == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.estados_equipo.Attach(estado_equipo);
            _equipoContext.estados_equipo.Remove(estado_equipo);
            _equipoContext.SaveChanges();
            return Ok(estado_equipo);
        }
        //estado equipos

        //Marcas

        //insert
        [HttpPost]
        [Route("AddMarcas")]
        public IActionResult Addmarcas([FromBody] marcas marca)
        {
            try
            {
                _equipoContext.marcas.Add(marca);
                _equipoContext.SaveChanges();
                return Ok(marca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateMarca/{id}")]

        public IActionResult updateMarca(int id, [FromBody] marcas marcas)
        {
            marcas? marcasAct = (from e in _equipoContext.marcas
                                                 where e.id_marca == id
                                                 select e).FirstOrDefault();

            if (marcasAct == null)
            {
                return BadRequest();
            }
            marcasAct.nombre_marca = marcas.nombre_marca;
            marcasAct.estados = marcas.estados;

            _equipoContext.Entry(marcasAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(marcasAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteMarca/{id}")]
        public IActionResult deleteMarca(int id)
        {
            //? para decirle que puede ser nulleable
            marcas? marca = (from e in _equipoContext.marcas
                                             where e.id_marca == id
                                             select e).FirstOrDefault();

            if (marca == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.marcas.Attach(marca);
            _equipoContext.marcas.Remove(marca);
            _equipoContext.SaveChanges();
            return Ok(marca);
        }
        //marcas



        //tipo equipo

        //insert
        [HttpPost]
        [Route("AddTequipo")]
        public IActionResult AddTequipo([FromBody] tipo_equipo tipo_Equipo)
        {
            try
            {
                _equipoContext.tipo_equipo.Add(tipo_Equipo);
                _equipoContext.SaveChanges();
                return Ok(tipo_Equipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateTequipo/{id}")]

        public IActionResult updateTe(int id, [FromBody] tipo_equipo tipo_Equipo)
        {
            tipo_equipo? tipo_equipoAct = (from e in _equipoContext.tipo_equipo
                                 where e.id_tipo_equipo == id
                                 select e).FirstOrDefault();

            if (tipo_equipoAct == null)
            {
                return BadRequest();
            }
            tipo_equipoAct.descripcion = tipo_Equipo.descripcion;
            tipo_equipoAct.estado = tipo_Equipo.estado;

            _equipoContext.Entry(tipo_equipoAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(tipo_equipoAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteTequipo/{id}")]
        public IActionResult deleteTequipo(int id)
        {
            //? para decirle que puede ser nulleable
            tipo_equipo? tipo_equipoAct = (from e in _equipoContext.tipo_equipo
                             where e.id_tipo_equipo == id
                             select e).FirstOrDefault();

            if (tipo_equipoAct == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.tipo_equipo.Attach(tipo_equipoAct);
            _equipoContext.tipo_equipo.Remove(tipo_equipoAct);
            _equipoContext.SaveChanges();
            return Ok(tipo_equipoAct);
        }
        //tipo equipo

        //estados reserva
        //insert
        [HttpPost]
        [Route("AddEstReserva")]
        public IActionResult AddEstReserva([FromBody] estados_reserva estReserva)
        {
            try
            {
                _equipoContext.estados_reserva.Add(estReserva);
                _equipoContext.SaveChanges();
                return Ok(estReserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateEstReserva/{id}")]

        public IActionResult updateEstReserva(int id, [FromBody] estados_reserva estReservas)
        {
            estados_reserva? estReservaAct = (from e in _equipoContext.estados_reserva
                                 where e.estado_res_id == id
                                 select e).FirstOrDefault();

            if (estReservaAct == null)
            {
                return BadRequest();
            }
            estReservaAct.estado = estReservas.estado;

            _equipoContext.Entry(estReservaAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(estReservaAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteEstReserva/{id}")]
        public IActionResult deleteEstReserva(int id)
        {
            //? para decirle que puede ser nulleable
            estados_reserva? est_reserva = (from e in _equipoContext.estados_reserva
                             where e.estado_res_id == id
                             select e).FirstOrDefault();

            if (est_reserva == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.estados_reserva.Attach(est_reserva);
            _equipoContext.estados_reserva.Remove(est_reserva);
            _equipoContext.SaveChanges();
            return Ok(est_reserva);
        }
        //estados reserva

        //facultades

        //insert
        [HttpPost]
        [Route("AddFacultades")]
        public IActionResult AddFacultades([FromBody] facultades estReserva)
        {
            try
            {
                _equipoContext.facultades.Add(estReserva);
                _equipoContext.SaveChanges();
                return Ok(estReserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateFacultades/{id}")]

        public IActionResult updateFacultades(int id, [FromBody] facultades facultad)
        {
            facultades? facultadAct = (from e in _equipoContext.facultades
                                              where e.facultad_id == id
                                              select e).FirstOrDefault();

            if (facultadAct == null)
            {
                return BadRequest();
            }
            facultadAct.nombre_facultad = facultad.nombre_facultad;

            _equipoContext.Entry(facultadAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(facultadAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteFacultades/{id}")]
        public IActionResult deleteFacultades(int id)
        {
            //? para decirle que puede ser nulleable
            facultades? facultad = (from e in _equipoContext.facultades
                                            where e.facultad_id == id
                                            select e).FirstOrDefault();

            if (facultad == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.facultades.Attach(facultad);
            _equipoContext.facultades.Remove(facultad);
            _equipoContext.SaveChanges();
            return Ok(facultad);
        }
        //facultades

        //reservas
        //insert
        [HttpPost]
        [Route("AddReservas")]
        public IActionResult AddReservas([FromBody] reservas estReserva)
        {
            try
            {
                _equipoContext.reservas.Add(estReserva);
                _equipoContext.SaveChanges();
                return Ok(estReserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateReserva/{id}")]

        public IActionResult updateReserva(int id, [FromBody] reservas reserva)
        {
            reservas? reservasAct = (from e in _equipoContext.reservas
                                       where e.reserva_id == id
                                       select e).FirstOrDefault();

            if (reservasAct == null)
            {
                return BadRequest();
            }
            reservasAct.fecha_salida = reserva.fecha_salida;
            reservasAct.hora_salida = reserva.hora_salida;
            reservasAct.tiempo_reserva = reserva.tiempo_reserva;
            reservasAct.fecha_retorno = reserva.fecha_retorno;
            reservasAct.hora_retorno = reserva.hora_retorno;

            _equipoContext.Entry(reservasAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(reservasAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteReservas/{id}")]
        public IActionResult deleteReservas(int id)
        {
            //? para decirle que puede ser nulleable
            reservas? reserva = (from e in _equipoContext.reservas
                                    where e.reserva_id == id
                                    select e).FirstOrDefault();

            if (reserva == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.reservas.Attach(reserva);
            _equipoContext.reservas.Remove(reserva);
            _equipoContext.SaveChanges();
            return Ok(reserva);
        }
        //reservas

        //usuario
        //insert
        [HttpPost]
        [Route("AddUsuario")]
        public IActionResult AddUsuarios([FromBody] usuarios usuario)
        {
            try
            {
                _equipoContext.usuarios.Add(usuario);
                _equipoContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateUsuarios/{id}")]

        public IActionResult updateUsuario(int id, [FromBody] usuarios usuario)
        {
            usuarios? usuarioAct = (from e in _equipoContext.usuarios
                                     where e.usuario_id == id
                                     select e).FirstOrDefault();

            if (usuarioAct == null)
            {
                return BadRequest();
            }
            usuarioAct.nombre = usuario.nombre;
            usuarioAct.documento = usuario.documento;
            usuarioAct.tipo = usuario.tipo;
            usuarioAct.carnet = usuario.carnet; 

            _equipoContext.Entry(usuarioAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(usuarioAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteUsuario/{id}")]
        public IActionResult deleteUsuarios(int id)
        {
            //? para decirle que puede ser nulleable
            usuarios? usuario = (from e in _equipoContext.usuarios
                                 where e.usuario_id == id
                                 select e).FirstOrDefault();

            if (usuario == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.usuarios.Attach(usuario);
            _equipoContext.usuarios.Remove(usuario);
            _equipoContext.SaveChanges();
            return Ok(usuario);
        }
        //usuario

        //carreras
        //insert
        [HttpPost]
        [Route("AddCarreras")]
        public IActionResult AddCarreras([FromBody] carreras carreras)
        {
            try
            {
                _equipoContext.carreras.Add(carreras);
                _equipoContext.SaveChanges();
                return Ok(carreras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //update
        [HttpPut]
        [Route("UpdateCarreras/{id}")]

        public IActionResult updateCarreras(int id, [FromBody] carreras carreras)
        {
            carreras? carrerasAct = (from e in _equipoContext.carreras
                                    where e.carrera_id == id
                                    select e).FirstOrDefault();

            if (carrerasAct == null)
            {
                return BadRequest();
            }
            carrerasAct.nombre_carrera = carreras.nombre_carrera;
            
            _equipoContext.Entry(carrerasAct).State = EntityState.Modified;
            _equipoContext.SaveChanges();
            return Ok(carrerasAct);
        }

        //delete
        [HttpDelete]
        [Route("DeleteCarrera/{id}")]
        public IActionResult deleteCarrera(int id)
        {
            //? para decirle que puede ser nulleable
            carreras? carrera = (from e in _equipoContext.carreras
                                 where e.carrera_id == id
                                 select e).FirstOrDefault();

            if (carrera == null)
            {
                return BadRequest();
            }

            //Para apuntar a uno en particular
            _equipoContext.carreras.Attach(carrera);
            _equipoContext.carreras.Remove(carrera);
            _equipoContext.SaveChanges();
            return Ok(carrera);
        }
        //carreras

        //union de las tablas
        [HttpGet]
        [Route("GetAllsecond")]
        public IActionResult Getal()
        {
            var equipos = (from u in _equipoContext.usuarios
                           join ca in _equipoContext.carreras
                           on u.carrera_id equals ca.carrera_id
                           join f in _equipoContext.facultades
                           on ca.facultad_id equals f.facultad_id
                           join r in _equipoContext.reservas
                           on u.usuario_id equals r.usuario_id
                           join est in _equipoContext.estados_reserva
                           on r.estado_reserva_id equals est.estado_res_id
                           select new
                           {
                               u.nombre,
                               ca.nombre_carrera,
                               f.nombre_facultad,
                               est.estado,
                               r.fecha_salida
                           }).ToList();
            if (equipos.Any())
            {
                return Ok(equipos);
            }
            return BadRequest();
        }
    }
}
