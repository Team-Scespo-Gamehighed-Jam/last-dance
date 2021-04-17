using System.Collections.Generic;

namespace Player.Rocket
{
    public static class RocketHelper
    {
        public static Dictionary<int, IRocket> RocketList = new Dictionary<int, IRocket>();

        public static void InitializeRocket(this IRocket rocket)
        {
            RocketList.Add(rocket.InstanceID, rocket);
        }

        public static void DestroyRocket(this IRocket rocket)
        {
            RocketList.Remove(rocket.InstanceID);
        }
        
    }
    
    public interface IRocket
    {
        int InstanceID { get; }
    }
}