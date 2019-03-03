using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    public class Tuile
    {
        public List<Element> Elements = new List<Element>();

        public bool AccepteVisiteur()
        {
            return Elements.All(element => element.AccepteVisiteur());
        }

        public void Detruire(Element element)
        {
            Enlever(element);
            GameObject.Destroy(element.gameObject);
        }

        public void Explosion()
        {
            Elements.ForEach(element =>
            {
                element.Explosion();
            });
        }

        public void Ajouter(Element element)
        {
            Elements.Add(element);
            element.Tuile = this;
        }

        public void Enlever(Element element)
        {
            Elements.Remove(element);
            element.Tuile = null;
        }
    }
}