using System;
using UniRx;

namespace Code
{
    public class Bombe : Element
    {
        public void DémarrerCompteÀRebours()
        {
            Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(x => Explose());
        }

        public void Explose()
        {
            Jeu.DetruitElementsSurTuile(x, y);
        }
    }
}