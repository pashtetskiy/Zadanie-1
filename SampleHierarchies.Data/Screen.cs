using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Screen base class with basic implementations.
    /// </summary>
    public class Screen : IScreen
    {
        public ConsoleColor ConsoleScreenColor { get; set; }
        public Screen() { ConsoleScreenColor = ConsoleColor.White; }
    }
}
