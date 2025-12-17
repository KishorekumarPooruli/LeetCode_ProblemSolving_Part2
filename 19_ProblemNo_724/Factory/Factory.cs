using _19_ProblemNo_724.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ProblemNo_724.Factory
{
    public class Factory : IFactory
    {
        public IPivotSolution CreatePivotSolutionProvider()
        {
            return new PivotSolution();
        }
    }
}
