using Client__Management_Task.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client__Management_Task.Controllers
{
    public class UploadController:Controller
    {
        private readonly DataContext context;
        private readonly IHostingEnvironment host;
        public UploadController(DataContext _context , IHostingEnvironment host)
        {
            context = _context;
            this.host = host;
        }

        [HttpPost]
        [Route("api/UploadPhoto/{clinetId}")]
        public IActionResult Upload(int clinetId)
        {

             var clinet = this.context.Clients.Find(clinetId);

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    clinet.ImagePath = dbPath;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }





    }
}
