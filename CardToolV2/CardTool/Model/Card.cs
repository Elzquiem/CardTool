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
		POSITIVE,
        NEGATIVE,
        NEUTRAL,
		NORMAL   
    }

    public enum Category
    {
        ACTION,
		RELIC,
		OBJECTIVE,
        CHARACTER,
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

        private string m__UniqueId;
        private string m__GlobalId;
        private int m__cost;

        private SfxType m__sfx;
        private Category m__category;

        private string m__title;
        private string m__description;
        private string m__imagePath;

        private CardEffect m__effect_1;
        private CardEffect m__effect_2;

        #region PROPERTIES

        public string CardUniqueId
        {
            get { return m__UniqueId; }
            set
            {
                m__UniqueId = value; 
                this.OnPropertyChanged("CardUniqueId");
            }
        }

        public string CardGlobalId
        {
            get { return m__GlobalId; }
            set
            {
                m__GlobalId = value;
                this.OnPropertyChanged("CardGlobalId");
            }
        }

        public int CardCost
        {
            get { return m__cost; }
            set { 
                m__cost = Math.Abs(value);
                this.OnPropertyChanged("CardCost");
            }
        }

        public string CardTitle
        {
            get { return m__title; }
            set { 
                m__title = value;
                this.OnPropertyChanged("CardTitle");
            }
        }

        public string CardDescription
        {
            get { return m__description; }
            set { 
                m__description = value;
                this.OnPropertyChanged("CardDescription");
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

        #endregion

        #region CONTRUCTORS

        public Card()
        {
            m__UniqueId = "UID not defined";
            m__GlobalId = "GID000020141200.01.00"; // TODO Generate GID according to syntax
            m__cost = 0;
            m__title = "Nouvelle carte";
            m__description = "";
            m__imagePath = "Ressources/default_img.png";
            m__sfx = SfxType.NEUTRAL;
            m__category = Category.NONE;
            m__effect_1 = CardEffect.NONE;
            m__effect_2 = CardEffect.NONE;
        }

        public Card(string id, int cost, string title, string description, string imgPath)
        {
            m__UniqueId = id;
            m__cost = cost;
            m__title = title;
            m__description = description;
            m__imagePath = imgPath;
        }

        public Card(string id, int cost, string title, string description, string imgPath, SfxType sfx, Category category)
        {
            m__UniqueId = id;
            m__cost = cost;
            m__title = title;
            m__description = description;
            m__imagePath = imgPath;
            m__sfx = sfx;
            m__category = category;
        }

        public Card(string uniqueId, string globalId, int cost, string title, string description, string imgPath, SfxType sfx, Category category, CardEffect effect1, CardEffect effect2)
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

        public Card(string globalId, int cost, string title, string description, string imgPath, SfxType sfx, Category category, CardEffect effect1, CardEffect effect2)
        {
            m__UniqueId = "UID not defined";
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

        /// <summary>
        /// When adding a new card, increment data of card for UX
        /// </summary>
        public void IncrementData()
        {
            //CardUniqueId++;
            CardGlobalId = "GID000020141200.01.00";
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
            CardUniqueId = "UID not defined";
            CardGlobalId = "GID000020141200.01.00";
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

                // Add new Validation Error messages here with properties
                //
                if (columnName == "CardTitle")
                {
                    if (CardTitle.Length == 0)
                        result = "Le titre ne doit pas être vide.";
                }

                if (columnName == "Card")
                {
                    if (CardGlobalId.Length != 21)
                        result = "L'id global doit comporter exactement 21 charactères.";
                }

                if (columnName == "CardGlobalId")
                {
                    if (CardGlobalId.Length != 21)
                        result = "L'id global doit comporter exactement 21 charactères.";
                }

                return result;
            }
        }

        #endregion

    }
}
