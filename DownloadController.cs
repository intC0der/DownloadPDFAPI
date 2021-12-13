using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;

namespace DowloadAPITest.Controllers
{
    public class DownloadController : ApiController
    {
        public HttpResponseMessage Get() 
        {
            HttpResponseMessage result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            string pdfLocation = HostingEnvironment.MapPath("~/Content/tst.pdf");

            var stream = new MemoryStream(System.IO.File.ReadAllBytes(pdfLocation));
            stream.Position = 0;

            if (stream == null)
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);

            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            //result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");

            result.Content.Headers.ContentDisposition.FileName = "fileTest.pdf";
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

            result.Content.Headers.ContentLength = stream.Length;

            return result;
        }


    }
}