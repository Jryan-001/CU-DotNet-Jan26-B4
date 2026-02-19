namespace SocialNetworkingSite
{
    class Person
    {
        public string Name { get; set; }

        public List<Person> friends  = new List<Person>();

        public Person(string name)
        {
            Name = name;
        }
        //public void AddFriend(Person friend)
        //{
        //    if (!friends.Contains(friend))
        //    {
        //        friends.Add(friend);
        //        friend.friends.Add(this);// here this means A person not B person obviously
        //    }
        //}
        public void RemoveFriend(Person friend)
        {
            if (friends.Contains(friend))
            {
                friends.Remove(friend);
                friend.friends.Remove(this);// here this means A person not B person obviously
            }
        }
    }

    class SocialNetwork
    {
        List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
        }
        public void AddFriend(Person friend1, Person friend2)
        {
            if (!(_members.Contains(friend1) && _members.Contains(friend2)))
            {
                Console.WriteLine($"Any of Friends {friend1.Name}, {friend2.Name} are not on Social Platform.");     // here this means A person not B person obviously
            }
            else
            {
                if(!friend1.friends.Contains(friend2))
                {
                    friend1.friends.Add(friend2);
                    friend2.friends.Add(friend1);
                }
                
            }
        }
        public void ShowNetwork()
        {
            //foreach (Person member in _members)
            //{
            //    Console.Write($"{member.Name, -6} -> ");
            //    foreach (Person person in member.friends)
            //    {
            //        Console.Write($"{person.Name} ");
            //    }
            //    Console.WriteLine();
            //}
            foreach (Person member in _members)
            {
                Console.Write($"{member.Name, -6} -> ");
                List<string>  friendss = new List<string>();
                foreach (Person person in member.friends)
                {
                    friendss.Add(person.Name);
                }
                Console.WriteLine($"{string.Join(",",friendss)}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();
            

            Person aman = new Person("Aman");

            Person bali = new Person("Bali");
            
            Person chetan = new Person("Chetan");

            Person divya = new Person("Divya");

            Person eena = new Person("Eena");

            network.AddMember(aman);

            network.AddMember(bali);

            network.AddMember(chetan);

            network.AddMember(divya);

            //aman.AddFriend(bali); 
            //aman.AddFriend(chetan); 
            //aman.AddFriend(divya); 
            //divya.AddFriend(bali);
            network.AddFriend(aman, bali);
            network.AddFriend(aman, chetan);
            network.AddFriend(aman, divya);
            network.AddFriend(divya, bali);
            network.AddFriend(aman, eena);

            network.ShowNetwork();
            aman.RemoveFriend(bali);
            network.ShowNetwork();
            
        }
    }
}
