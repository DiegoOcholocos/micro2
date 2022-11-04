using micro2.Context;
using Microsoft.AspNetCore.Mvc;
using micro2.Models;
using Microsoft.EntityFrameworkCore;

namespace micro2.Controllers
{
    [Route("[controller]")]
    public class blacklistDoc : Controller
    {
        private readonly ConexionMySQL _context;
        private readonly ConexionSQLServer _context2;
        public blacklistDoc(ConexionMySQL context,ConexionSQLServer context2)
        {
            _context = context;
            _context2 = context2;
        }
    
        [HttpGet("VerificarListaMysql/{Doc}")]
        public async Task<IActionResult> VerificarListaMysql(string Doc)
        {
            var equi = await _context.blacklist_on.FirstOrDefaultAsync(m => m.nro_doc == Doc);
            if (equi == null)
            {
                return NotFound(); 
            }
            return Ok(equi);
        }


        [HttpGet("VerificarListaSQLserver")]
        public async Task<IActionResult> VerificarListaSQLserver()
        {
            var equi = await _context2.blacklist_on.ToListAsync();
            if (equi == null)
            {
                return NotFound(); 
            }
            return Ok(equi);
        }


        [HttpGet("GUARDAR/{Doc}")]
        public async Task<IActionResult> VerificarListaSQLserver(string Doc)
        {
            var equiM = await _context2.blacklist_on.ToListAsync();
            var equi = await _context.blacklist_on.FirstOrDefaultAsync(m => m.nro_doc == Doc);
            _context2.blacklist_on.RemoveRange(equiM);
            _context2.blacklist_on.AddRange(equi);
            await _context2.SaveChangesAsync();
            if (equi == null)
            {
                return NotFound(); 
            }
            return Ok(equi);
        }
    }

    
}