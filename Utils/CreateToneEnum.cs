using System.Globalization;

namespace BeepMusic
{
    public static class CreateToneEnum
    {
        public static void Create()
        {
            var basePath = @"C:\Users\max\Documents\Repositories\Store\BeepMusic";
            var path = Path.Combine(basePath, @"Tones.txt");

            var lines = new List<string>();

            using (var textReader = new StreamReader(path))
            {
                while (!textReader.EndOfStream)
                {
                    lines.Add(textReader.ReadLine());
                }
            }

            var tones = "\tREST = 0\n";

            for (int i = 1; i < lines.Count; i++)
            {
                var line = lines[i].Split();

                var note = line[0].Replace("#", "Sharp");
                var freqs = line
                    .Skip(1)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .ToList();


                for (int j = 0; j < freqs.Count; j++)
                {
                    var octave = j;
                    var freqDouble = Convert.ToDouble(freqs[j], CultureInfo.InvariantCulture);
                    var freq = (int)Double.Round(freqDouble);
                    var tone = "\t" + note + octave + $" = {freq},\n";

                    tones += tone;
                }
            }

            var enumText = "enum Tone\n{\n" + tones + "\n}";
            var tonePath = Path.Combine(basePath, "Music.cs");


            using var reader = new StreamReader(tonePath);

            var currentText = reader.ReadToEnd();
            reader.Dispose();

            var currentLines = currentText.Split("\n");

            var listToReplace = currentLines
                .SkipWhile(l => !l.Contains("enum Tone"))
                .TakeWhile(l => !l.Contains("Duration"))
                .ToList();


            var textToReplace = string.Join("\n", listToReplace);

            currentText = currentText.Replace(textToReplace, enumText);

            using var writer = new StreamWriter(tonePath);

            writer.Write(currentText);

            //writer.Write(enumText);
        }
    }
}
