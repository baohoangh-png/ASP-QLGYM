using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoangDinhBao.Data;
using HoangDinhBao.Models;

namespace HoangDinhBao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor nhận AppDbContext từ hệ thống (Dependency Injection)
        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Members (Lấy danh sách tất cả hội viên)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5 (Lấy thông tin 1 hội viên theo ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy
            }

            return member;
        }

        // PUT: api/Members/5 (Cập nhật thông tin hội viên)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest(); // Trả về lỗi 400 nếu ID không khớp
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Thành công nhưng không trả về data (204)
        }

        // POST: api/Members (Thêm hội viên mới)
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            // Trả về mã 201 Created và thông tin người vừa tạo
            return CreatedAtAction("GetMember", new { id = member.MemberId }, member);
        }

        // DELETE: api/Members/5 (Xóa hội viên)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Hàm kiểm tra hội viên có tồn tại hay không
        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }
    }
}