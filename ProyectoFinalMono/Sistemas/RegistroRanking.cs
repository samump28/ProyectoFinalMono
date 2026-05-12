using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProyectoFinalMono.Sistemas
{
    public class RegistroRanking
    {
        private string rutaArchivo = "ranking.json";

        public List<EntradaRanking> Cargar()
        {
            List<EntradaRanking> ranking = new List<EntradaRanking>();

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);

                if (!string.IsNullOrWhiteSpace(json))
                {
                    ranking = JsonSerializer.Deserialize<List<EntradaRanking>>(json);
                }
            }

            if (ranking == null)
            {
                ranking = new List<EntradaRanking>();
            }

            return ranking;
        }

        public void Guardar(List<EntradaRanking> ranking)
        {
            string json = JsonSerializer.Serialize(
                ranking,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText(rutaArchivo, json);
        }

        public void Añadir(string nombre, int puntuacion)
        {
            List<EntradaRanking> ranking = Cargar();

            EntradaRanking entrada = new EntradaRanking(nombre, puntuacion);

            ranking.Add(entrada);

            ranking.Sort((a, b) => b.Puntuacion.CompareTo(a.Puntuacion));

            if (ranking.Count > 10)
            {
                ranking.RemoveRange(10, ranking.Count - 10);
            }

            Guardar(ranking);
        }
    }
}