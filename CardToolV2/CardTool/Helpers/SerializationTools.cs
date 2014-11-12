using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace CardTool
{
    public static class SerializationTools
    {

        /// <summary>
        /// Write the entire deck from a card collection into a XML file with the given path
        /// </summary>
        /// <param name="cardCollection">An observableCollection of Card objects</param>
        /// <param name="path">The path of the file</param>
        public static void WriteDeckToXML(ObservableCollection<Card> cardCollection, string path)
        {

            // Create XMLWriter settings for a readable xml file
            //
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineOnAttributes = true;

            // Create XML Writer
            //
            XmlWriter writer = XmlWriter.Create(path, settings);

            // WRITING
            //
            writer.WriteStartDocument();
            writer.WriteStartElement("deck");

            // Write each card in deck
            //
            foreach (Card card in cardCollection)
            {
                writer.WriteStartElement("card");

                writer.WriteStartElement("id");
                writer.WriteValue(card.CardId);
                writer.WriteEndElement();

                writer.WriteStartElement("title");
                writer.WriteValue(card.CardTitle);
                writer.WriteEndElement();

                writer.WriteStartElement("cost");
                writer.WriteValue(card.CardCost);
                writer.WriteEndElement();

                writer.WriteStartElement("category");
                writer.WriteValue((int)card.CardCategory);
                writer.WriteEndElement();

                writer.WriteStartElement("effect_1");
                writer.WriteValue((int)card.CardEffect_1);
                writer.WriteEndElement();

                writer.WriteStartElement("effect_2");
                writer.WriteValue((int)card.CardEffect_2);
                writer.WriteEndElement();

                writer.WriteStartElement("description");
                writer.WriteValue(card.CardDescription);
                writer.WriteEndElement();

                writer.WriteStartElement("sfx");
                writer.WriteValue((int)card.CardSfx);
                writer.WriteEndElement();

                writer.WriteStartElement("imagePath");
                writer.WriteValue(card.CardImagePath);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            // End writing
            //
            writer.WriteEndDocument();
            writer.Close();
        }

        /// <summary>
        /// Load all cards from a deck (XML file path) into the specified card collection
        /// </summary>
        /// <param name="cardCollection">An observableCollection of Card objects</param>
        /// <param name="path">The path of the file</param>
        public static void LoadDeckFromXML(ObservableCollection<Card> cardCollection, string path)
        {

            // Card attributes
            //
            int id, cost;
            string title, description, imagePath;

            CardEffect effect1, effect2;
            Category category;
            SfxType sfx;

            // Create XMLReader 
            //
            XmlReader reader = XmlReader.Create(path);

            // READING
            //
            while (reader.Read())
            {

                if (reader.ReadToFollowing("card"))
                {

                    try
                    {
                        reader.ReadToFollowing("id");
                        id = reader.ReadElementContentAsInt();
                        //Console.WriteLine("Content of " + reader.Name + " : " + reader.ReadElementContentAsString());

                        reader.ReadToFollowing("title");
                        title = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("cost");
                        cost = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("category");
                        category = (Category)(reader.ReadElementContentAsInt());

                        reader.ReadToFollowing("effect_1");
                        effect1 = (CardEffect)(reader.ReadElementContentAsInt());

                        reader.ReadToFollowing("effect_2");
                        effect2 = (CardEffect)(reader.ReadElementContentAsInt());

                        reader.ReadToFollowing("description");
                        description = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("sfx");
                        sfx = (SfxType)(reader.ReadElementContentAsInt());

                        reader.ReadToFollowing("imagePath");
                        imagePath = reader.ReadElementContentAsString();

                        // Create and add card to CardCollection
                        //
                        Card card = new Card(id, cost, title, description, imagePath, sfx, category, effect1, effect2);
                        cardCollection.Add(card);
                    }
                    catch (Exception e)
                    {
                        // If the reader fails, then the XML data is invalid. Notify the user of this error.
                        //
                        MessageBox.Show("Le fichier XML chargé n'est pas valide !", "Fichier invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            // End reading
            //
            reader.Close();

        }


    }
}