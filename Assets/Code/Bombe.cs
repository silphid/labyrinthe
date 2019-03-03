using System;
using UniRx;

namespace Code
{
    public class Bombe : Element
    {
        public void Amorcer()
        {
            Observable.Timer(TimeSpan.FromSeconds(1.5)).Subscribe(x => Explose());
        }

        public void Explose()
        {
            
            Jeu.Explose(x, y);
        }
        
        public override bool AccepteVisiteur()
        {
            return true;
        }

        public override void Explosion()
        {
            Detruire();
        }
    }
}