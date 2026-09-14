namespace Esercizio1_LoryTutor
{
    /* ESERICIZ LORY
     * METODO 1: Un metodo che accetta come argomento una stringa e restituisce la stessa stringa ma con tutte le lettere maiuscole.
     * METODO 2: Un metodo che accetta come argomento tre stringhe e ne restituisce la concatenazione.
     * METODO 3: Un metodo che accetta come argomento (in ordine) una stringa, un intero ed un char.
     *           Restituire una stringa che, nella posizione indicata dall’intero, sostituisca la lettera presente con l’argomento char.
     */
    internal class Program
    {
        //METODO 1
        public static string ConvertiStringaInMaiuscolo(string stringa)
        {
            return stringa.ToUpper();
        }
        //METODO 2
        public static string ConcatenaTreStringhe(string primaStringa, string secondaStringa, string terzaStringa)
        {
            return $"{primaStringa} {secondaStringa} {terzaStringa}";
        }
        //METODO 3
        public static string CambiaLaLetteraConIlChar(string stringa, int indice, char lettera) //Lory --> char[] 'L' 'o' 'r' 'y'
        {
            if( indice > stringa.Length || indice <= 0 )
            {
                return "Sei finito fuori range!";
            } else
            {
                char[] listOfChars = stringa.ToCharArray();
                listOfChars[indice - 1] = lettera;
                string newString = string.Join("", listOfChars); // 'L' 'o' 'r' 'y' --> "Lory"
                return newString;
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Stringa in maiuscolo: " + ConvertiStringaInMaiuscolo("Titti")); //Output: "TITTI"
            //Console.WriteLine(ConcatenaTreStringhe("Hai","la","scabbia?")); //Output: "Hai la scabbia?"
            Console.Write("Inserisci la parola: ");
            string inputString = Console.ReadLine().Trim();
            Console.Write("Inserisci l'indice della lettera che vuoi sostituire: ");
            int indiceReplace = int.Parse(Console.ReadLine());
            Console.Write("Inserisci la lettera che vuoi mettere al posto: ");
            char letterToReplace = char.Parse(Console.ReadLine());
            Console.WriteLine("Parola prima della sostituzione: " + inputString);
            Console.WriteLine("Parola dopo la sostituzione: " + CambiaLaLetteraConIlChar(inputString, indiceReplace , letterToReplace));
        }
    }
}
