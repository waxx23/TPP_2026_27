using System;


abstract class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count;
    
    public string Name => name;
    public int Hp => hp;
    public int Power => power;
    
    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        Console.WriteLine($"Создан игрок: {name} (HP: {hp}, Урон: {power})");
        count ++;
    }
    
    public bool IsAlive() => hp > 0;
    
    public abstract void Attack(Character target);
    
    public void Udar(int power)
    {
        hp = hp - power;
    }
    
    public void GetStatus()
    {
         Console.WriteLine($"{Name}: {Hp} HP");
    }
    
    static void HowMany() 
    {
        Console.WriteLine($"Всего игроков: {count}");
    }
    
    static bool IsValidStats(int hp, int power)
    {
        return hp > 0 & power > 0;
    }
}

class Player : Character
{
    public Player (string name, int hp, int power) :base (name, hp, power) {}
    
    public override void Attack(Character target)
    {
        if (!target.IsAlive() | !IsAlive()) Console.WriteLine("Игрок побежден!");
        else 
        {
            target.Udar(Power);
            Console.WriteLine($"{Name} атакует {target.Name} на {Power} урона");
        }
    }
}

class Enemy : Character
{
    public Enemy (string name, int hp, int power) :base (name, hp, power) {}
    
    public override void Attack(Character target)
    {
        if (!target.IsAlive() | !IsAlive()) Console.WriteLine("Игрок побежден!");
        else 
        {
            target.Udar(Power);
            Console.WriteLine($"{Name} атакует {target.Name} на {Power} урона");
        }
    }
}

class Program
{
    static void Main()
    {
        Character player = new Player("Ваня", 100, 13);
        Character enemy = new Enemy("Дима", 120, 17);
        while (player.IsAlive() & enemy.IsAlive())
        {
            player.Attack(enemy);
            enemy.GetStatus();
            if (!enemy.IsAlive()) break;
            enemy.Attack(player);
            player.GetStatus();
            if (!player.IsAlive()) break;
        }
    }
}
