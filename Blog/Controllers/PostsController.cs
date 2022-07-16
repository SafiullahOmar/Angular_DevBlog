using Blog.Data;
using Blog.Models.DTO;
using Blog.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DevBlogDbContext dbContext;
        public PostsController(DevBlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPosts() {
            var posts =await dbContext.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id) {
            var post=await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post != null) {
                return Ok(post);
            }

            return NotFound();
         }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest) {
            var post = new Post() {
            Title=addPostRequest.Title,
            Content=addPostRequest.Content,
            Author=addPostRequest.Author,
            FeautredImageURL=addPostRequest.FeautredImageURL,
            PublishDate=addPostRequest.PublishDate,
            UpdateDate=addPostRequest.UpdateDate,
            Summary=addPostRequest.Summary  ,
            URLHandle=addPostRequest.URLHandle,
            Visible=addPostRequest.Visible
            };

            post.Id = Guid.NewGuid();
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id },post );
         }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid id,UpdatePostRequest updatePostRequest) {
           

            var existingPost = await dbContext.Posts.FindAsync(id);
            if (existingPost != null) {
                existingPost.Title = updatePostRequest.Title;
                existingPost.Content = updatePostRequest.Content;
                existingPost.Author = updatePostRequest.Author;
                existingPost.FeautredImageURL = updatePostRequest.FeautredImageURL;
                existingPost.PublishDate = updatePostRequest.PublishDate;
                existingPost.UpdateDate = updatePostRequest.UpdateDate;
                existingPost.Summary = updatePostRequest.Summary;
                existingPost.URLHandle = updatePostRequest.URLHandle;
                existingPost.Visible = updatePostRequest.Visible;

                await dbContext.SaveChangesAsync();
                return Ok(existingPost);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {


            var existingPost = await dbContext.Posts.FindAsync(id);
            if (existingPost != null)
            {

                 dbContext.Posts.Remove(existingPost);
                await dbContext.SaveChangesAsync();
                return Ok(existingPost);
            }

            return NotFound();

        }
    }
}
