﻿namespace Semana10{

    class Program1{
         public  void menuApp(bool menu, string[] datos,List<string> Logs){
            double saldoCuenta = double.Parse(datos[5]);
            string titulo = "Sistema Bancario";
            string[] opciones = { "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Salir" };

            Console.Clear();
/*             Console.SetCursorPosition((Console.WindowHeight - titulo.Length) / 2, Console.CursorTop); */
            Console.WriteLine(titulo);

            opcionesPrincipales(opciones,datos,menu, saldoCuenta,Logs);
            
        }

        public string[] tomaDatos(){
            string[] datos = new string[6];
            Console.WriteLine("1. Cuenta monetaria Quetzales.\n2.Cuenta monetaria Dolares\n3.Cuenta de ahorro en Quetzales.\n4.Cuenta de ahorro en Dolares.");
            Console.Write("Seleccione su tipo de cuenta indicando la opcion acorde: ");
            int tipoCuenta = int.Parse(Console.ReadLine() ?? string.Empty );
            datos[0] = switchCase1(tipoCuenta);
            
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
            int menuOpciones = int.Parse(Console.ReadLine() ?? string.Empty);
            datos = switchCase2(menuOpciones, Logs, datos, menu, opciones, saldoCuenta);        
            return datos;    
        }
    

            public static string[] switchCase2( int menuOpciones, List<string> Logs, string[] datos, bool menu, string[] opciones, double saldoCuenta){
            datos[5] = saldoCuenta.ToString();
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
/* 

                    case 3:
                        Console.Clear();
                        if (saldoCuenta >= 500){
                            saldoCuenta = saldoCuenta + (saldoCuenta * 0.11);
                            Logs.Add(opciones[menuOpciones - 1]);
                            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
                        }
                        else{
                            Console.WriteLine($"No es factible realizar esta transaccion debido al bajo saldo de la cuenta, el porcentaje de ganacia si se realiza seria: {(saldoCuenta * 0.11).ToString("f2")}");
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        if (abonarCuenta >= 30){
                            contadorAbono = 0;
                            abonarCuenta = 0;
                        }
                        Console.Clear();
                        if (contadorAbono < 2 && saldoCuenta < 500){
                            saldoCuenta = saldoCuenta * 2;
                            Logs.Add(opciones[menuOpciones - 1]);
                            Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}");
                            contadorAbono++;
                        }
                        else{
                            Console.WriteLine("No se cumplen las condiciones necesarias para realizar esta accion.");
                        }
                        Console.ReadKey();
                        break;

                    case 5:

                        Console.Write("Ingrese el periodo de capitalizacion deseado en dias: ");
                        periodoCapitalizacion = int.Parse(Console.ReadLine() ?? string.Empty);
                        abonarCuenta += periodoCapitalizacion;
                        for (int i = 1; i < periodoCapitalizacion; i++){
                            Console.WriteLine($"Dia numero: {i}");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        float intereses = saldoCuenta * 0.02 * periodoCapitalizacion / 360;
                        saldoCuenta = saldoCuenta + intereses;
                        Logs.Add(opciones[menuOpciones - 1]);
                        Console.WriteLine($"Saldo de cuenta: {saldoCuenta.ToString("f2")}, genero: {intereses.ToString("f2")} en intereses.");
                        Console.ReadKey();
                        break;

                    case 6:
                        menu = false;
                        break; */

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