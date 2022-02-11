using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net.Http;
using Newtonsoft.Json.Linq;
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

        // Job Icons (and extras)
        BitmapImage JobGLA = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/U/F5JzG9RPIKFSogtaKNBk455aYA.png"));
        BitmapImage JobPLD = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/E/d0Tx-vhnsMYfYpGe9MvslemEfg.png"));
        BitmapImage JobMRD = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/N/St9rjDJB3xNKGYg-vwooZ4j6CM.png"));
        BitmapImage JobWAR = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/y/A3UhbjZvDeN3tf_6nJ85VP0RY0.png"));
        BitmapImage JobDRK = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/l/5CZEvDOMYMyVn2td9LZigsgw9s.png"));
        BitmapImage JobGNB = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/8/hg8ofSSOKzqng290No55trV4mI.png"));
        BitmapImage JobCNJ = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/s/gl62VOTBJrm7D_BmAZITngUEM8.png"));
        BitmapImage JobWHM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/7/i20QvSPcSQTybykLZDbQCgPwMw.png"));
        BitmapImage JobSCH = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/7/WdFey0jyHn9Nnt1Qnm-J3yTg5s.png"));
        BitmapImage JobAST = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/1/erCgjnMSiab4LiHpWxVc-tXAqk.png"));
        BitmapImage JobSGE = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/g/_oYApASVVReLLmsokuCJGkEpk0.png"));
        BitmapImage JobPGL = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/V/iW7IBKQ7oglB9jmbn6LwdZXkWw.png"));
        BitmapImage JobMNK = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/K/HW6tKOg4SOJbL8Z20GnsAWNjjM.png"));
        BitmapImage JobLNC = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/k/tYTpoSwFLuGYGDJMff8GEFuDQs.png"));
        BitmapImage JobDRG = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/m/gX4OgBIHw68UcMU79P7LYCpldA.png"));
        BitmapImage JobROG = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/y/wdwVVcptybfgSruoh8R344y_GA.png"));
        BitmapImage JobNIN = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/0/Fso5hanZVEEAaZ7OGWJsXpf3jw.png"));
        BitmapImage JobSAM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/m/KndG72XtCFwaq1I1iqwcmO_0zc.png"));
        BitmapImage JobRPR = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/7/cLlXUaeMPJDM2nBhIeM-uDmPzM.png"));
        BitmapImage JobARC = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/Q/ZpqEJWYHj9SvHGuV9cIyRNnIkk.png"));
        BitmapImage JobBRD = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/F/KWI-9P3RX_Ojjn_mwCS2N0-3TI.png"));
        BitmapImage JobMCH = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/E/vmtbIlf6Uv8rVp2YFCWA25X0dc.png"));
        BitmapImage JobDNC = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/t/HK0jQ1y7YV9qm30cxGOVev6Cck.png"));
        BitmapImage JobTHM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/4/IM3PoP6p06GqEyReygdhZNh7fU.png"));
        BitmapImage JobBLM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/P/V01m8YRBYcIs5vgbRtpDiqltSE.png"));
        BitmapImage JobACN = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/e/VYP1LKTDpt8uJVvUT7OKrXNL9E.png"));
        BitmapImage JobSMN = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/h/4ghjpyyuNelzw1Bl0sM_PBA_FE.png"));
        BitmapImage JobRDM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/q/s3MlLUKmRAHy0pH57PnFStHmIw.png"));
        BitmapImage JobBLU = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/p/jdV3RRKtWzgo226CC09vjen5sk.png"));
        BitmapImage JobCRP = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/v/YCN6F-xiXf03Ts3pXoBihh2OBk.png"));
        BitmapImage JobBSM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/5/EEHVV5cIPkOZ6v5ALaoN5XSVRU.png"));
        BitmapImage JobARM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/G/Rq5wcK3IPEaAB8N-T9l6tBPxCY.png"));
        BitmapImage JobGSM = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/L/LbEjgw0cwO_2gQSmhta9z03pjM.png"));
        BitmapImage JobLTW = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/b/ACAcQe3hWFxbWRVPqxKj_MzDiY.png"));
        BitmapImage JobWVR = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/X/E69jrsOMGFvFpCX87F5wqgT_Vo.png"));
        BitmapImage JobALC = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/C/bBVQ9IFeXqjEdpuIxmKvSkqalE.png"));
        BitmapImage JobCUL = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/m/1kMI2v_KEVgo30RFvdFCyySkFo.png"));
        BitmapImage JobMIN = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/A/aM2Dd6Vo4HW_UGasK7tLuZ6fu4.png"));
        BitmapImage JobBTN = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/I/jGRnjIlwWridqM-mIPNew6bhHM.png"));
        BitmapImage JobFSH = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/x/B4Azydbn7Prubxt7OL9p1LZXZ0.png"));
        BitmapImage JobEureka = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/d/db/061833.png/32px-061833.png"));
        BitmapImage JobBozja = new BitmapImage(new Uri("https://static.wikia.nocookie.net/finalfantasy/images/0/01/FFXIV_Bozja_Icon.png/revision/latest"));

        // City States
        BitmapImage CityLominsa = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/j/Xlz3DzGOKmwiDGho5aGWaudRNI.png"));
        BitmapImage CityGridania = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/u/ZHuDKgNULSbEA_VTXdjeA9MlEs.png"));
        BitmapImage CityUldah = new BitmapImage(new Uri("https://img.finalfantasyxiv.com/lds/h/u/qXfC-BmEzWbXW3sn62HMNnD3kU.png"));

        // Guardian Deities
        BitmapImage GuardianHalone = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/e/e8/Halone_Icon.png/35px-Halone_Icon.png"));
        BitmapImage GuardianMenphina = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/6/69/Menphina_Icon.png/35px-Menphina_Icon.png"));
        BitmapImage GuardianThaliak = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/7/7f/Thaliak_Icon.png/35px-Thaliak_Icon.png"));
        BitmapImage GuardianNymeia = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/f/fc/Nymeia_Icon.png/35px-Nymeia_Icon.png"));
        BitmapImage GuardianLlymlaen = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/3/3c/Llymlaen_Icon.png/35px-Llymlaen_Icon.png"));
        BitmapImage GuardianOschon = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/9/96/Oschon_Icon.png/35px-Oschon_Icon.png"));
        BitmapImage GuardianByregot = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/0/03/Byregot_Icon.png/35px-Byregot_Icon.png"));
        BitmapImage GuardianRhalgr = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/7/70/Rhalgr_Icon.png/35px-Rhalgr_Icon.png"));
        BitmapImage GuardianAzeyma = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/9/9f/Azeyma_Icon.png/35px-Azeyma_Icon.png"));
        BitmapImage GuardianNaldthal = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/9/99/Nald%27thal_Icon.png/35px-Nald%27thal_Icon.png"));
        BitmapImage GuardianNophica = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/a/ac/Nophica_Icon.png/35px-Nophica_Icon.png"));
        BitmapImage GuardianAlthyk = new BitmapImage(new Uri("https://ffxiv.gamerescape.com/w/images/thumb/2/22/Althyk_Icon.png/35px-Althyk_Icon.png"));


        private void SetupFrames(Grid[] frames)
        {
            foreach (Grid g in frames)
            {
                g.Visibility = Visibility.Visible;
                g.Opacity = 0;
                g.IsEnabled = false;
                Canvas.SetZIndex(g, -1);
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

            SetupFrames(new Grid[] { CharacterFrame, CharSearchFrame, ItemFrame, ItemSearchFrame, SettingsFrame });

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
                CurrentActiveGrid.IsEnabled = false;
                Canvas.SetZIndex(CurrentActiveGrid, -1);

                To.BeginAnimation(OpacityProperty, fadeFrameTo);
                To.Visibility = Visibility.Visible;
                To.Opacity = 0;
                To.IsEnabled = true;
                Canvas.SetZIndex(To, 0);

                CurrentActiveGrid = To;
                CurrentActiveIcon = Icon;
            }
        }

        private void SidebarCharSearch_MouseLeftButtonUp(object sender, RoutedEventArgs e) { SwitchFrame(CharSearchFrame, SidebarCharSearch); }
        private void SidebarMenu_MouseLeftButtonUp(object sender, RoutedEventArgs e) { SwitchFrame(MenuFrame, SidebarMenu); }
        private void SidebarSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) { SwitchFrame(ItemSearchFrame, SidebarSearch); }
        private void SidebarExpand_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) { SwitchFrame(SettingsFrame, SidebarSettings); }
        private void SidebarIcon_MouseEnter(object sender, MouseEventArgs e) { ((Image)sender).BeginAnimation(OpacityProperty, fadeSidebarIconTo); }
        private void SidebarIcon_MouseLeave(object sender, MouseEventArgs e) { if (CurrentActiveIcon != ((Image)sender)) ((Image)sender).BeginAnimation(OpacityProperty, fadeSidebarIconFrom); }

        // Search Entry Template
        private Grid CreateSearchEntry(int results, string name, string id, string sub, string imageurl)
        {
            Grid EntryGrid = new Grid();
            EntryGrid.Width = results > 6 ? 393 : 410;
            EntryGrid.Height = 50;
            EntryGrid.Background = new SolidColorBrush(Color.FromRgb(44, 53, 112));
            EntryGrid.Cursor = Cursors.Hand;

            Image EntryImage = new Image();
            EntryImage.Width = 50;
            EntryImage.Height = 50;
            EntryImage.Source = new BitmapImage(new Uri(imageurl));
            EntryImage.HorizontalAlignment = HorizontalAlignment.Left;

            Label EntryName = new Label();
            EntryName.Foreground = new SolidColorBrush(Colors.White);
            EntryName.FontFamily = new FontFamily("Dubai");
            EntryName.Content = name;
            EntryName.FontWeight = FontWeights.Bold;
            EntryName.Height = 50;
            EntryName.FontSize = 15;
            EntryName.Margin = new Thickness(55, 0, 0, 0);
            EntryName.HorizontalAlignment = HorizontalAlignment.Left;
            EntryName.VerticalContentAlignment = VerticalAlignment.Center;

            Label EntryID = new Label();
            EntryID.Content = id;
            EntryID.Height = 25;
            EntryID.Margin = new Thickness(0, 2, 10, 23);
            EntryID.Foreground = new SolidColorBrush(Colors.White);
            EntryID.FontFamily = new FontFamily("Dubai");
            EntryID.FontSize = 13;
            EntryID.HorizontalAlignment = HorizontalAlignment.Right;

            Label EntrySub = new Label();
            EntrySub.Content = sub;
            EntrySub.Height = 25;
            EntrySub.Margin = new Thickness(0, 17, 10, 4);
            EntrySub.Foreground = new SolidColorBrush(Colors.White);
            EntrySub.FontFamily = new FontFamily("Dubai");
            EntrySub.FontSize = 13;
            EntrySub.HorizontalAlignment = HorizontalAlignment.Right;

            EntryGrid.Children.Add(EntryImage);
            EntryGrid.Children.Add(EntryName);
            EntryGrid.Children.Add(EntryID);
            EntryGrid.Children.Add(EntrySub);

            return EntryGrid;
        }

        // Character Searching
        private void CharSearchFind_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CharSearchBox.Text == "") return;
                CharSearchResults.Items.Clear();
                CharSearchErrorFrame.Visibility = Visibility.Hidden;

                HttpClient Client = new HttpClient();
                string Result = Client.GetAsync("https://xivapi.com/character/search?name=" + CharSearchBox.Text).Result.Content.ReadAsStringAsync().Result;
                if (Result == "false") throw new Exception("XIVAPI is not currently working");

                JObject JSON = JObject.Parse(Result);
                if ((string)JSON["Error"] != null) throw new Exception("The Lodestone is currently unavailable");
                if (!(bool)JSON["Pagination"]["Results"]) throw new Exception("That character probably doesn't exist");

                JToken Results = JSON["Results"];

                foreach (var user in Results)
                {
                    ListBoxItem entry = new ListBoxItem();
                    entry.Width = Results.Count() > 17 ? 350 : 371;
                    entry.Background = new SolidColorBrush(Color.FromRgb(44, 53, 112));
                    entry.Foreground = new SolidColorBrush(Colors.White);
                    entry.Cursor = Cursors.Hand;
                    entry.Content = string.Format("{0} - {1}", (string)user["ID"], (string)user["Server"]);
                    entry.FontFamily = new FontFamily("Dubai");
                    entry.FontSize = 14;
                    entry.HorizontalAlignment = HorizontalAlignment.Left;
                    CharSearchResults.Items.Add(entry);
                }
            }
            catch (Exception error)
            {
                CharSearchErrorMessage.Content = error.Message;
                CharSearchErrorFrame.Visibility = Visibility.Visible;
            }

            CharSearchResults.UnselectAll();
            CharSearchResults.SelectedItem = -1;
        }

        private void CharSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
                //Console.WriteLine(Result);

                string sdata = Properties.Resources.data;
                Data = JObject.Parse(sdata);

                //string Result = Properties.Resources.me;
                JObject JSON = JObject.Parse(Result);
                if ((string)JSON["Error"] != null) throw new Exception("The Lodestone is currently unavailable");

                JToken Character = JSON["Character"];
                JToken GrandCompany = Character["GrandCompany"];
                JToken FreeCompany = JSON["FreeCompany"];
                JToken Job = Character["ClassJobs"];

                // General
                Console.WriteLine(FreeCompany.HasValues);
                CharacterName.Content = Character["Name"] + (FreeCompany.HasValues ? "< " + FreeCompany["Tag"] + " >" : "");
                CharacterWorld.Content = string.Format("{0} ({1})", Character["Server"], Character["DC"]);
                CharacterCard.Source = new BitmapImage(new Uri((string)Character["Portrait"]));
                CharacterGender.Source = new BitmapImage(new Uri((string)Character["Gender"] == "2" ? "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/120/facebook/304/female-sign_2640-fe0f.png" : "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/120/facebook/304/male-sign_2642-fe0f.png"));

                // General - Job
                /*
                JToken ActiveJob = Character["ActiveClassJob"]["UnlockedState"];
                //CharacterJobIcon.Source = new BitmapImage(new Uri((string)Data["JobList"][(string)ActiveJob["ID"]]["Icon"]));

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
                */

                // Race
                switch ((string)Character["Race"])
                {
                    case "1": { CharacterRace.Content = "Hyur"; ; break; }
                    case "2": { CharacterRace.Content = "Elezen"; break; }
                    case "3": { CharacterRace.Content = "Lalafell"; break; }
                    case "4": { CharacterRace.Content = "Miqo'te"; break; }
                    case "5": { CharacterRace.Content = "Roegadyn"; break; }
                    case "6": { CharacterRace.Content = "Au Ra"; break; }
                    case "7": { CharacterRace.Content = "Hrothgar"; break; }
                    case "8": { CharacterRace.Content = "Viera"; break; }
                }

                // Tribe
                switch ((string)Character["Tribe"])
                {
                    case "1": { CharacterRaceClan.Content = "Midlander"; ; break; }
                    case "2": { CharacterRaceClan.Content = "Highlander"; break; }
                    case "3": { CharacterRaceClan.Content = "Wildwood"; break; }
                    case "4": { CharacterRaceClan.Content = "Duskwight"; break; }
                    case "5": { CharacterRaceClan.Content = "Plainsfolk"; break; }
                    case "6": { CharacterRaceClan.Content = "Dunesfolk"; break; }
                    case "7": { CharacterRaceClan.Content = "Seeker of the Sun"; break; }
                    case "8": { CharacterRaceClan.Content = "Keeper of the Moon"; break; }
                    case "9": { CharacterRaceClan.Content = "Sea Wolf"; break; }
                    case "10": { CharacterRaceClan.Content = "Hellsguard"; break; }
                    case "11": { CharacterRaceClan.Content = "Raen"; break; }
                    case "12": { CharacterRaceClan.Content = "Xaela"; break; }
                    case "13": { CharacterRaceClan.Content = "Helion"; break; }
                    case "14": { CharacterRaceClan.Content = "The Lost"; break; }
                    case "15": { CharacterRaceClan.Content = "Rava"; break; }
                    case "16": { CharacterRaceClan.Content = "Veena"; break; }
                }

                CharacterNameday.Content = Character["Nameday"];

                // Starting city state
                switch ((string)Character["Town"])
                {
                    case "1":
                        {
                            CharacterCity.Source = CityLominsa;
                            CharacterCity.ToolTip = "Limsa Lominsa";
                            break;
                        }
                    case "2":
                        {
                            CharacterCity.Source = CityGridania;
                            CharacterCity.ToolTip = "Gridania";
                            break;
                        }
                    case "3":
                        {
                            CharacterCity.Source = CityUldah;
                            CharacterCity.ToolTip = "Ul'dah";
                            break;
                        }
                }

                // Guardian deity
                switch ((string)Character["GuardianDeity"])
                {
                    case "1":
                        {
                            CharacterGuardian.Source = GuardianHalone;
                            CharacterGuardian.ToolTip = "Halone, the Fury";
                            break;
                        }
                    case "2":
                        {
                            CharacterGuardian.Source = GuardianMenphina;
                            CharacterGuardian.ToolTip = "Menphina, the Lover";
                            break;
                        }
                    case "3":
                        {
                            CharacterGuardian.Source = GuardianThaliak;
                            CharacterGuardian.ToolTip = "Thaliak, the Scholar";
                            break;
                        }
                    case "4":
                        {
                            CharacterGuardian.Source = GuardianNymeia;
                            CharacterGuardian.ToolTip = "Nymeia, the Spinner";
                            break;
                        }
                    case "5":
                        {
                            CharacterGuardian.Source = GuardianLlymlaen;
                            CharacterGuardian.ToolTip = "Llymlaen, the Navigator";
                            break;
                        }
                    case "6":
                        {
                            CharacterGuardian.Source = GuardianOschon;
                            CharacterGuardian.ToolTip = "Oschon, the Wanderer";
                            break;
                        }
                    case "7":
                        {
                            CharacterGuardian.Source = GuardianByregot;
                            CharacterGuardian.ToolTip = "Byregot, the Builder";
                            break;
                        }
                    case "8":
                        {
                            CharacterGuardian.Source = GuardianRhalgr;
                            CharacterGuardian.ToolTip = "Rhalgr, the Destroyer";
                            break;
                        }
                    case "9":
                        {
                            CharacterGuardian.Source = GuardianMenphina;
                            CharacterGuardian.ToolTip = "Azeyma, the Warden";
                            break;
                        }
                    case "10":
                        {
                            CharacterGuardian.Source = GuardianNaldthal;
                            CharacterGuardian.ToolTip = "Nald'thal, the Trader";
                            break;
                        }
                    case "11":
                        {
                            CharacterGuardian.Source = GuardianNophica;
                            CharacterGuardian.ToolTip = "Nophica, the Matron";
                            break;
                        }
                    case "12":
                        {
                            CharacterGuardian.Source = GuardianAlthyk;
                            CharacterGuardian.ToolTip = "Althyk, the Keeper";
                            break;
                        }
                }


                JToken Deity = Data["CharacterGuardian"][(string)Character["GuardianDeity"]];
                CharacterGuardian.Source = new BitmapImage(new Uri(Deity["Icon"].ToString()));
                CharacterGuardian.ToolTip = Deity["Name"];

                // Grand Company
                if (Character["GrandCompany"].HasValues)
                {
                    JToken Company = Data["GrandCompanies"][(string)Character["GrandCompany"]["NameID"]]; // company data
                    JToken Rank = Company["Rank"][(string)Character["GrandCompany"]["RankID"]]; // rank data
                    CharacterGC.Source = new BitmapImage(new Uri((string)Rank["Icon"]));
                    CharacterGC.ToolTip = Rank["Name"];
                    CharacterGC.Visibility = Visibility.Visible;
                }
                else CharacterGC.Visibility = Visibility.Hidden;

                // Free Company
                if (FreeCompany.HasValues)
                {
                    CharacterFCFrame.Visibility = Visibility.Visible;
                    CharacterFC.Content = (string)FreeCompany["Name"];
                    CharacterFCTag.Content = " < " + (string)FreeCompany["Tag"] + " >";
                    CharacterFCCrest.Source = new BitmapImage(new Uri((string)FreeCompany["Crest"].Last));
                    CharacterFCFrame.Visibility = Visibility.Visible;
                }
                else CharacterFCFrame.Visibility = Visibility.Hidden;

                // Job
                int LevelCap = 90;
                SolidColorBrush GoldLevel = new SolidColorBrush(Color.FromRgb(255, 197, 0));
                SolidColorBrush WhiteText = new SolidColorBrush(Colors.White);
                int Level = (int)Job[0]["Level"];

                CharacterJobPLDLevel.Content = Level; // Paladin
                CharacterJobPLD.Source = Level >= 30 ? JobPLD : JobGLA;
                CharacterJobPLDLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[1]["Level"];
                CharacterJobWARLevel.Content = Level; // Warrior
                CharacterJobWAR.Source = Level >= 30 ? JobWAR : JobMRD;
                CharacterJobWARLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[2]["Level"];
                CharacterJobDRKLevel.Content = Level; // Dark Knight
                CharacterJobDRKLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[3]["Level"];
                CharacterJobGNBLevel.Content = Level; // Gunbreaker
                CharacterJobGNBLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[4]["Level"];
                CharacterJobWHMLevel.Content = Level; // White Mage
                CharacterJobWHM.Source = Level >= 30 ? JobWHM : JobCNJ;
                CharacterJobWHMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[5]["Level"];
                CharacterJobSCHLevel.Content = Level; // Scholar
                CharacterJobSCHLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[6]["Level"];
                CharacterJobASTLevel.Content = Level; // Astrologian
                CharacterJobASTLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[7]["Level"];
                CharacterJobSGELevel.Content = Level; // Sage
                CharacterJobSGELevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[8]["Level"];
                CharacterJobMNKLevel.Content = Level; // Monk
                CharacterJobMNK.Source = Level >= 30 ? JobMNK : JobPGL;
                CharacterJobMNKLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[9]["Level"];
                CharacterJobDRGLevel.Content = Level; // Dragoon
                CharacterJobDRG.Source = Level >= 30 ? JobDRG : JobLNC;
                CharacterJobDRGLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[10]["Level"];
                CharacterJobNINLevel.Content = Level; // Ninja
                CharacterJobNIN.Source = Level >= 30 ? JobNIN : JobROG;
                CharacterJobNINLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[11]["Level"];
                CharacterJobSAMLevel.Content = Level; // Samurai
                CharacterJobSAMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[12]["Level"];
                CharacterJobRPRLevel.Content = Level; // Reaper
                CharacterJobRPRLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[13]["Level"];
                CharacterJobBRDLevel.Content = Level; // Bard
                CharacterJobBRD.Source = Level >= 30 ? JobBRD : JobARC;
                CharacterJobBRDLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[14]["Level"];
                CharacterJobMCHLevel.Content = Level; // Machinist
                CharacterJobMCHLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[15]["Level"];
                CharacterJobDNCLevel.Content = Level; // Dancer
                CharacterJobDNCLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[16]["Level"];
                CharacterJobBLMLevel.Content = Level; // Black Mage
                CharacterJobBLM.Source = Level >= 30 ? JobBLM : JobTHM;
                CharacterJobBLMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[17]["Level"];
                CharacterJobSMNLevel.Content = Level; // Summoner
                CharacterJobSMN.Source = Level >= 30 ? JobSMN : JobACN;
                CharacterJobSMNLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[18]["Level"];
                CharacterJobRDMLevel.Content = Level; // Red Mage
                CharacterJobRDMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[19]["Level"];
                CharacterJobBLULevel.Content = Level; // Blue Mage
                CharacterJobBLULevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[20]["Level"];
                CharacterJobCRPLevel.Content = Level; // Carpenter
                CharacterJobCRPLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[21]["Level"];
                CharacterJobBSMLevel.Content = Level; // Blacksmith
                CharacterJobBSMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[22]["Level"];
                CharacterJobARMLevel.Content = Level; // Armorer
                CharacterJobARMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[23]["Level"];
                CharacterJobGSMLevel.Content = Level; // Goldsmith
                CharacterJobGSMLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[24]["Level"];
                CharacterJobLTWLevel.Content = Level; // Leatherworker
                CharacterJobLTWLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[25]["Level"];
                CharacterJobWVRLevel.Content = Level; // Weaver
                CharacterJobWVRLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[26]["Level"];
                CharacterJobALCLevel.Content = Level; // Alchemist
                CharacterJobALCLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[27]["Level"];
                CharacterJobCULLevel.Content = Level; // Culinarian
                CharacterJobCULLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[28]["Level"];
                CharacterJobMINLevel.Content = Level; // Miner
                CharacterJobMINLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[29]["Level"];
                CharacterJobBTNLevel.Content = Level; // Botanist
                CharacterJobBTNLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                Level = (int)Job[30]["Level"];
                CharacterJobFSHLevel.Content = Level; // Fisher
                CharacterJobFSHLevel.Foreground = Level == LevelCap ? GoldLevel : WhiteText;

                if (Character["ClassJobsElemental"].HasValues)
                {
                    Level = (int)Character["ClassJobsElemental"]["Level"];
                    CharacterJobEurekaLevel.Content = Level; // Eureka
                    CharacterJobEurekaLevel.Foreground = Level == 60 ? GoldLevel : WhiteText;
                }

                if (Character["ClassJobsBozjan"].HasValues && Character["ClassJobsBozjan"]["Level"].ToString() != "")
                {
                    Level = (int)Character["ClassJobsBozjan"]["Level"];
                    CharacterJobBozjaLevel.Content = Level; // Bozja
                    CharacterJobBozjaLevel.Foreground = Level == 25 ? GoldLevel : WhiteText;
                }
                else
                {
                    CharacterJobBozjaLevel.Content = "0";
                    CharacterJobBozjaLevel.Foreground = WhiteText;
                }

                SwitchFrame(CharacterFrame, SidebarCharSearch);
            }
            catch (Exception error)
            {
                CharSearchErrorMessage.Content = error.Message;
                CharSearchErrorFrame.Visibility = Visibility.Visible;
            }
        }

        // Settings
        private void SettingsGitHub_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/minokah/XIVSearch");
        }

        // Item Search
        private void ItemSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemSearchResults.SelectedIndex > -1) DisplayItem(((Label)((Grid)ItemSearchResults.SelectedItem).Children[2]).Content.ToString());
        }

        private void ItemSearchFind_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ItemSearchBox.Text == "") return;
                ItemSearchResults.Items.Clear();
                ItemSearchErrorFrame.Visibility = Visibility.Hidden;

                HttpClient Client = new HttpClient();
                string Result = Client.GetAsync("https://www.garlandtools.org/api/search.php?text=" + ItemSearchBox.Text + "&lang=en").Result.Content.ReadAsStringAsync().Result;
                if (Result == "[]") throw new Exception("That item probably doesn't exist");
                Console.WriteLine(Result);

                //string Result = Properties.Resources.items;
                JToken Results = JToken.Parse(Result);

                foreach (var item in Results) ItemSearchResults.Items.Add(CreateSearchEntry(Results.Count(), (string)item["obj"]["n"], (string)item["id"], (string)item["type"], string.Format("https://garlandtools.org/files/icons/{0}/{1}.png", (string)item["type"], (string)item["obj"]["c"])));
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                Console.WriteLine(error.Message);
                ItemSearchErrorMessage.Content = error.Message;
                ItemSearchErrorFrame.Visibility = Visibility.Visible;
            }

            ItemSearchResults.UnselectAll();
        }

        private void DisplayItem(string item)
        {
            try
            {
                HttpClient Client = new HttpClient();
                string Result = Client.GetAsync("https://www.garlandtools.org/db/doc/item/en/3/" + item + ".json").Result.Content.ReadAsStringAsync().Result;

                string sdata = Properties.Resources.data;
                Data = JObject.Parse(sdata);

                //string Result = Properties.Resources.me;
                JObject JSON = JObject.Parse(Result);
                JToken Item = JSON["item"];

                // General
                ItemName.Content = (string)Item["name"];
                ItemLevel.Content = (string)Data["CategoryList"][(string)Item["category"]]["Name"] + (Item["ilvl"] != null ? " • Item Level " + (string)Item["ilvl"] : "");
                ItemIcon.Source = new BitmapImage(new Uri("https://garlandtools.org/files/icons/item/" + (string)Item["icon"] + ".png"));
                if (Item["description"] != null) ItemDescription.Text = (string)Item["description"];
                else ItemDescription.Text = "No description";

                // General - Job
                if (Item["jobCategories"] != null)
                {
                    ItemJobName.Content = (string)Item["jobCategories"];
                    ItemJobLevel.Content = "Lv. " + (string)Item["elvl"];
                    string[] Jobs = ((string)Item["jobCategories"]).Split(' ');
                    if (Jobs.Length > 1 || Jobs[0] == "All") ItemJobIcon.Source = new BitmapImage(new Uri("https://static.wikia.nocookie.net/finalfantasy/images/a/aa/Jobs_only_party_icon_from_Final_Fantasy_XIV.png"));
                    else ItemJobIcon.Source = new BitmapImage(new Uri((string)Data["JobIcons"][Jobs[0]]));
                }
                else ItemJob.Visibility = Visibility.Hidden;

                // Set gradient for banner based on rarity
                LinearGradientBrush RarityGradient = new LinearGradientBrush();
                RarityGradient.StartPoint = new Point(0, 0);
                RarityGradient.EndPoint = new Point(0, 1);
                switch ((string)Item["rarity"])
                {
                    case "1":
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(79, 79, 79), 0));
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(124, 124, 124), 0.3));
                        break;
                    case "2":
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(27, 120, 52), 0));
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(23, 189, 108), 0.3));
                        break;
                    case "3":
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(25, 57, 124), 0));
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(45, 122, 199), 0.3));
                        break;
                    case "4":
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(117, 74, 147), 0));
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(143, 93, 186), 0.3));
                        break;
                    case "5":
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(188, 178, 218), 0));
                        RarityGradient.GradientStops.Add(new GradientStop(Color.FromRgb(235, 135, 185), 0.3));
                        break;
                }
                ItemBanner.Background = RarityGradient;

                SwitchFrame(ItemFrame, SidebarSearch);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ItemSearchErrorMessage.Content = error.Message;
                ItemSearchErrorFrame.Visibility = Visibility.Visible;
            }
        }
    }
}
