using LkTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LkTest.Controllers
{
    public class BookController : ApiController
    {
        [Route("book/add")]
        [HttpPost]
        public IHttpActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Json(book);
        }

        [Route("book/upload")]
        [HttpPost]
        public IHttpActionResult Upload(HttpPostedFileBase upload)
        {
            // получаем имя файла
            string fileName = System.IO.Path.GetFileName(upload.FileName);
            // сохраняем файл в папку Files в проекте
            //upload.SaveAs(Server.MapPath("~/Files/" + fileName));

            //var provider = new MultipartMemoryStreamProvider();
            //var result = await Request.Content.ReadAsMultipartAsync(provider);

            //var stream = provider.Contents[0];  // если гарантированно один файл передавался, иначе - пройдитесь с помощью foreach
            //var fileName = stream.Headers.ContentDisposition.FileName.Trim('"');
            //var imgStream = await stream.ReadAsStreamAsync();

            return Ok();
        }
    }
}
