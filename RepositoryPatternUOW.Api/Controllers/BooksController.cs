using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternUOW.Core;
using RepositoryPatternUOW.Core.Contss;
using RepositoryPatternUOW.Core.Interfaces;
using RepositoryPatternUOW.Core.Models;

namespace RepositoryPatternUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Books.GetById(id));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Books.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Books.GetAllAsync());
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByName(string title)
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == title, new[] { "Author" }));
        }

        [HttpGet("GetByTitleAsync")]
        public async Task<IActionResult> GetByTitleAsync(string title)
        {
            return Ok(await _unitOfWork.Books.FindAsync(a => a.Title == title, new[] { "Author" }));
        }
        [HttpGet("GetOrderd")]
        public async Task<IActionResult> GetOrderd()
        {
            return Ok(await _unitOfWork.Books.FindAllAsync(b => string.IsNullOrEmpty(b.Title) == string.IsNullOrEmpty("B"), null, null, b => b.Id,OrderBy.Descending));
        }
        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Test 3", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }
    }
}
