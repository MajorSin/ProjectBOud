using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections.Generic;

namespace MyApp {
	public class Program {
		public class filmOverzicht {
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
		public class MyObject {
			public int OrderId { get; set; }
		}
		static void Main() {
			//LAAD JSON IN
			var json = File.ReadAllText("../../../films.json", Encoding.GetEncoding("iso-8859-1"));
			var films = JsonConvert.DeserializeObject<List<filmOverzicht>>(json);
			//INTRO BERICHT
			Console.WriteLine("----------------------------\nBIOSCOOP HR - FILMS OVERZICHT\n----------------------------\nHier kunt u een overzicht van alle films vinden.\n");
			//VRAAG VOOR FILTER: TITEL
			Console.WriteLine("Wilt op zoek naar een specifieke titel? Typ 1 van de volgende nummer in:\n1. Ja\n2. Nee");
			//TITEL KEUZE
			var keuzeTitel = Console.ReadLine();
			while (keuzeTitel != "1" && keuzeTitel != "2") {
				Console.WriteLine("Kies uit 1 of 2.");
				keuzeTitel = Console.ReadLine();
			}
			if (keuzeTitel == "1") {
				Console.WriteLine("Welk titel wil u kiezen?");
				var titelFilter = Console.ReadLine();
				while (string.IsNullOrWhiteSpace(titelFilter)) {
					Console.WriteLine("Kies uit een titel.");
					titelFilter = Console.ReadLine();
				}
				//FILTER DE JSON
				if (films != null) {
					int i = 0;
					while (i < films.Count) {
						if (films[i].Titel?.ToLower() != titelFilter.ToLower()) {
							films.RemoveAt(i);
						} else { i++; }
					}
				}
			}
			Console.Clear();
			//LAAT FILM OVERZICHT ZIEN
			if (films != null) {
				Console.WriteLine("Uw zoekopdracht heeft de volgende resultat(en) opgeleverd:\n");
				foreach (var film in films) {
					//KRIJG DE TALEN
					int taalLength = film?.Taal?.Count ?? 0;
					string talen = "";
					for (int i = 0; i < taalLength; i++) {
						talen += film?.Taal?[i];
						//VOEG DE JUISTE TEKEN TOE
						if (taalLength > 1) {
							if ((taalLength - 2) == i) {
								talen += " & ";
							} else if ((taalLength - 1) != i) {
								talen += ", ";
							}
						}
					}
					string taalString = taalLength == 1 ? "Taal" : "Talen";
					//KRIJG DE GENRE(S)
					int genreLength = film?.Genre?.Count ?? 0;
					string genres = "";
					for (int i = 0; i < genreLength; i++) {
						genres += film?.Genre?[i];
						//VOEG DE JUISTE TEKEN TOE
						if (genreLength > 1) {
							if ((genreLength - 2) == i) {
								genres += " & ";
							} else if ((genreLength - 1) != i) {
								genres += ", ";
							}
						}
					}
					string genreString = genreLength == 1 ? "Genre" : "Genres";
					//LAAT ALLES BOVEN DE 1 UUR ZIEN
					if (film?.Looptijd > 60) {
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
					else {
						//PRINT DE GEGEVENS
						Console.WriteLine($"- {film?.Titel} ({film?.Jaar}), \nPlot: {film?.Plot}\nLooptijd: {film?.Looptijd} minuten \n");
					}
				}
			}
		}
	}
}