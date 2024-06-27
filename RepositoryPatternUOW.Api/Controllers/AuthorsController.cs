using Microsoft.AspNetCore.Mvc;
using RepositoryPatternUOW.Core;
using RepositoryPatternUOW.Core.Interfaces;
using RepositoryPatternUOW.Core.Models;

namespace RepositoryPatternUOW.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Authors.GetById(id));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Authors.GetAllAsync());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            return Ok(_unitOfWork.Authors.Find(a => a.Name == name));
        }

        [HttpGet("GetByNameAsync")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return Ok(await _unitOfWork.Authors.FindAsync(a => a.Name == name));
        }
    }
}
