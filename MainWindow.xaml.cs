using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Zombie_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// generate zombie data on generate click
    /// log new zombies inside database
    /// show next zombie on next zombie click
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static Random rand = new Random();
        private static object[] typeArray = new string[6] {"Walker", "Runner", "Blue Walker", "Voodoo", "Ghoul" ,"Crawler"};
        private static string[] specialtyArray = new string[4] { "Spitter", "Exploder", "Tank", "Hazmat" };
        private static string[] locationArray = new string[8] { "New York", "Youngstown", "Seattle", "Antartica", "Germany", "The Moon", "The Sun", "Andromeda Galaxy" };
        private static string[] nameArray = new string[9] { "Bob", "Jessica", "John", "Joseph", "Sally", "Lesa", "Leah", "Scarett", "Ozwald" };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cs = @"server=localhost;user=root;database=testdb;port=3306;password=******";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                string query = $@"INSERT INTO Zombie(1,2,3) VALUES(a,b,c);";
                MySqlCommand cmd = new MySqlCommand(query,  con);
                cmd.ExecuteNonQuery();

                int randNumb = rand.Next(0, typeArray.Length);
                IZombie zomb;
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
                zomb = (IZombie)randomZombie((string)typeArray[randNumb]);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
                nameValue.Content = zomb.Name;
                ageValue.Content = zomb.Age;
                typeValue.Content = zomb.Type;
                locationValue.Content = zomb.LastKnownLocation;
                specialtyValue.Content = zomb.Specialty;
                brainsValue.Content = zomb.EatsBrains ? "yes" : "no";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error starting thing");
            }
            con.Close();

        }
        public static IZombie? randomZombie(string type)
        {
            if(type == "Walker")
            {
                return new Walker();
            }
            else if (type == "Runner")
            {
                return new Runner();
            }
            else if (type == "Blue Walker")
            {
                return new BlueWalker();
            }
            else if (type == "Voodoo")
            {
                return new Voodoo();
            }
            else if (type == "Ghoul")
            {
                return new Ghoul();
            }
            else if (type == "Crawler")
            {
                return new Crawler();
            }
            else
            {
                return null;
            }
        }
        public class IZombie
        {
            public string Name { get; set; }
            public int Age { get; set ;  }
            public string Type { get; set ;  }
            public string LastKnownLocation { get; set; }
            public string Specialty { get; set ;  }
            public bool EatsBrains { get; set; }
        }
        public class Walker : IZombie
        {
            public Walker(string? name = null, int? age = null, string? lastKnownLocation = null, string? specialty = null, bool? eatsBrains = null)
            {
                Name = name ?? nameArray[rand.Next(0, nameArray.Length)];
                Age = age ?? rand.Next(20, 41);
                LastKnownLocation = lastKnownLocation ?? locationArray[rand.Next(0, locationArray.Length)];
                Specialty = specialty ?? specialtyArray[rand.Next(0, specialtyArray.Length)];
                EatsBrains = eatsBrains ?? rand.Next(0, 2) == 1 ? true : false;
                Type = "Walker";
            }
        }
        public class Runner : IZombie
        {
            public Runner(string? name = null, int? age = null, string? lastKnownLocation = null, string? specialty = null, bool? eatsBrains = null)
            {
                Name = name ?? nameArray[rand.Next(0, nameArray.Length)];
                Age = age ?? rand.Next(20, 41);
                LastKnownLocation = lastKnownLocation ?? locationArray[rand.Next(0, locationArray.Length)];
                Specialty = specialty ?? specialtyArray[rand.Next(0, specialtyArray.Length)];
                EatsBrains = eatsBrains ?? rand.Next(0, 2) == 1 ? true : false;
                Type = "Runner";
            }
        }
        public class BlueWalker : IZombie
        {
            public BlueWalker(string? name = null, int? age = null, string? lastKnownLocation = null, string? specialty = null, bool? eatsBrains = null)
            {
                Name = name ?? nameArray[rand.Next(0, nameArray.Length)];
                Age = age ?? rand.Next(20, 41);
                LastKnownLocation = lastKnownLocation ?? locationArray[rand.Next(0, locationArray.Length)];
                Specialty = specialty ?? specialtyArray[rand.Next(0, specialtyArray.Length)];
                EatsBrains = eatsBrains ?? rand.Next(0, 2) == 1 ? true : false;
                Type = "Blue Walker";
            }
        }
        public class Voodoo : IZombie
        {
            public Voodoo(string? name = null, int? age = null, string? lastKnownLocation = null, string? specialty = null, bool? eatsBrains = null)
            {
                Name = name ?? nameArray[rand.Next(0, nameArray.Length)];
                Age = age ?? rand.Next(20, 41);
                LastKnownLocation = lastKnownLocation ?? locationArray[rand.Next(0, locationArray.Length)];
                Specialty = specialty ?? specialtyArray[rand.Next(0,specialtyArray.Length)];
                EatsBrains = eatsBrains ?? rand.Next(0,2) == 1 ? true:false;
                Type = "Voodoo";
            }
        }
        public class Ghoul : IZombie
        {
            public Ghoul(string? name = null, int? age = null, string? lastKnownLocation = null, string? specialty = null, bool? eatsBrains = null)
            {
                Name = name ?? nameArray[rand.Next(0, nameArray.Length)];
                Age = age ?? rand.Next(20, 41);
                LastKnownLocation = lastKnownLocation ?? locationArray[rand.Next(0, locationArray.Length)];
                Specialty = specialty ?? specialtyArray[rand.Next(0, specialtyArray.Length)];
                EatsBrains = eatsBrains ?? rand.Next(0, 2) == 1 ? true : false;
                Type = "Ghoul";
            }
        }
        public class Crawler : IZombie
        {
            public Crawler(string? name = null, int? age = null, string? lastKnownLocation = null, string? specialty = null, bool? eatsBrains = null)
            {
                Name = name ?? nameArray[rand.Next(0, nameArray.Length)];
                Age = age ?? rand.Next(20, 41);
                LastKnownLocation = lastKnownLocation ?? locationArray[rand.Next(0, locationArray.Length)];
                Specialty = specialty ?? specialtyArray[rand.Next(0, specialtyArray.Length)];
                EatsBrains = eatsBrains ?? rand.Next(0, 2) == 1 ? true : false;
                Type = "Crawler";
            }
        }
    }
}
