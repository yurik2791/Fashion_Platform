using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionPlatform.Domain.Abstract;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Concrete
{
   public class EFPersonRepository : IPersonRepository
    {
        EFDbContext context = new EFDbContext(); // Класс для взаимодействия с базой данных (Свойства соответсвует имени таблицы из базы данных)
        public IEnumerable<Person> Persons
        {
            get
            {
                return context.Persons;
            }
        }
    }
}
