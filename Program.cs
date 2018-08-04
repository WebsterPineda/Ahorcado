using System;

namespace Ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            bool jugar = true;
            bool ciclo = true;
            Juego juego = new Juego();
            while (jugar)
            {
                juego.Jugar();
                Console.WriteLine("\n\n");
                Console.Write("Deseas seguir jugando? (y/n): ");
                do
                {
                    ciclo = true;
                    keyInfo = Console.ReadKey(true);
                    if (char.IsLetter(keyInfo.KeyChar))
                    {
                        if (char.ToLower(keyInfo.KeyChar) == 'y')
                        {
                            jugar = true;
                            ciclo = false;
                            juego.NuevaPartida();
                        }
                        else if (char.ToLower(keyInfo.KeyChar) == 'n')
                        {
                            jugar = false;
                            ciclo = false;
                            Console.Write("n");
                        }
                    }
                } while (ciclo);
            }
            Console.WriteLine();
        }
    }
}
