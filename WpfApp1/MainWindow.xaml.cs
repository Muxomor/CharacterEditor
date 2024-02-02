using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Character = classList[0];
            DataContext = Character;
            currentStatPointsCount = Character.UnspendedPoints;
            _oldStrength = Character.Strength;
            _oldDexterity = Character.Dexterity;
            _oldIntelligence = Character.Intelligence;
            _oldVitality = Character.Vitality;

            Binding statPointsBinding = new Binding("statPointsAsString");
            statPointsBinding.Source = this;
            BindingOperations.SetBinding(statPointsTb, TextBlock.TextProperty, statPointsBinding);
            BindingExpression statPointsExpression = statPointsTb.GetBindingExpression(TextBlock.TextProperty);

            Binding addExpPanelBinding = new Binding("CanAddExp");
            addExpPanelBinding.Source = this;
            BindingOperations.SetBinding(ExpPanel, IsEnabledProperty, addExpPanelBinding);
            BindingExpression addExpPanelExpression = ExpPanel.GetBindingExpression(IsEnabledProperty);
            DataContextChanged += (object sender, DependencyPropertyChangedEventArgs e) =>
            {
                statPointsExpression.UpdateTarget();
                addExpPanelExpression.UpdateTarget();
            };
        }
        public ICharacter Character { get; set; }

        private List<ICharacter> classList = new List<ICharacter>() { new Warrior(), new Rogue(), new Wizard() };

        public int currentStatPointsCount;
        private int _oldStrength;
        private int _oldDexterity;
        private int _oldIntelligence;
        private int _oldVitality;

        private void applyPointsBtn_Click(object sender, RoutedEventArgs e)
        {
            Character.UnspendedPoints = currentStatPointsCount;
            _oldStrength = Character.Strength;
            _oldDexterity = Character.Dexterity;
            _oldIntelligence = Character.Intelligence;
            _oldVitality = Character.Vitality;
            Character.UnspendedPoints = currentStatPointsCount;
            DataContext = null;
            DataContext = Character;
        }
         
        private void resetPointsBtn_Click(object sender, RoutedEventArgs e)
        {
            Character.Strength = _oldStrength;
            Character.Dexterity = _oldDexterity;
            Character.Intelligence = _oldIntelligence;
            Character.Vitality = _oldVitality;
            currentStatPointsCount = Character.UnspendedPoints;

            DataContext = null;
            DataContext = Character;
        }

        private void changeClassForwardBTN_Click(object sender, RoutedEventArgs e)
        {
            int i = classList.IndexOf(Character);
            i = i < classList.Count - 1 ? i + 1 : 0;
            Character = classList[i];
            DataContext = null;
            DataContext = Character;
        }

        private void changeClassBackwardBTN_Click(object sender, RoutedEventArgs e)
        {
            int i = classList.IndexOf(Character);
            i = i > 0 ? i - 1 : classList.Count - 1;
            Character = classList[i];
            DataContext = null;
            DataContext = Character;
        }

        private void onehundredExpBtn_Click(object sender, RoutedEventArgs e)
        {
            Character.Experience += 100;
            OnExpUpdate();
        }

        private void fivehundredExpBtn_Click(object sender, RoutedEventArgs e)
        {
            Character.Experience += 500;
            OnExpUpdate();
        }

        private void thousandExpBtn_Click(object sender, RoutedEventArgs e)
        {
            Character.Experience += 1000;
            OnExpUpdate();
        }

        private void OnExpUpdate()
        {
            currentStatPointsCount = Character.UnspendedPoints;
            DataContext = null;
            DataContext = Character;
        }

        private void strPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Strength < Character.MaxStrength && currentStatPointsCount > 0)
            {
                Character.Strength++;
                currentStatPointsCount--;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void strMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Strength > _oldStrength)
            {
                Character.Strength--;
                currentStatPointsCount++;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void dexPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Dexterity < Character.MaxDexterity && currentStatPointsCount > 0)
            {
                Character.Dexterity++;
                currentStatPointsCount--;
                ExpPanel.IsEnabled = false;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void dexMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Dexterity > _oldDexterity)
            {
                Character.Dexterity--;
                currentStatPointsCount++;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void intPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Intelligence < Character.MaxIntelligence && currentStatPointsCount > 0)
            {
                Character.Intelligence++;
                currentStatPointsCount--;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void intMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Intelligence > _oldIntelligence)
            {
                Character.Intelligence--;
                currentStatPointsCount++;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void vitPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Vitality < Character.MaxVitality && currentStatPointsCount > 0)
            {
                Character.Vitality++;
                currentStatPointsCount--;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void vitMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Character.Vitality > _oldVitality)
            {
                Character.Vitality--;
                currentStatPointsCount++;
                DataContext = null;
                DataContext = Character;
            }
        }

        private void ApplyClassBtn_Click(object sender, RoutedEventArgs e)
        {
            StatPanel.IsEnabled = true;
            ClassPanel.IsEnabled = false;
            PointsBtn.IsEnabled = true;
        }
    }
}
