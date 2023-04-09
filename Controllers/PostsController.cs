using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternacionalizacionAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternacionalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        public PostsController(IStringLocalizer<PostsController> stringLocalizer, IStringLocalizer<SharedResource> sharedResource)
        {
            _sharedResourceLocalizer = sharedResource;
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        [Route("PostsControllerResource")]
        public IActionResult GetUsingPostControllerResource()
        {
            // Find text
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;
            return Ok(
                new
                {
                    PostType = article.Value,
                    PostName = postName
                }
            );
        }

        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;
            var todayIs = string.Format(_sharedResourceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());
            return Ok(
                new
                {
                    PostrType = article.Value,
                    PostName = postName,
                    TodayIs = todayIs
                }
            );
        }

    }
}
