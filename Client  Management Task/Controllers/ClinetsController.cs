using Client__Management_Task.Data;
using Client__Management_Task.Entites;
using Client__Management_Task.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client__Management_Task.Entites.models;
using Client__Management_Task.Interfaces;
using Newtonsoft.Json;

namespace Client__Management_Task.Controllers
{
    public class ClinetsController:Controller
    {
        private readonly DataContext context;
        private readonly IclientInterface clientRepositry;

        public ClinetsController(DataContext _context , IclientInterface clientRepositry)
        {
            this.context = _context;
            this.clientRepositry = clientRepositry;
        }


        [HttpGet]
        [Route("api/GetClients")]
        public IActionResult GetClinets([FromQuery] ClientParameter clientParameters)
        {
            var clinet = clientRepositry.FindAll(clientParameters);
            var metadata = new
            {
                clinet.TotalCount,
                clinet.PageSize,
                clinet.CurrentPage,
                clinet.TotalPages,
                clinet.HasNext,
                clinet.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(clinet);

        }


        [HttpGet]
        [Route("api/findByStoredProcdure")]
        public IActionResult FindAll()
        {
          return Ok(clientRepositry.GetAllClients());
        }


        [HttpGet]
        [Route("api/GetClient/{id}")]
        public IActionResult GetClinets(int id)
        {
            return Ok(clientRepositry.GetById(id));
        }


        [HttpPost]
        [Route("api/AddClient")]
        public IActionResult Add([FromBody] UpdateClientDTOs Newclinet)
        {
            return Ok(clientRepositry.Add(Newclinet));
        }



        [HttpGet]
        [Route("api/Search/{phoneNumber}")]
        public IActionResult Search(string phoneNumber)
        {

            var clinet = clientRepositry.Search(phoneNumber);
            return Ok(clientRepositry.Search(phoneNumber));

        }


        [HttpPut]
        [Route("api/EditClient/{Id}")]
        public IActionResult EditClinet(int Id,[FromBody] UpdateClientDTOs clientUpdate)
        {
            var client = clientRepositry.Update(Id, clientUpdate);
            return Ok(client);
        }
        
        [HttpDelete]
        [Route("api/delete/{id}")]
        public IActionResult DeleteClient(int id)
        {
           return Ok(clientRepositry.Delete(id));
        }





    }
}
