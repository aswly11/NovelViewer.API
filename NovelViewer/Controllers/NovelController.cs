using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace NovelViewer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NovelController : ControllerBase
    {

        private readonly INovelService _novelService;

        public NovelController(INovelService novelService)
        {
            _novelService = novelService;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_novelService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var novel = _novelService.GetById(id);
            if (novel == null)
                return NotFound();

            return Ok(novel);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Novel novel )
        {
            _novelService.Insert(novel);
            return Ok(novel);

        }



        [HttpPut]
        public IActionResult Put([FromBody] Novel novel)
        {

            var Exist = _novelService.GetByIdAsNoTracking(novel.NovelId);
            if (Exist == null)
            {
                return NotFound("Novel Not Found");
            }

            _novelService.Update(novel);
            return Ok(novel);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Exist = _novelService.GetByIdAsNoTracking(id);
            if (Exist == null)
            {
                return NotFound("Novel Not Found");
            }
            _novelService.Delete(id);
            return Ok(id);

        }
    }

}
