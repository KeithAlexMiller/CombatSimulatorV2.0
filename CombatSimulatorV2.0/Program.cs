using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulatorV2._0
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
        public Actor(string name, int hp)
        {
        this.Name = name;
        this.HP = hp;
        }
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

        public virtual void Attack(Actor actor);
    }

    public class Enemy : Actor
    {
        public Enemy(string name, int hp) : base (name, hp)
        {

        }
        public override void Attack(Actor actor)
        {
 	        //combat text and all logic for hits/damage
            //base.Attack(actor);
        }
    }

    public class Player : Actor
    {
        public enum AttackType
        {
            Sword = 1,
            Magic,
            Heal
        }
    //enums attackType (3 enums: Sword, Magic, Heal)

        public Player(string name, int hp) : base(name, hp) 
        {

        }

        public override void Attack(Actor actor)
        {
        //takes all logic for determining a hit
        //Call Attack(ChooseAttack)????
        //combat text goes here
            public void Attack()
            {
            ChooseAttack();
                //comabt text for attack
            }
        }
        private AttackType ChooseAttack()
        {
        //declare variable (may need to be an enum)
        string attackType;

        //get input from user
        Console.WriteLine("Choose attack type: ");
        attackType = Console.ReadLine();
        return int.TryParse(attackType);
        }
    }
    public class Game
    {
        this.Player = player;
        this.Enemy = enemy;
        public string Player
        {
            get;
            set;
        }
        public string Enemy
        {
            get;
            set;
        }

        public DisplayComabtInfo()
        {
        
        }

        public PlayGame()
        {
        while (this.Player.IsAlive && this.Enemy.IsAlive)
        {
            DisplayComabtInfo();
            this.Player.Attack(this.Enemy);
            this.Enemy.Attack(this.Player);
        }
            if(this.Player.IsAlive)
            {
            Console.WriteLine("You Won!");
            }
            else
            {
            Console.WriteLine("You Lose Sucka!");
            }
        }
    }
}
