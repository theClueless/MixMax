using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Common;
using System.IO;
using Newtonsoft.Json;

namespace MixMax.Main.Services.DataProvider
{
    public class JsonDataProvider : IDataProvider
    {
        private readonly IFileHandler _fileHandler;
        private readonly string _filePath;

        public JsonDataProvider(string filePath, IFileHandler fileHandler)
        {
            _filePath = filePath;
            _fileHandler = fileHandler;
        }

        public DataRepository Get()
        {
            DataRepository dataRepository = new DataRepository();
            try
            {
                string json = _fileHandler.ReadAllText(_filePath);
                dataRepository = JsonConvert.DeserializeObject<DataRepository>(json);
            }
            catch (FileNotFoundException e)
            {
            }
            catch (Exception e)
            {
                throw new MixMaxException("Something went wrong", e);
            }
            return dataRepository;
        }

        public void Set(DataRepository dataRepository)
        {
            string json = JsonConvert.SerializeObject(dataRepository);
            try
            {
                _fileHandler.WriteAllText(_filePath, json);
            }
            catch (Exception e)
            {
                throw new MixMaxException(string.Format("Could not save package to file in path: {0}", _filePath), e.InnerException);
            }            
        }
    }

    public interface IFileHandler
    {
        string ReadAllText(string filePath);
        void WriteAllText(string filePath, string content);
    }
}
