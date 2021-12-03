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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListPopulation();
        }
        enum activityType
        { 
            Land, 
            Water, 
            Air 
        }
        List<Activity> allActivities = new List<Activity>();
        public void ListPopulation()
        {
            //Declaration of variables
            Random random = new Random();
            DateTime currentDate = DateTime.Now;
            //Creating the activity objects
            allActivities.Add(new Activity()
            {
                Name = "Treking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "All day walking, up the moutains, then some more walking.",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            allActivities.Add(new Activity()
            {
                Name = "Kayaking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half day lakeland kayak with island picnic",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            allActivities.Add(new Activity()
            {
                Name = "Parachuting",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half a day falling, all day screaming",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            allActivities.Add(new Activity()
            {
                Name = "Mountain Biking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half day cycle from France to Dublin with a great geography lesson at the end",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            allActivities.Add(new Activity()
            {
                Name = "Surfing",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Quarter day seaside surf with some hot chocolate after",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            allActivities.Add(new Activity()
            {
                Name = "Hang Gliding",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "'This isn't flying, this is falling with style!'...for a half day",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            allActivities.Add(new Activity()
            {
                Name = "Abseiling",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half a day being spiderman",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            allActivities.Add(new Activity()
            {
                Name = "Sailing",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half day on a boat, but a pirate for life",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            allActivities.Add(new Activity()
            {
                Name = "Helicopter Tour",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Quarter day of flying, or as things get smaller, an iconic Father Ted scene",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });

            lbxOptions.ItemsSource = allActivities;
            lbxOptions.Items.Refresh();
            //lbxOptions.ItemsSource = allActivities;

        }

        private void LbxOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxOptions.SelectedItem = allActivities;

        }
    }
}
