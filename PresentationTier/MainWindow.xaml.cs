using System.Windows;
using LogicTier;
namespace PresentationTier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Shop logicTier = new Shop();
            this.DataContext = logicTier;
            InitializeComponent();
        }
    }
}