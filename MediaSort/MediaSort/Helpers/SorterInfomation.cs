using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSort.Helpers
{
    public class SorterInfomation
    {
        public SorterInfomation(string source, string destination)
        {
            SourcePath = source;
            DestinationPath = destination;
        }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
    }
}
