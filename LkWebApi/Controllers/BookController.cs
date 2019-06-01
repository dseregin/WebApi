using System;
using System.IO;
using System.Threading.Tasks;
using LkWebApi.Models;
using BS = LkWebApi.BookService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LkWebApi.Helpers;

namespace LkWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BS.BookService _bookService;

        IHostingEnvironment _appEnvironment;

        public BookController(IHostingEnvironment appEnvironment, BS.BookService bookService)
        {
            _appEnvironment = appEnvironment;

            _bookService = bookService;
        }

        /// <summary>
        /// Добавление книги со списком авторов
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bookService.AddBook(book);

            return new JsonResult(book);
        }

        /// <summary>
        /// Загрузка изображения обложки либо в файловую систему сервера
        /// либо в бд, взависимости от параметра bdMode
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <param name="bookId"></param>
        /// <param name="bdMode"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync(IFormFile uploadedFile, [FromQuery] Guid bookId, bool bdMode = false)
        {
            if (_bookService.IsExistBook(bookId) && uploadedFile != null)
            {
                try
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
                            _bookService.AddImage(new BookImage { BookId = bookId, FileName = uploadedFile.FileName, Path = path });
                        }
                    }
                    //Сохранение в т.н. БД
                    else
                    {
                        using (var binaryReader = new BinaryReader(uploadedFile.OpenReadStream()))
                        {
                            var imageData = binaryReader.ReadBytes((int)uploadedFile.Length);
                            _bookService.AddImage(new BookImage { BookId = bookId, Data = imageData });
                        }
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Удаление книги по id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("deleteById/{bookId}")]
        public IActionResult DeleteById(Guid bookId)
        {
            var result = _bookService.DeleteBookById(bookId);
            return Ok(result);
        }

        /// <summary>
        /// Полуение списка, отсортированного по загаловку или году
        /// </summary>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        [HttpGet("getBooks")]
        public IActionResult GetBooks([FromQuery] SortFilter sortFilter)
        {
            return new JsonResult(_bookService.SortBookByFilter(sortFilter));
        }

        [HttpPut("update/{bookId}")]
        public IActionResult UpdateBook(Book book, Guid bookId)
        {
            DeleteById(bookId);
            AddBook(book);

            return new JsonResult(book);
        }
    }
}
