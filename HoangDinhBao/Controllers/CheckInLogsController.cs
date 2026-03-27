using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoangDinhBao.Data;
using HoangDinhBao.Models;

namespace HoangDinhBao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckInLogsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckInLog>>> GetCheckInLogs()
        {
            return await _context.CheckInLogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckInLog>> GetCheckInLog(int id)
        {
            var checkInLog = await _context.CheckInLogs.FindAsync(id);

            if (checkInLog == null)
            {
                return NotFound();
            }

            return checkInLog;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckInLog(int id, CheckInLog checkInLog)
        {
            if (id != checkInLog.LogId)
            {
                return BadRequest();
            }

            _context.Entry(checkInLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CheckInLog>> PostCheckInLog(CheckInLog checkInLog)
        {
            _context.CheckInLogs.Add(checkInLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckInLog", new { id = checkInLog.LogId }, checkInLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckInLog(int id)
        {
            var checkInLog = await _context.CheckInLogs.FindAsync(id);
            if (checkInLog == null)
            {
                return NotFound();
            }

            _context.CheckInLogs.Remove(checkInLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckInLogExists(int id)
        {
            return _context.CheckInLogs.Any(e => e.LogId == id);
        }
    }
}