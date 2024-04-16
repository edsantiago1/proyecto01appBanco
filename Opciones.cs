namespace Semana10
{
    class OpcionesClass
    {
        /* "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Salir" */
        public void infoCuenta(string[] datos)
        {
            Console.Clear();
            Console.WriteLine($"Tipo de cuenta: {datos[0]}\nNombre cuentaHabiente: {datos[1]}\nNo. de DPI: {datos[2]}\nDireccion: {datos[3]}\nNo. de Telefono: {datos[4]}\nSaldo de cuenta: ${datos[5]}");

        }

        public double compraProducto(double saldoCuenta)
        {
            saldoCuenta = saldoCuenta - (saldoCuenta * 0.1);
            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
            Console.ReadKey();
            return saldoCuenta;
        }

        public double ventaProducto(double saldoCuenta)
        {
            if (saldoCuenta >= 500)
            {
                saldoCuenta = saldoCuenta + (saldoCuenta * 0.11);
                Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
            }
            else
            {
                Console.WriteLine($"No es factible realizar esta transaccion debido al bajo saldo de la cuenta, el porcentaje de ganacia si se realiza seria: {(saldoCuenta * 0.11).ToString("f2")}");
            }
            Console.ReadKey();
            return saldoCuenta;
        }

        public double abonoCuenta(double saldoCuenta)
        {
            if (saldoCuenta > 500)
            {
                saldoCuenta = saldoCuenta * 2;
                Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
            }
            else
            {
                Console.WriteLine("No se cumplen las condiciones necesarias para realizar esta accion.");
            }
            Console.ReadKey();
            return saldoCuenta;
        }

        public double pasoTiempo(double saldoCuenta,double intereses)
        {
            int Seleccion;
            double periodoCapitalizacion = 0;
            Console.WriteLine("Seleccion el periodo de Capitalizacion deseado, indicando el numero de opcion");
            Console.Write("1. 15 dias.\n2. 30 dias.");
            string? periodocapitalizacionString = Console.ReadLine();
            if(periodocapitalizacionString == ""){
                Seleccion = 0;
            }else{
                Seleccion = int.Parse(periodocapitalizacionString ?? string.Empty);
            }
            switch (Seleccion){
                case 1:
                periodoCapitalizacion = 15;
                break;

                case 2:
                periodoCapitalizacion = 30;
                break;

                default:
                Console.WriteLine("Opcion invalida");
                break;
            }  
            intereses = saldoCuenta *  0.02 * (periodoCapitalizacion/360);
            saldoCuenta += intereses;
            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}, generó: {intereses.ToString("f2")} en intereses.");
            Console.ReadKey();
            return saldoCuenta;
        }

        public void printLogs(List<string> Logs)
        {
            Console.WriteLine("\n\nLogs: ");
            for (int i = 0; i < Logs.Count; i++)
            {
                Console.WriteLine($"{i}.{Logs[i]}");
            }
        }

        public void addLogs(List<string> Logs, string[] opciones, int menuOpciones)
        {
            Logs.Add(opciones[menuOpciones - 1]);
        }
    }
}