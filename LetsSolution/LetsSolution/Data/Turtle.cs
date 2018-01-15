using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSolution
{
    class Turtle
    {
        private Boolean _mineHit;

        //  public Boolean MineHit {get{ return _mineHit; } set { _mineHit = value; }}
        public Boolean MineHit { get { return _mineHit; } }

        public int x_postion { get; set; }
        public int y_postion { get; set; }

        public Direction direction { get; set; }

        public void perform_rotate_action()
        {

            if (this.direction == Direction.West)
            { this.direction = Direction.North; }
            else
            { this.direction++; }



        }

        public void perform_move_action(int x_max, int y_max)
        {

            if (this.direction == Direction.North)
            {
                if (this.y_postion != 0)
                {
                    this.y_postion = this.y_postion - 1;
                }


            }


            if (this.direction == Direction.South)
            {
                if (this.y_postion != y_max)
                {
                    this.y_postion = this.y_postion + 1;
                }


            }


            if (this.direction == Direction.West)
            {
                if (this.x_postion != 0)
                {
                    this.x_postion = this.x_postion - 1;
                }


            }

            if (this.direction == Direction.East)
            {
                if (this.x_postion != x_max)
                {
                    this.x_postion = this.x_postion + 1;
                }



            }


        }

        public Boolean IsMineHit(List<Mine> mineList) {
          

            //Has Mine been hit 
            foreach (var m in mineList)
            {
                if (m.x_postion == this.x_postion && m.y_postion == this.y_postion)
                {
                    
                    _mineHit = true;
                    return true;
                }
                
            }
            _mineHit = false;
                   return false;

        }


        public bool EvaluateSuccess(int exitX, int exitY)
        {
            if (this.x_postion == exitX && this.y_postion == exitY)
            {
                return true;
                
            }
            else
            {   return false;
                 }

        }





    }
}