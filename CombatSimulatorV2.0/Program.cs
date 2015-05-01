using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CombatSim2._0
{

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
        }
    }
    public abstract class Actor
    {
        //declare random
        public Random rng = new Random();

        public int damage = 0;
        public int hitChance = 0;

        public string Name
        {
            get;
            set;
        }
        public int HP
        {
            get;
            set;
        }
        public bool IsAlive
        {
            get
            {
                return this.HP > 0;
            }
        }
        //make Attack method
        public virtual int Attack(Actor actor)
        {
            return 0;
        }
        //make constructor 
        public Actor(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

    }
    public class Enemy : Actor
    {
        //method for enemy attack
        public override int Attack(Actor actor)
        {
            damage = rng.Next(15, 31);
            hitChance = rng.Next(1, 11);
            if (hitChance > 8)
            {
                actor.HP -= damage;
                Console.WriteLine("{0} has hit {1} for {2} HP!", this.Name, actor.Name, damage);
                Thread.Sleep(500);
                return damage;
            }
            Console.WriteLine("{0} misses", this.Name);
            Thread.Sleep(500);
            return 0;
        }
        //build enemy constuctor that implements base 
        public Enemy(string enemy, int hp)
            : base(enemy, hp)
        {

        }
    }
    public class Player : Actor
    {
        enum AttackType
        {
            Sword = 1,
            Magic,
            Heal,
            miss
        }
        public override int Attack(Actor actor)
        {
            //set chooseattack to a variable to compare
            AttackType choosenAttack = ChooseAttack();
            switch (choosenAttack)
            {
                case AttackType.Sword:
                    damage = rng.Next(25, 36);
                    hitChance = rng.Next(1, 11);
                    if (hitChance <= 7)
                    {
                        actor.HP -= damage;
                        Console.WriteLine("{0} has hit {1} for {2} HP!", this.Name, actor.Name, damage);
                        return damage;
                    }
                    Console.WriteLine("You missed", this.Name);
                    return 0;
                case AttackType.Magic:
                    damage = rng.Next(10, 16);
                    actor.HP -= damage;
                    Console.WriteLine("{0} has hit {1} for {2} HP!", this.Name, actor.Name, damage);
                    Thread.Sleep(800);
                    return damage;
                case AttackType.Heal:
                    damage = rng.Next(10, 21);
                    this.HP += damage;
                    Console.WriteLine("{0} has healed for {1} HP", this.Name, damage);
                    Thread.Sleep(800);
                    return damage;
                case AttackType.miss:
                    damage = rng.Next(5, 11);
                    this.HP -= damage;
                    Console.WriteLine("{0} attack fails!", this.Name, damage);
                    Thread.Sleep(800);
                    return damage;
            }
            return 0;
        }
        private AttackType ChooseAttack()
        {
            //
            int isNumber = 0;
            Console.Write("Select your weapon: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out isNumber))
            {
                switch (isNumber)
                {
                    case 1:
                        return AttackType.Sword;
                    case 2:
                        return AttackType.Magic;
                    case 3:
                        return AttackType.Heal;
                }
            }
            Console.WriteLine("Please enter 1, 2, or 3");
            Thread.Sleep(500);
            return AttackType.miss;
        }
        public Player(string player, int hp)
            : base(player, hp)
        {

        }
    }
    public class Game
    {
        public Player Player
        {
            get;
            set;
        }
        public Enemy Enemy
        {
            get;
            set;
        }
        //make string variables to hold name
        public string playerName = "Brad";
        public string enemyName = "Gary";

        public Game()
        {
            this.Player = new Player(playerName, 100);
            this.Enemy = new Enemy(enemyName, 200);
        }

        public void DisplayCombatInfo()
        {
            Console.Clear();

            if (Player.HP != 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                                          Brad's Hit Points: " + Player.HP);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                               Gary the Dragon's Hit Points: " + Enemy.HP);
                Console.ResetColor();
                Console.WriteLine();

            Console.WriteLine("Press 1 to attack with Sword!");
            Console.WriteLine("Press 2 to attack with Magic!");
            Console.WriteLine("Press 3 to heal!");
            }
        }
        public void PlayGame()
        {

            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {
                DisplayCombatInfo();
                this.Player.Attack(this.Enemy);
                this.Enemy.Attack(this.Player);
            }
            if (this.Player.IsAlive)
            {
                Console.Clear();
                Console.Write("Congratulations! Brad has ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("slain the dragon");
                Console.ResetColor();
                Console.WriteLine("!");
                Console.WriteLine();
                Console.Write("Unfortunately he is suddenly filled with an odd sense of disgust, foreboding and shame. This is one case where violence was not the answer.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have been ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("brutally slain");
                Console.ResetColor();
                Console.WriteLine(". It's not pretty.");
                Console.ReadKey();
            }
        }
    }
}