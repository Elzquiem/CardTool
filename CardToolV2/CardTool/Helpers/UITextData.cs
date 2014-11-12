using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Translate the tool here

namespace CardTool
{
    public class UITextData
    {

        private static UITextData instance;

        // MENU DATA TEXT
        //
        private string m__menuFile = "Fichier";

        // MENU ITEM DATA TEXT
        //
        private string m__menuItemOpen = "Ouvrir un deck";
        private string m__menuItemSave = "Sauvegarder un deck";
        private string m__menuItemExit = "Quitter";

        // GRIDVIEW DATA HEADER TEXT
        private string m__gridviewDataHeaderId          = "Id";
        private string m__gridviewDataHeaderTitle       = "Titre";
        private string m__gridviewDataHeaderCategory    = "Catégorie";

        // BUTTONS DATA TEXT
        //
        private string m__buttonAdd     = "Ajouter";
        private string m__buttonEdit    = "Editer";
        private string m__buttonDelete  = "Supprimer";

        // CONTENT DATA TEXT
        //
        private string m__dataTextTitle         = "Titre :";
        private string m__dataTextId            = "ID :";
        private string m__dataTextCost          = "Coût :";
        private string m__dataTextSFX           = "SFX :";
        private string m__dataTextCategory      = "Catégorie :";
        private string m__dataTextEffects       = "Effets :";
        private string m__dataTextDescription   = "Description :";


        #region GETTERS
        public string MenuFile
        {
            get { return m__menuFile; }
        }
        public string MenuItemOpen
        {
          get { return m__menuItemOpen; }
        }
       
        public string MenuItemSave
        {
          get { return m__menuItemSave; }
        }
        
        public string MenuItemExit
        {
          get { return m__menuItemExit; }
        }

        public string ButtonAdd
        {
            get { return m__buttonAdd; }
        }
        public string ButtonEdit
        {
            get { return m__buttonEdit; }
        }
        public string ButtonDelete
        {
            get { return m__buttonDelete; }
        }

        public string DataTextTitle
        {
            get { return m__dataTextTitle; }
        }

        public string DataTextId
        {
            get { return m__dataTextId; }
        }

        public string DataTextCost
        {
            get { return m__dataTextCost; }
        }

        public string DataTextSFX
        {
            get { return m__dataTextSFX; }
        }
        public string DataTextCategory
        {
            get { return m__dataTextCategory; }
        }

        public string DataTextEffects
        {
            get { return m__dataTextEffects; }
        }

        public string DataTextDescription
        {
            get { return m__dataTextDescription; }
        }

        public string GridviewDataHeaderId
        {
            get { return m__gridviewDataHeaderId; }
        }

        public string GridviewDataHeaderTitle
        {
            get { return m__gridviewDataHeaderTitle; }
        }

        public string GridviewDataHeaderCategory
        {
            get { return m__gridviewDataHeaderCategory; }
        }

        #endregion


        public UITextData() { }

        public UITextData Instance
        {
            get { if (instance == null){ instance = new UITextData();} return instance; }
        }



    }
}
