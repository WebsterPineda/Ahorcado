using System;

namespace Ahorcado
{
    class Juego
    {
        public Juego()
        {
            random = new Random();
            NuevaPartida();
        }
        
        ~Juego()
        {
            palabra = null;
            pantalla = null;
            letrasIntentadas = null;
        }

        public void NuevaPartida()
        {
            espacios = 0;
            ElegirPalabra();
            pantalla = null;
            letrasIntentadas = null;
            pantalla = new char[palabra.Length];
            letrasIntentadas = new char[30];
            vidas = 3;
            aciertos = 0;
            inicio = true;
        }

        public void Jugar()
        {
            Partida();
            ConsoleKeyInfo tecla;
            while (vidas > 0)
            {
                tecla = Console.ReadKey(true);
                if (Char.IsLetter(tecla.KeyChar))
                {
                    letra = char.ToLower(tecla.KeyChar);
                    Verificar();
                }
                else
                {
                    Console.WriteLine("Debes de presionar una letra");
                    System.Threading.Thread.Sleep(1000);
                }
                Partida();
                if (aciertos == palabra.Length - espacios)
                {
                    Victoria();
                    break;
                }
            }
            if (vidas == 0)
            {
                Derrota();
            }
        }

        private void Partida()
        {
            Console.Clear();
            Console.WriteLine();
            if (inicio)
            {
                for (i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] == ' ')
                    {
                        pantalla[i] = ' ';
                    }else
                    {
                        pantalla[i] = '_';
                    }
                }
                inicio = false;
            }
            for (i = 0; i < palabra.Length; i++)
            {
                Console.Write(" ");
                Console.Write(pantalla[i]);
            }
            Console.WriteLine();
            Estado();
        }

        private void ElegirPalabra()
        {
            palabra = banco[random.Next(0, 11)].ToCharArray();
            foreach (char c in palabra)
                if (c == ' ') espacios++;
        }

        private void Estado()
        {
            Console.WriteLine("\nLetras acertadas: " + aciertos.ToString() + " de "+ (palabra.Length - espacios) + "\nVidas restantes: " + vidas.ToString());
            Console.WriteLine();
        }

        private void Verificar()
        {
            coincide = false;
            for (i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra && palabra[i] != pantalla[i])
                {
                    pantalla[i] = letra;
                    aciertos++;
                    coincide = true;
                }else if (palabra[i] == letra && palabra [i] == pantalla[i])
                {
                    coincide = true;
                }
            }
            if (!coincide)
            {
                vidas--;
            }
        }

        private void Victoria()
        {
            Console.Clear();
            Console.WriteLine("Felicidades, has ganado la partida!");
            Console.WriteLine();
        }

        private void Derrota()
        {
            Console.Clear();
            Console.WriteLine("Lo sentimos, has perdido la partida");
        }

        private int vidas, aciertos, i, espacios;
        private char letra;
        private char[] palabra, pantalla, letrasIntentadas; //palabra es lo que buscamos
        //pantalla es lo que muestro, letrasIntentadas son todos los intentos realizados.
        private bool inicio, coincide;
        private string[] banco = new string[] { "hola", "programacion", "sol y luna", "ccna", "hipotalamo", "mango", "queso", "pan", "crimpadora", "hamburguesa", "jarabe" };
        private Random random;
    }
}
