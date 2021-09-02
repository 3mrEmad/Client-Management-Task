using Client__Management_Task.Data;
using Client__Management_Task.DTOs;
using Client__Management_Task.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client__Management_Task.Entites.models
{
    public class ClientRepositry : IclientInterface
    {


        private readonly DataContext context;
        public ClientRepositry(DataContext _context)
        {
            context = _context;
        }


        public Client Add(UpdateClientDTOs Newclient)
        {      
               Client client = new Client()
                {
                    FirstName = Newclient.FirstName,
                    LastName = Newclient.LastName,
                    DateofBirth = Newclient.DateofBirth,
                    MaritalStatus = Newclient.MaritalStatus,
                    MobileNumber = Newclient.MobileNumber,
                    Email = Newclient.Email,
                    ImagePath = Newclient.ImagePath,
                };

                  context.Clients.Add(client);
                  context.SaveChanges();
                  return client;
        }

        public Client Delete(int id)
        {
            var client =  context.Clients.Find(id);
            context.Clients.Remove(client);
            context.SaveChanges();
            return client;
        }

        public IEnumerable<Client> GetAllClients()
        {
            var clients = context.Clients
            .FromSqlRaw("EXECUTE dbo.MyClients");

            
            return clients;
        }

        public PageList<Client> FindAll(ClientParameter ClientParameters)
        {
            
            return PageList<Client>
       .ToPagedList(context.Clients, ClientParameters.PageNumber, ClientParameters.PageSize);

        }

        public Client GetById(int id)
        {
            var client =  context.Clients
                .Find(id);
            return client;
        }

        public Client Update(int id , UpdateClientDTOs clientUpdate)
        {

                var client = context.Clients.Find(id); // client beforeUpdate //
                client.FirstName = clientUpdate.FirstName;
                client.LastName = clientUpdate.LastName;
            client.DateofBirth = client.DateofBirth;
                client.MaritalStatus = clientUpdate.MaritalStatus;
                client.MobileNumber = clientUpdate.MobileNumber;
                client.Email = clientUpdate.Email;
                context.Clients.Update(client);
                context.SaveChanges();
                return client;

        }

       public Client Search(string PhoneNumber)
        {
            var client = context.Clients.FirstOrDefault(e => e.MobileNumber == PhoneNumber);
            return client;
        }

    }
}
