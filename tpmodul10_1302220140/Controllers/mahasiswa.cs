using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

public class mahasiswa
{
    public string nama { get; set; }
    public string NIM { get; set; }

}

namespace tpmodul10_1302220140.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mahasiswaController : ControllerBase
    {
        private static List<mahasiswa> mahasiswaList = new List<mahasiswa>
        {
            new mahasiswa{nama = "Raphael Permana Barus",NIM ="1302220140" },
            new mahasiswa{nama = "Dafa Raimi Suandi",NIM ="1302223156" },
            new mahasiswa{nama = "Haikal Risnandar",NIM ="1302221050" },
            new mahasiswa{nama = "Fersya Zufar",NIM ="1302223090" },
            new mahasiswa{nama = "Mahesa Athaya Zain",NIM ="1302220105" },
            new mahasiswa{nama = "Darryl Frizangelo Rambi",NIM ="1302223154" },
        };

        // GET /api/mahasiswa
        [HttpGet]
        public IEnumerable<mahasiswa> GetMahasiswa()
        {
            return mahasiswaList;
        }

        // GET /api/mahasiswa/{id}
        [HttpGet("{id}")]
        public IActionResult GetMahasiswa(int id)
        {
            if (id >= 0 && id < mahasiswaList.Count)
            {
                return Ok(mahasiswaList[id]);
            }
            else
            {
                return NotFound();
            }
        }

        // POST /api/mahasiswa
        [HttpPost]
        public IActionResult PostMahasiswa([FromBody] mahasiswa input)
        {
            mahasiswaList.Add(input);
            return CreatedAtAction(nameof(GetMahasiswa), new { id = mahasiswaList.Count - 1 }, input);
        }

        // DELETE /api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMahasiswa(int id)
        {
            if (id >= 0 && id < mahasiswaList.Count)
            {
                mahasiswaList.RemoveAt(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
