using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyApp {
    public class Program {
        public class filmOverzicht {
            public string? Title { get; set; }
            public int year { get; set; }
        }
        static void Main() {
            //INTRO BERICHT
            Console.WriteLine("----------------------------\nBIOSCOOP HR - FILMS OVERZICHT\n----------------------------\nHier bevindt een overzicht van alle films, je kunt de resultaten filteren om een duidelijk overzicht te krijgen.\n");
            //LAAT FILM OVERZICHT ZIEN
            string json = System.IO.File.ReadAllText("../../../films.json");
            var films = Newtonsoft.Json.JsonConvert.DeserializeObject<List<filmOverzicht>>(json);
            foreach (var film in films) {
                Console.WriteLine($"- {film.Title} ({film.year})\n   Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris cursus quis dolor cursus porta. Nulla et arcu suscipit, blandit lectus a, pellentesque odio. Nunc suscipit est a lacus faucibus, ut vehicula metus efficitur. Integer nec convallis nisi. Aenean justo diam, blandit quis porttitor vitae, tincidunt vel ex. \n");
            }
        }
    }
}