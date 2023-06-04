using static ReservaAsientoAvion.Reserva;

namespace ReservaAsientoAvion
{
    public partial class Ventanilla : Form
    {
        public Ventanilla()
        {
            InitializeComponent();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            // Crear algunos pasajeros y asignarles asientos
            //Pasajero pasajero1 = new Pasajero("Pasajero1");
            //Pasajero pasajero2 = new Pasajero("Pasajero2");
            //Pasajero pasajero3 = new Pasajero("Pasajero3");

            //Thread hilo1 = new Thread(() => ReservarAsiento(pasajero1, 1));
            //Thread hilo2 = new Thread(() => ReservarAsiento(pasajero2, 2));
            //Thread hilo3 = new Thread(() => ReservarAsiento(pasajero3, 1));

            //hilo1.Start();
            //hilo2.Start();
            //hilo3.Start();

            //Thread.Sleep(2000); // Esperar un tiempo antes de liberar el asiento

            //LiberarAsiento(1); // Liberar el asiento ocupado por el pasajero1

            //hilo1.Join();
            //hilo2.Join();
            //hilo3.Join();

            //Ejemplo Barrera de uso
            InicializarTodosDisponibles();

            //Codigo de ejemplo para asientos no disponibles visualmente
            int asientosND = 2;
            ColorNoDisponible(asientosND);

            //Codigo de ejemplo para asientos disponibles visualmente
            int asientosD = 1;
            ColorDisponible(asientosD);
        }

        public void ColorDisponible(int identificadorAsiento)
        {
            Dictionary<int, Button> botones = CargaDeAsientos();

            botones[identificadorAsiento].BackColor = Color.Green;
        }

        public void ColorNoDisponible(int identificadorAsiento)
        {
            Dictionary<int, Button> asientos = CargaDeAsientos();

            asientos[identificadorAsiento].BackColor = Color.Yellow;
        }

        private Dictionary<int, Button> CargaDeAsientos()
        {
            Dictionary<int, Button> asientos = new Dictionary<int, Button>();

            Regex patron = new Regex("^A(\\d+)$"); // Patrón para nombres como "A1", "A2", etc.

            foreach (Control control in this.Controls)
            {
                if (control is Button boton)
                {
                    Match match = patron.Match(boton.Name);
                    if (match.Success)
                    {
                        int numero = int.Parse(match.Groups[1].Value);
                        asientos[numero] = boton;
                    }
                }
            }

            return asientos;
        }

        public void InicializarTodosDisponibles()
        {
            Dictionary<int, Button> asientos = CargaDeAsientos();

            foreach (Button asiento in asientos.Values)
            {
                asiento.BackColor = Color.Green;
            }

        }
    }
}