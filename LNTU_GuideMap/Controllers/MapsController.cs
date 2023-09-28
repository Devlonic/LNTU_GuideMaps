using LNTU_GuideMap.Data;
using LNTU_GuideMap.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LNTU_GuideMap.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MapsController : ControllerBase {
        private readonly MapsDbContext db;

        public MapsController(MapsDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            var list = await db.Maps.Select(m=> new {id = m.Id}).ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm]NewMapDto dto) {
            var s = dto.Image.OpenReadStream();

            byte[]? image = null!;
            await Task.Run(() => {
                image = new BinaryReader(s).ReadBytes((int)s.Length);
            });

            db.Maps.Add(new Map() {
                Id = Guid.NewGuid(),
                Image = image,
            });
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
