using System;
using UnityEngine;

namespace Code
{
	public class Jeu : MonoBehaviour
	{
		public GameObject Hero;
		public GameObject Mur;
		public GameObject Plancher;
		public GameObject Bombe;
		public GameObject Boite;
		public GameObject Explosion;

		private const int Largeur = 13;
		private const int Hauteur = 6;

		private readonly string[] tableau =
		{
			"XXXXXXXXXXXXX",
			"XXXXXXBBXXXXX",
			"XXO  X  XXXXX",
			"XB  BB  BBXXX",
			"X    XBBXXXXX",
			"XXXXXXXXXXXXX"
		};

		public Tuile[,] tuiles;

		void Start()
		{
			tuiles = new Tuile[Largeur, Hauteur];

			int y = 0;
			foreach (var ligne in tableau)
			{
				int x = 0;
				foreach (var charactère in ligne)
				{
					CréeObjet(charactère, x, y);
					x++;
				}

				y++;
			}
		}

		private void CréeObjet(char charactère, int x, int y)
		{
			var tuile = new Tuile();

			if (charactère == 'X')
			{
				Créer<Mur>(Mur, tuile, x, y);
			}
			else if (charactère == ' ')
			{
				Créer<Plancher>(Plancher, tuile, x, y);
			}
			else if (charactère == 'O')
			{
				Créer<Plancher>(Plancher, tuile, x, y);
				Créer<Hero>(Hero, tuile, x, y);
			}
			else if (charactère == 'B')
			{
				Créer<Plancher>(Plancher, tuile, x, y);
				Créer<Boite>(Boite, tuile, x, y);
			}
			else
			{
				throw new Exception("Le charactère est invalide: " + charactère);
			}

			tuiles[x, y] = tuile;
		}

		private T Créer<T>(GameObject prefab, Tuile tuile, int x, int y) where T : Element
		{
			var objet = Instantiate(prefab, transform);
			var t = objet.GetComponent<T>();
			t.Jeu = this;
			t.x = x;
			t.y = y;
			RéglerPosition(objet, x, y);
			tuile.Ajouter(t);
			return t;
		}

		private void RéglerPosition(GameObject objet, int x, int y)
		{
			objet.transform.position = new Vector3(x, -y, 0);
		}

		public bool PeutOccuperTuile(int x, int y)
		{
			if (x < 0 || x >= Largeur || y < 0 || y >= Hauteur)
				return false;

			var tuile = tuiles[x, y];
			return tuile.AccepteVisiteur();
		}

		public void PlacerBombe(int x, int y)
		{
			var tuile = tuiles[x, y];
			var bombe = Créer<Bombe>(Bombe, tuile, x, y);
			bombe.Amorcer();
		}

		public void Explose(int x, int y)
		{
			var objet = Instantiate(Explosion, transform);
			RéglerPosition(objet, x, y);

			for (int i = x - 1; i <= x + 1; i++)
			{
				for (int j = y - 1; j <= y + 1; j++)
				{
					if (i >= 0 && j >= 0 && i < Largeur && j < Hauteur)
					{
						var tuile = tuiles[i, j];
						tuile.Explosion();
					}
				}
			}
		}
	}
}