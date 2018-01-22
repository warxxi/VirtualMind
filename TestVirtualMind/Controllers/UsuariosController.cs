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
using TestVirtualMind.Models.Clases;

namespace TestVirtualMind.Controllers
{
    public class UsuariosController : ApiController
    {
        private UserContext context = new UserContext();

        [Route("Usuarios")]
        [HttpGet]
        public IQueryable<User> List()
        {
            return this.context.User;
        }

        [Route("Usuarios/{id}")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            User user = this.context.User.Find(id);
            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        [Route("Usuarios/{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Update(int id, User user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            //if (id != user.id)
            //{
            //    return this.BadRequest();
            //}
            User userDB = this.context.User.Find(id);

            if (userDB==null)
            {
                return this.NotFound();
            }

            userDB.apellido = user.apellido;
            userDB.email = user.email;
            userDB.nombre= user.nombre;
            userDB.password = user.password;
            this.context.Entry(userDB).State = EntityState.Modified;

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UserExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("Usuarios/")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult Insert(User user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.context.User.Add(user);
            this.context.SaveChanges();

            return this.Ok(user);
        }

        [Route("Usuarios/{id}")]
        [HttpDelete]
        [ResponseType(typeof(User))]
        public IHttpActionResult Delete(int id)
        {
            User user = this.context.User.Find(id);
            if (user == null)
            {
                return this.NotFound();
            }

            this.context.User.Remove(user);
            this.context.SaveChanges();

            return this.Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return this.context.User.Count(e => e.id == id) > 0;
        }
    }
}