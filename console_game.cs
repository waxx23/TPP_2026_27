using System;
using System.Collections.Generic;


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
		Console.WriteLine();
        Console.WriteLine($"Создан игрок: {name} (HP: {hp}, Урон: {power})");
        count ++;
    }
    
    public bool IsAlive() => hp > 0;
    
    public abstract void Attack(Character target);
    
    public void Udar(int power)
    {
        if (hp >= power) hp = hp - power;
		else hp = 0;
    }
    
    static void HowMany() 
    {
        Console.WriteLine($"Всего игроков: {count}");
    }
    
    static bool IsValidStats(int hp, int power)
    {
        return hp > 0 & power > 0;
    }

	public override string ToString()
	{
		return $"{Name}: {Hp} HP";
	}

    // public static bool Equals(Character obj) return obj is Character other && this.Name == other.Name;

    // public override int GetHashCode() return Name.GetHashCode();

    // public static bool operator ==(Character obj1, Character obj2) return Equals(obj1, obj2);

    // public static bool operator !=(Character obj1, Character obj2) return !Equals(obj1, obj2);
}

class Player : Character
{
    public Player (string name, int hp, int power) :base (name, hp, power) {}
    
    public override void Attack(Character target)
    {
        if (!target.IsAlive() | !IsAlive()) Console.WriteLine("Игрок побежден!");
        else 
        {
			Console.WriteLine();
            target.Udar(Power);
            Console.WriteLine($"{Name} атакует {target.Name} на {Power} урона");
        }
    }
}

class Program
{
    static void Main()
    {
		List<Character> chs = new List<Character>();
		Console.Write("Введите количество игроков: ");
		int counts = int.Parse(Console.ReadLine());
		Console.WriteLine();
		for (int i = 1; i <= counts; i++)
		{
			Console.Write("Введите имя игрока: ");
        	string name = Console.ReadLine();
        	Console.Write("Введите hp игрока: ");
        	int hp = int.Parse(Console.ReadLine());
        	Console.Write("Введите силу игрока: ");
        	int power = int.Parse(Console.ReadLine());
			Character player = new Player(name, hp, power);
			chs.Add(player);
		}
		Console.WriteLine();

		while (true)
		{
    		int alive = 0;
    		foreach (Character c in chs)
        		if (c.IsAlive()) alive++;
		
    		if (alive <= 1) break;  

			for (int i = 0; i < chs.Count; i++)
   			{
        		Character attacker = chs[i];
        		if (!attacker.IsAlive()) continue;
        		Character target = null;
        		for (int st = 1; st < chs.Count; st++)
        		{
            		Character pl = chs[(i + st) % chs.Count];
            		if (pl.IsAlive())
            		{
                		target = pl;
                		break;
            		}
        		}
        		if (target == null) break;
        		attacker.Attack(target);
        		Console.WriteLine($"{attacker} | {target}");

				alive = 0;
				foreach (Character c in chs)
    				if (c.IsAlive()) alive++;
				if (alive <= 1) break;
    		}
		}
		Console.WriteLine();

		foreach (Character c in chs)
        if (c.IsAlive())
            Console.WriteLine($"Победитель: {c.Name} ({c.Hp} HP)");
	}
}