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
using System.Diagnostics;

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

        private void SetupFrames(Grid[] frames)
        {
            foreach (Grid g in frames)
            {
                g.Visibility = Visibility.Visible;
                g.Opacity = 0;
                g.IsEnabled = false;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            string sdata = Properties.Resources.data;
            Data = JObject.Parse(sdata);

            CurrentActiveGrid = MenuFrame;
            CurrentActiveIcon = SidebarMenu;

            MenuFrame.Visibility = Visibility.Visible;
            MenuFrame.Opacity = 1;
            MenuFrame.IsEnabled = true;

            SetupFrames(new Grid[] { CharacterFrame, CharSearchFrame, ItemSearchFrame, SettingsFrame});

            TopographyFilter.Visibility = Visibility.Visible;
        }

        // Sidebar
        private void SwitchFrame(Grid To, Image Icon)
        {
            if (CurrentActiveGrid != To)
            {
                CurrentActiveGrid.BeginAnimation(OpacityProperty, fadeFrameFrom);
                CurrentActiveIcon.BeginAnimation(OpacityProperty, fadeSidebarIconFrom);
                CurrentActiveGrid.Visibility = Visibility.Hidden;
                To.Visibility = Visibility.Visible;
                To.Opacity = 0;
                To.BeginAnimation(OpacityProperty, fadeFrameTo);
                CurrentActiveGrid.IsEnabled = false;
                To.IsEnabled = true;
                CurrentActiveGrid = To;
                CurrentActiveIcon = Icon;
            }
        }

        private void SidebarCSearch_MouseLeftButtonUp(object sender, RoutedEventArgs e) { SwitchFrame(CharSearchFrame, SidebarCSearch); }
        private void SidebarMenu_MouseLeftButtonUp(object sender, RoutedEventArgs e) { SwitchFrame(MenuFrame, SidebarMenu); }
        private void SidebarSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e){ SwitchFrame(ItemSearchFrame, SidebarSearch); }
        private void SidebarExpand_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) { SwitchFrame(SettingsFrame, SidebarSettings); }
        private void SidebarIcon_MouseEnter(object sender, MouseEventArgs e) { ((Image)sender).BeginAnimation(OpacityProperty, fadeSidebarIconTo); }
        private void SidebarIcon_MouseLeave(object sender, MouseEventArgs e) { if (CurrentActiveIcon != ((Image)sender)) ((Image)sender).BeginAnimation(OpacityProperty, fadeSidebarIconFrom); }

        // Character Searching
        private void CharSearchFind_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            CharSearchFrame.IsEnabled = false;

            try
            {
                CharSearchResults.Items.Clear();

                HttpClient Client = new HttpClient();
                string Result = Client.GetAsync("https://xivapi.com/character/search?name=" + CharSearchBox.Text).Result.Content.ReadAsStringAsync().Result;

                JObject JSON = JObject.Parse(Result);
                if ((string)JSON["Error"] != null) throw new Exception("The Lodestone is currently unavailable");
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
                //string Result = Client.GetAsync("https://xivapi.com/character/" + character + "?data=FC").Result.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(Result);

                string sdata = Properties.Resources.data;
                Data = JObject.Parse(sdata);

                string Result = Properties.Resources.me;
                JObject JSON = JObject.Parse(Result);
                if ((string)JSON["Error"] != null) throw new Exception("The Lodestone is currently unavailable");

                JToken Character = JSON["Character"];
                JToken GrandCompany = Character["GrandCompany"];
                JToken FreeCompany = JSON["FreeCompany"];
                JToken Job = Character["ClassJobs"];

                // General
                CharacterName.Content = Character["Name"] + (FreeCompany.HasValues ? "< " + FreeCompany["Tag"] + " >" : "");
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

                // Free Company
                if (FreeCompany.HasValues)
                {
                    CharacterFCFrame.Visibility = Visibility.Visible;
                    CharacterFC.Content = (string)FreeCompany["Name"];
                    CharacterFCTag.Content = " < " + (string)FreeCompany["Tag"] + " >";
                    CharacterFCCrest.Source = new BitmapImage(new Uri((string)FreeCompany["Crest"].Last));
                }

                // Job
                int LevelCap = 80;
                SolidColorBrush GoldLevel = new SolidColorBrush(Color.FromRgb(255, 197, 0));
                int Level = (int)Job[0]["Level"];

                CharacterJobPLDLevel.Content = Level; // Paladin
                if (Level < 30) CharacterJobPLD.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/U/F5JzG9RPIKFSogtaKNBk455aYA.png"));
                if (Level == LevelCap) CharacterJobPLDLevel.Foreground = GoldLevel;

                Level = (int)Job[1]["Level"];
                CharacterJobWARLevel.Content = Level; // Warrior
                if (Level < 30) CharacterJobWAR.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/N/St9rjDJB3xNKGYg-vwooZ4j6CM.png"));
                if (Level == LevelCap) CharacterJobWARLevel.Foreground = GoldLevel;

                Level = (int)Job[2]["Level"];
                CharacterJobDRKLevel.Content = Level; // Dark Knight
                if (Level == LevelCap) CharacterJobDRKLevel.Foreground = GoldLevel;

                Level = (int)Job[3]["Level"];
                CharacterJobGNBLevel.Content = Level; // Gunbreaker
                if (Level == LevelCap) CharacterJobGNBLevel.Foreground = GoldLevel;

                Level = (int)Job[8]["Level"];
                CharacterJobWHMLevel.Content = Level; // White Mage
                if (Level < 30) CharacterJobWHM.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/s/gl62VOTBJrm7D_BmAZITngUEM8.png"));
                if (Level == LevelCap) CharacterJobWHMLevel.Foreground = GoldLevel;

                Level = (int)Job[9]["Level"];
                CharacterJobSCHLevel.Content = Level; // Scholar
                if (Level == LevelCap) CharacterJobSCHLevel.Foreground = GoldLevel;

                Level = (int)Job[10]["Level"];
                CharacterJobASTLevel.Content = Level; // Astrologian
                if (Level == LevelCap) CharacterJobASTLevel.Foreground = GoldLevel;

                Level = (int)Job[4]["Level"];
                CharacterJobMNKLevel.Content = Level; // Monk
                if (Level < 30) CharacterJobMNK.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/V/iW7IBKQ7oglB9jmbn6LwdZXkWw.png"));
                if (Level == LevelCap) CharacterJobMNKLevel.Foreground = GoldLevel;

                Level = (int)Job[5]["Level"];
                CharacterJobDRGLevel.Content = Level; // Dragoon
                if (Level < 30) CharacterJobDRG.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/k/tYTpoSwFLuGYGDJMff8GEFuDQs.png"));
                if (Level == LevelCap) CharacterJobDRGLevel.Foreground = GoldLevel;

                Level = (int)Job[6]["Level"];
                CharacterJobNINLevel.Content = Level; // Ninja
                if (Level < 30) CharacterJobNIN.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/y/wdwVVcptybfgSruoh8R344y_GA.png"));
                if (Level == LevelCap) CharacterJobNINLevel.Foreground = GoldLevel;

                Level = (int)Job[7]["Level"];
                CharacterJobSAMLevel.Content = Level; // Samurai
                if (Level == LevelCap) CharacterJobSAMLevel.Foreground = GoldLevel;

                Level = (int)Job[11]["Level"];
                CharacterJobBRDLevel.Content = Level; // Bard
                if (Level < 30) CharacterJobBRD.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/Q/ZpqEJWYHj9SvHGuV9cIyRNnIkk.png"));
                if (Level == LevelCap) CharacterJobBRDLevel.Foreground = GoldLevel;

                Level = (int)Job[12]["Level"];
                CharacterJobMCHLevel.Content = Level; // Machinist
                if (Level == LevelCap) CharacterJobMCHLevel.Foreground = GoldLevel;

                Level = (int)Job[13]["Level"];
                CharacterJobDNCLevel.Content = Level; // Dancer
                if (Level == LevelCap) CharacterJobDNCLevel.Foreground = GoldLevel;

                Level = (int)Job[14]["Level"];
                CharacterJobBLMLevel.Content = Level; // Black Mage
                if (Level < 30) CharacterJobBLM.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/4/IM3PoP6p06GqEyReygdhZNh7fU.png"));
                if (Level == LevelCap) CharacterJobBLMLevel.Foreground = GoldLevel;

                Level = (int)Job[15]["Level"];
                CharacterJobSMNLevel.Content = Level; // Summoner
                if (Level < 30) CharacterJobSMN.Source = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/e/VYP1LKTDpt8uJVvUT7OKrXNL9E.png"));
                if (Level == LevelCap) CharacterJobSMNLevel.Foreground = GoldLevel;

                Level = (int)Job[16]["Level"];
                CharacterJobRDMLevel.Content = Level; // Red Mage
                if (Level == LevelCap) CharacterJobRDMLevel.Foreground = GoldLevel;

                Level = (int)Job[17]["Level"];
                CharacterJobBLULevel.Content = Level; // Blue Mage
                if (Level == LevelCap) CharacterJobBLULevel.Foreground = GoldLevel;

                Level = (int)Job[18]["Level"];
                CharacterJobCRPLevel.Content = Level; // Carpenter
                if (Level == LevelCap) CharacterJobCRPLevel.Foreground = GoldLevel;

                Level = (int)Job[19]["Level"];
                CharacterJobBSMLevel.Content = Level; // Blacksmith
                if (Level == LevelCap) CharacterJobBSMLevel.Foreground = GoldLevel;

                Level = (int)Job[20]["Level"];
                CharacterJobARMLevel.Content = Level; // Armorer
                if (Level == LevelCap) CharacterJobARMLevel.Foreground = GoldLevel;

                Level = (int)Job[21]["Level"];
                CharacterJobGSMLevel.Content = Level; // Goldsmith
                if (Level == LevelCap) CharacterJobGSMLevel.Foreground = GoldLevel;

                Level = (int)Job[22]["Level"];
                CharacterJobLTWLevel.Content = Level; // Leatherworker
                if (Level == LevelCap) CharacterJobLTWLevel.Foreground = GoldLevel;

                Level = (int)Job[23]["Level"];
                CharacterJobWVRLevel.Content = Level; // Weaver
                if (Level == LevelCap) CharacterJobWVRLevel.Foreground = GoldLevel;

                Level = (int)Job[24]["Level"];
                CharacterJobALCLevel.Content = Level; // Alchemist
                if (Level == LevelCap) CharacterJobALCLevel.Foreground = GoldLevel;

                Level = (int)Job[25]["Level"];
                CharacterJobCULLevel.Content = Level; // Culinarian
                if (Level == LevelCap) CharacterJobCULLevel.Foreground = GoldLevel;

                Level = (int)Job[26]["Level"];
                CharacterJobMINLevel.Content = Level; // Miner
                if (Level == LevelCap) CharacterJobMINLevel.Foreground = GoldLevel;

                Level = (int)Job[27]["Level"];
                CharacterJobBTNLevel.Content = Level; // Botanist
                if (Level == LevelCap) CharacterJobBTNLevel.Foreground = GoldLevel;

                Level = (int)Job[28]["Level"];
                CharacterJobFSHLevel.Content = Level; // Fisher
                if (Level == LevelCap) CharacterJobFSHLevel.Foreground = GoldLevel;

                Level = (int)Character["ClassJobsElemental"]["Level"];
                CharacterJobEurekaLevel.Content = Level; // Eureka
                if (Level == 60) CharacterJobEurekaLevel.Foreground = GoldLevel;

                Level = (int)Character["ClassJobsBozjan"]["Level"];
                CharacterJobBozjaLevel.Content = Level; // Bozja
                if (Level == 25) CharacterJobBozjaLevel.Foreground = GoldLevel;

                SwitchFrame(CharacterFrame, SidebarCSearch);
            }
            catch (Exception error)
            {
                CSearchErrorMessage.Content = error.Message;
                CSearchErrorFrame.Visibility = Visibility.Visible;
            }
        }

        // Settings
        private void SettingsGitHub_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/minokah/XIVSearch");
        }
    }
}
