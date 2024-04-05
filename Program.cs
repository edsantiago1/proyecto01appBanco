namespace Semana10{
    class Program{

        public static void Main(){
            int abonarCuenta = 0;
            int periodoCapitalizacion = 0;
            int contadorAbono = 0;
            double saldoCuenta = 0;
            List<String> Logs = new List<string>();
            string[] datos = new string[6];
            string[] opciones = { "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Salir" };
            string titulo = "Sistema bancario";
            bool menu = true;
            bool solicitarDatos = false;
            while (menu){
                Console.SetCursorPosition((Console.WindowWidth-titulo.Length)/2,Console.CursorTop);
                Console.Clear();
                Console.WriteLine(titulo);
                if (!solicitarDatos){
                    datos = TomarDatos();
                    Console.Clear();
                    solicitarDatos = true;
                    saldoCuenta = float.Parse(datos[5]);
                }
                for (int i = 0; i < opciones.Length; i++){
                    Console.WriteLine($"{i + 1}.{opciones[i]}");
                }
                Console.Write("Seleccione la accion que desea ejecutar indicando el numero de opcion: ");
                string? menu_opciones = Console.ReadLine();
                datos[5] = saldoCuenta.ToString("F2");
                switch (menu_opciones){
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Tipo de cuenta: {datos[0]}\nNombre cuentaHabiente: {datos[1]}\nNo. de DPI: {datos[2]}\nDireccion: {datos[3]}\nNo. de Telefono: {datos[4]}\nSaldo de cuenta: ${datos[5]}");
                        Console.WriteLine("\n\nLogs: ");
                        for (int i = 0; i < Logs.Count; i++){
                            Console.WriteLine(Logs[i]);
                        }
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        saldoCuenta = saldoCuenta - (saldoCuenta * 0.1);
                        Logs.Add(opciones[int.Parse(menu_opciones) - 1]);
                        Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        if (saldoCuenta >= 500){
                            saldoCuenta = saldoCuenta + (saldoCuenta * 0.11);
                            Logs.Add(opciones[int.Parse(menu_opciones) - 1]);
                            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
                        }
                        else{
                            Console.WriteLine($"No es factible realizar esta transaccion debido al bajo saldo de la cuenta, el porcentaje de ganacia si se realiza seria: {(saldoCuenta * 0.11).ToString("f2")}");
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        if (abonarCuenta >= 30){
                            contadorAbono = 0;
                            abonarCuenta = 0;
                        }
                        Console.Clear();
                        if (contadorAbono < 2 && saldoCuenta < 500){
                            saldoCuenta = saldoCuenta * 2;
                            Logs.Add(opciones[int.Parse(menu_opciones) - 1]);
                            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
                            contadorAbono++;
                        }
                        else{
                            Console.WriteLine("No se cumplen las condiciones necesarias para realizar esta accion.");
                        }
                        Console.ReadKey();
                        break;

                    case "5":
                        /* Interes simple = Capital * Porcentaje de interes * Tiempo (días) / 360  */
                        Console.Write("Ingrese el periodo de capitalizacion deseado en dias: ");
                        periodoCapitalizacion = int.Parse(Console.ReadLine() ?? string.Empty);
                        abonarCuenta += periodoCapitalizacion;
                        for (int i = 1; i < periodoCapitalizacion; i++){
                            Console.WriteLine($"Dia numero: {i}");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        double intereses = saldoCuenta * 0.02 * periodoCapitalizacion / 360;
                        saldoCuenta = saldoCuenta + intereses;
                        Logs.Add(opciones[int.Parse(menu_opciones) - 1]);
                        Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}, genero: {intereses.ToString("f2")} en intereses.");
                        Console.ReadKey();
                        break;

                    case "6":
                        menu = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        break;

                }

            }
        }
        public static string[] TomarDatos(){
            string[] datos = new string[6];
            Console.WriteLine("1. Cuenta monetaria Quetzales.\n2.Cuenta monetaria Dolares\n3.Cuenta de ahorro en Quetzales.\n4.Cuenta de ahorro en Dolares.");
            Console.Write("Seleccione su tipo de cuenta indicando el numero de la opcion deseada: ");
            int tc = int.Parse(Console.ReadLine() ?? string.Empty);
            switch (tc){
                case 1:
                    datos[0] = "Cuenta monetaria Quetzales";
                    break;

                case 2:
                    datos[0] = "Cuenta monetaria Dolares";
                    break;

                case 3:
                    datos[0] = "Cuenta de ahorro Quetzales";
                    break;

                case 4:
                    datos[0] = "Cuenta de ahorro Dolares";
                    break;

                default:
                    break;
            }
            Console.WriteLine("A continuacion ingrese los datos solicitados");
            Console.Write("Ingrese su nombre: ");
            datos[1] = Console.ReadLine() ?? string.Empty;
            do{
                Console.Write("Ingrese su numero de DPI (Campo estricto de 5 caracteres): ");
                datos[2] = Console.ReadLine() ?? string.Empty;
            } while (datos[2].Length < 5 || datos[2].Length > 5);
            Console.Write("Ingrese su direccion de residencia: ");
            datos[3] = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese su numero de telefono: ");
            datos[4] = Console.ReadLine() ?? string.Empty;
            datos[5] = "2500";
            Console.WriteLine($"Su saldo inicial sera de {datos[5]}");
            return datos;
        }

    }
}