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
        List<Activity> filteredActivities = new List<Activity>();
        decimal cost = 0;//The total cost of all selected activities
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
                Cost = random.Next(3000, 9000) / 100m,//Sets a random cost between 30 and 90 euro
                Description = "All day walking, up the moutains, then some more walking.",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            optionActivities.Add(new Activity()
            {
                Name = "Kayaking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Half day lakeland kayak with island picnic",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            optionActivities.Add(new Activity()
            {
                Name = "Parachuting",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Half a day falling, all day screaming",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            optionActivities.Add(new Activity()
            {
                Name = "Mountain Biking",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Half day cycle from France to Dublin with a great geography lesson at the end",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            optionActivities.Add(new Activity()
            {
                Name = "Surfing",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Quarter day seaside surf with some hot chocolate after",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            optionActivities.Add(new Activity()
            {
                Name = "Hang Gliding",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "'This isn't flying, this is falling with style!'...for a half day",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            optionActivities.Add(new Activity()
            {
                Name = "Abseiling",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Half a day being spiderman",
                TypeOfActivity = (Activity.ActivityType)activityType.Land
            });
            optionActivities.Add(new Activity()
            {
                Name = "Sailing",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Half day on a boat, but a pirate for life",
                TypeOfActivity = (Activity.ActivityType)activityType.Water
            });
            optionActivities.Add(new Activity()
            {
                Name = "Helicopter Tour",
                ActivityDate = currentDate.AddDays(random.Next(1, 7)),
                Cost = random.Next(3000, 9000) / 100m,
                Description = "Quarter day of flying; or, as things get smaller, an iconic Father Ted scene",
                TypeOfActivity = (Activity.ActivityType)activityType.Air
            });
            optionActivities.Sort();//Using IComparable, sorts by date
            radioAll.IsChecked = true;//Sets the itemsource of the options listbox
        }

        private void LbxOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selected = lbxOptions.SelectedItem as Activity;//The selected activity object
            if (selected != null)//If the selected option is removed / not there
            {
                txtDescription.Text = selected.Description;//Updates description
            }
        }
        private void LbxSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selected = lbxSelected.SelectedItem as Activity;//The selected activity object
            if (selected != null)//If the selected option is removed / not there
            {
                txtDescription.Text = selected.Description;//Updates description
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Activity selected = lbxOptions.SelectedItem as Activity;//Show the selected activity object
                bool validActivity = true;//Checks if the selected activity is able to be added
                if (selected != null)
                {
                    for (int i = 0; i < selectedActivities.Count; i++)//Loops through all the selected activities
                    {
                        if (selectedActivities[i].ActivityDate == selected.ActivityDate)//If the selected option and a previously selected activity have the same dates
                        {
                            MessageBox.Show("DATE CONFLICT BETWEEN " + selected + " AND " + selectedActivities[i]);//Displays an alert that informs the user of date clashes
                            validActivity = false;//Sets bool to false so no change occurs in the lists
                        }
                    }
                    if (validActivity == true && selected != null)//If there is no date conflict
                    {
                        cost += selected.Cost;//Adds to the total cost
                        lblTotalCost.Content = cost;//Displays new cost
                        selectedActivities.Add(selected);//Adds the selected option to selectedActivities list
                        optionActivities.Remove(selected);//Removes the option from optionActivities list
                        FilterRefresh();//Filtered list checking
                        lbxSelected.ItemsSource = null;//Clears the selected itemsource
                        lbxSelected.ItemsSource = selectedActivities;//Sets a new itemsource
                    }
                }

                else if (selected == null)
                {
                    MessageBox.Show("Click a valid option and use the appropriate button");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"The following error has occurred - {error}");
            }
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Activity selected = lbxSelected.SelectedItem as Activity;//Show the selected activity object
            if (selected != null)
            {
                cost -= selected.Cost;//Deducts from total cost
                lblTotalCost.Content = cost;//Displays new cost
                optionActivities.Add(selected);//Adds the selected option to the options list
                selectedActivities.Remove(selected);//Removes the selected option from the selected options list
                FilterRefresh();//Filtered list checking
                lbxSelected.ItemsSource = null;//Clears the selected itemsource
                lbxSelected.ItemsSource = selectedActivities;//Sets a new itemsource
            }
        }
        
        private void FilterRefresh()
        {   //Determines which list, filtered or unfiltered, we use
            if (radioAir.IsChecked.Value == true)
            {
                Filter(Activity.ActivityType.Air);
            }
            if (radioLand.IsChecked.Value == true)
            {
                Filter(Activity.ActivityType.Land);
            }
            if (radioWater.IsChecked.Value == true)
            {
                Filter(Activity.ActivityType.Water);
            }
            if (radioAll.IsChecked.Value == true)
            {
                lbxOptions.ItemsSource = null;//Clears the options itemsource
                lbxOptions.ItemsSource = optionActivities;//Sets a new itemsource
            }
        }

        private void Filter(Activity.ActivityType type)
        {
            lbxOptions.ItemsSource = null;
            filteredActivities.Clear();
            foreach (Activity activity in optionActivities)
            {
                if (activity.TypeOfActivity == type)
                {
                    filteredActivities.Add(activity);
                }
            }
            lbxOptions.ItemsSource = filteredActivities;//Sets itemsource to the filtered list
        }
        //Radio button checked check
        private void radioLand_Checked(object sender, RoutedEventArgs e)
        {
            Filter(Activity.ActivityType.Land);
        }
        private void radioWater_Checked(object sender, RoutedEventArgs e)
        {
            Filter(Activity.ActivityType.Water);
        }
        private void radioAir_Checked(object sender, RoutedEventArgs e)
        {
            Filter(Activity.ActivityType.Air);
        }
        private void radioAll_Checked(object sender, RoutedEventArgs e)
        {
            lbxOptions.ItemsSource = null;
            lbxOptions.ItemsSource = optionActivities;
        }
    }
}
