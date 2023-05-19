namespace Cyolo.Models
{
    public class Result
    {
        const string SPACE_NEW = "\"\n \r\"";

        public int Min { get; set; }

        public double Average { get; set; }

        public string? Top5 { get; set; }

        public override string ToString()
        {
            // we might can enhance it by string builder but i'm not sure this is needed here
            return "Top5: " + Top5 + SPACE_NEW
                + "Min: " + Min + SPACE_NEW
                + "Average: " + Average + SPACE_NEW;
        }
    }
}
