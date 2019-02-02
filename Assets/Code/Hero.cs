using UnityEngine;

namespace Code
{
	public class Hero : Element
	{
		public const float TempsEntreTouches = 0.25f;

		private int x = 2;
		private int y = 2;
		private float tempsDernièreTouche;

		void Update()
		{
			float tempsÉcouléDepuisDernièreTouche = Time.time - tempsDernièreTouche;
			if (Input.GetKey(KeyCode.RightArrow) && tempsÉcouléDepuisDernièreTouche > TempsEntreTouches)
			{
				if (Jeu.PeutOccuperTuile(x + 1, y))
				{
					Déplacer(x, y, x + 1, y);
					x++;
					MettreÀJourLaPosition();
					tempsDernièreTouche = Time.time;
				}
			}
			else if (Input.GetKey(KeyCode.LeftArrow) && tempsÉcouléDepuisDernièreTouche > TempsEntreTouches)
			{
				if (Jeu.PeutOccuperTuile(x - 1, y))
				{
					Déplacer(x, y, x - 1, y);
					x--;
					MettreÀJourLaPosition();
					tempsDernièreTouche = Time.time;
				}
			}
			else if (Input.GetKey(KeyCode.UpArrow) && tempsÉcouléDepuisDernièreTouche > TempsEntreTouches)
			{
				if (Jeu.PeutOccuperTuile(x, y - 1))
				{
					Déplacer(x, y, x, y - 1);
					y--;
					MettreÀJourLaPosition();
					tempsDernièreTouche = Time.time;
				}
			}
			else if (Input.GetKey(KeyCode.DownArrow) && tempsÉcouléDepuisDernièreTouche > TempsEntreTouches)
			{
				if (Jeu.PeutOccuperTuile(x, y + 1))
				{
					Déplacer(x, y, x, y + 1);
					y++;
					MettreÀJourLaPosition();
					tempsDernièreTouche = Time.time;
				}
			}
			else if (Input.GetKey(KeyCode.Space) && tempsÉcouléDepuisDernièreTouche > TempsEntreTouches)
			{
				Jeu.PlacerBombe(x, y);
			}
		}

		void MettreÀJourLaPosition()
		{
			transform.position = new Vector3(x, -y, 0);
		}
	}
}