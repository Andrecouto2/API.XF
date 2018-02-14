using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Atividade._06;
using API.Atividade._06.Models;

namespace API.Atividade._06.Controllers
{
    public class AtividadesController : ApiController
    {
        private FiapDbContext db = new FiapDbContext();

        // GET: api/Atividades
        public IQueryable<Models.Atividade> GetAtividades()
        {
            return db.Atividades;
        }

        // GET: api/Atividades/5
        [ResponseType(typeof(Models.Atividade))]
        public IHttpActionResult GetAtividade(int id)
        {
            Models.Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return NotFound();
            }

            return Ok(atividade);
        }

        // PUT: api/Atividades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtividade(int id, Models.Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atividade.Id)
            {
                return BadRequest();
            }

            db.Entry(atividade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Atividades
        [ResponseType(typeof(Models.Atividade))]
        public IHttpActionResult PostProfessor(Models.Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!AtividadeExists(atividade.Id))
            {
                db.Atividades.Add(atividade);
                db.SaveChanges();
                return Ok(atividade);
            }
            else
            {
                db.Entry(atividade).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // DELETE: api/Atividades/5
        [ResponseType(typeof(Models.Atividade))]
        public IHttpActionResult DeleteProfessor(int id)
        {
            Models.Atividade professor = db.Atividades.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            db.Atividades.Remove(professor);
            db.SaveChanges();

            return Ok(professor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtividadeExists(int id)
        {
            return db.Atividades.Count(e => e.Id == id) > 0;
        }

    }
}
