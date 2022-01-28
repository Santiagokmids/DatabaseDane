using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Dane
{
    internal class Municipality
    {

        public string Departament_Code { get; set; }
        public string Municipality_Code { get; set; }
        public string Departament_Name { get; set; }
        public string Municipality_Name { get; set; }
        public string Municipality_Type { get; set; }

        public Municipality(string Departament_Code, string Municipality_Code, string Departament_Name, string Municipality_Name, string Municipality_Type)
        { 
            this.Departament_Code = Departament_Code; 
            this.Municipality_Code = Municipality_Code;
            this.Departament_Name = Departament_Name;
            this.Municipality_Name = Municipality_Name;
            this.Municipality_Type = Municipality_Type;
        }
    }
}
