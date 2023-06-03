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

        }
    }
}