using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LetsSolution
{
    class Sequences
    {

        public Direction StartingDirection { get; set; }

        public List<List<TurtleAction>> SequenceList { get; set; }



        public string SequencesPath { get; set; }

        public void GetSequences()
        {
            string[] lines = File.ReadAllLines(SequencesPath);
            SequenceList = new List<List<TurtleAction>>();
            foreach (string line in lines)
            {
                int i = 0;
                List<TurtleAction> Sequence = new List<TurtleAction>();
                foreach (var turtact in line.Split(','))
                {
                  
                   
                    var sequenceValue = line.Substring(((2 * i)), 1);
                    Sequence.Add(new TurtleAction { MoveOrRotate = sequenceValue.Trim() });
                    
                    i++;


                }
                SequenceList.Add(Sequence);
            }
          



        }
    }
}
