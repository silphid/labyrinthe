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

		private readonly string[] tableau =
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
				tuile = CréerPlancher(x, y);
				objet = Instantiate(Hero, transform);
				var hero = objet.GetComponent<Hero>();
				tuile.Element = hero;
				hero.Jeu = this;
			}
			else
			{
				throw new Exception("Le charactère est invalide: " + charactère);
			}

			tuiles[x, y] = tuile;
			RéglerPosition(objet, x, y);
		}

		private void RéglerPosition(GameObject objet, int x, int y)
		{
			objet.transform.position = new Vector3(x, -y, 0);
		}

		private Plancher CréerPlancher(int x, int y)
		{
			var objet = Instantiate(Plancher, transform);
			var plancher = objet.GetComponent<Plancher>();
			RéglerPosition(objet, x, y);
			return plancher;
		}

		public bool PeutOccuperTuile(int x, int y)
		{
			if (x < 0 || x >= Largeur || y < 0 || y >= Hauteur)
				return false;

			var tuile = tuiles[x, y];
			if (tuile.Element != null)
				return false;

			if (tuile is Mur)
				return false;

			return true;
		}

		public void DéplacerÉlément(Element element, int x1, int y1, int x2, int y2)
		{
			var tuile1 = tuiles[x1, y1];
			var tuile2 = tuiles[x2, y2];

			tuile1.Element = null;
			tuile2.Element = element;
		}
	}
}