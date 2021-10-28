using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Linq;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly DataContext context;

        public PostsController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// GET api/posts
        /// </summary>
        /// <returns>A list of posts</returns>
        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return this.context.Posts.ToList();
        }

        /// <summary>
        /// GET api/post/[id]
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>A single post</returns>
        [HttpGet("{id}")]
        public ActionResult<Post> GetById(Guid id)
        {
            return this.context.Posts.Find(id);
        }

    }
}