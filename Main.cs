namespace Semana10{

    public class MainClass{

        public static void Main(string[] args){
            string titulo = "Sistema Bancario";
            string[] datos = new string[6];
            var program = new ProgramClass();
            bool menu = true;
            List<string> Logs = new List<string>();
            
            Console.Clear();
            Console.WriteLine(titulo);
            datos = program.tomaDatos();
            while(menu){
                program.menuApp(menu,datos,Logs);
            }
        }
    }
}