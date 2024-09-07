using Music;

namespace BeepMusic
{
    public class PianoKey
    {
        public Tone Tone { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleKey MapKey { get; set; }

        public string[,] GetMatrix()
        {
            const string tl = "┌";
            const string tr = "┐";
            const string bl = "└";
            const string br = "┘";
            const string v = "│";
            const string h = "─";

            var textMatrix = new string[7, 7];


            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var text = " ";

                    if (i is 0 or 6 && j is not 0 or 6)
                        text = h;


                    else if (j is 0 or 6 && i is not 0 or 6)
                        text = v;

                    else
                        text = " ";
                    //if (j is 6)
                    //    text += "\n";

                    textMatrix[i, j] = text;
                }
            }

            textMatrix[0, 0] = tl.ToString();
            textMatrix[0, 6] = tr.ToString();
            textMatrix[6, 0] = bl.ToString();
            textMatrix[5, 3] = MapKey.ToString();
            textMatrix[6, 6] = br.ToString();


            //var doj = tl.ToString().PadRight(4, h) + tr + "\n" +
            //    v.ToString().PadRight(4) + v + "\n" +
            //    v.ToString().PadRight(4) + v + "\n" +
            //    v.ToString().PadRight(4) + v + "\n" +
            //    v.ToString().PadRight(4) + v + "\n" +
            //    v.ToString().PadRight(2) + MapKey.ToString().PadRight(2) + v + "\n" +
            //    bl.ToString().PadRight(4, h) + br;

            return textMatrix;
        }
    }


}
