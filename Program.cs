using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Virtual_League_Die_Spieler
{
    public enum PlayerRolle
    {
        Torwart,
        Abwehrspieler,
        Mittelfeldspieler,
        Stuermer
    }

    public enum Nation
    {
        Deutschland,
        Polen,
        Slovakei
    }

    public static class RandomProvider   // für die Objekte der Klasse Random, für Players Alter
    {
        public static Random Random => random;   // property 

        private static readonly Random random = new Random();   // Fields, readonly
    }

    public class Player
    {
        public string Name   // property, readonly
        {
            get
            {
                return name;
            }
        }

        public PlayerRolle Rolle => rolle;     // auch property, readonly

        public DateTime Geburtsdatum => geburtsdatum;

        public Player(string name, PlayerRolle rolle)  // Konstruktor
        {
            this.name = name;
            this.rolle = rolle;
            Random random = RandomProvider.Random;
            int tag = random.Next() % 28 + 1;                //
            int monat = random.Next() % 12 + 1;              // der Spieler kann 1980 oder später geboren sein
            int jahr = random.Next() % 21 + 1980;            //
            geburtsdatum = new DateTime(jahr, monat, tag);   // Fields
        }

        public int PlayerAlter()      // Methode
        {
            int alter = DateTime.Now.Year - geburtsdatum.Year;
            return alter;   
        }

        private string name;    
        private PlayerRolle rolle;       // Fields
        private DateTime geburtsdatum;
    }

    public class Team
    {
        public Nation Nation => nation;   // property, readonly

        List<Player> Players => players;   // List von Objekte Player

        public static Team Create(Nation nation)   // Die statische Methode wird verwendet, um den Konstruktor 'private Team(Nation ...') aufzurufen
        {
            Team resultat = new Team(nation);
            return resultat;    
        }

        private Team(Nation nation)   // Konstruktor
        {
            this.nation = nation;
            players = new List<Player>();

            Player torwart = new Player("Torwart", PlayerRolle.Torwart);
            players.Add(torwart);   

            Player abwehrspieler1 = new Player("Abwehrspieler1", PlayerRolle.Abwehrspieler);
            players.Add(abwehrspieler1);
            Player abwehrspieler2 = new Player("Abwehrspieler2", PlayerRolle.Abwehrspieler);
            players.Add(abwehrspieler2);
            Player abwehrspieler3 = new Player("Abwehrspieler3", PlayerRolle.Abwehrspieler);
            players.Add(abwehrspieler3);
            Player abwehrspieler4 = new Player("Abwehrspieler4", PlayerRolle.Abwehrspieler);
            players.Add(abwehrspieler4);

            Player mittelfeldspieler = new Player("Mittelfeldspieler1", PlayerRolle.Mittelfeldspieler);
            Players.Add(mittelfeldspieler);
            mittelfeldspieler = new Player("Mittelfeldspieler2", PlayerRolle.Mittelfeldspieler);
            players.Add(mittelfeldspieler);
            mittelfeldspieler = new Player("Mittelfeldspieler3", PlayerRolle.Mittelfeldspieler);
            players.Add(mittelfeldspieler);
            mittelfeldspieler = new Player("Mittelfeldspieler4", PlayerRolle.Mittelfeldspieler);
            players.Add(mittelfeldspieler);

            Player stuermer = new Player("Stuermer1", PlayerRolle.Stuermer);
            players.Add(stuermer);
            stuermer = new Player("Stuermer2", PlayerRolle.Stuermer);
            players.Add(stuermer);
        }

        public string EntnehmenAlsAufschrift()
        {
            string resultat = "Unten sind die Players von Nation: " + nation + "\n";
            for (int i = 0; i < players.Count; i++)
            {
                resultat += ("Spielername: " + players[i].Name + ", " + "Spielerart: " + players[i].Rolle + ", " + "Spieler-alter: " + players[i].PlayerAlter() + "\n"); 
            }
            return resultat;
        }

        private Nation nation;         // Field >>> enum
        private List<Player> players;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Team Team_Deutschland = Team.Create(Nation.Deutschland);    // Erstellen einer neuen Instanz der Team-Klasse, Enum hinzufügen 
            Console.WriteLine(Team_Deutschland.EntnehmenAlsAufschrift());
            
            Team Team_Polen = Team.Create(Nation.Polen);
            Console.WriteLine(Team_Polen.EntnehmenAlsAufschrift());

            Team Team_Slovakei = Team.Create(Nation.Slovakei);
            Console.WriteLine(Team_Slovakei.EntnehmenAlsAufschrift());

            Console.ReadLine();
        }
    }
}
