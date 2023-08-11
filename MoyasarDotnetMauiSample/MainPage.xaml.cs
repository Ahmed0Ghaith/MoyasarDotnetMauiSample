using Moyasar;
using Moyasar.Models;
using Moyasar.Services;
using System.Web;

namespace MoyasarDotnetMauiSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
       
            }

    // Publish Key : pk_test_34535235555555555554
    // Secret Key : sk_test_52344444444444444444

    private void ApplePay_Clicked(object sender, EventArgs e)
    {

    }

    private void CreditCard_Clicked(object sender, EventArgs e)
    {
        try
        {
            MoyasarService.ApiKey = "sk_test_52344444444444444444";
            // Frist You have to create Invoice


            var invoice = Invoice.Create(new InvoiceInfo
            {
                Amount = 60000,
                Currency = "SAR",
                
                Description = "Kindle Paperwhite",
                CallbackUrl = "http://www.google.com/",
                Metadata = new Dictionary<string, string>
                {

                }
            });

            PaymentWebView.Source = invoice.Url;
        }
        catch
        { 
        
        
        }
    }

    private void PaymentWebView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Source" && PaymentWebView != null&&PaymentWebView.Source.ToString().Contains("google.com"))
        {
            Uri myUri = new Uri(PaymentWebView.Source.ToString());
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("param1");
        }
    }

    private void PaymentWebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        //if (e.Url.Contains("https://www.google.com/"))
        //{
            Uri myUri = new Uri(e.Url.ToString());
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("message");
            if (param1 != null && param1 == "Succeeded")
            {

                Console.WriteLine("Succeeded");
            }
        //}
    }
}

