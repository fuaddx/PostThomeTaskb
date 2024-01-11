using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.Services.Interfaces;

namespace TwitFriday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService _service { get; }

        public PostsController(IPostService service)
        {
            _service = service;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PostCreateDto dto)
        {
            string authorname = User.Identity.Name;
            await _service.Create(dto,authorname);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(id);
            return Ok();
        }
        [HttpDelete("SoftDelete")]
        public async Task<IActionResult>SoftDelete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
