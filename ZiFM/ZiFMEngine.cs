using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using MXit.Messaging;
using MXit.ExternalApp;
using MXit.Navigation;
using MXit.Common;
using MXit.Billing;
using MXit.User;
using MXit.Log;

namespace ZiFM
{
    public class ZiFMEngine : ExternalAppLogicEngine<ExternalAppUserSession>
    {
         /// <summary>
        /// The ExternalAppAPI admin bot's service name.
        /// </summary>
        public string ExternalAppApiAdminBotName { get; private set; }
        public long transType;

        /// <summary>
        /// Displays the main menu to the user.
        /// </summary>
        /// <param name="messageReceived">The message received from the user.</param>
        /// <param name="userSession">The object that represents the user's session on the application for the current context.</param>
        /// 
        public void DisplayMainMenu(MessageReceived messageReceived, ExternalAppUserSession userSession)
        {

            MessageToSend reply = messageReceived.CreateReplyMessage();

            reply.AppendLine(MessageBuilder.Elements.CreateClearScreen());
            reply.AppendLine("Welcome to ZiFM Stereo on Mxit.");

            // We returned to this context after being redirected somewhere else
            if (messageReceived.Type == MessageType.ServiceRedirect && messageReceived.Body.StartsWith("Data="))
            {
                reply.AppendLine("Your selection is: " + messageReceived.Body.Substring(5));
            }
            reply.AppendLine();

            reply.AppendLine("My Station. Your Station.");
            reply.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("1", "About ZiFM Stereo."));
            reply.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("2", "Coverage."));
            reply.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("3", "Shows."));
            reply.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("4", "DJs/Teams."));
            reply.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("5", "Contact Us."));
            reply.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("6", "Credits."));
            ExternalAppApiComms.SendMessage(reply);

        }

         /// <summary>
        /// An event handler that will be invoked whenever a message is received from a MXit user.
        /// </summary>
        /// <param name="messageReceived">The message that was received from the MXit user.</param>
        /// <param name="userSession">The user's session object.</param>
        public override void OnMessageReceived(MessageReceived messageReceived, ExternalAppUserSession userSession)
        {
            RedirectRequest redirectRequest;
            // For the purpose of this example anything that is not one of our defined codes will show the main menu.
            switch (messageReceived.Body)
            {
                case "1":
                    //The following is our response
                    MessageToSend messageToSend = messageReceived.CreateReplyMessage();
                    messageToSend.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                    messageToSend.AppendLine("About ZiFM Stereo");
                    messageToSend.AppendLine("ZiFM Stereo is the 1st privately owned radio station broadcasting in Zimbabwe with a wide range of programming content to keep the public tuned in 24 hours a day.");
                    messageToSend.AppendLine("The station will be playing up to 70% music that is current and entertaining with a range of informative, social and engaging talk topics.");
                    messageToSend.AppendLine("");
                    // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                    messageToSend.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                    // Add a back link
                    messageToSend.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                    ExternalAppApiComms.SendMessage(messageToSend);
                    break;
                case "2":
                    //The following is our response
                    MessageToSend messageToSend2 = messageReceived.CreateReplyMessage();
                    messageToSend2.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                    messageToSend2.AppendLine("Coverage");
                    messageToSend2.AppendLine("ZiFM Stereo currently can be found on the following frequencies in Zimbabwe:");
                    messageToSend2.AppendLine("Harare: 106.4");
                    messageToSend2.AppendLine("Bulawayo: 106.7;");
                    messageToSend2.AppendLine("Mutare: 95.4");
                    messageToSend2.AppendLine("Nyanga: 98.2");
                    messageToSend2.AppendLine("Gweru: 104.3");
                    messageToSend2.AppendLine("Masvingo: 96.1");
                    messageToSend2.AppendLine("Victoria Falls: 106.5");
                    messageToSend2.AppendLine("Beitbridge: 101.6");
                    messageToSend2.AppendLine("Mutorashanga: 97.6");
                    messageToSend2.AppendLine("Kadoma: 105.2");
                    messageToSend2.AppendLine("");
                    // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                    messageToSend2.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                    // Add a back link
                    messageToSend2.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                    ExternalAppApiComms.SendMessage(messageToSend2);
                    break;
                case "3":
                    //The following is our response
                    MessageToSend reply3 = messageReceived.CreateReplyMessage();
                    reply3.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                    reply3.AppendLine("Pick a show to below to see the DJs and details about the show:");
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s1", "“The Ignition” Monday – Friday, 6am – 9am."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s2", "“xHale” Monday – Friday, 9am – 12noon."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s3", "“The Block” Monday – Friday, 12noon – 3pm."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s4", "“The Rush” Monday – Friday, 3pm – 6pm."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s5", "“Chart Show” Monday – Friday 6pm – 6.30pm."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s6", "“In The Zone” Monday – Friday, Monday – Friday."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s7", "“Judgement Yard” Thursdays, 9pm – 12midnight."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s8", "“The Fixx” Fridays, 9pm – 12midnight."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s9", "“Hidden Culture” Saturday, 9pm – 12midnight."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s10", "“Off The Wall” Saturday, 9am – 12noon."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s11", "“Afro Republic” Monday, Tuesday & Saturday."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s12", "“Lots of Love” Sundays, 9pm – 12 midnight."));
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s13", "“Iron Lion” Sunday, 6pm – 7pm."));
                    reply3.AppendLine("");
                    // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                    // Add a back link
                    reply3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                    ExternalAppApiComms.SendMessage(reply3);
                    break;
                case "4":
                    //The following is our response
                    MessageToSend reply4 = messageReceived.CreateReplyMessage();
                    reply4.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                    reply4.AppendLine("Select a Dj/Team to see details about their show and what time it airs:");
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s1", "TK, Tin Tin & Pozzo."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s2", "Patience & Wonderful."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s3", "Tony Friday."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s4", "Delani, Christine & Tinashe."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s5", "Delani."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s6", "Pozzo, Dirk & Alois."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s7", "Dj Flevah, Mc Etherton, Dj Two Bad."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s8", "Dj Tbass, Pstyles, Mc Cutz & Karizma."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s9", "Jason le Roux & Evey."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s10", "Dan & Lo."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s11", "Morris Touch."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s12", "Plaxedes."));
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("s13", "Marlon."));
                    reply4.AppendLine("");
                    // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                    // Add a back link
                    reply4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                    ExternalAppApiComms.SendMessage(reply4);
                    break;
                
                case "5":
                     MessageToSend reply5 = messageReceived.CreateReplyMessage();
                    reply5.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                    reply5.AppendLine("ZiFM Stereo");
                    reply5.AppendLine("Address: 7 Kenilworth Road, Newlands, Harare, Zimbabwe");
                    reply5.AppendLine("Email: sales@zifmstereo.co.zw");
                    reply5.AppendLine("Tel: +263 4 746668");
                    reply5.AppendLine("Website: www.zifmstereo.co.zw");
                    reply5.AppendLine("Facebook: www.facebook.com/zifmstereo");
                    reply5.AppendLine("Twitter: @zifmstereo");
                    reply5.AppendLine("");
                    // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                    reply5.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                    // Add a back link
                    reply5.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                    ExternalAppApiComms.SendMessage(reply5);
                    break;

                case "6":
                    MessageToSend reply6 = messageReceived.CreateReplyMessage();
                    reply6.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                    reply6.AppendLine("App developed by Tawanda Kembo");
                    reply6.AppendLine("");
                    reply6.AppendLine("Email: tkembo@gmail.com");
                    reply6.AppendLine("");
                    // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                    reply6.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                    // Add a back link
                    reply6.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                    ExternalAppApiComms.SendMessage(reply6);
                    break;
                case "s1":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 1;
                        
                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s1";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;

                case "s2":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 2;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s2";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s3":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);
                        
                        transType = 3;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s3";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s4":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 4;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s4";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s5":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 5;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s5";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s6":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 6;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s6";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s7":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 7;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s7";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s8":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 8;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s8";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s9":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);
                        
                        transType = 9;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s9";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s10":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 10;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s10";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s11":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 11;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s11";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s12":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 12;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s12";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                case "s13":
                    try
                    {
                        
                        // Regardless of what the user sends to us, we will simply submit a payment request
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Received message:\n" + messageReceived.ToString(), Level.Debug);

                        transType = 13;

                        // Create a new payment request
                        PaymentRequest paymentRequest = new PaymentRequest();
                        paymentRequest.UserId = messageReceived.From;
                        paymentRequest.MoolaAmount = 1;
                        paymentRequest.ProductId = "s13";
                        paymentRequest.ProductName = "Detailed Description of Show";
                        paymentRequest.ProductDescription = "Detailed Description of Show & Host - Including Time, Day, and Summary";
                        paymentRequest.ContactName = messageReceived.To;

                        // Transaction reference has a maximum length of 100
                        paymentRequest.TransactionReference = Guid.NewGuid().ToString();
                        ExternalAppApiComms.RequestPayment(paymentRequest);

                        // Payment request submitted
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Submitted payment request:\n" + paymentRequest.ToString(), Level.Debug);

                        // Note:
                        // Do not try to send messages to the user before you've received a payment
                        // response. The API will reject all such messages.
                    }
                    catch (Exception e)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
                    }
                    break;
                
                case "h":
                    // If this application is not currently the root context and the user has selected the home link.
                    if (!messageReceived.HasRootContext)
                    {
                        redirectRequest = messageReceived.CreateRedirectRequest_Home();
                        ExternalAppApiComms.RedirectUser(redirectRequest);
                    }
                    else
                    {
                        // Just redisplay the main menu if we this application is the root context.
                        DisplayMainMenu(messageReceived, userSession);
                    }
                    break;
                case "b":
                    // If this application is not currently the root context and the user has selected the back link.
                    if (!messageReceived.HasRootContext)
                    {
                        // Redirect the user back to the previous context they were in.
                        redirectRequest = messageReceived.CreateRedirectRequest_Back();
                        ExternalAppApiComms.RedirectUser(redirectRequest);
                    }
                    else
                    {
                        // Just redisplay the main menu if we this application is the root context.
                        DisplayMainMenu(messageReceived, userSession);
                    }
                    break;
                default:
                    // If none of our options where selected, just display the main menu.
                    DisplayMainMenu(messageReceived, userSession);
                    break;
            }
        }

        /// <summary>
        /// An event handler that will be invoked whenever a payment response is received from a MXit user.
        /// </summary>
        /// <param name="paymentResponse">The payment response that was received from the ExternalAppAPI.</param>
        /// <param name="userSession">The user's session object.</param>
        public override void OnPaymentResponseReceived(PaymentResponse paymentResponse, ExternalAppUserSession userSession)
        {
            try
            {
                // Confirm the transaction
                // NB: This is not needed to complete the transaction.
                //
                // This section of code is included to demonstrate how to use the ConfirmPayment function to confirm if
                // a transaction was successful, any time after the transaction completed.
                long? moolaBilled = ExternalAppApiComms.ConfirmPayment(null, paymentResponse.TransactionReference);

                // If the transaction was successful 
                if (paymentResponse.TransactionResult == TransactionResult.Success)
                {
                    ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Transaction confirmed", Level.Debug);
                    // The Moola amount billed should equal the Moola amount asked for
                    switch (transType)
                    {
                        case 1:
                            //The following is our response
                            MessageToSend replys1 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys1.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys1.AppendLine("The Ignition");
                            replys1.AppendLine("with TK, Tin Tin & Pozzo");
                            replys1.AppendLine("Monday – Friday");
                            replys1.AppendLine("6am – 9am");
                            replys1.AppendLine("What you hear in the morning can make or break the 24 hours that follow. TK and Tin Tin make day break an explosion of light, positive energy, chuckles, news and entertainment. In contrast to the snail-pace of traffic during rush hour, or the sluggish speed at which one’s mind moves before a cup of coffee, this show is there to put an up-beat rhythm into every week day from the crack of dawn.");
                            replys1.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys1.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));

                            // Add a back link
                            replys1.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys1);

                            break;

                        case 2:
                            //The following is our response
                            MessageToSend replys2 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys2.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys2.AppendLine("xHale");
                            replys2.AppendLine("with Patience & Wonderful");
                            replys2.AppendLine("Monday – Friday");
                            replys2.AppendLine("9am – 12noon");
                            replys2.AppendLine("Patience and Wonderful target different topics every day, such as health and beauty, to farming and agriculture, to food and wine, as well as house and home. In so doing, they, paint pictures with their discussions and interviews so clear that you can see, taste, smell and feel each topic just from hearing it.");
                            replys2.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys2.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys2.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys2);
                            break;
                        case 3:
                            //The following is our response
                            MessageToSend replys3 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys3.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys3.AppendLine("The Block");
                            replys3.AppendLine("with Tony Friday");
                            replys3.AppendLine("Monday – Friday");
                            replys3.AppendLine("12noon – 3pm");
                            replys3.AppendLine("Tony is both charming and charismatic and it is this that makes the show a favourite ‘hang out’ for children and light hearted listening for the mature audience. Broadcast daily the pair have created a synergy of humour and wit giving the perfect balance to your lunch time listening.");
                            replys3.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys3.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys3);
                            break;
                        case 4:
                            //The following is our response
                            MessageToSend replys4 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys4.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys4.AppendLine("The Rush");
                            replys4.AppendLine("with Delani, Christine , Tinashe");
                            replys4.AppendLine("Monday – Friday");
                            replys4.AppendLine("3pm – 6pm");
                            replys4.AppendLine("The latest, the freshest, the most flavor-filled and fascinating of stuff is dished out in generous helpings in this here show. Film, theatre, music, sport and all things entertainment are covered in the show. They present comedy to loosen the tight strings on any long or hard day. News, reviews, traffic, travel, weather and sport updates decorate the show and a specialist DJ drops a mix to get those heads bopping and fingers tapping as the end of day mellowness sets in, waning the weight of the day just passed.");
                            replys4.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys4.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys4);
                            break;
                        case 5:
                            //The following is our response
                            MessageToSend replys5 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys5.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys5.AppendLine("Chart Show");
                            replys5.AppendLine("with Delani");
                            replys5.AppendLine("Monday – Friday");
                            replys5.AppendLine("6pm – 6.30pm");
                            replys5.AppendLine("An energetic, fast paced show playing the latest and hottest Zimbabwean and International pop hits voted for by the listener. The show will include a chart prediction competition also via texts and Internet platforms. Delani draws his music from the major chart toppers locally, in the USA, Latin America, Jamaica and Europe to create a universal sound and a culturally diverse chart");
                            replys5.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys5.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys5.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys5);
                            break;
                        case 6:
                            //The following is our response
                            MessageToSend replys6 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys6.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys6.AppendLine("In The Zone");
                            replys6.AppendLine("with Pozzo, Dirk & Alois");
                            replys6.AppendLine("Monday – Friday");
                            replys6.AppendLine("6.30pm – 7pm");
                            replys6.AppendLine("Short of cheerleaders and screaming fans, this show imitates a live game of each sporting discipline it reports on. Alois Bunjira and Marc Pozzo delivers all the Messi Bolts of sporting action from around the globe, with clips from the most epic highlights as well as profiles and interviews with various sportsmen and women.");
                            replys6.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys6.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys6.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys6);
                            break;
                        case 7:
                            //The following is our response
                            MessageToSend replys7 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys7.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys7.AppendLine("Judgement Yard");
                            replys7.AppendLine("with Dj Flevah, Mc Etherton, Dj Two Bad");
                            replys7.AppendLine("Thursdays");
                            replys7.AppendLine("9pm – 12midnight");
                            replys7.AppendLine("The weekend eve! Judgement Yard, DJs to the most liked ragga gigs in the country, hosts a party that cannot keep the body still. The trio entertains and unifies the nation with Dancehall, Lovers, and Conscious Reggae music.");
                            replys7.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys7.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys7.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys7);
                            break;
                        case 8:
                            //The following is our response
                            MessageToSend replys8 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys8.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys8.AppendLine("The Fixx");
                            replys8.AppendLine("with Dj Tbass, Pstyles, Mc Cutz & Karizma");
                            replys8.AppendLine("Fridays");
                            replys8.AppendLine("9pm – 12midnight");
                            replys8.AppendLine("Base and Styles bust club anthems to put party lovers and club hoppers in the right mind-frame for a night out on the town. There is no better fix than this! Known as Harare’s A-list DJs, playing the best hip-hop, R&B and club bangers. Their following is massive. Their beats are epic. Their rapport is tight. Their fix…is just right.");
                            replys8.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys8.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys8.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys8);
                            break;
                        case 9:
                            //The following is our response
                            MessageToSend replys9 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys9.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys9.AppendLine("Hidden Culture");
                            replys9.AppendLine("with Jason le Roux & Evey");
                            replys9.AppendLine("Saturday");
                            replys9.AppendLine("9pm – 12midnight");
                            replys9.AppendLine("The international renowned dj mixes international dance music with tunes from Zimbabwe and the African continent uniting Zimbabweans and people from around the globe with music , ably co-hosted by the vivacious Evey Mwatse.");
                            replys9.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys9.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys9.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys9);
                            break;
                        case 10:
                            //The following is our response
                            MessageToSend replys10 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys10.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys10.AppendLine("Off The Wall");
                            replys10.AppendLine("with Dan & Lo");
                            replys10.AppendLine("Saturday");
                            replys10.AppendLine("9am – 12noon");
                            replys10.AppendLine("Dan and Lo own their title, ‘the cool kids’. With Dan’s contemporary swag and Lo’s diasporan twang, the two are a feisty pair who poke fun at just about everything that their senses come into contact with. They bring a lighthearted, humorous look at the latest celebrity news whilst playing the latest urban music. Get informed of all the must-attend events, concerts, gigs and parties. Travel is something ‘cool kids’ do and through their adventures, Dan and Lo show off local and international tourist attractions plus general travel information.");
                            replys10.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys10.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys10.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys10);
                            break;
                        case 11:
                            //The following is our response
                            MessageToSend replys11 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys11.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys11.AppendLine("Afro Republic");
                            replys11.AppendLine("with Morris Touch");
                            replys11.AppendLine("Monday, Tuesday & Saturday");
                            replys11.AppendLine("This show is dedicated to showcasing the best of African entertainment in music, film and literature. Nollywood- the budding hall fame on the continent is filled with celebrities and their news, so Morris navigates the listener through this glittery maze. If you’ve never felt African before, this show will convince you that the only garment to wear when identifying with this continent, is ‘pride.’");
                            replys11.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys11.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys11.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys11);
                            break;
                        case 12:
                            //The following is our response
                            MessageToSend replys12 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys12.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys12.AppendLine("Lots of Love");
                            replys12.AppendLine("with Plaxedes");
                            replys12.AppendLine("Sundays");
                            replys12.AppendLine("9pm – 12 midnight");
                            replys12.AppendLine("Lots of love is what the show promotes and encourages through finding solutions for problems in love relationships. Plaxedes Wenyika the singer popular for her love ballads, brings you lots of love on Zifm Stereo.");
                            replys12.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys12.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys12.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys12);
                            break;
                        case 13:
                            //The following is our response
                            MessageToSend replys13 = MessageBuilder.CreateMessageToSend(paymentResponse.ContactName, paymentResponse.UserId);
                            replys13.AppendLine(MessageBuilder.Elements.CreateClearScreen());
                            replys13.AppendLine("Iron Lion");
                            replys13.AppendLine("with Marlon");
                            replys13.AppendLine("Sunday");
                            replys13.AppendLine("6pm – 7pm");
                            replys13.AppendLine("Marlon is indestructible and proud of African History. He is a follower of the teachings of His Imperial Majesty, Conquering Lion from the 12 tribes of Judah. This show, ‘Iron Lion,’ unites and uplifts Zimbabwe through reggae music. His roots in the reggae culture find him explaining and guiding the listener through the meanings behind lyrics and the significance in each message, showcasing that what is heard is never ‘just a song’.");
                            replys13.AppendLine("");
                            // Add a home link, this takes the user back to the root context regardless of any redirects in between.
                            replys13.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("h", "Go to the Main Menu"));
                            // Add a back link
                            replys13.AppendLine(MessageBuilder.Elements.CreateTextMenuItem("b", "Go Back to the last screen!"));
                            ExternalAppApiComms.SendMessage(replys13);
                            break;
                    }
                }

                // If the transaction was not successful
                else
                {
                    // The confirmation result should be null
                    if (moolaBilled == null)
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Transaction was not successful, user was not billed", Level.Debug);
                    }
                    else
                    {
                        ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "Transaction was not successful, but the transaction confirmation indicates that the user was billed", Level.Error);
                    }
                }
            }
            catch (Exception e)
            {
                ConsoleLogger.Log(MethodBase.GetCurrentMethod(), "An error occurred:\n" + e.ToString(), Level.Error);
            }
        }

     }
    }