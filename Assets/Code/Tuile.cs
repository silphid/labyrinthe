using System.Collections.Generic;

namespace Code
{
    public class Tuile
    {
        public List<Element> Elements = new List<Element>();

        public bool PeuxTuÊtreOccupée()
        {
            return Elements.Count == 1 && Elements[0] is Plancher;
        }
    }
}