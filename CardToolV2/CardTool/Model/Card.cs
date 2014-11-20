using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardTool
{

    public enum SfxType
    {
        NEUTRAL,
        BONUS,
        MALUS
    }

    public enum Category
    {
        TREASURE,
        DISCOVERY,
        MISCELLANEOUS,
        NONE
    }

    public enum CardEffect
    {
        SLOW,
        SPEED_UP,
        NONE
    }

    public class Card : IDataErrorInfo, INotifyPropertyChanged
    {

        private int m__UniqueId;
        private int m__GlobalId;
        private int m__cost;

        private SfxType m__sfx;
        private Category m__category;

        private string m__title;
        private string m__description;
        private string m__imagePath;

        private CardEffect m__effect_1;
        private CardEffect m__effect_2;

        // TODO Add missing field and properties

        #region PROPERTIES

        public int CardUniqueId
        {
            get { return m__UniqueId; }
            set
            {
                m__UniqueId = Math.Abs(value); 
                this.OnPropertyChanged("CardUniqueId");
                this.OnPropertyChanged("FullCard");
            }
        }

        public int CardGlobalId
        {
            get { return m__GlobalId; }
            set
            {
                m__GlobalId = Math.Abs(value);
                this.OnPropertyChanged("CardGlobalId");
            }
        }

        public int CardCost
        {
            get { return m__cost; }
            set { 
                m__cost = Math.Abs(value);
                this.OnPropertyChanged("CardCost");
                this.OnPropertyChanged("FullCard");
            }
        }

        public string CardTitle
        {
            get { return m__title; }
            set { 
                m__title = value;
                this.OnPropertyChanged("CardTitle");
                this.OnPropertyChanged("FullCard");
            }
        }

        public string CardDescription
        {
            get { return m__description; }
            set { 
                m__description = value;
                this.OnPropertyChanged("CardDescription");
                this.OnPropertyChanged("FullCard");
            }
        }

        public string CardImagePath
        {
            get { return m__imagePath; }
            set { 
                m__imagePath = value;
                this.OnPropertyChanged("CardImagePath");
            }
        }

        public SfxType CardSfx
        {
            get { return m__sfx; }
            set { 
                m__sfx = value;
                this.OnPropertyChanged("CardSfx");
            }
        }

        public Category CardCategory
        {
            get { return m__category; }
            set {
                m__category = value;
                this.OnPropertyChanged("CardCategory");
            }
        }

        public CardEffect CardEffect_1
        {
            get { return m__effect_1; }
            set {
                m__effect_1 = value;
                this.OnPropertyChanged("CardEffect_1");
            }
        }


        public CardEffect CardEffect_2
        {
            get { return m__effect_2; }
            set { 
                m__effect_2 = value;
                this.OnPropertyChanged("CardEffect_2");
            }
        }

        // DEBUG
        //
        public string FullCard
        {
            get
            {
                return this.CardUniqueId + " " + this.CardTitle + " " + this.CardCost + " " + this.CardDescription;
            }
        }
        #endregion

        #region CONTRUCTORS

        public Card()
        {
            m__UniqueId = 0;
            m__cost = 0;
            m__title = "Nouvelle carte";
            m__description = "";
            m__imagePath = "Ressources/default_img.png";
            m__sfx = SfxType.NEUTRAL;
            m__category = Category.NONE;
            m__effect_1 = CardEffect.NONE;
            m__effect_2 = CardEffect.NONE;
        }

        public Card(int id, int cost, string title, string description, string imgPath)
        {
            m__UniqueId = id;
            m__cost = cost;
            m__title = title;
            m__description = description;
            m__imagePath = imgPath;
        }

        public Card(int id, int cost, string title, string description, string imgPath, SfxType sfx, Category category)
        {
            m__UniqueId = id;
            m__cost = cost;
            m__title = title;
            m__description = description;
            m__imagePath = imgPath;
            m__sfx = sfx;
            m__category = category;
        }

        public Card(int uniqueId, int globalId, int cost, string title, string description, string imgPath, SfxType sfx, Category category, CardEffect effect1, CardEffect effect2)
        {
            m__UniqueId = uniqueId;
            m__GlobalId = globalId;
            m__cost = cost;
            m__title = title;
            m__description = description;
            m__imagePath = imgPath;
            m__sfx = sfx;
            m__category = category;
            m__effect_1 = effect1;
            m__effect_2 = effect2;
        }

        #endregion


        #region METHODS

        // TODO Finalize methods with missing data

        /// <summary>
        /// When adding a new card, increment data of card for UX
        /// </summary>
        public void IncrementData()
        {
            CardUniqueId++;
            CardGlobalId = 0;
            CardCost = 0;
            CardTitle = "Nouvelle carte";
            CardDescription = "";
            //CardCategory = Category.NONE;
            CardSfx = SfxType.NEUTRAL;
            CardImagePath = @"Ressources/default_img.png";
            CardEffect_1 = CardEffect.NONE;
            CardEffect_2 = CardEffect.NONE;
        }

        /// <summary>
        /// Reset data of the card
        /// </summary>
        public void ResetData()
        {
            CardUniqueId = 0;
            CardGlobalId = 0;
            CardCost = 0;
            CardTitle = "Nouvelle carte";
            CardDescription = "";
            CardSfx = SfxType.NEUTRAL;
            CardCategory = Category.NONE;
            CardImagePath = @"Ressources/default_img.png";
            CardEffect_1 = CardEffect.NONE;
            CardEffect_2 = CardEffect.NONE;
        }

        #endregion


        #region NOTIFY PROPERTY CHANGE

        // Event and method in order to notify UI that properties need to be updated on change

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion


        #region IDataErrorInfo MEMBERS

        // Methods to display errors nature when a ValidationError occurs

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "CardTitle")
                {
                    if (CardTitle.Length == 0)
                        result = "Le titre ne doit pas être vide.";
                }

                return result;
            }
        }

        #endregion

    }
}
