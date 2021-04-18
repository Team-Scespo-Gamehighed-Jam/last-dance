using System.Collections.Generic;

namespace Player.Glider
{
    public static class GliderHelper
    {
        public static Dictionary<int, IGlider> GliderList = new Dictionary<int, IGlider>();

        public static void InitializeGlider(this IGlider glider)
        {
            GliderList.Add(glider.InstanceID, glider);
        }

        public static void DestroyGlider(this IGlider glider)
        {
            GliderList.Remove(glider.InstanceID);
        }
        
    }
    
    public interface IGlider
    {
        int InstanceID { get; }
        
        GliderContoller Controller { get; }
    }
}