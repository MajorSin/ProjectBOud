using Newtonsoft.Json;
using System.Text;

namespace ticketsReserveren
{
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
				if (plattegronden[i].plattegrond == zaalNummer)
				{
					zaalIndex = i;
					break;
				}
			}
			this.zaalIndex = zaalIndex;
		}
		public class plattegrondJson
		{
			public int? plattegrond { get; set; }
			public int? rijen { get; set; }
			public int? stoelen { get; set; }
			public string? scherm { get; set; }
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
			for (int rij = 0; rij < plattegronden?[zaalIndex].rijen; rij++)
			{
				for (int stoel = 0; stoel < plattegronden?[zaalIndex].stoelen; stoel++)
				{
					plattegrond += "[ ]";
				}
				plattegrond += "\n";
			}
			plattegrond += plattegronden?[zaalIndex].scherm + "\n";
			return plattegrond;
		}
	}
	public class Program
	{
		static void Main()
		{
			//PRINT ZAAL 1
			Zaal zaal1 = new Zaal(1);
			string zaal1Plattegrond = zaal1.zaal();
			Console.WriteLine($"Zaal 1\n{zaal1Plattegrond}");
			//PRINT ZAAL 2
			Zaal zaal2 = new Zaal(2);
			string zaal2Plattegrond = zaal2.zaal();
			Console.WriteLine($"Zaal 2\n{zaal2Plattegrond}");
			//PRINT ZAAL 3
			Zaal zaal3 = new Zaal(3);
			string zaal3Plattgerond = zaal3.zaal();
			Console.WriteLine($"Zaal 3\n{zaal3Plattgerond}");
		}
	}
}