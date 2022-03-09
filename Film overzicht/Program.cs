using Newtonsoft.Json;
using System.Text;

namespace MyApp
{
	public class Program
	{
		public class filmOverzicht
		{
			public int? Id { get; set; }
			public string? Titel { get; set; }
			public int? Jaar { get; set; }
			public List<string>? Taal { get; set; }
			public int? Looptijd { get; set; }
			public List<string>? Genre { get; set; }
			public string? Directeur { get; set; }
			public string? Acteurs { get; set; }
			public string? Plot { get; set; }
		}
		public class MyObject
		{
			public int OrderId { get; set; }
		}
		static void Main()
		{
			//LAAD JSON IN
			var json = File.ReadAllText("../../../films.json", Encoding.GetEncoding("utf-8"));
			var films = JsonConvert.DeserializeObject<List<filmOverzicht>>(json);
			//INTRO BERICHT
			Console.WriteLine("----------------------------\nBIOSCOOP HR - FILMS OVERZICHT\n----------------------------\nHier kunt u een overzicht van alle films vinden.\n");
			//VRAAG VOOR FILTER: TITEL
			Console.WriteLine("Wilt op zoek naar een specifieke titel? Typ 1 van de volgende nummer in:\n1. Ja\n2. Nee");
			//TITEL KEUZE
			var keuzeTitel = Console.ReadLine();
			while (keuzeTitel != "1" && keuzeTitel != "2")
			{
				Console.WriteLine("\n");
				Console.WriteLine("Kies uit 1 of 2.");
				keuzeTitel = Console.ReadLine();
			}
			if (keuzeTitel == "1")
			{
				Console.WriteLine("\n");
				Console.WriteLine("Welk titel wil u kiezen?");
				var titelFilter = Console.ReadLine();
				while (string.IsNullOrWhiteSpace(titelFilter))
				{
					Console.WriteLine("Kies uit een titel.");
					titelFilter = Console.ReadLine();
				}
				//FILTER DE JSON
				if (films != null)
				{
					int i = 0;
					while (i < films.Count)
					{
						string? title = films[i].Titel;
						string? titleLower = title?.ToLower();
						if (titleLower != null)
						{
							if (!titleLower.Contains(titelFilter.ToLower()))
							{
								films.RemoveAt(i);
							} else { i++; }
						}
					}
				}
				Console.Clear();
			} else
			{
				Console.Clear();
				//VRAAG VOOR FILTER: GENRES
				Console.WriteLine("Wilt op zoek naar een specifieke genres? Typ 1 van de volgende nummer in:\n1. Ja\n2. Nee");
				var keuzeGenre = Console.ReadLine();
				while (keuzeGenre != "1" && keuzeGenre != "2")
				{
					Console.WriteLine("Kies uit 1 of 2.");
					keuzeGenre = Console.ReadLine();
				}
				Console.WriteLine("\n");
				if (keuzeGenre == "1")
				{
					//LIJST EN ARRAY OM TE CHECKEN
					List<string> genres = new();
					string[] genreKeuzeUit = { "war", "drama" };
					string GenreKeuze = "";
					if (genreKeuzeUit.Length > 1)
					{
						for (int i = 0; i < genreKeuzeUit.Length; i++)
						{
							if ((genreKeuzeUit.Length - 1) == i)
							{
								GenreKeuze += $"{genreKeuzeUit[i]}";
							} else if ((genreKeuzeUit.Length - 2) == i)
							{
								GenreKeuze += $"{genreKeuzeUit[i]} & ";
							} else
							{
								GenreKeuze += $"{genreKeuzeUit[i]}, ";
							}
						}
					} else
					{
						GenreKeuze = genreKeuzeUit[0];
					}
					string keuzesofKeuze = genreKeuzeUit.Length == 1 ? "keuze is" : "keuzes zijn";
					//string uurString = uur == 1 ? "uur" : "uren";
					Console.WriteLine($"De {keuzesofKeuze}: {GenreKeuze}. U kunt telkens een genre kiezen, de keuze stopt tot u een lege input geeft");
					var genreKeuze = "nothing";
					while (!string.IsNullOrWhiteSpace(genreKeuze))
					{
						genreKeuze = Console.ReadLine();
						//STOP BIJ LEGE INPUT
						if (string.IsNullOrWhiteSpace(genreKeuze))
						{
							break;
						} else if (genreKeuzeUit.Contains(genreKeuze.ToLower()))
						{
							if (genres != null)
							{
								//GENRE IS EERDER NIET GEKOZEN: VOEG TOE AAN LIST
								if (!genres.Contains(genreKeuze.ToLower()))
								{
									genres?.Add(genreKeuze.ToLower());
									Console.WriteLine($"{genreKeuze.ToLower()} is toegevoegd!");
								} else { Console.WriteLine($"{genreKeuze.ToLower()} heeft u al eerder gekozen!"); }
							}
						} else
						{
							Console.WriteLine("Keuze niet geldig");
						}
						Console.WriteLine("\n");
					}
					//KIES ALLE FILMS VAN DE GENRES
					if (genres?.Count > 0)
					{
						int i = 0;
						while (i < films?.Count)
						{
							var filmsCheckList = films[i].Genre;
							if (filmsCheckList != null)
							{
								//GENRE GEVONDEN
								if (filmsCheckList.Any(x => genres.Any(y => y == x))) { i++; } else
								//GENRE ZIT ER NIET IN
								{
									films.RemoveAt(i);
								}
							}
						}
					}
				}
				Console.Clear();
			}
			//LAAT FILM OVERZICHT ZIEN
			if (films != null)
			{
				Console.WriteLine("Uw zoekopdracht heeft de volgende resultat(en) opgeleverd:\n");
				foreach (var film in films)
				{
					//KRIJG DE TALEN
					int taalLength = film?.Taal?.Count ?? 0;
					string talen = "";
					for (int i = 0; i < taalLength; i++)
					{
						talen += film?.Taal?[i];
						//VOEG DE JUISTE TEKEN TOE
						if (taalLength > 1)
						{
							if ((taalLength - 2) == i)
							{
								talen += " & ";
							} else if ((taalLength - 1) != i)
							{
								talen += ", ";
							}
						}
					}
					string taalString = taalLength == 1 ? "Taal" : "Talen";
					//KRIJG DE GENRE(S)
					int genreLength = film?.Genre?.Count ?? 0;
					string genres = "";
					for (int i = 0; i < genreLength; i++)
					{
						genres += film?.Genre?[i];
						//VOEG DE JUISTE TEKEN TOE
						if (genreLength > 1)
						{
							if ((genreLength - 2) == i)
							{
								genres += " & ";
							} else if ((genreLength - 1) != i)
							{
								genres += ", ";
							}
						}
					}
					string genreString = genreLength == 1 ? "Genre" : "Genres";
					//LAAT ALLES BOVEN DE 1 UUR ZIEN
					if (film?.Looptijd > 60)
					{
						int? uur = film.Looptijd / 60;
						int? minuten = film.Looptijd - (uur * 60);
						string uurString = uur == 1 ? "uur" : "uren";
						string minuutString = minuten == 1 ? "minuut" : "minuten";
						//PRINT DE GEGEVENS
						Console.WriteLine($"- {film.Titel} ({film.Jaar}) \n" +
							$"  - {taalString} : {talen} \n" +
							$"  - Looptijd: {uur} {uurString} en {minuten} {minuutString}.\n" +
							$"  - {genreString} : {genres}\n" +
							$"  - Directeur(s) : {film.Directeur}\n" +
							$"  - Acteurs : {film.Acteurs}\n" +
							$"  - Plot: {film.Plot}\n");
					}
					//LAAT ALLES ONDER DE 1 UUR ZIEN
					else
					{
						//PRINT DE GEGEVENS
						Console.WriteLine($"- {film?.Titel} ({film?.Jaar}), \n" +
							$"  - {taalString} : {talen} \n" +
							$"  - Looptijd: {film?.Looptijd}.\n" +
							$"  - {genreString} : {genres}\n" +
							$"  - Directeur(s) : {film?.Directeur}\n" +
							$"  - Acteurs : {film?.Acteurs}\n" +
							$"  - Plot: {film?.Plot}\n");
					}
				}
			}
		}
	}
}