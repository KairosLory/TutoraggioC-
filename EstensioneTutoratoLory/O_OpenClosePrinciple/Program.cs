namespace O_OpenClosePrinciple
{
    /* O - OCP - Open Close Principle
     * Ogni classe deve essere aperta ad estensioni, ma chiusa a modificazioni.
     */

    public enum TypeOfDamage
    {
        IceDamage,
        FireDamage,
        CutDamage,
        SlashDamage
    }
    public enum TypeOfWeapon
    {
        IceSceptre,
        Katana,
        Knife
    }
    public class WeaponsWithoutO //La combinazione fra gli enum e la classe WeaponsWithoutO palesemente viola il OCP, in quanto se dovessi aggiungere un nuovo tipo di arma dovrei manualmente andare a cambiare il codice all'interno della classe. Avrei un OPEN alla modifica e un CLOSE all'estensione, praticamente il contrario!
    {
        public string WeaponName { get; set; }
        public TypeOfDamage TypeOfDamage { get; set; }
        public TypeOfWeapon TypeOfWeapon { get; set; }
        public WeaponsWithoutO(string name, TypeOfWeapon typeOfWeapon)
        {
            WeaponName = name;
            TypeOfWeapon = typeOfWeapon;
        }
        public void GetTypeDamage()
        {
            TypeOfDamage result = TypeOfWeapon switch
            {
                TypeOfWeapon.IceSceptre => TypeOfDamage.IceDamage,
                TypeOfWeapon.Knife => TypeOfDamage.CutDamage,
                TypeOfWeapon.Katana => TypeOfDamage.SlashDamage,
            };
            Console.WriteLine($"Il tipo di danno dell'arma \"{this.WeaponName}\" è {result}.");
        }
    }

    //Possiamo superare questo ostacolo grazie all'utilizzo di INCAPSULAMENTO ed EREDITARIETÀ.
    //In questo caso possiamo utilizzare una classe astratta!

    public abstract class Weapons //Possiamo tranquillamente fare a meno degli enum nella classe astratta, andando poi a farla ereditare da ogni nuovo tipo di arma! Nessuna possibilità di modifica, ma completa apertura all'estensione!
    {
        public string WeaponName { get; set; }
        public abstract void GetTypeDamage();
    }

    public class IceSceptre : Weapons
    {
        public TypeOfDamage TypeOfDamage { get; set; }
        public IceSceptre(string name, TypeOfDamage typeOfDamage)
        {
            WeaponName = name;
            TypeOfDamage = typeOfDamage;
        }
        public override void GetTypeDamage()
        {
            Console.WriteLine($"Il tipo di danno dell'arma \"{this.WeaponName}\" è {this.TypeOfDamage}.");
        }
    }

    public class Katana : Weapons
    {
        public TypeOfDamage TypeOfDamage { get; set; }
        public Katana(string name, TypeOfDamage typeOfDamage)
        {
            WeaponName = name;
            TypeOfDamage = typeOfDamage;
        }
        public override void GetTypeDamage()
        {
            Console.WriteLine($"Il tipo di danno dell'arma \"{this.WeaponName}\" è {this.TypeOfDamage}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            WeaponsWithoutO firstWeapon = new WeaponsWithoutO("Katana di Sangue", TypeOfWeapon.Katana);
            firstWeapon.GetTypeDamage();

            IceSceptre iceSceptre = new IceSceptre("Scettro del Moguri Glaciale", TypeOfDamage.IceDamage);
            iceSceptre.GetTypeDamage();

            Katana katana = new Katana("Riva di Sangue", TypeOfDamage.SlashDamage);
            katana.GetTypeDamage();
        }
    }
}
