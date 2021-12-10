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
        }
        enum activityType
        { 
            Land, 
            Water, 
            Air 
        }
        List<Activity> optionActivities = new List<Activity>();//Activity objects are accessible in all functions
        List<Activity> selectedActivities = new List<Activity>();//Selected options list
        decimal cost = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Declaration of variables
            Random random = new Random();
            DateTime currentDate = DateTime.Now;//Sets datetime to the current datetime
            //Creating the activity objects
            optionActivities.Add(new Activity()
            {
                Name = "Treking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),//Sets random dates for each of the activity within the next week
                Cost = random.Next(3000, 9000) / 100,
                Description = "All day walking, up the moutains, then some more walking.",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            optionActivities.Add(new Activity()
            {
                Name = "Kayaking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half day lakeland kayak with island picnic",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            optionActivities.Add(new Activity()
            {
                Name = "Parachuting",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half a day falling, all day screaming",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            optionActivities.Add(new Activity()
            {
                Name = "Mountain Biking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half day cycle from France to Dublin with a great geography lesson at the end",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            optionActivities.Add(new Activity()
            {
                Name = "Surfing",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Quarter day seaside surf with some hot chocolate after",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            optionActivities.Add(new Activity()
            {
                Name = "Hang Gliding",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "'This isn't flying, this is falling with style!'...for a half day",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            optionActivities.Add(new Activity()
            {
                Name = "Abseiling",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half a day being spiderman",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            optionActivities.Add(new Activity()
            {
                Name = "Sailing",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Half day on a boat, but a pirate for life",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            optionActivities.Add(new Activity()
            {
                Name = "Helicopter Tour",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100,
                Description = "Quarter day of flying; or, as things get smaller, an iconic Father Ted scene",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            optionActivities.Sort();
            //Declaration of listbox content sources
            lbxOptions.ItemsSource = optionActivities;
            lbxSelected.ItemsSource = selectedActivities;
        }

        private void LbxOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //txtDescription.Text = optionActivities[listBoxIndex()].Description;//Updates description
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int index = OptionsBoxIndex();//Locates the index of the selected item in the options list
                for (int i = 0; i < selectedActivities.Count; i++)//Loops through all the selected activities
                {
                    if(selectedActivities[i].ActivityDate == optionActivities[index].ActivityDate)//If the selected option and a previously selected activity have the same dates
                    {
                        MessageBox.Show("DATE CONFLICT BETWEEN " + optionActivities[index] + " AND " + selectedActivities[i]);//Displays an alert that informs the user of date clashes
                    }
                }
            cost += optionActivities[index].Cost;
            lblTotalCost.Content = cost;
            selectedActivities.Add(optionActivities[index]);//Adds the selected option to selectedActivities list
            optionActivities.Remove(optionActivities[index]);//Removes the option from optionActivities list
            lbxSelected.Items.Refresh();//Refreshes both lists
            lbxOptions.Items.Refresh();
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int index = SelectedBoxIndex();//Locates the index of the selected item in the selected list
            cost -= selectedActivities[index].Cost;
            lblTotalCost.Content = cost;
            optionActivities.Add(selectedActivities[index]);
            selectedActivities.Remove(selectedActivities[index]);
            lbxOptions.Items.Refresh();
            lbxSelected.Items.Refresh();
        }
        private int OptionsBoxIndex()
        {
            int counter = -1;
            do
            {
                counter++;
            } while (optionActivities[counter].ToString() != lbxOptions.SelectedItem.ToString());
            return counter;
        }
        private int SelectedBoxIndex()
        {
            int counter = -1;
            do
            {
                counter++;
            } while (selectedActivities[counter].ToString() != lbxSelected.SelectedItem.ToString());
            return counter;
        }

        private void radioLand_Checked(object sender, RoutedEventArgs e)
        {
            lbxOptions.ItemsSource = null;
            lbxOptions.Items.Clear();
            int counter = 0;
            do
            {
                if (optionActivities[counter].TypeOfActivity == (Activity.ActivityType)activityType.Land)
                {
                    lbxOptions.Items.Add(optionActivities[counter]);
                }
                counter++;
            }
            while (optionActivities.Count > counter);

        }

        private void radioWater_Checked(object sender, RoutedEventArgs e)
        {
            lbxOptions.ItemsSource = null;
            lbxOptions.Items.Clear();
            int counter = 0;
            do
            {
                if (optionActivities[counter].TypeOfActivity == (Activity.ActivityType)activityType.Water)
                {
                    lbxOptions.Items.Add(optionActivities[counter]);
                }
                counter++;
            }
            while (optionActivities.Count > counter);
        }

        private void radioAir_Checked(object sender, RoutedEventArgs e)
        {
            lbxOptions.ItemsSource = null;
            lbxOptions.Items.Clear();
            int counter = 0;
            do
            {
                if (optionActivities[counter].TypeOfActivity == (Activity.ActivityType)activityType.Air)
                {
                    lbxOptions.Items.Add(optionActivities[counter]);
                }
                counter++;
            }
            while (optionActivities.Count > counter);
        }

        private void radioAll_Checked(object sender, RoutedEventArgs e)
        {
            lbxOptions.ItemsSource = null;
            lbxOptions.Items.Clear();
            lbxOptions.ItemsSource = optionActivities;
        }
    }
}
