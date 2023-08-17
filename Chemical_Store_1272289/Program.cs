using Chemical_Store_1272289.Models;
using Chemical_Store_1272289.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemical_Store_1272289
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DisplayOption();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        public static void DisplayOption()
        {
            Console.WriteLine("\n\t\t\tApplication\n\n");
            Console.Write("Press '1' For Show All Chemical_Info/ '2' For Insert Chemical_Info/ \n      '3' For Update Chemical_Info/ '4' For Delete Chemical_Info : \t");            
            var index = int.Parse(Console.ReadLine());
            Show(index);

        }
        public static void Show(int index)
        {
            Chemical_Store_Repo chemical_store_Repo = new Chemical_Store_Repo();
            if (index == 1)
            {
                var chemicalList = chemical_store_Repo.GetAll();
                if (chemicalList.Count() == 0)
                {
                    
                    Console.WriteLine("\nNo data found\n");                    
                    DisplayOption();
                }
                else
                {
                    foreach (var item in chemical_store_Repo.GetAll())
                    {
                        Console.Write($"\nChemical Id: {item.ChemicalId},\nChemical Name: {item.ChemicalName},\nStorage Unit: {item.Storage_Unit},\nEntry Date: {item.EntryDate},\nExpiry Date: {item.ExpiryDate} \n");
                    }                   
                    DisplayOption();
                }
            }
            else if (index == 2)
            {
                
                Console.Write("\n Chemical Name :");
                string name = Console.ReadLine();

                Console.Write("\nStorage Unit :");
                int storage_unit = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nEntry Date :");
                DateTime entry_date = Convert.ToDateTime(Console.ReadLine());

                Console.Write("\nExpiry Date :");
                DateTime expiry_date = Convert.ToDateTime(Console.ReadLine());


                int maxId = chemical_store_Repo.GetAll().Any() ? chemical_store_Repo.GetAll().Max(x => x.ChemicalId) : 0;

                Chemical_Info chemical_info = new Chemical_Info
                {
                    ChemicalId = maxId + 1,
                    ChemicalName = name,
                    Storage_Unit = storage_unit,
                    EntryDate = entry_date,
                    ExpiryDate = expiry_date
                };
                chemical_store_Repo.Insert(chemical_info);
                Console.WriteLine("\nData Inserted successfully!!!\n");               
                DisplayOption();
            }
            else if (index == 3)
            {                
                Console.Write("\nEnter Chemical Id to Update: ");
                int id = int.Parse(Console.ReadLine());
                var _chemical = chemical_store_Repo.GetById(id);

                if (_chemical == null)
                {
                    
                    Console.WriteLine("\nChemical Id is invalid!!!\n");                    
                    DisplayOption();
                }
                else
                {
                    Console.WriteLine($"Update Info for Chemical Id : {id}");
                    
                    Console.Write("Chemical Name :");
                    string name = Console.ReadLine();

                    Console.Write("Storage Unit :");
                    int storage_unit = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nEntry Date :");
                    DateTime entry_date = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("\nExpiry Date :");
                    DateTime expiry_date = Convert.ToDateTime(Console.ReadLine());

                    Chemical_Info chemical_info = new Chemical_Info
                {
                    ChemicalId = id,
                    ChemicalName = name,
                    Storage_Unit = storage_unit,
                    EntryDate = entry_date,
                    ExpiryDate = expiry_date
                };
                chemical_store_Repo.Insert(chemical_info);
                Console.WriteLine("\nData Update successfully!!!\n");               
                DisplayOption();
                }
            }
            else if (index == 4)
            {
                Console.Write("\nEnter Chemical Id to Delete: ");
                int id = int.Parse(Console.ReadLine());
                var _chemical = chemical_store_Repo.GetById(id);

                if (_chemical == null)
                {                                     
                    Console.WriteLine("\nChemical Id is invalid!!!\n");                    
                    DisplayOption();
                }
                else
                {
                    chemical_store_Repo.Delete(id);
                    Console.WriteLine("\nData Deleted Successfully!!!\n");                    
                    DisplayOption();
                }
            }
        }
    }
}
