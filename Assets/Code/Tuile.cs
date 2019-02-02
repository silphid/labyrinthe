using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    public class Tuile
    {
        public List<Element> Elements = new List<Element>();

        public bool PeuxTuÊtreOccupée()
        {
            return Elements.Count == 1 && Elements[0] is Plancher;
        }

        public void DetruitTout()
        {
            Elements.ToList().ForEach(element =>
            {
                if (!(element is Plancher))
                {
                    Elements.Remove(element);
                    GameObject.Destroy(element.gameObject);
                }
            });
        }
    }
}