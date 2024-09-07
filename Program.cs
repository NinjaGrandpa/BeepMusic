using BeepMusic;
using BeepMusic.Utils;
using Music;
using System.Text;
using static System.Console;

OutputEncoding = Encoding.Unicode;

Clear();
ResetColor();

var pianoKeys = new List<PianoKey>
{
    new PianoKey() { Color = ConsoleColor.White, MapKey = ConsoleKey.Q, Tone = Tone.A3 },
    new PianoKey() { Color = ConsoleColor.White, MapKey = ConsoleKey.Q, Tone = Tone.A3 },
};

var matrixes = pianoKeys.Select(x => x.GetMatrix()).ToList();

var mxHeight = 7;
var mxWidth = matrixes.Select(x => x.GetLength(1)).Sum();

var fullMatrix = new string[mxHeight, mxWidth];

foreach (var matrix in matrixes)
{
    var mxIndex = matrixes.IndexOf(matrix);
    for (int i = 0; i < mxHeight; i++)
    {
        for (int j = 0; j < mxWidth / matrixes.Count; j++)
        {
            var fullMxIndex = (mxWidth / (matrixes.Count)) * mxIndex + j;

            fullMatrix[i, fullMxIndex] = matrix[i, j];

            if (j == mxWidth / matrixes.Count - 1 && mxIndex == matrixes.Count - 1)
            {
                fullMatrix[i, fullMxIndex] += "\n";
            }
        }
    }
}

for (int i = 0; i < fullMatrix.GetLength(0); i++)
{
    for (int j = 0; j < fullMatrix.GetLength(1); j++)
    {
        BackgroundColor = ConsoleColor.White;
        ForegroundColor = ConsoleColor.Black;
        Write(fullMatrix[i, j]);
    }
}

ResetColor();
Console.WriteLine();

var exit = false;

var tone = Tone.A3;
var duration = Duration.QUARTER;
var bpm = 150;

var tones = Enum.GetValues<Tone>().ToList();
var durations = Enum.GetValues<Duration>().ToList();

do
{
    var note = new Note(tone, duration);
    var song = new Song(bpm, new List<Note>() { note });

    if (!KeyAvailable)
    {
        continue;
    }
    var key = ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.Escape:
            WriteLine("Exiting program.");
            exit = true;
            break;

        case ConsoleKey.Spacebar:
            Clear();
            PrintPlaySong(song);
            MusicPlayer.Play(song);

            break;

        case ConsoleKey.RightArrow:
            tone = tones.GetNextItem(tone);

            PrintCurrentTone(tone);
            break;

        case ConsoleKey.LeftArrow:
            tone = tones.GetNextItem(tone, -1);

            PrintCurrentTone(tone);
            break;

        case ConsoleKey.UpArrow:
            duration = durations.GetNextItem(duration);
            PrintCurrentDuration(duration);
            break;

        case ConsoleKey.DownArrow:
            duration = durations.GetNextItem(duration, -1);
            PrintCurrentDuration(duration);
            break;

        case ConsoleKey.E:
            Write("\n\nInput: ");

            var input = ReadLine();
            var arguments = input.Split(' ');
            int? modifier = null;

            if (arguments.Length > 1)
                modifier = Int32.Parse(arguments[1]);

            if (input.Contains("bpm") && modifier != null)
            {
                bpm = (int)modifier;
                WriteLine($"Current BPM {bpm}");
            }

            break;
    }
}
while (!exit);



void PrintCurrentTone(Tone tone)
{
    WriteLine($"Current Tone {tone} at {(int)tone}Hz");
}

void PrintCurrentDuration(Duration duration)
{
    WriteLine($"Current Duration {duration}");
}

void PrintCurrentNote(Note note)
{
    WriteLine($"Current Note {note.Tone} for duration {note.Duration}");
}

void PrintCurrentBPM(int bpm)
{
    WriteLine($"Current BPM {bpm}");
}

void PrintPlaySong(Song song)
{
    var note = song.notes[0];
    WriteLine($"Playing Note {note.Tone} for duration {note.Duration} / {song.bpm}");
}
