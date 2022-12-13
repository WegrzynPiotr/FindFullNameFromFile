namespace ConsoleApp6
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Plik z lista.txt powienien zostać wrzucony do tego samego katalogu co Program.cs
            // Jeżeli coś nie zadziała to zmienić ścieżkę w zmiennej path
            string path = "../../../lista.txt";
            while (true)
            {
                List<string> names = new List<string>();
                FileStream openFile = new FileStream(path, FileMode.Open);
                StreamReader streamReader = new StreamReader(openFile);
                
                while (!streamReader.EndOfStream)
                {
                    names.Add(streamReader.ReadLine());
                }
                start(names);
                streamReader.Close();
            }
        }
        static void start(List<string> names) {
            Console.WriteLine("\nWybierz opcję:\n1.Szukanie po numerze indexu\n2.Szukanie po imieniu");
            int.TryParse(Console.ReadLine(),out int option);

            switch (option) {
                case 1:
                    Console.Clear();
                    checkNameByIndex(names);
                    break;
                    default:
                    Console.Clear();
                    findNameByInput(names);
                    break;
            }
        }

        static void checkNameByIndex(List<string> names)
        {
            Console.WriteLine("Wybierz nr indexu, który chcesz znaleźć na liście!");
            int.TryParse(Console.ReadLine(), out int index);
            if(index<names.Count)
            {
                Console.WriteLine($"1.Element na liście nr {index} - {names[index]}");
            }
            else
            {
                Console.WriteLine("Nie no, aż tyle elementów to nie ma");
            }
            

        }

        static string searchByName()
        {
            Console.WriteLine("2.Wpisz imię, które szukasz na liście (Program szuka tylko po imionach, nazwiska ignoruje)"); // Nie chciałem, żeby program szukał imion, które mogą się pojawić w nazwiskach, np. Piotr(owska)
            string input = Console.ReadLine();
            input = input[0].ToString().ToUpper() + input.Substring(1).ToLower();
            return input;
        }
        static void findNameByInput(List<string> names)
        {
            string input = searchByName();

            names = names.FindAll(name =>
            {
                if (name.Remove(name.IndexOf(" ")).Contains(input))
                {
                    return true;
                }
                else if (name.Contains(input))
                    return false;
                return false;
            });
            names.ForEach(name => Console.WriteLine(name));
        }
    }
}