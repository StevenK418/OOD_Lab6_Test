using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Lab6
{

    /// <summary>
    /// Partial class to extend Author class functionality
    /// </summary>
    public partial class Author
    {
        /// <summary>
        /// Overrides the ToString Method of the parent class. 
        /// </summary>
        /// <returns>Returns the name property value as a string</returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
