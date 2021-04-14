using LeronTech.LanternComponents.Handlers.Interfaces;
using LeronTech.LanternComponents.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LeronTech.LanternComponents.Handlers
{
    public class ComponentPriceHandlerJSON : IComponentPriceHandler
    {
        public ComponentPrices Get()
        {
            var jsonFile = GetFile();

            using (var reader = jsonFile.OpenText())
                return JsonConvert.DeserializeObject<ComponentPrices>(reader.ReadToEnd());
        }

        public void Update(ComponentPrices prices)
        {
            var jsonFile = GetFile();

            using (var writer = jsonFile.CreateText())
                writer.Write(JsonConvert.SerializeObject(prices));
        }

        private FileInfo GetFile()
        {
            var jsonName = "Prices.json";
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}/{jsonName}";

            try
            {
                return new FileInfo(path);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(null, "Файл с ценами компонентов не найден");
            }
        }
    }
}
