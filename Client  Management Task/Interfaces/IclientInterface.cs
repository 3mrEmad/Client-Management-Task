using Client__Management_Task.DTOs;
using Client__Management_Task.Entites;
using Client__Management_Task.Entites.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client__Management_Task.Interfaces
{
     public interface IclientInterface
    {



        PageList<Client> FindAll(ClientParameter ClientParameter);
        IEnumerable<Client> GetAllClients();
        Client Add(UpdateClientDTOs client);
        Client Delete(int id);
        Client Update( int id  ,  UpdateClientDTOs updateClient);
        Client GetById(int id);
        Client Search(string PhoneNumber);

    }
}
