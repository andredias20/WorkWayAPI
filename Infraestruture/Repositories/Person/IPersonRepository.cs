using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestruture.Repositories
{
    public interface IPersonRepository
    {
        public List<PersonReadDTO>? GetAll(int page, int size);
        Person? GetPersonById(int id);
        PersonReadDTO? GetPersonReadDTOById(int id);
        Person? CreatePerson(PersonCreateDTO personCreateDTO);
        Person? UpdatePerson(PersonUpdateDTO personUpdateDTO);
        Person? DeletePerson(int id);
    }
}
