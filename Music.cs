namespace Music;

public enum Tone
{
    REST = 0,
    C0 = 16,
    C1 = 33,
    C2 = 65,
    C3 = 131,
    C4 = 262,
    C5 = 523,
    C6 = 1046,
    C7 = 2093,
    C8 = 4186,
    CSharp0 = 17,
    CSharp1 = 35,
    CSharp2 = 69,
    CSharp3 = 139,
    CSharp4 = 277,
    CSharp5 = 554,
    CSharp6 = 1109,
    CSharp7 = 2217,
    CSharp8 = 4435,
    D0 = 18,
    D1 = 37,
    D2 = 73,
    D3 = 147,
    D4 = 294,
    D5 = 587,
    D6 = 1175,
    D7 = 2349,
    D8 = 4699,
    DSharp0 = 19,
    DSharp1 = 39,
    DSharp2 = 78,
    DSharp3 = 156,
    DSharp4 = 311,
    DSharp5 = 622,
    DSharp6 = 1245,
    DSharp7 = 2489,
    DSharp8 = 4978,
    E0 = 21,
    E1 = 41,
    E2 = 82,
    E3 = 165,
    E4 = 330,
    E5 = 659,
    E6 = 1319,
    E7 = 2637,
    E8 = 5274,
    F0 = 22,
    F1 = 44,
    F2 = 87,
    F3 = 175,
    F4 = 349,
    F5 = 698,
    F6 = 1397,
    F7 = 2794,
    F8 = 5588,
    FSharp0 = 23,
    FSharp1 = 46,
    FSharp2 = 92,
    FSharp3 = 185,
    FSharp4 = 370,
    FSharp5 = 740,
    FSharp6 = 1480,
    FSharp7 = 2960,
    FSharp8 = 5920,
    G0 = 24,
    G1 = 49,
    G2 = 98,
    G3 = 196,
    G4 = 392,
    G5 = 784,
    G6 = 1568,
    G7 = 3136,
    G8 = 6272,
    GSharp0 = 26,
    GSharp1 = 52,
    GSharp2 = 104,
    GSharp3 = 208,
    GSharp4 = 415,
    GSharp5 = 831,
    GSharp6 = 1661,
    GSharp7 = 3322,
    GSharp8 = 6645,
    A0 = 28,
    A1 = 55,
    A2 = 110,
    A3 = 220,
    A4 = 440,
    A5 = 880,
    A6 = 1760,
    A7 = 3520,
    A8 = 7040,
    ASharp0 = 29,
    ASharp1 = 58,
    ASharp2 = 117,
    ASharp3 = 233,
    ASharp4 = 466,
    ASharp5 = 932,
    ASharp6 = 1865,
    ASharp7 = 3729,
    ASharp8 = 7459,
    B0 = 31,
    B1 = 62,
    B2 = 123,
    B3 = 247,
    B4 = 494,
    B5 = 988,
    B6 = 1976,
    B7 = 3951,
    B8 = 7902,
}

public enum Duration
{
    WHOLE = 1,
    HALF = WHOLE * 2,
    QUARTER = HALF * 2,
    EIGHTH = QUARTER * 2,
    SIXTEENTH = EIGHTH * 2,
}

public struct Note
{
    Tone toneVal;
    Duration durval;

    public Note(Tone frequency = Tone.REST, Duration time = Duration.QUARTER)
    {
        toneVal = frequency;
        durval = time;
    }

    public Tone Tone { get { return toneVal; } }
    public Duration Duration { get { return durval; } }
}

public record Song(int bpm, List<Note> notes);

public static class MusicPlayer
{
    public static void Play(Song song)
    {

        for (var i = 0; i < song.notes.Count; i++)
        {
            var note = song.notes[i];
            var beats = 60.0 / (double)song.bpm;
            var timeSignature = beats * 4000;
            int time = (int)timeSignature / (int)note.Duration;

            if (note.Tone == Tone.REST)
                Thread.Sleep(time);
            else
                Console.Beep((int)note.Tone, time);
        }
    }
}
