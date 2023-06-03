using System.Collections.Concurrent;


namespace ReservaAsientoAvion
{
    public class Reserva
    {
        // Estructura de datos para almacenar los asientos ocupados y la cola de espera
        private static ConcurrentDictionary<int, Pasajero> asientosOcupados = new ConcurrentDictionary<int, Pasajero>();
        private static ConcurrentDictionary<int, AutoResetEvent> eventosAsientos = new ConcurrentDictionary<int, AutoResetEvent>();

        // Método para que el pasajero intente ocupar un asiento
        public static void ReservarAsiento(Pasajero pasajero, int numeroAsiento)
        {
            AutoResetEvent eventoAsiento;
            bool asientoOcupado = true;

            lock (asientosOcupados)
            {
                if (!asientosOcupados.ContainsKey(numeroAsiento))
                {
                    asientosOcupados[numeroAsiento] = pasajero;
                    asientoOcupado = false;
                }
            }

            if (asientoOcupado)
            {
                eventoAsiento = new AutoResetEvent(false);

                lock (eventosAsientos)
                {
                    eventosAsientos[numeroAsiento] = eventoAsiento;
                }

                eventoAsiento.WaitOne(); // Esperar hasta que el asiento esté desocupado

                lock (asientosOcupados)
                {
                    asientosOcupados[numeroAsiento] = pasajero;
                }
            }

            Console.WriteLine(pasajero.Nombre + " ha ocupado el asiento " + numeroAsiento);
        }

        // Método para liberar un asiento
        public static void LiberarAsiento(int numeroAsiento)
        {
            lock (asientosOcupados)
            {
                if (asientosOcupados.ContainsKey(numeroAsiento))
                {
                    asientosOcupados.TryRemove(numeroAsiento, out _);
                    Console.WriteLine("El asiento " + numeroAsiento + " ha sido liberado.");
                }
            }

            AutoResetEvent eventoAsiento;

            lock (eventosAsientos)
            {
                if (eventosAsientos.ContainsKey(numeroAsiento))
                {
                    eventoAsiento = eventosAsientos[numeroAsiento];
                    eventosAsientos.TryRemove(numeroAsiento, out _);
                    eventoAsiento.Set(); // Liberar el asiento para que otros puedan ocuparlo
                }
            }
        }

        public class Pasajero
        {
            public string Nombre { get; }

            public Pasajero(string nombre)
            {
                Nombre = nombre;
            }
        }
    }


}

