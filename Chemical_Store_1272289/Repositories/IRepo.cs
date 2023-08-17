using Chemical_Store_1272289.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemical_Store_1272289.Repositories
{
    public interface IRepo
    {
        IEnumerable<Chemical_Info> GetAll();
        Chemical_Info GetById(int ChemicalId);
        void Insert(Chemical_Info chemical_info);
        void Update(Chemical_Info chemical_info);
        void Delete(int ChemicalId);
    }
}
