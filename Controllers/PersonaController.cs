using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Context;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers{
    [Route("api/[controller]")]
    public class PersonaController:Controller{
        public readonly AppDbContext context;
        public PersonaController(AppDbContext context){
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get(){
            try
            {
                return Ok(context.Persona.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}",Name = "GetPersona")]
        public ActionResult Get(int id){
            try
            {
                var persona = context.Persona.FirstOrDefault(p => p.id == id);
                return Ok(persona);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Persona persona){
            try
            {
                context.Persona.Add(persona);
                context.SaveChanges();
                return CreatedAtRoute("GetPersona", new {id = persona.id}, persona);
            }
            catch (Exception e)
            {  
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona persona){
            try
            {
                //Validamos si el registro existe
                if(persona.id == id){
                    context.Entry(persona).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPersona", new {id = persona.id}, persona);
                }else{
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            try
            {
                var persona = context.Persona.FirstOrDefault(p => p.id == id);
                //Validamos si existe este registro
                if(persona != null){
                    context.Persona.Remove(persona);
                    return Ok(id);
                }else{
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}