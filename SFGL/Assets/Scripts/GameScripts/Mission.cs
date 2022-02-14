using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Missions
{
    public List<Mission> missions;

    public void Save()
    {
        string content = JsonConvert.SerializeObject(this);
        System.IO.File.WriteAllText("Missions.txt", content);
    }

    public static Missions Load()
    {
        string content = System.IO.File.ReadAllText("Missions.txt");
        return JsonConvert.DeserializeObject<Missions>(content);
    }
}

public class Mission 
{
    public int number;
    public string name;
    public string description;

    public Mission(){}

    public class Stage
    {
        public Stage() { }
        public int number;

        public class Wing
        {
            public Wing() { }
            public int number;
            /// <summary>
            /// Задержка перед тем, как появится это крыло(в секундах)
            /// </summary>
            public float delay;

            public enum WingDelayType
            {
                AfterAppear=1,//это крыло появляется через delay секунд после предыдущего
                AfterDestruction=2//появляется через delay секунд после уничтожения предыдущего
            }
            public WingDelayType delayType;

            public class EnemyShip
            {
                public EnemyShip() { }
                public string modelName;
                public int hp;

                public class Weapon
                {
                    public Weapon() { }

                    public enum WeaponType
                    {
                        Laser = 1,
                        Explosive = 2,
                        Kinetic = 3,
                        Ray = 4,
                        Plasma = 5,
                        Gravity = 6,
                        Doom = 7
                    }

                    public WeaponType weaponType;
                    public float fireRate;//задержка в секундах между выстрелами
                    public float damage;
                }
                public List<Weapon> weaponry;
            }
            public List<EnemyShip> ships;
        }
    }
}

