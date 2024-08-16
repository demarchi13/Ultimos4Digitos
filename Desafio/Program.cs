using System;
using System.Collections.Generic;

namespace Desafio
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Una máquina arranca su tarea imprimiendo los números 2023, 2024 y 2025.Luego, sin interrupción,
            sigue imprimiendo la suma de los últimos tres números que ha impreso: 6072, 10121, 18218, y 
            así sucesivamente. ¿Serías capaz de determinar cuáles son los cuatro dígitos finales del 
            número impreso en la posición 2023202320232023 ? Como referencia, en la posición 50, el 
            número impreso es 8188013234823360, que finaliza en 3360.*/

            solucion();
        }

        public static void solucion()
        {
            // Inicializamos con los primeros tres numeros
            int a = 2023, b = 2024, c = 2025;
            
            // Inicializas el conjunto con los primeros tres numeros de la secuencia que nos va a
            // permitir comprobar mas adelante si aparecio un nuevo numero en la secuencia
            HashSet<int> Ultimos4Digitos = new HashSet<int> { a, b, c };

            // Lista para almacenar los resultados de los ultimos cuatro dígitos
            List<int> secuencia = new List<int> { a % 10000, b % 10000, c % 10000 };

            // Variable para detectar el ciclo y guardar la longitud del ciclo una vez encontrado
            int tamanioCiclo = -1;
            // El ciclo comienza con 4 porque ya tenemos los primeros 3 numeros
            for (int i = 4; i < 1000000; i++)
            {
                //Calcula d
                int d = (a + b + c) % 10000; // Solo los ultimos cuatro digitos

                // Imprime el valor de la posicion 50
                if (i == 50)
                {
                    Console.WriteLine($"Los últimos cuatro dígitos en la posición 50 son {d:D4}");
                }

                // Verifica si "d" ya esta en el HashSet. Si es asi, encontro un ciclo
                // y procede a calcular el tamaño de este
                if (Ultimos4Digitos.Contains(d))
                {
                    tamanioCiclo = i - 3; // Detectamos la longitud del ciclo
                    break;
                }

                // Si "d" no esta en el HashSet, lo agrega tanto en "Ultimos4Digitos" y en "secuencia"
                // luego se actualiza el valor de a, b, c dejandolos listos para la siguiente vuelta
                Ultimos4Digitos.Add(d);
                secuencia.Add(d);
                a = b;
                b = c;
                c = d;
            }

            // Verificacion de ciclo
            if (tamanioCiclo == -1)
            {
                Console.WriteLine("No se detecto un ciclo en el limite de iteraciones.");
                return;
            }

            // Calculo e impresion de la longitud del ciclo
            Console.WriteLine("Ciclo detectado de longitud " + tamanioCiclo);

            // Encontrar la posición dentro del ciclo calculando su modulo usando el tamaño del ciclo
            double position = 2023202320232023 % tamanioCiclo;

            // Obtener el resultado en la posición calculada
            int result = secuencia[(int)position];

            Console.WriteLine($"Los últimos cuatro dígitos en la posición 2023202320232023 son {result:D4}");
        }     
    }
 }