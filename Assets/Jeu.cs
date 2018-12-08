using System;
using UnityEngine;

public class Jeu : MonoBehaviour
{
	public GameObject Hero;
	public GameObject Mur;
	public GameObject Plancher;

	private const int Largeur = 13;
	private const int Hauteur = 6 ;

	private string[] tableau =
	{   "XXXXXXXXXXXXX",
		"XXXXXX  XXXXX",
		"XXO  X  XXXXX",
		"X        XXXX",
		"X    X  XXXXX",
		"XXXXXXXXXXXXX"
	};

	private Element[,] elements;
	
	void Start ()
	{
		elements = new Element[Largeur, Hauteur];
		
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
		
		if (charactère == 'X')
			objet = Instantiate(Mur, transform);
		else if (charactère == ' ')
			objet = Instantiate(Plancher, transform);
		else if (charactère == 'O')
		{
			objet = Instantiate(Hero, transform);
			Hero hero = objet.GetComponent<Hero>();
			hero.Jeu = this;
			CréeObjet(' ', x, y);			
		}
		else
		{
			throw new Exception("Le charactère est invalide: " + charactère);
		}
		
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
