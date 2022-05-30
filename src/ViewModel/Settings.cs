namespace ViewModel
{
    public class Settings
    {
        public int Size { get; set; }
        public double MineProbability { get; set; }
        public bool Flooding { get; set; }

        public Settings(int size, double mineProbability, bool flooding)
        {
            Size = size;
            MineProbability = mineProbability;
            Flooding = flooding;
        }

        // Initialize settings with default values
        public Settings() : this(10, 0.2, true) { }

    }
}
