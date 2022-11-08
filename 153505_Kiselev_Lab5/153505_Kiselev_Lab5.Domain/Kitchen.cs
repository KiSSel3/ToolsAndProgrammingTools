namespace _153505_Kiselev_Lab5.Domain
{
    [Serializable]
    public class Kitchen
    {
        public Kitchen() { }

        public Kitchen(int Number = 1, int Width = 100, int Height = 100, bool Works = false)/* => 
            (Number, Width, Height, Works) = (Number, Width, Height, Works);*/
        {
            this.Number = Number;
            this.Width = Width;
            this.Height = Height;
            this.Works = Works;
        }

        public int Number { get; set; } = 1;
        public int Width { get; set; } = 100;
        public int Height { get; set; } = 100;
        public bool Works { get; set; } = false;

    }
}
