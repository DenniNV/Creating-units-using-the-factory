using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstactFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICreateHuman humanStore = new NeutralHuman();
            List<Human> AllHuman = new List<Human>();

            AllHuman.Add(humanStore.CreateHuman("Warrior"));
            AllHuman.Add(humanStore.CreateHuman("Mag"));
            AllHuman.Add(humanStore.CreateHuman("Hunter"));
            humanStore = new FriendlyHuman();
            AllHuman.Add(humanStore.CreateHuman("Warrior"));
            AllHuman.Add(humanStore.CreateHuman("Mag"));
            AllHuman.Add(humanStore.CreateHuman("Hunter"));
            foreach(Human h in AllHuman)
            {
                h.PrintInfo();
            }
            Console.ReadKey();
        }
    }

    public abstract  class Human {
        public string Name;
        public int Age;
        public float HP;
        public int Damage;
        public int Protection;
        public Weapon Weapon;
        public Armor Armor;

        public int IinflictDamage()
        {
            return Damage;
        }

        public void PrintInfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Age);
            Console.WriteLine(HP);
            Console.WriteLine(Damage);
            Console.WriteLine(Protection);
        }
    }

    public class Warrior: Human
    {
        public Warrior(string name , int age , float hp , ICreateWeapon createWeapon , ICreateArmor createArmor)
        {
            Name = name;
            Age = age;
            HP = hp;
            Weapon = createWeapon.CreateWeapon();
            Damage = Weapon.Damage;
            Armor = createArmor.CreateArmor();
            Protection = Armor.GetArmor;
        }

    }

    public class Mag : Human
    {
        public Mag(string name, int age, float hp, ICreateWeapon createWeapon, ICreateArmor createArmor)
        {
            Name = name;
            Age = age;
            HP = hp;
            Weapon = createWeapon.CreateWeapon();
            Damage = Weapon.Damage;
            Armor = createArmor.CreateArmor();
            Protection = Armor.GetArmor;
        }

    }

    public class Hunter : Human
    {
        public Hunter(string name, int age, float hp, ICreateWeapon createWeapon, ICreateArmor createArmor)
        {
            Name = name;
            Age = age;
            HP = hp;
            Weapon = createWeapon.CreateWeapon();
            Damage = Weapon.Damage;
            Armor = createArmor.CreateArmor();
            Protection = Armor.GetArmor;
        }
    }


    public interface ICreateHuman
    {
         Human CreateHuman(string type);
    }

    public abstract class HumanStore
    {
        public Human orderHuman(string type)
        {
            Human human = null;

            human = CreateHuman(type);
            return human;
        }
        public abstract Human CreateHuman(string type);
    }
    
    public class NeutralHuman : ICreateHuman
    {
        public NeutralHuman()
        {
        }

        public Human CreateHuman(string type)
        {
            Human human = null;

            if (type.Equals("Warrior"))
            {
                human = new Warrior("Denis", 20, 300, new Sword() , new HeavyArmor());
            }
            else if (type.Equals("Mag"))
            {

                human = new Mag("Laura", 20, 30, new MagicStaff() , new LightArmor());
            }
            else if (type.Equals("Hunter"))
            {

                human = new Hunter("Bear", 220, 3030, new Bow() , new MediumArmor());
            }


            return human;
        }
    }

    public class FriendlyHuman: ICreateHuman
    {

        public  Human CreateHuman(string type)
        {
            Human human = null;

            if (type.Equals("Warrior"))
            {
                human = new Warrior("Denis", 1, 1, new Dagger() , new HeavyArmor());
            }
            else if (type.Equals("Mag"))
            {

                human = new Mag("Laura", 1, 1, new MagicStaff() , new LightArmor() );
            }
            else if (type.Equals("Hunter"))
            {

                human = new Hunter("Alex", 1, 1, new Bow() , new MediumArmor());
            }


            return human;
        }
    }

    public interface ICharacterComponents
    {
    }

    public interface ICreateArmor : ICharacterComponents
    {
        Armor CreateArmor();
    }

    public interface ICreateWeapon : ICharacterComponents
    {

        Weapon CreateWeapon();
    }

    public class Armor
    {
        private int _armor;
        public int GetArmor => _armor;
        private int _weight;
        
        public Armor(int armor , int weight)
        {
            _armor = armor;
            _weight = weight;
        }
    }

    public class LightArmor: ICreateArmor
    {
        public  Armor CreateArmor()
        {
            return new Armor(30, 30);
        }

    }

    public class MediumArmor: ICreateArmor
    {
        public  Armor CreateArmor()
        {
            return new Armor(45, 60);
        }

    }

    public class HeavyArmor : ICreateArmor
    {
        public  Armor CreateArmor()
        {
            return new Armor(60, 80);
        }
    }

    public class Weapon
    {
        private int _damage;
        public int Damage { get => _damage; }
        private int _weight;
        private int _length;

        public Weapon(int damage, int weigth, int length)
        {
            _damage = damage;
            _weight = weigth;
            _length = length;
        }


    }

    public class Bow : ICreateWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon(30, 2, 1);
        }
    }
    public class Sword : ICreateWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon(1111, 4, 2);
        }
    }
    public class Dagger : ICreateWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon(40, 2, 1);
        }
    }
    public class MagicStaff : ICreateWeapon
    {
        public Weapon CreateWeapon()
        {
            return new Weapon(666, 4, 2);
        }
    }




}


