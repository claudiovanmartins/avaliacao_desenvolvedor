using Avaliacao.WorkinHub.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Avaliacao.WorkinHub.Web.Tests.Controllers
{
    [TestClass]
    public class UploadControllerTest
    {
        [TestMethod]
        public void TestGetPedidos()
        {
            var controller = new UploadController();
            var result = controller.GetPedidos();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new UploadController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestPostFile()
        {
            var file = MockRepository.GenerateStub<HttpPostedFileBase>();
            file.Expect(f => f.ContentLength).Return(1);
            file.Expect(f => f.FileName).Return("fileName");

            var controller = new UploadController();
            controller.Index(file);
        }
    }
}
