using Avaliacao.WorkinHub.Web.DAL.Repository;
using System.Configuration;
using System.Web.Mvc;

namespace Avaliacao.WorkinHub.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        #region Declare

        public string FOLDER_PATH = ConfigurationManager.AppSettings["PathUploadFiles"].ToString();
        public PedidoRepository PedidoRepository;

        #endregion
    }
}