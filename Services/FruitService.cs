    using ContosoPizza.Models;
    namespace ContosoPizza.Services;
    public static class FruitService
    {
        static List<Fruit> Fruits { get; }
        static int nextId = 3;
        static FruitService()
        {
            Fruits = new List<Fruit>
            {
            new Fruit { Id = 1, Name = "Classic Italian", Price = 30,Color="red" },
            new Fruit { Id = 2, Name = "Veggie",  Price = 30,Color="red" },
            new Fruit { Id = 3, Name = "Banana",  Price = 30,Color="red" },
            new Fruit { Id = 4, Name = "Apple",  Price = 30,Color="red" }
            
            };
        }
        public static List<Fruit> GetAll() => Fruits;
        public static List<Fruit> GetAllOrder() => Fruits.OrderBy(f => f.Name).ToList();

        public static Fruit? Get(int id) => Fruits.FirstOrDefault(p => p.Id == id);
        public static void Add(Fruit fruit)
        {
            fruit.Id = nextId++;
            Fruits.Add(fruit);
        }
        public static void Delete(int id)
        {
            var fruit = Get(id);
            if (fruit is null)
                return;

            Fruits.Remove(fruit);
        }
        public static void Update(Fruit fruit)
        {
            var index = Fruits.FindIndex(p => p.Id == fruit.Id);
            if (index == -1)
                return;
            Fruits[index] = fruit;
        }
    }