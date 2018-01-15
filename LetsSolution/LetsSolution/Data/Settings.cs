using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LetsSolution
{


    public class Settings
    {


        private string _settingsPath;

        public string SettingsPath { get; set; }

        public int BoardSize_x { get; set; }

        public int BoardSize_y { get; set; }


        public int StartingPoint_x { get; set; }
        public int StartingPoint_y { get; set; }

        public int ExitPoint_x { get; set; }
        public int ExitPoint_y { get; set; }

        public Direction StartingDirection { get; set; }

        public List<Mine> MineList { get; set; }




        public void GetSettings()
        {
            string[] lines = File.ReadAllLines(SettingsPath);

            // Get the position of the = sign within each line
            var pairs = lines.Select(l => new { Line = l, Pos = l.IndexOf("=") });

            // Build a dictionary of key/value pairs by splitting the string at the = sign
            var dictionary = pairs.ToDictionary(p => p.Line.Substring(0, p.Pos), p => p.Line.Substring(p.Pos + 1));

            // Now you can retrieve values by key:
            var bsx = dictionary["board_size_x"];
            BoardSize_x = int.Parse(bsx);

            var bsy = dictionary["board_size_y"];
            BoardSize_y = int.Parse(bsy);

            var spx= dictionary["starting_point_x"];
            StartingPoint_x= int.Parse(spx);

            var spy = dictionary["starting_point_y"];
            StartingPoint_y = int.Parse(spy);

            var epx = dictionary["exit_point_x"];
            ExitPoint_x = int.Parse(epx);

            var epy = dictionary["exit_point_y"];
            ExitPoint_y = int.Parse(epy);


            var sd = dictionary["starting_direction"];
            //Convert sd string to enum
             StartingDirection   = (Direction)Enum.Parse(typeof(Direction), sd, true);

            var mineLineString = dictionary["mines"].Trim();
               MineList= LayMines(mineLineString);


        }


        private List<Mine> LayMines(string mineLine)
        {
            int j = 0;
            MineList = new List<Mine>();
            try
            {
                foreach (var coord in mineLine.Split(';')   )
                {

                   var x = mineLine.Substring((1 + (6 * j)), 1);
                   var y = mineLine.Substring((3 + (6 * j)), 1);
                  
              Mine AnotherMine = new Mine() { x_postion = int.Parse(x), y_postion = int.Parse(y) };

                  MineList.Add(AnotherMine);
                   j++;
                    
                    
                }
            }
            catch { throw new Exception("Check Format of Mine Values"); }

            return MineList;







        }






    }
}
