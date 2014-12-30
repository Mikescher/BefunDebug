using System.Windows.Controls;

namespace BefunGen
{
	/// <summary>
	/// Interaction logic for GraphUserControl.xaml
	/// </summary>
	public partial class GraphUserControl : UserControl
	{
		public MainGraphViewModel vm;

		public GraphUserControl()
		{
			vm = new MainGraphViewModel();
			this.DataContext = vm;
			InitializeComponent();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			graphLayout.Relayout();
		}
	}
}
