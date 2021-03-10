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
    public class VacunaController : Controller{
        public readonly AppDbContext context;
        public VacunaController(AppDbContext context){
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get(){
            try
            {
                return Ok(context.Vacuna.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetVacuna")]
        public ActionResult Get(int id){
            try
            {
                var vacuna = context.Vacuna.FirstOrDefault(v => v.id == id);
                return Ok(vacuna);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Vacuna vacuna){
            try
            {
                context.Add(vacuna);
                context.SaveChanges();
                return CreatedAtRoute("GetVacuna", new {id = vacuna.id}, vacuna);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Vacuna vacuna){
            try
            {
                if(vacuna.id == id){
                    context.Entry(vacuna).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetVacuna", new {id = vacuna.id}, vacuna);
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
                var vacuna =  context.Vacuna.FirstOrDefault(v => v.id == id);
                if(vacuna !=  null){
                    context.Remove(vacuna);
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