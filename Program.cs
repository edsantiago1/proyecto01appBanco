using System.Collections.Concurrent;

namespace Semana10{

    class ProgramClass{
        public static bool menu1 = true;
         public bool menuApp(bool menu, string[] datos,List<string> Logs){
            double saldoCuenta = double.Parse(datos[5]);
            string titulo = "Sistema Bancario";
            string[] opciones = { "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Salir" };

            Console.Clear();
            Console.WriteLine(titulo);

            opcionesPrincipales(opciones,datos,menu, saldoCuenta,Logs);
            return menu1;
            
        }

        public string[] tomaDatos(){
            string[] datos = new string[6];
            Console.WriteLine("1. Cuenta monetaria Quetzales.\n2.Cuenta monetaria Dolares\n3.Cuenta de ahorro en Quetzales.\n4.Cuenta de ahorro en Dolares.");
            Console.Write("Seleccione su tipo de cuenta indicando la opcion acorde: ");
            string? tipoCuentaString = Console.ReadLine();
            if(tipoCuentaString == ""){
                switchCase1(0);
            }else{
                int tipoCuentaInt = int.Parse(tipoCuentaString ?? string.Empty);
                datos[0] = switchCase1(tipoCuentaInt);
            }
            Console.WriteLine("A continuacion ingrese los datos solicitados");
            
            Console.Write("Ingrese su nombre: ");
            datos[1] = Console.ReadLine() ?? string.Empty;
            do{
                Console.Write("Ingrese su numero de DPI (Campo estrico de 5 caracteres): ");
                datos[2] = Console.ReadLine() ?? string.Empty;
            } while(datos[2].Length < 5 || datos[2].Length > 5);
            
            Console.Write("Ingrese su direccion de residencia: ");
            datos[3] = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Ingrese su numero de telefono: ");
            datos[4] = Console.ReadLine() ?? string.Empty;

            datos[5] = "2500";
            Console.WriteLine($"Su saldo inicial sera de {datos[5]}");
            return datos;
        }

        public static string switchCase1( int tipoCuenta){
            string retorno;
            switch(tipoCuenta){
                case 1:
                    retorno = "Cuenta Monetaria Quetzales";
                    break;
                    
                case 2:
                    retorno = "Cuenta Monetaria Dolares";
                    break;
                    
                case 3:
                    retorno = "Cuenta de Ahorro Quetzales";
                    break;
                    
                case 4:
                    retorno = "Cuenta de ahorro Dolares";
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opcion invalida");
                    Console.ReadKey();
                    retorno = "";
                    break;
            }

            return retorno;

        }

        public static string[] opcionesPrincipales(string[] opciones, string[] datos, bool menu, double saldoCuenta,List<string> Logs){
            for (int i = 0; i < opciones.Length; i++){
                Console.WriteLine($"{i + 1}.{opciones[i]}");
            }
            Console.Write("Seleccione la accion que desea ejecutar indicando el numero de opcion: ");
            string? menuOpciones = Console.ReadLine();
            if(menuOpciones==""){
                Console.Clear();
                Console.WriteLine("Debe ingresar un valor");
                Console.ReadKey();
            }else{
            int menuOpcionesVal = int.Parse(menuOpciones ?? string.Empty);
            datos = switchCase2(menuOpcionesVal, Logs, datos, menu, opciones, saldoCuenta);        
            }
            return datos;    
        }
    

            public static string[] switchCase2( int menuOpciones, List<string> Logs, string[] datos, bool menu, string[] opciones, double saldoCuenta){
            datos[5] = saldoCuenta.ToString("f2");
            double intereses = 0;
            var Opciones = new OpcionesClass();
               switch (menuOpciones){
                    case 1:
                        Opciones.infoCuenta(datos);
                        Opciones.printLogs(Logs);
                    break;
                    
                    case 2 :
                        saldoCuenta = Opciones.compraProducto(saldoCuenta);
                        Opciones.addLogs(Logs, opciones, menuOpciones);
                    break;

                    case 3:
                       saldoCuenta = Opciones.ventaProducto(saldoCuenta);
                       Opciones.addLogs(Logs, opciones, menuOpciones); 
                    break;

                    case 4:
                        saldoCuenta = Opciones.abonoCuenta(saldoCuenta);
                        Opciones.addLogs(Logs, opciones, menuOpciones);
                        break;
 

                    case 5:
                        saldoCuenta = Opciones.pasoTiempo(saldoCuenta, intereses);
                        Opciones.addLogs(Logs, opciones, menuOpciones);

                        break;

                    case 6:
                        menu1 = false;
                        
                        break; 

                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        break;

                }
                datos[5] = saldoCuenta.ToString();
                Console.ReadKey();
            return datos;

        }
    }

}  