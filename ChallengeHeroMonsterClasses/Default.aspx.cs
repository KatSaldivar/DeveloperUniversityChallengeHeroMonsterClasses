using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClasses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dice dice = new Dice();

            Character hero = new Character();
            hero.Name = "Hero";
            hero.Health = 100;
            hero.DamageMaximum = 20;
            hero.AttackBonus = false;
            

            Character monster = new Character();
            monster.Name = "Monster";
            monster.Health = 100;
            monster.DamageMaximum = 20;
            monster.AttackBonus = true;

            //bonus
            if (hero.AttackBonus)
                monster.Defend(hero.Attack(dice));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(dice));

            //runs through battle
            while (monster.Health > 0 && monster.Health > 0)
            {
                monster.Defend(hero.Attack(dice));
                hero.Defend(monster.Attack(dice));
                displayStats(hero);
                displayStats(monster);
            }

            //int damage = hero.Attack(dice);
            //monster.Defend(damage);
            //damage = monster.Attack(dice);
            //hero.Defend(damage);
            displayResult( hero,  monster);
        }

        private void displayStats(Character character)
        {
            resultLabel.Text += String.Format("<p> Name: {0} - Health: {1} - Damage Maximum {2} - Attack Bonus: {3} </p>",
                character.Name, character.Health.ToString(), character.DamageMaximum.ToString(), character.AttackBonus.ToString());
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent2.Health <= 0 && opponent1.Health <= 0)
                resultLabel.Text += String.Format("Both {0} and {1} died.  It is a draw.", opponent2.Name, opponent1.Name);
            else if (opponent1.Health <= 0)
                resultLabel.Text += String.Format("{0} wins! {1} is vanquished.", opponent2.Name, opponent1.Name);
            else //if (opponent2.Health <= 0)
                resultLabel.Text += String.Format("{0} wins! {1} is vanquished.", opponent1.Name, opponent2.Name);
            
        }

    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            //return int -  randomly determine the amount of damage this Character object inflicted
            //Random random = new Random();
            //int damage = random.Next(this.DamageMaximum);
            //return damage;
            dice.Sides = this.DamageMaximum;
            return dice.Roll();
        }

        public int Defend(int damage)
        {
            //deduct damage from characters health
            return this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            return random.Next(this.Sides);
        }
    
    }
}