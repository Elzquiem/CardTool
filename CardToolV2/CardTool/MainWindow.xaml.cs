using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardTool
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int m__numberOfErrors;                              // Used to determine the number of validation errors

        private bool m__deckSaved;                                  // Used to determine if the deck have been saved or not when exiting application

        private string m__fileDialogFilter = "XML (*.xml)|*.xml";   // Used to define filters of OpenFileDialog and SaveFileDialog
        private string m__fileDialogImageFilter = "Image (*.png, *.jpeg, *.jpg)|*.png;*.PNG;*.jpeg;*.jpg";   // Used to define filters of OpenFileDialog for images

        private Card m__currentCard;                                // Used for binding UI with Data

        private ObservableCollection<Card> m__cardCollection;       // Used to know the entire deck. ObservableCollection mandatory for updating the ListView

        private UITextData m__uiTextData = new UITextData();        // Used for the UI text localisation

        ListSortDirection direction = ListSortDirection.Ascending;  // Used to know the current direction of the sorting arrow

        GridViewColumnHeader _lastHeaderClicked = null;                 // Used to know the last header clicked of the GridView
        ListSortDirection _lastDirection = ListSortDirection.Ascending; // Used to know the last direction of the sorting in the GridView

        #region PROPERTIES

        public Card CurrentCard
        {
            get { return m__currentCard; }
            set { m__currentCard = value; }
        }

        public UITextData UITranslation
        {
            get { return m__uiTextData.Instance; }
        }

        public ObservableCollection<Card> CardCollection
        {
            get { return m__cardCollection; }
        }

        #endregion

        public MainWindow()
        {

            m__currentCard = new Card();
            m__cardCollection = new ObservableCollection<Card>();

            m__deckSaved = true;

            InitializeComponent();

            // Bind the data context to the whole window in order to get both CardCollection and CurrentCard binding
            //
            base.DataContext = this;

        }

        // VALIDATION ERROR
        // If an error is added, increment the number of errors
        //
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                m__numberOfErrors++;
            else
                m__numberOfErrors--;
        }

        // DEBUG CLICK METHODS (DEPRECATED IN WPF)
        //
        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            Card serializedCard1 = new Card("0", "GID010020141200.01.00", 1, "Test 1", "Description 1", Environment.CurrentDirectory + "/images/ImgTest.jpg", SfxType.NEUTRAL, Category.CHARACTER, CardEffect.NONE, CardEffect.NONE);
            Card serializedCard2 = new Card("2", "GID020020141200.01.00", 2, "Test 2", "Description 2", Environment.CurrentDirectory + "/images/ImgTest.png", SfxType.POSITIVE, Category.ACTION, CardEffect.SPEED_UP, CardEffect.SPEED_UP);
            Card serializedCard3 = new Card("5", "GID030020141200.01.00", 5, "Test 3", "Description 3", Environment.CurrentDirectory + "/images/ImgTest.jpeg", SfxType.NEGATIVE, Category.MISCELLANEOUS, CardEffect.SLOW, CardEffect.NONE);
            Card serializedCard4 = new Card("3", "GID040020141200.01.00", 4, "Test 4", "Description 4", Environment.CurrentDirectory + "/images/ImgTest.jpg", SfxType.NEUTRAL, Category.NONE, CardEffect.NONE, CardEffect.NONE);
			Card serializedCard5 = new Card("12", "GID050020141200.01.00", 2, "Test 5", "Description 5", Environment.CurrentDirectory + "/images/ImgTest.png", SfxType.POSITIVE, Category.RELIC, CardEffect.NONE, CardEffect.NONE);
            Card serializedCard6 = new Card("50", "GID060020141200.01.00", 1, "Test 6", "Description 6", Environment.CurrentDirectory + "/images/ImgTest.jpeg", SfxType.NORMAL, Category.OBJECTIVE, CardEffect.SLOW, CardEffect.SLOW);
			Card serializedCard7 = new Card("42", "GID070020141200.01.00", 42, "Test 7", "La réponse", Environment.CurrentDirectory + "/images/ImgTest.jpg", SfxType.POSITIVE, Category.NONE, CardEffect.NONE, CardEffect.NONE);
            Card serializedCard8 = new Card("37", "GID080020141200.01.00", 2, "Test 8", "Description 7", Environment.CurrentDirectory + "/images/ImgTest.png", SfxType.NEUTRAL, Category.CHARACTER, CardEffect.SPEED_UP, CardEffect.SLOW);
            Card serializedCard9 = new Card("25", "GID090020141200.01.00", 3, "Test 9", "Description 8", Environment.CurrentDirectory + "/images/ImgTest.jpeg", SfxType.NEGATIVE, Category.MISCELLANEOUS, CardEffect.NONE, CardEffect.NONE);

            // Update collection by adding a card
            //
            m__cardCollection.Add(serializedCard1);
            m__cardCollection.Add(serializedCard2);
            m__cardCollection.Add(serializedCard3);
            m__cardCollection.Add(serializedCard4);
            m__cardCollection.Add(serializedCard5);
            m__cardCollection.Add(serializedCard6);
            m__cardCollection.Add(serializedCard7);
            m__cardCollection.Add(serializedCard8);
            m__cardCollection.Add(serializedCard9);

            // Sort collection
            //
            //SortCardCollectionByAcendingId();

        }

        #region LISTVIEW EVENTS

        // Mouse Event for the ListView collection on click (selected item)
        //
        private void CardCollection_SelectionChanged(object sender, MouseButtonEventArgs e)
        {

            if ( ((Card)CardDeck.SelectedItem) != null ) {

                // Affect data from deck (selected card) to current card
                // Need to use properties setters because properties call OnPropertyChange for UI update
                //
                m__currentCard.CardUniqueId     = ((Card)CardDeck.SelectedItem).CardUniqueId;
                m__currentCard.CardGlobalId     = ((Card)CardDeck.SelectedItem).CardGlobalId;
                m__currentCard.CardTitle        = ((Card)CardDeck.SelectedItem).CardTitle;
                m__currentCard.CardCost         = ((Card)CardDeck.SelectedItem).CardCost;
                m__currentCard.CardDescription  = ((Card)CardDeck.SelectedItem).CardDescription;
                m__currentCard.CardSfx          = ((Card)CardDeck.SelectedItem).CardSfx;
                m__currentCard.CardCategory     = ((Card)CardDeck.SelectedItem).CardCategory;
                m__currentCard.CardImagePath    = ((Card)CardDeck.SelectedItem).CardImagePath;
                m__currentCard.CardEffect_1     = ((Card)CardDeck.SelectedItem).CardEffect_1;
                m__currentCard.CardEffect_2     = ((Card)CardDeck.SelectedItem).CardEffect_2;
            }
 
        }

        // Event for sorting the ListView collection on header click
        //
        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            // Get the header clicked
            //
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;

            if (headerClicked != null)
            {

                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    // If the header clicked is different from before, sort with an ascending order
                    // Else, the header is the same : reverse the sorting order
                    //
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    // Get the name of the header clicked and sort the listview
                    //
                    string headerName = headerClicked.Column.Header as string;
                    SortCardCollection(headerName, direction);

                    // Change arrow template direction
                    //
                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    //
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    // Keep in memory the last header clicked and the last direction for next action
                    //
                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
                
            }

        }

        #endregion


        #region COMMANDS

        // OPEN
        //
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Use OpenFileDialog to create/select a file and load it if the user click on "Open"
            //
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = m__fileDialogFilter;

            if (openFileDialog.ShowDialog() == true)
            {
                m__cardCollection.Clear();
                m__currentCard.ResetData();
                SerializationTools.LoadDeckFromXML(m__cardCollection, openFileDialog.FileName);
                m__deckSaved = true;
            }
        }

        // SAVE
        //
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveDeck();
        }

        // EXIT
        //
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // CLEAR DECK
        //
        private void ClearDeckCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (m__cardCollection.Count != 0);
        }

        private void ClearDeckCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            MessageBoxResult clearCardCollection = MessageBox.Show("Vider intégralement le deck ? ", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // If yes, clear collection
            //
            if (clearCardCollection == MessageBoxResult.Yes)
            {
                m__cardCollection.Clear();
                m__currentCard.ResetData();
                m__deckSaved = true; // Avoid "bad" blank save
            }
            
        }

        // ADD CARD
        //
        private void AddCardCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = ( m__numberOfErrors == 0 );
        }

        private void AddCardCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // If card ID exists, don't add and inform user. Else, add a new card in the collection.
            //
            if (CardExistWithGlobalId(m__currentCard.CardGlobalId))
            {
                MessageBox.Show("La carte avec l'ID global " + m__currentCard.CardGlobalId + " existe déjà !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                Card serializedCard = new Card(m__currentCard.CardUniqueId, m__currentCard.CardGlobalId, m__currentCard.CardCost, m__currentCard.CardTitle, m__currentCard.CardDescription,
                    m__currentCard.CardImagePath, m__currentCard.CardSfx, m__currentCard.CardCategory, m__currentCard.CardEffect_1, m__currentCard.CardEffect_2);

                // Update collection by adding a card
                //
                m__cardCollection.Add(serializedCard);

                // Increment card data for UX and sort card collection
                //
                m__currentCard.IncrementData();
                //SortCardCollectionByAcendingId();

                m__deckSaved = false;
            } 

        }

        // EDIT CARD
        //
        private void EditCardCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((Card)CardDeck.SelectedItem) != null && m__numberOfErrors == 0;
        }

        private void EditCardCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            // If another card exists with a specified ID, don't edit
            // Else, edit the card and sort the card collection
            //
            if (CardExistWithGlobalId(m__currentCard.CardGlobalId) && ((Card)CardDeck.SelectedItem).CardGlobalId != m__currentCard.CardGlobalId) 
            {
                MessageBox.Show("Edition impossible. La carte avec l'ID global " + m__currentCard.CardGlobalId + " existe déjà !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ((Card)CardDeck.SelectedItem).CardUniqueId      = m__currentCard.CardUniqueId;
                ((Card)CardDeck.SelectedItem).CardGlobalId      = m__currentCard.CardGlobalId;
                ((Card)CardDeck.SelectedItem).CardCost          = m__currentCard.CardCost;
                ((Card)CardDeck.SelectedItem).CardTitle         = m__currentCard.CardTitle;
                ((Card)CardDeck.SelectedItem).CardDescription   = m__currentCard.CardDescription;
                ((Card)CardDeck.SelectedItem).CardImagePath     = m__currentCard.CardImagePath;
                ((Card)CardDeck.SelectedItem).CardSfx           = m__currentCard.CardSfx;
                ((Card)CardDeck.SelectedItem).CardCategory      = m__currentCard.CardCategory;
                ((Card)CardDeck.SelectedItem).CardEffect_1      = m__currentCard.CardEffect_1;
                ((Card)CardDeck.SelectedItem).CardEffect_2      = m__currentCard.CardEffect_2;

                //SortCardCollectionByAcendingId();

                m__deckSaved = false;
            }

        }

        // DELETE CARD
        //
        private void DeleteCardCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ( m__cardCollection.Count != 0 );
        }

        private void DeleteCardCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult deleteCurrentCard = MessageBox.Show("Supprimer la carte " + ((Card)CardDeck.SelectedItem).CardTitle + ", possédant l'id " + ((Card)CardDeck.SelectedItem).CardUniqueId + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // If yes, update collection by removing and sorting
            //
            if (deleteCurrentCard == MessageBoxResult.Yes)
            {
                m__cardCollection.Remove(((Card)CardDeck.SelectedItem));
                m__deckSaved = false;
            }

        }

        // ADD IMAGE TO CARD
        //
        private void AddImageCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddImageCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("add image");

            // Use OpenFileDialog to select a file and load it if the user click on "Open"
            //
            OpenFileDialog imageFileDialog = new OpenFileDialog();
            imageFileDialog.Title = "Ajouter Image";
            imageFileDialog.Filter = m__fileDialogImageFilter;

            if (imageFileDialog.ShowDialog() == true)
            {

                 //MessageBox.Show(Environment.CurrentDirectory);

                // Create a Image directory if the latest does not exist
                // NOTE : A string literal prefixed with @ the escape sequences starting with \ are disabled.
                // TODO Externalize image directory path ?
                //
                if (!Directory.Exists(@"images")){
                    Directory.CreateDirectory(@"images");
                }

                // If the image does not exist in our directory, copy it 
                //
                if (!File.Exists(@"images\" + imageFileDialog.SafeFileName)) {
                    File.Copy(imageFileDialog.FileName, @"images\"+imageFileDialog.SafeFileName);
                }

                m__currentCard.CardImagePath = Environment.CurrentDirectory + @"\images\" + imageFileDialog.SafeFileName;

                Console.WriteLine("Image path : " + m__currentCard.CardImagePath);

                /*m__cardCollection.Clear();
                m__currentCard.ResetData();
                SerializationTools.LoadDeckFromXML(m__cardCollection, openFileDialog.FileName);*/
            }

        }

        #endregion


        #region METHODS

        /// <summary>
        /// Opens a SaveFileDialog for saving deck
        /// </summary>
        void SaveDeck()
        {
            // Use SaveFileDialog to create/select a file and save it with the specified name and path if the user click on "Save"
            //
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = m__fileDialogFilter;

            if (saveFileDialog.ShowDialog() == true)
            {
                // Sort m__cardCollection in a new collection because OrderBy does not modify the source !
                //
                ObservableCollection<Card> collectionSorted = new ObservableCollection<Card>(m__cardCollection.OrderBy(c => c.CardGlobalId));
                SerializationTools.WriteDeckToXML(collectionSorted, saveFileDialog.FileName);
                m__deckSaved = true;
            }
        }

        /// <summary>
        /// Sort the card collection of the application
        /// </summary>
        void SortCardCollectionByAcendingId()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CardDeck.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CardUniqueId", ListSortDirection.Ascending));
        }

        /// <summary>
        /// Sort the card collection of the application according to the column clicked name and the direction of sorting
        /// </summary>
        /// <param name="headerName">The name of the GridView header</param>
        /// <param name="direction">The ListSortDirection</param>
        private void SortCardCollection(string headerName, ListSortDirection direction)
        {

            // Translate headerName to sortBy data
            //
            string sortBy = "CardGlobalId";

            if (headerName == m__uiTextData.GridviewDataHeaderId)
            {
                sortBy = "CardGlobalId";
            }
            else if (headerName == m__uiTextData.GridviewDataHeaderTitle)
            {
                sortBy = "CardTitle";
            }
            else if (headerName == m__uiTextData.GridviewDataHeaderCategory)
            {
                sortBy = "CardCategory";
            }

            // Sort collection with the new sorting order
            //
            ICollectionView dataView = CollectionViewSource.GetDefaultView(CardDeck.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        /// <summary>
        /// Test if the card exists with the given unique id
        /// </summary>
        /// <param name="uniqueId">The unique id of the card</param>
        /// <returns><b>True</b> if the card exists, <b>False</b> otherwise</returns>
        bool CardExistWithUniqueId(string uniqueId)
        {
            foreach(Card card in m__cardCollection){
                if (card.CardUniqueId == uniqueId) 
                    return true;
            }

            return false;

        }

        /// <summary>
        /// Test if the card exists with the given global id
        /// </summary>
        /// <param name="globalId">The global id of the card</param>
        /// <returns><b>True</b> if the card exists, <b>False</b> otherwise</returns>
        bool CardExistWithGlobalId(string globalId)
        {
            foreach (Card card in m__cardCollection)
            {
                if (card.CardGlobalId == globalId)
                    return true;
            }

            return false;

        }

        /// <summary>
        /// Auto-called when closing the application. Must be defined in XAML as a closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            
            // Ask for user if they want to save when exiting and when lastest modifications haven't been saved 
            //
            if (!m__deckSaved)
            {

                MessageBoxResult exitButWantSaving = MessageBox.Show("Les modifications n'ont pas été sauvegardées.\nVoulez-vous sauvegarder ?", "Quitter sans sauvegarder", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (exitButWantSaving == MessageBoxResult.Yes)
                {
                    SaveDeck();
                }

                Application.Current.Shutdown();

            }
            else
            {
                Application.Current.Shutdown();
            }

        }


        #endregion


    }

    
}
