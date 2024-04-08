namespace Semana10{

    public class MainClass{

        public static void Main(string[] args){
            string[] datos = new string[6];
            var program = new Program1();
            bool menu = true;
            List<string> Logs = new List<string>();
            
            Console.WriteLine("hola mundo");
            datos = program.tomaDatos();
            while(menu){
                program.menuApp(menu,datos,Logs);
            }
        }
    }
}