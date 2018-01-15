using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSolution
{
    class Program
    {
        static string settingspath = "C:\\Jobs17\\Lets\\Settings.txt";
        static string sequencespath = "C:\\Jobs17\\Lets\\Sequences.txt";
        static void Main(string[] args)
        {
            Settings initial_settings = new Settings();
            initial_settings.SettingsPath = settingspath;
            initial_settings.GetSettings();
            
            Sequences all_sequences= new Sequences();
            all_sequences.SequencesPath = sequencespath;
            all_sequences.GetSequences();
                                 
            Turtle Ninj = new Turtle { x_postion = initial_settings.StartingPoint_x,
                                       y_postion = initial_settings.StartingPoint_y,
                                       direction = initial_settings.StartingDirection };

            int sequenceCount = 0;
            
            foreach (var one_sequence in all_sequences.SequenceList)
            {
                sequenceCount++;
                //TurtleAction counter initialisation
                int turtleAction_count = 0;
                //Delegate below is better way to allow return/break from innerloop when mine hit than a GoTo
                Action performTurtleActions = delegate
                 {
                     foreach (var turtleAction in one_sequence)
                     {
                     
                       turtleAction_count++;
                         if (turtleAction.MoveOrRotate == "r")
                         {
                             Ninj.perform_rotate_action();
                            //debug Console.WriteLine("Direction after rotate action {0}", Ninj.direction);
                         }
                         else if (turtleAction.MoveOrRotate == "m")
                         {
                             Ninj.perform_move_action(initial_settings.BoardSize_x - 1, initial_settings.BoardSize_y - 1);

                             //Has Mine been hit 

                             if (Ninj.IsMineHit(initial_settings.MineList))
                                 {
                                 //Console.WriteLine("TurtleAction {0} ,Mine hit position {1},{2}", turtleAction_count, Ninj.x_postion, Ninj.y_postion);
                                 Console.WriteLine("Sequence {0} Mine hit!", sequenceCount);
                                 return;
                             }
                             }
                         //debug 
                         //Console.WriteLine("TurtleAction {0} ,Current position after Move Or Rotate action{1},{2}", turtleAction_count, Ninj.x_postion, Ninj.y_postion);
                     }
                 };

                performTurtleActions();

                if (!Ninj.MineHit)
                { 
                if (Ninj.EvaluateSuccess(initial_settings.ExitPoint_x, initial_settings.ExitPoint_y))
                {
                    Console.WriteLine("Sequence {0}: Success!", sequenceCount);
                }
                else
                {
                    Console.WriteLine("Sequence {0}: Still in  Danger!", sequenceCount);
                }
                }
            }
            Console.ReadKey();
        }
        }
    
    }

