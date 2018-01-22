using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using TestVirtualMind.Controllers;
using TestVirtualMind.Models.Clases;

namespace TestVirtualMind.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public void ListTest()
        {
            UsuariosController controller = new UsuariosController();

            IQueryable<User> result = controller.List();

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count());
        }

        [TestMethod]
        public void GetUsuarioTest()
        {
            UsuariosController controller = new UsuariosController();

            IHttpActionResult result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(OkResult));

            result = controller.Get(12);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UpdateTest()
        {
            UsuariosController controller = new UsuariosController();

            User userOrig = (controller.Get(1) as OkNegotiatedContentResult<User>).Content;
            User userEdit = new User();

            userEdit.id = userOrig.id;
            userEdit.apellido += userOrig.apellido + "update";
            userEdit.email += userOrig.email + "update";
            userEdit.nombre += userOrig.nombre + "update";
            userEdit.password += userOrig.password + "update";

            IHttpActionResult result = controller.Update(1, userEdit);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            User userUpdate = (controller.Get(1) as OkNegotiatedContentResult<User>).Content;
            Assert.IsNotNull(userUpdate);
            Assert.AreEqual(userEdit.id, userUpdate.id);
            Assert.AreEqual(userEdit.apellido, userUpdate.apellido);
            Assert.AreEqual(userEdit.email, userUpdate.email);
            Assert.AreEqual(userEdit.nombre, userUpdate.nombre);
            Assert.AreEqual(userEdit.password, userUpdate.password);
        }

        [TestMethod]
        public void UpdateNotExistTest()
        {
            UsuariosController controller = new UsuariosController();

            IQueryable<User> users = controller.List();
            User lastUser = users.ToList<User>()[users.Count() - 1];

            User userOrig = (controller.Get(1) as OkNegotiatedContentResult<User>).Content;
            User userEdit = new User();


            userEdit.id = lastUser.id + 1;
            userEdit.apellido += userOrig.apellido + "update";
            userEdit.email += userOrig.email + "update";
            userEdit.nombre += userOrig.nombre + "update";
            userEdit.password += userOrig.password + "update";

            IHttpActionResult result = controller.Update(userEdit.id, userEdit);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void Insert()
        {
            UsuariosController controller = new UsuariosController();

            User userNew = new User();
            userNew.apellido = "insert";
            userNew.email = "insert";
            userNew.nombre = "insert";
            userNew.password = "insert";

            IHttpActionResult result = controller.Insert(userNew);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<User>));

            IQueryable<User> users = controller.List();
            User lastUser = users.ToList<User>()[users.Count() - 1];

            Assert.AreEqual(userNew.apellido, lastUser.apellido);
            Assert.AreEqual(userNew.email, lastUser.email);
            Assert.AreEqual(userNew.nombre, lastUser.nombre);
            Assert.AreEqual(userNew.password, lastUser.password);

            controller.Delete(lastUser.id);
        }

        [TestMethod]
        public void Delete()
        {
            UsuariosController controller = new UsuariosController();

            User userNew = new User();
            userNew.id = 0;
            userNew.apellido = "delete";
            userNew.email = "delete";
            userNew.nombre = "delete";
            userNew.password = "delete";

            User lastUser = (controller.Insert(userNew) as OkNegotiatedContentResult<User>).Content;
            IHttpActionResult deleteResult = controller.Delete(lastUser.id);
            Assert.IsNotNull(deleteResult);
            Assert.IsInstanceOfType(deleteResult, typeof(OkNegotiatedContentResult<User>));
        }

        [TestMethod]
        public void DeleteNotExists()
        {
            UsuariosController controller = new UsuariosController();

            IQueryable<User> users = controller.List();
            User lastUser = users.ToList<User>()[users.Count() - 1];

            IHttpActionResult deleteResult = controller.Delete(lastUser.id + 1);
            Assert.IsNotNull(deleteResult);
            Assert.IsInstanceOfType(deleteResult, typeof(NotFoundResult));
        }
    }
}
