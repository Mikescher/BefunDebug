using System.Windows.Controls;

namespace BefunDebug.Graph
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

		private void OnSelectVertex(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var b = (sender as Border);
			if (b == null) return;

			var v = (b.DataContext as PocVertex);
			if (v == null) return;

			vm.SelectedVertex = v;
		}
	}
}
