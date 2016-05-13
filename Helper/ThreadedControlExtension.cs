using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace BefunGen.Helper
{
	public static class ThreadedControlExtension
	{
		private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

		// http://stackoverflow.com/a/661706/1761622
		public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
		{
			var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo;

			if (propertyInfo == null || !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) || @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
			{
				throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
			}

			if (@this.InvokeRequired)
			{
				@this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
			}
			else
			{
				@this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
			}
		}

		public static void Output(this TextBox box, string line)
		{
			box.BeginInvoke(new Action(() =>
			{
				box.Text += line;
				box.SelectionStart = box.Text.Length;
				box.ScrollToCaret();
			}));
		}

		[StringFormatMethod("lineFormat")]
		public static void Output(this TextBox box, string lineFormat, params object[] args)
		{
			box.BeginInvoke(new Action(() =>
			{
				box.Text += string.Format(lineFormat, args);
				box.SelectionStart = box.Text.Length;
				box.ScrollToCaret();
			}));
		}
	}
}
