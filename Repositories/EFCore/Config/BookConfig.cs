using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData
            (
            new Book { Id = 1, Title = "Karagöz ve Hacivat",Price= 85},
            new Book { Id = 2, Title = "Karagöz ve Hacivat", Price = 235 },
            new Book { Id = 3, Title = "Karagöz ve Hacivat", Price = 150 }
            );
    }
}
