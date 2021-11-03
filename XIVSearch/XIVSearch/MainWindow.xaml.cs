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
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Threading;

namespace XIVSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DoubleAnimation fadeFrameFrom = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15));
        DoubleAnimation fadeFrameTo = new DoubleAnimation(1, TimeSpan.FromSeconds(0.15));
        DoubleAnimation fadeSidebarIconFrom = new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.15));
        DoubleAnimation fadeSidebarIconTo = new DoubleAnimation(1, TimeSpan.FromSeconds(0.15));

        Grid CurrentActiveGrid;
        Image CurrentActiveIcon;

        private JObject Data;
        public MainWindow()
        {
            InitializeComponent();
            string sdata = Properties.Resources.data;
            Data = JObject.Parse(sdata);

            CurrentActiveGrid = MenuFrame;
            CurrentActiveIcon = SidebarMenu;
        }

        // Sidebar
        private void SwitchFrame(Grid To, Image Icon)
        {
            if (CurrentActiveGrid != To)
            {
                CurrentActiveGrid.BeginAnimation(OpacityProperty, fadeFrameFrom);
                CurrentActiveIcon.BeginAnimation(OpacityProperty, fadeSidebarIconFrom);
                To.BeginAnimation(OpacityProperty, fadeFrameTo);
                CurrentActiveGrid.IsEnabled = false;
                To.IsEnabled = true;
                CurrentActiveGrid = To;
                CurrentActiveIcon = Icon;
            }
        }

        private void SidebarCSearch_Click(object sender, RoutedEventArgs e) { SwitchFrame(CharSearchFrame, SidebarCSearch); }
        private void SidebarMenu_Click(object sender, RoutedEventArgs e) { SwitchFrame(MenuFrame, SidebarMenu); }
        private void SidebarIcon_MouseEnter(object sender, MouseEventArgs e) { ((Image)sender).BeginAnimation(OpacityProperty, fadeSidebarIconTo); }
        private void SidebarIcon_MouseLeave(object sender, MouseEventArgs e) { if (CurrentActiveIcon != ((Image)sender)) ((Image)sender).BeginAnimation(OpacityProperty, fadeSidebarIconFrom); }

        // Character Searching
        private void CharSearchFind_Click(object sender, RoutedEventArgs e)
        {
            CharSearchFindLabel.Content = "Searching...";
            CharSearchFrame.IsEnabled = false;

            try
            {
                CharSearchResults.Items.Clear();

                HttpClient Client = new HttpClient();
                string Result = Client.GetAsync("https://xivapi.com/character/search?name=" + CharSearchBox.Text).Result.Content.ReadAsStringAsync().Result;

                JObject JSON = JObject.Parse(Result);
                if ((string)JSON["Error"] != null) throw new Exception("The Lodestone is currently having issues/maintenance");
                if (!(bool)JSON["Pagination"]["Results"]) throw new Exception("That character probably doesn't exist");

                JToken Results = JSON["Results"];

                foreach (var user in Results) 
                {
                    ListBoxItem entry = new ListBoxItem();
                    entry.Width = Results.Count() > 13 ? 350 : 371;
                    entry.Background = new SolidColorBrush(Color.FromRgb(44, 53, 112));
                    entry.Foreground = new SolidColorBrush(Colors.White);
                    entry.Cursor = Cursors.Hand;
                    entry.Content = String.Format("{0} - {1}", (string)user["ID"], (string)user["Server"]);
                    entry.FontFamily = new FontFamily("Dubai");
                    entry.FontSize = 14;
                    entry.HorizontalAlignment = HorizontalAlignment.Left;
                    CharSearchResults.Items.Add(entry);
                }

                CharSearchResultsHeader.Visibility = Visibility.Visible;
            }
            catch (Exception error)
            {
                CSearchErrorMessage.Content = error.Message;
                CSearchErrorFrame.Visibility = Visibility.Visible;
            }

            CharSearchFindLabel.Content = "Search";
            CharSearchFrame.IsEnabled = true;
        }

        private void CharSearchEntryClick(object sender, SelectionChangedEventArgs e) {

            if (CharSearchResults.SelectedIndex > -1)
            {
                string[] name = ((string)((ListBoxItem)CharSearchResults.SelectedItem).Content).Split('-');
                DisplayCharacter(name[0].Trim());
            }
        }

        private void DisplayCharacter(string character)
        {
            try
            {
                HttpClient Client = new HttpClient();
                string Result = Client.GetAsync("https://xivapi.com/character/" + character + "?data=FC").Result.Content.ReadAsStringAsync().Result;

                string sdata = Properties.Resources.data;
                Data = JObject.Parse(sdata);

                //string Result = Properties.Resources.me;
                JObject JSON = JObject.Parse(Result);
                if ((string)JSON["Error"] != null) throw new Exception("The Lodestone is currently having issues");

                JToken Character = JSON["Character"];
                JToken FreeCompany = JSON["FreeCompany"];

                // General
                CharacterName.Content = Character["Name"];
                CharacterWorld.Content = string.Format("{0} ({1})", Character["Server"], Character["DC"]);
                CharacterCard.Source = new BitmapImage(new Uri((string)Character["Portrait"]));
                CharacterGender.Source = new BitmapImage(new Uri((string)Character["Gender"] == "2" ? "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/120/facebook/304/female-sign_2640-fe0f.png" : "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/120/facebook/304/male-sign_2642-fe0f.png"));

                // General - Job
                JToken ActiveJob = Character["ActiveClassJob"]["UnlockedState"];
                CharacterJob.Content = ActiveJob["Name"];
                CharacterJobIcon.Source = new BitmapImage(new Uri((string)Data["JobList"][(string)ActiveJob["ID"]]["Icon"]));
                CharacterJobLevel.Content = "Lv. " + Character["ActiveClassJob"]["Level"];

                // Set gradient for banner based on job
                LinearGradientBrush JobGradient = new LinearGradientBrush();
                JobGradient.StartPoint = new Point(0, 0);
                JobGradient.EndPoint = new Point(0, 1);
                switch ((string)Data["JobList"][(string)ActiveJob["ID"]]["Type"])
                {
                    case "dps":
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 6, 6), 0));
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(172, 54, 56), 0.3));
                        break;
                    case "tank":
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(26, 39, 100), 0));
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(44, 58, 128), 0.3));
                        break;
                    case "healer":
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(39, 110, 18), 0));
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(62, 145, 39), 0.3));
                        break;
                    case "crafter":
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(73, 49, 128), 0));
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(109, 77, 183), 0.3));
                        break;
                    case "gatherer":
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(183, 108, 33), 0));
                        JobGradient.GradientStops.Add(new GradientStop(Color.FromRgb(224, 179, 25), 0.3));
                        break;
                }
                CharacterBanner.Background = JobGradient;

                // Race
                CharacterRace.Content = (string)Data["CharacterRaces"][(string)Character["Race"]];
                CharacterRaceClan.Content = (string)Data["CharacterTribes"][(string)Character["Tribe"]];
                CharacterNameday.Content = (string)Character["Nameday"];
                CharacterCity.Source = new BitmapImage(new Uri((string)Data["CharacterTown"][(string)Character["Town"]]));
                CharacterGuardian.Source = new BitmapImage(new Uri((string)Data["CharacterGuardian"][(string)Character["GuardianDeity"]]));

                // Grand Company
                if (Character["GrandCompany"].HasValues)
                {
                    string NameID = (string)Character["GrandCompany"]["NameID"]; // company ID
                    JToken Company = Data["GrandCompanies"][NameID]; // company data
                    JToken Rank = Company["Rank"][(string)Character["GrandCompany"]["RankID"]]; // rank data

                    // Set gradient for Grand Company colours
                    LinearGradientBrush GCGradient = new LinearGradientBrush();
                    GCGradient.StartPoint = new Point(0, 0);
                    GCGradient.EndPoint = new Point(0, 1);
                    switch (NameID)
                    {
                        case "1": // storm
                            GCGradient.GradientStops.Add(new GradientStop(Color.FromRgb(120, 38, 51), 0));
                            GCGradient.GradientStops.Add(new GradientStop(Color.FromRgb(235, 27, 51), 1));
                            break;
                        case "2": // serpent
                            GCGradient.GradientStops.Add(new GradientStop(Color.FromRgb(187, 129, 19), 0));
                            GCGradient.GradientStops.Add(new GradientStop(Color.FromRgb(255, 169, 0), 1));
                            break;
                        case "3": // flame
                            GCGradient.GradientStops.Add(new GradientStop(Color.FromRgb(50, 55, 56), 0));
                            GCGradient.GradientStops.Add(new GradientStop(Color.FromRgb(92, 99, 100), 1));
                            break;
                    }

                    CharacterGCBanner.Background = GCGradient;
                    CharacterGC.Content = (string)Company["Company"];
                    CharacterGC.Foreground = new SolidColorBrush(Color.FromRgb(255, 197, 0));
                    CharacterGCRank.Content = (string)Rank["Name"];
                    CharacterGCRank.Foreground = new SolidColorBrush(Colors.White);
                    CharacterGCLogo.Source = new BitmapImage(new Uri((string)Rank["Icon"]));
                }

                SwitchFrame(CharacterFrame, SidebarCSearch);
            }
            catch (Exception error)
            {
                CSearchErrorMessage.Content = error.Message;
                CSearchErrorFrame.Visibility = Visibility.Visible;
            }
        }
    }
}
