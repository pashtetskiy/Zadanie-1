using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data
{
    /// <summary>
    /// Interface describing an Screen.
    /// </summary>
    public interface IScreen
    {
       public ConsoleColor ConsoleScreenColor { get; set; }
    }
}
