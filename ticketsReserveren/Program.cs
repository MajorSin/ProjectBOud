using Newtonsoft.Json;
using System.Text;

namespace ticketsReserveren
{
	//DE CLASS OM FILMS OP TE ZOEKEN
	class zoekFilms
	{
		public List<filmOverzicht>? films;
		//LEES JSON
		public void readJson()
		{
			var json = File.ReadAllText("../../../films.json", Encoding.GetEncoding("utf-8"));
			this.films = JsonConvert.DeserializeObject<List<filmOverzicht>>(json);
		}
		//WAARDEN VAN DE JSON
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
		//DE TITEL FILTER
		public void titelZoeken()
		{
			Console.WriteLine("Wilt op zoek naar een specifieke titel? Typ 1 van de volgende nummer in:\n1. Ja\n2. Nee");
			var keuzeTitel = Console.ReadLine();
			while (keuzeTitel != "1" && keuzeTitel != "2")
			{
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
			}
			Console.Clear();
		}
		//DE GENRE FILTER
		public void genreZoeken()
		{
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
				List<string> genresGekozen = new();
				string[] genreKeuzeUit = { "actie", "animatie", "avontuur", "documentaire", "drama", "familie", "fantasy", "historisch", "horror", "komedie", "misdaad", "mystery", "oorlog", "romantisch", "sci-fi" };
				string GenreOpties = "";
				//PRINT DE OPTIES
				for (int i = 0; i < genreKeuzeUit.Length; i++)
				{
					GenreOpties += "- " + genreKeuzeUit[i] + "\n";
				}
				string keuzesofKeuzeGenre = genreKeuzeUit.Length == 1 ? "keuze is" : "keuzes zijn";
				Console.WriteLine($"De {keuzesofKeuzeGenre}:\n{GenreOpties}U kunt telkens een genre kiezen, de keuze stopt tot u een lege input geeft of alles is gekozen");
				//FILTER
				var genreKeuze = "nothing";
				while (!string.IsNullOrWhiteSpace(genreKeuze))
				{
					genreKeuze = Console.ReadLine();
					//STOP BIJ LEGE INPUT OF ALLES IS GEKOZEN
					if (string.IsNullOrWhiteSpace(genreKeuze)) { break; }
					//JUIST GEKOZEN
					else if (genreKeuzeUit.Contains(genreKeuze.ToLower()))
					{
						if (genresGekozen != null)
						{
							//GENRE IS EERDER NIET GEKOZEN: VOEG TOE AAN LIST
							if (!genresGekozen.Contains(genreKeuze.ToLower()))
							{
								genresGekozen?.Add(genreKeuze.ToLower());
								Console.WriteLine($"{genreKeuze.ToLower()} is toegevoegd!");
							} else { Console.WriteLine($"{genreKeuze.ToLower()} heeft u al eerder gekozen!"); }
						}
					} else
					{
						Console.WriteLine("Keuze niet geldig");
					}
					Console.WriteLine("\n");
					//STOP ALS ALLES IS GEKOZEN
					if (genreKeuzeUit.Length == genresGekozen?.Count) { break; }
				}
				//KIES ALLE FILMS VAN DE GENRES
				if (genresGekozen?.Count > 0)
				{
					int i = 0;
					while (i < films?.Count)
					{
						var filmsCheckList = films[i].Genre;
						if (filmsCheckList != null)
						{
							//GENRE GEVONDEN
							if (filmsCheckList.Any(x => genresGekozen.Any(y => y == x))) { i++; } else
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
		//DE TAAL FILTER
		public void taalZoeken()
		{
			Console.WriteLine("Wilt u kiezen uit een taal?\n1: Ja\n2: Nee");
			var keuzeTaal = Console.ReadLine();
			while (keuzeTaal != "1" && keuzeTaal != "2")
			{
				Console.WriteLine("Kies uit 1 of 2.");
				keuzeTaal = Console.ReadLine();
			}
			Console.WriteLine("\n");
			if (keuzeTaal == "1")
			{
				//LIJST EN ARRAY OM TE CHECKEN
				List<string> taalGekozen = new();
				string[] taalKeuzeUit = { "Nederlands", "Engels", "Spaans", "Duits", "Japans" };
				string taalOpties = "";
				//PRINT DE OPTIES
				for (int i = 0; i < taalKeuzeUit.Length; i++)
				{
					taalOpties += "- " + taalKeuzeUit[i] + "\n";
				}
				string keuzesofKeuzeTaal = taalKeuzeUit.Length == 1 ? "keuze is" : "keuzes zijn";
				Console.WriteLine($"De {keuzesofKeuzeTaal}:\n{taalOpties}U kunt telkens een taal kiezen, de keuze stopt tot u een lege input geeft");
				//FILTER
				string? taalKeuze = "nothing";
				while (!string.IsNullOrWhiteSpace(taalKeuze))
				{
					taalKeuze = Console.ReadLine();
					if ((taalKeuze != null) && (!string.IsNullOrWhiteSpace(taalKeuze))) { taalKeuze = char.ToUpper(taalKeuze[0]) + taalKeuze[1..].ToLower(); }
					//STOP BIJ LEGE INPUT OF ALLES IS GEKOZEN
					if (string.IsNullOrWhiteSpace(taalKeuze)) { break; }
					//JUIST GEKOZEN
					else if (taalKeuzeUit.Contains(taalKeuze))
					{
						if (taalGekozen != null)
						{
							//GENRE IS EERDER NIET GEKOZEN: VOEG TOE AAN LIST
							if (!taalGekozen.Contains(taalKeuze))
							{
								taalGekozen?.Add(taalKeuze);
								Console.WriteLine($"{taalKeuze} is toegevoegd!");
							} else { Console.WriteLine($"{taalKeuze} heeft u al eerder gekozen!"); }
						}
					} else
					{
						Console.WriteLine("Keuze niet geldig");
					}
					Console.WriteLine("\n");
					//STOP ALS ALLES IS GEKOZEN
					if (taalKeuzeUit.Length == taalGekozen?.Count) { break; }
				}
				//KIES ALLE FILMS MET DE JUISTE TAAL
				if (taalGekozen?.Count > 0)
				{
					int i = 0;
					while (i < films?.Count)
					{
						var filmsCheckList = films[i].Taal;
						if (filmsCheckList != null)
						{
							//TAAL GEVONDEN
							if (filmsCheckList.Any(x => taalGekozen.Any(y => y == x))) { i++; } else
							//TAAL ZIT ER NIET IN
							{
								films.RemoveAt(i);
							}
						}
					}
				}
			}
			Console.Clear();
		}
		//ZOEKEN
		public List<filmOverzicht>? zoeken()
		{
			readJson();
			titelZoeken();
			genreZoeken();
			taalZoeken();
			if (films != null)
			{
				return films;
			} else
			{
				return null;
			}
		}
	}
	//KRIJG ALLE DRAAIENDE FILMS
	class getFilms
	{
		public List<zoekFilms.filmOverzicht>? films;
		public List<draaienFilms>? draaienFilmsList;
		public int? filmID;
		//CONSTRUCTER OM DE FILMS MET TOEGEPASTE FILTERS TE IMPORTEN
		public getFilms(List<zoekFilms.filmOverzicht> films)
		{
			this.films = films;
			this.filmID = 0;
		}
		public class draaienFilms
		{
			public int FilmID { get; set; }
			public List<string>? Datum { get; set; }
			public List<string>? Zaal { get; set; }
		}
		public void readJson()
		{
			var jsonFilmsDraaien = File.ReadAllText("../../../gedraaideFilms.json", Encoding.GetEncoding("utf-8"));
			this.draaienFilmsList = JsonConvert.DeserializeObject<List<draaienFilms>>(jsonFilmsDraaien);
		}
		//LAAT ALLE FILMS ZIEN DIE BINNENKORT DRAAIEN
		public List<string> laatDraaiendeFilmsZien()
		{
			readJson();
			List<string> draaiendeFilms = new List<string>();
			//LOOP DOOR ALLE FILMS DIE DRAAIEN
			for(int i = 0; i < draaienFilmsList?.Count; i++)
			{
				int? indexfilm = null;
				//LOOP DOOR ALLE FILMS OM TITEL TOE TE VOEGEN AAN LIST
				for(int j = 0; j < films?.Count; j++)
				{
					//KRIJG DE FILM ID
					if(films[j].Id == draaienFilmsList[i].FilmID)
					{
						indexfilm = j;
						break;
					}
				}
				if (indexfilm.HasValue) {
#pragma warning disable CS8604 // Possible null reference argument.
					draaiendeFilms.Add(films?[indexfilm.Value].Titel);
#pragma warning restore CS8604 // Possible null reference argument.
				}
			}
			return draaiendeFilms;
		}
		//KRIJG DE DETAILS VAN GEDRAAIDE FILMS
		public void Details(int index, List<string> draaiendeFilmsList)
		{
			string titel = draaiendeFilmsList[index - 1];
			int filmIndex = 0;
			//ZOEK DE FILM ID
			for(int i = 0; i < films?.Count; i++)
			{
				if(films[i].Titel == titel)
				{
					this.filmID = films[i]?.Id;
					filmIndex = i;
				}
			}
			//PRINT ALLE INFO
			Console.WriteLine($"U hebt gekozen voor de titel: {films?[filmIndex].Titel}. Deze film draait op de volgende data(s):");
			for (int i = 0; i < draaienFilmsList?.Count; i++)
			{
				if (draaienFilmsList?[i].FilmID == this.filmID)
				{
					//PRINT DE DATUMS EN ZAAL
					for(int j = 0; j < draaienFilmsList?[i].Datum?.Count; j++)
					{
						Console.WriteLine($"[{j+1}] {draaienFilmsList?[i].Datum?[j]} in zaal {draaienFilmsList?[i].Zaal?[j]}");
					}
				}
			}
		}
		//GA VERDER MET DE RESERVERING
		public void Reserveer()
		{

		}
	}
	//PRINT DE ZAAL
	class Zaal
	{
		public int zaalNummer;
		public int zaalIndex;
		public string? json;
		public List<plattegrondJson>? plattegronden;
		public Zaal(int zaalNummer)
		{
			this.zaalNummer = zaalNummer;
			//ZOEK NAAR DE INDEX VAN PLATTEGROND.JSON
			readJson();
			int zaalIndex = 0;
			for(int i = 0; i < plattegronden?.Count; i++)
			{
				if (plattegronden[i].Plattegrond == zaalNummer)
				{
					zaalIndex = i;
					break;
				}
			}
			this.zaalIndex = zaalIndex;
		}
		public class plattegrondJson
		{
			public int? Plattegrond { get; set; }
			public int? Rijen { get; set; }
			public int? Stoelen { get; set; }
			public string? Scherm { get; set; }
		}
		public void readJson()
		{
			//LEEST JSON
			this.json = File.ReadAllText("../../../plattegrond.json", Encoding.GetEncoding("utf-8"));
			this.plattegronden = JsonConvert.DeserializeObject<List<plattegrondJson>>(json);
		}
		public string zaal()
		{
			//GEEFT DE ZAAL TERUG
			string plattegrond = "";
			readJson();
			for (int rij = 0; rij < plattegronden?[zaalIndex].Rijen; rij++)
			{
				for (int stoel = 0; stoel < plattegronden?[zaalIndex].Stoelen; stoel++)
				{
					plattegrond += "[ ]";
				}
				plattegrond += "\n";
			}
			plattegrond += plattegronden?[zaalIndex].Scherm + "\n";
			return plattegrond;
		}
	}
	public class Program
	{
		static void Main()
		{
			//INTRO BERICHT
			Console.WriteLine("----------------------------\nBIOSCOOP HR - TICKETS RESERVEREN\n----------------------------\nOp deze pagina kunt u tickets reserveren. U krijgt ook de optie om te kunnen zoeken naar films.\n");
			//PAS DE FILTERS TOE
			zoekFilms zoeken = new zoekFilms();
			var films = zoeken.zoeken();
			//ROEP DE FUNCTIES AAN OM DRAAIENDE FILMS TE LATEN ZIEN
			if(films != null) {
				//LAAT ALLE FILMS ZIEN DIE BINNENKORT DRAAIEN
				Console.WriteLine("De volgende film(s) zijn beschikbaar voor reservering:");
				getFilms draaiendeFilms = new getFilms(films);
				List<String> draaiendeFilmsList = draaiendeFilms.laatDraaiendeFilmsZien();
				string[] menuKeuzes = new string[draaiendeFilmsList.Count];
				for (int i = 0; i < draaiendeFilmsList.Count; i++)
				{
					Console.WriteLine((i+1) + ". " + draaiendeFilmsList[i]);
					menuKeuzes[i] = (1+i).ToString();
				}
				//KRIJG DE DETAILS VAN DE FILM
				Console.WriteLine("\nWelk film wilt u boeken? Typ een nummer en klik dan op enter.");
				string? keuzeFilm = Console.ReadLine();
				while(!menuKeuzes.Contains(keuzeFilm))
				{
					Console.WriteLine("\nU kunt dit nummer niet kiezen, kies een ander nummer");
					keuzeFilm = Console.ReadLine();
				}
				Console.WriteLine("\n");
				if (keuzeFilm != null)
				{
					//KRIJG ALLE DETAILS
					draaiendeFilms.Details(Int32.Parse(keuzeFilm), draaiendeFilmsList);
				}
			} else { Console.WriteLine("Iets ging fout."); }
		}
	}
}