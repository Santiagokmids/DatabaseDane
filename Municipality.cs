using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Dane
{
    internal class Municipality
    {
        private string departament_Code;
        private string municipality_Code;
        private string departament_Name;
        private string municipality_Name;
        private string municipality_Type;

        public Municipality(string departament_Code, string municipality_Code, string departament_Name, string municipality_Name, string municipality_Type)
        { 
            this.departament_Code = departament_Code; 
            this.municipality_Code = municipality_Code;
            this.departament_Name = departament_Name;
            this.municipality_Name = municipality_Name;
            this.municipality_Type = municipality_Type;
        }

        public string Get_Departament_Code()
        { 
            return departament_Code;
        }

        public string Get_Municipality_Code()
        {
            return municipality_Code;
        }
        public string Get_Departament_Name()
        {
            return departament_Name;
        }
        public string Get_Municipality_Name()
        {
            return municipality_Name;
        }
        public string Get_Municipality_Type()
        {
            return municipality_Type;
        }
    }
}
