using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts.Models
{
    // This model holds the arguments that a user can pass in when running the program.
    class ArgumentsModel
    {
        public int Number { get; set; }
        public bool NumberProvided { get; set; }
        public bool RandomNumber { get; set; }
        public bool MathFact { get; set; }
        public bool TriviaFact { get; set; }
    }
}
