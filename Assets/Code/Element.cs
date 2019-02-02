using UnityEngine;

namespace Code
{
    public class Element : MonoBehaviour
    {
        public Jeu Jeu;
        public int x;
        public int y;
   
        public void Déplacer(int x1, int y1, int x2, int y2)
        {
            var ancienneTuile = Jeu.tuiles[x1, y1];
            var nouvelleTuile = Jeu.tuiles[x2, y2];

            ancienneTuile.Elements.Remove(this);
            nouvelleTuile.Elements.Add(this);
        }
    }
}