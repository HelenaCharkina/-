using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Upgrader
    {
        public static string Upgrade(string variable)
        {
            if (variable.Contains('=')) variable = variable.Substring(0, variable.IndexOf('='));
            if (variable.Contains(';')) variable = variable.Substring(0, variable.IndexOf(';'));
            if (variable.Contains('(')) variable = variable.Substring(0, variable.IndexOf('('));
            if (variable.Contains('{')) variable = variable.Substring(0, variable.IndexOf('{'));
            if (variable.Contains('[')) variable = variable.Substring(0, variable.IndexOf('['));
            return variable;
        }
    }
}
