using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
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
        public Tamagotchi ReadModelFromFile(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream streamLoad = null;
            try
            {
                streamLoad = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
                Tamagotchi loadedCollection =
                    (Tamagotchi)formatter.Deserialize(
                        streamLoad);
                Console.WriteLine("loadedCollection-Ausgabe-----------");
                Console.WriteLine(loadedCollection.BackgroundColor);

                return loadedCollection;
            }
            catch (FileNotFoundException)
            {
                Tamagotchi MyTamagotchi = new Tamagotchi
                {
                    Hunger = 0,
                    Health = 0,
                    Happiness = 0,
                    Name = "Tamagotchi",
                    LoginTime = DateTime.Now,
                    Birthday = DateTime.Now,
                    TamagotchiColor = "Blue",
                    BackgroundColor = "#1E90FF",
                    ButtonColor = "#1e6cff"
                };

                Console.WriteLine("ModelFileHandler TamagotchiColor: " + MyTamagotchi.TamagotchiColor);

                return MyTamagotchi;
            }
            catch (Exception ex)
            {
                Tamagotchi MyTamagotchi = new Tamagotchi
                {
                    Hunger = 0,
                    Health = 0,
                    Happiness = 0,
                    Name = "Tamagotchi",
                    LoginTime = DateTime.Now,
                    Birthday = DateTime.Now,
                    TamagotchiColor = "Blue",
                    BackgroundColor = "#1E90FF",
                    ButtonColor = "#1e6cff"
                };
                
                Console.WriteLine("ModelFileHandler TamagotchiColor: " + MyTamagotchi.TamagotchiColor);

                return MyTamagotchi;
            }
            finally
            {
                if (streamLoad != null)
                {
                    streamLoad.Close();
                }
            } 
        }


        public void WriteModelToFile(string path, Tamagotchi model)
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
