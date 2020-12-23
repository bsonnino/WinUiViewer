using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPFXamlIslands.Model;

namespace WPFXamlIslands.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            var fileName = $"{AppDomain.CurrentDomain.BaseDirectory}Photos\\__credits.json";
            Photos = JsonConvert.DeserializeObject<Dictionary<string, PhotoData>>(
                File.ReadAllText(fileName),
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                }).Select(p => new PhotoData() { PhotoUrl = $".\\Photos\\{p.Key}.jpg", UserName = p.Value.UserName });
        }

        
        public IEnumerable<PhotoData> Photos { get; }

    }
}