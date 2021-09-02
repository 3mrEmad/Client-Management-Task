
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client__Management_Task.Entites.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(

                new Client
                {
                    Id  = 1,
                    FirstName = "Amr",
                    LastName = "Emad",
                    DateofBirth = new DateTime(),
      
                    MaritalStatus  = "Single",
                    MobileNumber = "01205890601",
                    Email  = "3mr3mad74@gmail.com",
                },

                new Client
                {
                    Id  = 2,
                    FirstName = "Sayed",
                    LastName = "Fahmy",
                    DateofBirth = new DateTime(5/ 4 / 1990),
                    MaritalStatus = "Married",
                    MobileNumber = "01105890804",
                    Email = "SayedFahmy33@gmail.com",
                }


                );
        }
        }
}
