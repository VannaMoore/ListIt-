using Api.Data;
using Api.Data.List;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class  ListController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public ListController(AppDbContext context)
        {
            _context = context;
        }

        // Get all lists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListDto>>> GetLists()
        {
            var lists = await _context.Lists
                .Select(l => new ListDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    CreatedAt = l.CreatedAt,
                    Type = l.Type,
                    OwnerId = l.OwnerId,
                    ParentListId = l.ParentListId
                })
                .ToListAsync();

            return Ok(lists);
        }

        // Get a list by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ListDto>> GetList(int id)
        {
            var list = await _context.Lists.FindAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            return new ListDto
            {
                Id = list.Id,
                Name = list.Name,
                Description = list.Description,
                CreatedAt = list.CreatedAt,
                Type = list.Type,
                OwnerId = list.OwnerId,
                ParentListId = list.ParentListId
            };

        }

        // POST - create a new list
        [HttpPost]
        public async Task<ActionResult<List>> CreateList(CreateListDto dto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized();

            if (!int.TryParse(userIdString, out int userId))
                return Unauthorized();

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return Unauthorized();

            var list = new List
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                Type = dto.Type,
                Owner = user,
                ParentListId = dto.ParentListId
            };

            _context.Lists.Add(list);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetList), new { id = list.Id }, list);
        }

        // PUT: api/list/{id} - Update a list
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(int id, UpdateListDto dto)
        {
            List? list = await _context.Lists.FindAsync(id);

            if (list == null)
                return NotFound();

            // Update fields
            list.Name = dto.Name;
            list.Description = dto.Description;
            list.Type = dto.Type;
            list.ParentListId = dto.ParentListId;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 success, no body
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var list = await _context.Lists.FindAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(list);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }

}