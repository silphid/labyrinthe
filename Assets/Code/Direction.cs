using UnityEngine;

namespace Code
{
    public class Direction
    {
        public static readonly Direction Haut = new Direction(0, "Haut", 0, 1, 0f);
        public static readonly Direction Droite = new Direction(1, "Droite", 1, 0, 90f);
        public static readonly Direction Bas = new Direction(2, "Bas", 0, -1, 180f);
        public static readonly Direction Gauche = new Direction(3, "Gauche", -1, 0, 270f);
        public static readonly Direction Aucune = new Direction(4, "Aucune", 0, 0, 0f);

        public static Direction[] Toutes = { Haut, Droite, Bas, Gauche };

        public int Index { get; private set; }
        public string Nom { get; private set; }
        public Vector3 Increment { get; private set; }
        public Vector3Int IncrementInt { get; private set; }
        public float Angle { get; private set; }

        public Direction Horaire { get { return Toutes[(Index + 1) % 4]; } }
        public Direction AntiHoraire { get { return Toutes[(Index + 3) % 4]; } }
        public Direction Opposée { get { return Toutes[(Index + 2) % 4]; } }

        public Direction(int index, string nom, int offsetX, int offsetY, float angle)
        {
            Index = index;
            Nom = nom;
            Increment = new Vector3(offsetX, offsetY, 0);
            IncrementInt = new Vector3Int(offsetX, offsetY, 0);
            Angle = angle;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}