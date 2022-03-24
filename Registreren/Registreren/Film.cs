using System;
using System.Collections.Generic;

namespace Registreren
{
    public class Film
    {
		private int Id { get; set; }
		private string Titel { get; set; }
		private int Jaar { get; set; }
		private List<string> Taal { get; set; }
		private int Looptijd { get; set; }
		private List<string> Genre { get; set; }
		private string Directeur { get; set; }
		private string Acteurs { get; set; }
		private string Plot { get; set; }
	}
}
