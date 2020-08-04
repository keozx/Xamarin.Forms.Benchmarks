using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Xamarin.Forms.Benchmarks
{
	class BindingData
	{
		public string Text { get; set; }
	}

	[MemoryDiagnoser]
	[Orderer (SummaryOrderPolicy.FastestToSlowest)]
	public class Bindings : BaseBenchmark
	{
		BindingData bindingContext = new BindingData {
			Text = "Foo"
		};

		[Benchmark]
		public void ByHand ()
		{
			var label = new Label ();
			var binding = new Binding ("Text");
			label.SetBinding (Label.TextProperty, binding);
			label.BindingContext = bindingContext;
		}

		[Benchmark]
		public void XamlC ()
		{
			var label = new BindingLabel {
				BindingContext = bindingContext,
			};
		}

		[Benchmark]
		public void Typed ()
		{
			var label = new TypedBindingLabel {
				BindingContext = bindingContext,
			};
		}
	}
}
