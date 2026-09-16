namespace S_SingleResponsibilityPrinciple
{
    /* S - SRP - Single Responsibility Principle 
     * Ogni classe deve servire per esattamente un solo scopo. Detta diversamente, ogni classe deve avere un solo motivo per essere modificata.
     */
    
    public class PlayerWithoutS //Questa classe viola palesemente il "Single Responsibility Principle" in quanto ha ben 2 scopi: tiene conto dei dati sensibili dell'utente e si occupa del Log In!
    {
        public string NamePlayer {  get; set; }
        public DateOnly BirthdayPlayer { get; set; }
        public string CountryPLayer { get; set; }
        public PlayerWithoutS(string name, DateOnly birthdayPlayer, string countryPLayer)
        {
            NamePlayer = name;
            BirthdayPlayer = birthdayPlayer;
            CountryPLayer = countryPLayer;
        }
        public void LogInPlayer()
        {
            Console.WriteLine($"Il player {this.NamePlayer} si sta loggando sul server locato a {this.CountryPLayer}");
        }
    }

    //Il modo principale di rifattorizzare seguendo il SRP è quello di dividere ogni utilità classe per classe!

    public class Player
    {
        public string NamePlayer { get; set; }
        public DateOnly BirthdayPlayer { get; set; }
        public string CountryPLayer { get; set; }
        public Player(string name, DateOnly birthdayPlayer, string countryPLayer)
        {
            NamePlayer = name;
            BirthdayPlayer = birthdayPlayer;
            CountryPLayer = countryPLayer;
        }
    }

    public static class LogInService
    {
        public static void LogInPlayer(Player player)
        {
            Console.WriteLine($"Il player {player.NamePlayer} si sta loggando sul server locato a {player.CountryPLayer}.");
        }
    }

    //Ora la combo Player + LogInService rispetta egregiamente il SRP, dando ad oguna delle due classi un solo scopo, rispettivamente quello di tenere i dati dell'utente e quello di loggare il giocatore.

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerWithoutS firstPlayer = new PlayerWithoutS("Andromedus", new DateOnly(1989, 3, 12), "Berlino");
            firstPlayer.LogInPlayer();
            Player secondPlayer = new Player("Cinicus", new DateOnly(1995, 12, 12), "Roma");
            LogInService.LogInPlayer(secondPlayer);
        }
    }
}
