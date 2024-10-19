namespace PmP_gyak_06
{
    class Teglalap
    {
        int width, height;
        string color;

        public Teglalap(int width, int height, string color)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }

        int Area()
        {
            return width * height;
        }

        public bool IsValid()
        {
            

            return width>0 && height > 0 ? true : false;
        }

        public void Draw(int x, int y)
        {
            ConsoleColor consoleColor;
            if (Enum.TryParse(color, true, out consoleColor))
            {
                Console.ForegroundColor = consoleColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White; 
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(new string('*', width));
            }
            Console.ResetColor();
        }
    }
}