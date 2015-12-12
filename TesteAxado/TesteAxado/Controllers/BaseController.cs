using System;
using System.Web.Mvc;

namespace Teste2.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Show success message
        /// </summary>
        /// <param name="mensagem">Message to show</param>
        protected void SuccessMessage(string message)
        {
            TempData["Message"] = Uri.EscapeUriString(message);
            TempData["MessageType"] = "Success";
        }

        /// <summary>
        /// Show information message
        /// </summary>
        /// <param name="mensagem">Message to show</param>
        protected void InformationMessage(string message)
        {
            TempData["Message"] = Uri.EscapeUriString(message);
            TempData["MessageType"] = "Info";
        }

        /// <summary>
        /// Show warning message
        /// </summary>
        /// <param name="mensagem">Message to show</param>
        protected void WarningMessage(string message)
        {
            TempData["Message"] = Uri.EscapeUriString(message);
            TempData["MessageType"] = "Warning";
        }

        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="mensagem">Message to show</param>
        protected void ErrorMessage(string message)
        {
            TempData["Message"] = Uri.EscapeUriString(message);
            TempData["MessageType"] = "Error";
        }
    }
}