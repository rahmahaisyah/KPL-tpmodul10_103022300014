using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300014.Controllers
{
    [ApiController] //Menentukan route untuk controller ini.
                    //Dalam hal ini, endpoint-nya akan dimulai dengan /api/mahasiswa
    [Route("[controller]")]
    public class MahasiswaController : ControllerBase
    {
        //Static list untuk  menyimpan data Mahasiswa
        private static List<Mahasiswa> mhsList = new List<Mahasiswa>
        {
            new Mahasiswa("Rahmah Aisyah", "103022300014"),
            new Mahasiswa("Muhammad Fauzan", "103022300065 "),
            new Mahasiswa("Dewanta Rahma Satria", "103022300071"),
            new Mahasiswa("Dhea Sri Noor Septianiz", "103022300072"),
            new Mahasiswa("Dina Salsabilla", "103022300153"),
        };

        //GET: api/mahasiswa
        [HttpGet] //Mengambil data mahasiswa.
        public ActionResult<List<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mhsList);
        }

        //GET: api/mahasiswa{index}
        [HttpGet("{index}")]
        public ActionResult<List<Mahasiswa>> GetMahaiswaIdx(int index)
        {
            if(index < 0 || index >= mhsList.Count)
            {
                return NotFound("Mahasiswa not found");
            }
            return Ok(mhsList[index]);
        }

        // POST: api/mahasiswa
        [HttpPost] //Menambahkan mahasiswa baru.
        public ActionResult AddMhs(Mahasiswa newMhs)
        {
            mhsList.Add(newMhs);
            return CreatedAtAction(nameof(GetMahaiswaIdx), new
            {
                Index = mhsList.Count - 1
            }, newMhs);
        }

        // DELETE: api/mahasiswa/{index}
        [HttpDelete("{index}")] //Menghapus mahasiswa berdasarkan index
        public ActionResult DeleteMhs(int index)
        {
            if(index < 0 || index >= mhsList.Count)
            {
                return NotFound("Mahasiswa not found");
            }
            mhsList.RemoveAt(index);
            return NoContent();
        }
    }
}
