using System;
using UnityEngine;

namespace Code
{
	public class Jeu : MonoBehaviour
	{
		public GameObject Hero;
		public GameObject Mur;
		public GameObject Plancher;

		private const int Largeur = 13;
		private const int Hauteur = 6;

		private string[] tableau =
		{
			"XXXXXXXXXXXXX",
			"XXXXXX  XXXXX",
			"XXO  X  XXXXX",
			"X        XXXX",
			"X    X  XXXXX",
			"XXXXXXXXXXXXX"
		};

		private Tuile[,] tuiles;

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
			GameObject objet;
			Tuile tuile;
			
			if (charactère == 'X')
			{
				objet = Instantiate(Mur, transform);
				tuile = objet.GetComponent<Mur>();
			}
			else if (charactère == ' ')
			{
				objet = Instantiate(Plancher, transform);
				tuile = objet.GetComponent<Plancher>();
			}
			else if (charactère == 'O')
			{
				objet = Instantiate(Plancher, transform);
				tuile = objet.GetComponent<Plancher>();
				Hero hero = objet.GetComponent<Hero>();
				tuile.Element = hero;
				hero.Jeu = this;
			}
			else
			{
				throw new Exception("Le charactère est invalide: " + charactère);
			}

			tuiles[x, y] = tuile;
			objet.transform.position = new Vector3(x, -y, 0);
		}

		public bool PeutOccuperTuile(int x, int y)
		{
			if (x < 0 || x >= Largeur || y < 0 || y >= Hauteur)
				return false;

			char charactère = tableau[y][x];
			if (charactère == 'X')
				return false;

			return true;
		}
	}
}