namespace Semana10{
class OpcionesClass{
        /* "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Salir" */
        public void infoCuenta(string[] datos){
            Console.Clear();
            Console.WriteLine($"Tipo de cuenta: {datos[0]}\nNombre cuentaHabiente: {datos[1]}\nNo. de DPI: {datos[2]}\nDireccion: {datos[3]}\nNo. de Telefono: {datos[4]}\nSaldo de cuenta: ${datos[5]}");
            
        }

        public double compraProducto(double saldoCuenta){
            saldoCuenta = saldoCuenta - (saldoCuenta * 0.1);
            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
            Console.ReadKey();
            return saldoCuenta;
        }

        public double ventaProducto(double saldoCuenta){
            return saldoCuenta;
        }

        public double abonoCuenta(double saldoCuenta){
            return saldoCuenta;
        }

        public double pasoTiempo(double saldoCuenta){
            return saldoCuenta;
        }

        public  void printLogs(List<string> Logs){
            Console.WriteLine("\n\nLogs: ");
                        for (int i = 0; i < Logs.Count; i++){
                            Console.WriteLine(Logs[i]);
                        }
        }

        public  void addLogs(List<string> Logs,string[] opciones, int menuOpciones){
                        Logs.Add(opciones[menuOpciones - 1]);
        }
    }
}