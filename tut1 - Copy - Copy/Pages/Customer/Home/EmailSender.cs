using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
namespace tut1.Pages.Customer.Home
{
    public class EmailSender
    {
        //code block skeleton provided by the sendgrid API
        public async Task SendEmail(string user, int id, double cost)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("johnmcfilm@outlook.com", "Picture Perfect Picturehouse");
            var subject = "Picture Perfect Picturehouse";
            var to = new EmailAddress(user, "User");
            var plainTextContent = "Thank you for using our Picturehouse \n Your Booking ID is "+id+" and your card has been charged "+cost;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from,to,subject,plainTextContent,htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
