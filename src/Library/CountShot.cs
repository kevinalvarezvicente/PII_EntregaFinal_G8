using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase tendria que devolver la cantidad de tiros
    /// </summary>
    public class CountShot
    {

        public int shots { get;  set;}

        public int water { get;  set;}

        public Game game;
        public int TotalShotWater(){
            if(game.PegoElAgua){
                return water;
            }
            return 1;
        }   

        public int TotalShotships(){
            if(game.PegoElBarco){
                return water;
            }
        return 1;
        }
    }   
}