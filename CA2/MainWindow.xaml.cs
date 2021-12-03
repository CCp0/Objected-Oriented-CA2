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

        List<Activity> allActivities = new List<Activity>();
        enum activityTypes
        {
            Treking,
            MountainBiking = 0,
            Abseiling = 0,
            Kayaking,
            Surfing = 1,
            Sailing = 1,
            Parachuting,
            HangGliding = 2,
            HelicopterTour = 2
        }
        public void ListPopulation()
        {
            //Declaration of arrays
            string[,] options = { { "Treking", "All day walking, up the moutains, then some more walking." }, { "Kayaking", "Half day lakeland kayak with island picnic" }, { "Parachuting", "Half day falling, all day screaming" }, {"Mountain Biking", "Half day cycle from France to Dublin with a great geography lesson at the end" }, { "Surfing", "Quarter day seaside surf with some hot chocolate after"}, { "Hang Gliding", "'This isn't flying, this is falling with style!' for a half day" }, { "Abseiling", "Half a day being spiderman"}, {"Sailing", "Half day on a boat, but a pirate for life"}, {"Helicopter Tour", "Quarter day of flying, or things getting smaller depending on your depth perception...Dougal"}};
            DateTime[] dates = new DateTime[options.GetLength(0)];
            //Declaration of variables
            Random random = new Random();
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < options.GetLength(0); i++ )
            {
                dates[i] = currentDate.AddDays(random.Next(1,7));
                allActivities.Add(new Activity() { Name = options[i,0], ActivityDate = dates[i], Cost = random.Next(3000, 9000) / 100, Description = options[i, 1] });
            }

            lbxOptions.ItemsSource = allActivities;

        }

        private void LbxOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxOptions.SelectedItem = allActivities;

        }
    }
}
