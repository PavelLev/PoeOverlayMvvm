using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM;
using PoeOverlayMvvm.ViewModels;

namespace PoeOverlayMvvm {
    public sealed class ApplicationViewModel: MyObservable {
        private RelayCommand _testCommand;
        private List<string> _leagueNamesList;
        private bool _isVisible = true;
        private static bool _isForeground;

        public RelayCommand TestCommand => _testCommand ?? (_testCommand = new RelayCommand(parameter => {
            
        }));

        public ApplicationViewModel() {
            DownloadLeagueNamesList();
        }

        public ItemSearchesPanel ItemSearchesPanel { get; set; } = new ItemSearchesPanel();
        public ItemsPanel ItemsPanel { get; set; } = new ItemsPanel();

        public List<string> LeagueNamesList {
            get => _leagueNamesList;
            set => SetField(ref _leagueNamesList, value);
        }

        private async void DownloadLeagueNamesList() {
            try {
                using (var stream =
                    await MyHttpClient.GetStreamAsync("http://api.pathofexile.com/leagues?type=main&compact=1"))
                using (var streamReader = new StreamReader(stream))
                using (var jsonTextReader = new JsonTextReader(streamReader)) {
                    var json = await JArray.LoadAsync(jsonTextReader);

                    LeagueNamesList = json.Select(leagueToken => leagueToken["id"].Value<string>())
                        .Where(name => !name.StartsWith("SSF") && !name.Contains("Solo")).ToList();
                }
            }
            catch {
                LeagueNamesList = new List<string> {
                    "Standard",
                    "Hardcore",
                    "Harbinger",
                    "Harbinger Hardcore",
                };
            }
        }

        public void ToggleIsVisible() {
            IsVisible = !IsVisible;
        }

        public bool IsVisible {
            get => _isVisible;
            set => SetField(ref _isVisible, value);
        }


        public bool IsForeground {
            get => _isForeground;
            set => SetField(ref _isForeground, value);
        }
    }
}
