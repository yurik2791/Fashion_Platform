using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Abstract
{
    public interface IPersonRepository // Интерфейс для работы с хранилищем пользователей
    {
        IEnumerable<Person> Persons { get; }
    }
}
