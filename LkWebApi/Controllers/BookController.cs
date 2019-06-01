using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LkWebApi.Models;
using LkWebApi.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LkWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IHostingEnvironment _appEnvironment;
        BookRepository _bookRepository;
        BookImageRepository _bookImageRepository;

        public BookController(IHostingEnvironment appEnvironment, BookRepository bookRepository, BookImageRepository bookImageRepository)
        {
            _appEnvironment = appEnvironment;
            _bookRepository = bookRepository;
            _bookImageRepository = bookImageRepository;
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (book.Id == Guid.Empty)
                book.Id = Guid.NewGuid();

            DbSet.Books.Add(book);

            return Ok();
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile uploadedFile, [FromQuery] Guid bookId, bool bdMode = false)
        {
            try
            {
                if (_bookRepository.IsExists(bookId) && uploadedFile != null)
                {
                    //Сохранение в файловую систему
                    if (!bdMode)
                    {
                        // путь к папке Files в каталоге wwwroot
                        string path = _appEnvironment.WebRootPath + @"\Files\";

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        using (var fileStream = new FileStream(path + uploadedFile.FileName, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                            _bookImageRepository.AddImage(new BookImage { BookId = bookId, FileName = uploadedFile.FileName, Path = path });
                        }
                    }
                    //Сохранение в т.н. БД
                    else
                    {
                        using (var binaryReader = new BinaryReader(uploadedFile.OpenReadStream()))
                        {
                            var imageData = binaryReader.ReadBytes((int)uploadedFile.Length);
                            _bookImageRepository.AddImage(new BookImage { BookId = bookId, Data = imageData });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    }
}
