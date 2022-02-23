using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        static void Main() {
            //INTRO BERICHT
            Console.WriteLine("----------------------------\nBIOSCOOP HR - FILMS OVERZICHT\n----------------------------\nHier kunt u een overzicht van alle films vinden.\n");
            //LAAT FILM OVERZICHT ZIEN
            string json = System.IO.File.ReadAllText("../../../films.json");
            var films = JsonConvert.DeserializeObject<List<filmOverzicht>>(json);
            if (films != null) {
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