﻿using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Services.SerializationService
{
    public class ModelFileHandler
    {
        public ClientCollection ReadModelFromFile(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream streamLoad = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            ClientCollection loadedCollection =
                (ClientCollection)formatter.Deserialize(
                    streamLoad);
            streamLoad.Close();
            return loadedCollection;
        }
        public void WriteModelToFile(string path, ClientCollection model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }
    }
}
