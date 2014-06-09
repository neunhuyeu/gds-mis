using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS_Service.Structs
{
    /// <summary>
    /// structure to store medicine informations
    /// </summary>
    public struct Medicine
    {
        public string name { get; set; }
        public string description { get; set; }
        public int strength_mg { get; set; }

        public List<string> classification { get; private set; }
        public List<string> side_effects { get; private set; }

        public void set_side_effects(string input_string)
        {
            side_effects = input_string.Split('|').ToList();
        }
        public void set_classifications(string input_string)
        {
            classification = input_string.Split('|').ToList();
        }
    }
}
