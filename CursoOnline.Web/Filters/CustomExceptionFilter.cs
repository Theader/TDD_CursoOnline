using CursoOnline.Dominio._Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CursoOnline.Web.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-request-with"] == "XMLHttpRequest";

            if (isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = context.Exception is ExcecaoDeDominio ? 502 : 500;
                var message = context.Exception is ExcecaoDeDominio dominio ?
                              new JsonResult(dominio.MensagensDeErros) :
                              new JsonResult("An error ocorred");
                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }
    }
}
