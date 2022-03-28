using System;
using System.Collections.Generic;

namespace Registreren
{
    public class Film
    {
		public int Id { get; set; }
		public string Titel { get; set; }
		public int Jaar { get; set; }
		public List<string> Taal { get; set; }
		public int Looptijd { get; set; }
		public List<string> Genre { get; set; }
		public string Directeur { get; set; }
		public string Acteurs { get; set; }
		public string Plot { get; set; }

		public Film(int id, string title, int jaar, List<string> taal, int looptijd, List<string> genre, string directeur, string acteurs, string plot) 
        {
			this.Id = id;
			this.Titel = title;
			this.Jaar = jaar;
			this.Taal = taal;
			this.Looptijd = looptijd;
			this.Genre = genre;
			this.Directeur = directeur;
			this.Acteurs = acteurs;
			this.Plot = plot;
        }

		public override string ToString()
		{
			string talen = "";
			string genres = "";

			if (Taal.Count > 1)
            {
				for (int t = 0; t < Taal.Count; t++)
				{
					if (t == Taal.Count - 1)
					{
						talen += Taal[t];
					} else {
						talen += Taal[t] + ", ";
					}
				}
            } else
            {
				talen += Taal[0];
            }

			if (Genre.Count > 1)
			{
				for (int g = 0; g < Genre.Count; g++)
				{
					if (g == Genre.Count - 1)
					{
						genres += Genre[g];
					} else
                    {
						genres += Genre[g] + ", ";
					}
				}
			}
			else
			{
				genres += Genre[0];
			}

			return String.Format(
				"  Titel: {0}\n" +
				"  Jaar: {1}\n" +
				"  Taal: {2}\n" +
				"  Looptijd: {3}\n" +
				"  Genre: {4}",
				Titel, Jaar, talen, Looptijd, genres
			);
		}
	}
}
