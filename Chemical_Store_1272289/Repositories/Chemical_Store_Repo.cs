using Chemical_Store_1272289.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemical_Store_1272289.Repositories
{
    public class Chemical_Store_Repo : IRepo
    {
        public void Delete(int chemicalId)
        {
            Chemical_Info chemical = Chemical_DB.ChemicalList.FirstOrDefault(x => x.ChemicalId == chemicalId);
            Chemical_DB.ChemicalList.Remove(chemical);
        }
        public IEnumerable<Chemical_Info> GetAll()
        {
            return Chemical_DB.ChemicalList;
        }
        public Chemical_Info GetById(int ChemicalId)
        {
            Chemical_Info chemical = Chemical_DB.ChemicalList.FirstOrDefault(x => x.ChemicalId == ChemicalId);
            return chemical;
        }
        public void Insert(Chemical_Info chemical_info)
        {
            Chemical_DB.ChemicalList.Add(chemical_info);
        }
        public void Update(Chemical_Info chemical_info)
        {
            Chemical_Info _chemical = Chemical_DB.ChemicalList.FirstOrDefault(x => x.ChemicalId == chemical_info.ChemicalId);
            if (chemical_info.ChemicalName != null)
            {
                _chemical.ChemicalName = chemical_info.ChemicalName;
            }
            if (chemical_info.Storage_Unit != 0)
            {
                _chemical.Storage_Unit = chemical_info.Storage_Unit;
            }
        }
    }
}
