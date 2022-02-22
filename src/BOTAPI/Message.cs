using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
namespace BotApi.M;

class Message
{
    public static void Send(string body, string to)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        string accountSid = "ACe1d8b7105c0c4300b093ac388bd221e2";
        string authToken = "03f9807f84fc88f7f582e5acf2824973";

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: "Hello there!",
            from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            to: new Twilio.Types.PhoneNumber($"{to}")
        );

        Console.WriteLine(message.Sid);
    }

    public static void Recipe(FormCollection message)
    {
      Console.WriteLine(message);
    }
}
/* 
{
  "account_sid": "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
  "api_version": "2010-04-01",
  "body": "Hello there!",
  "date_created": "Thu, 30 Jul 2015 20:12:31 +0000",
  "date_sent": "Thu, 30 Jul 2015 20:12:33 +0000",
  "date_updated": "Thu, 30 Jul 2015 20:12:33 +0000",
  "direction": "outbound-api",
  "error_code": null,
  "error_message": null,
  "from": "whatsapp:+14155238886",
  "messaging_service_sid": "MGXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
  "num_media": "0",
  "num_segments": "1",
  "price": null,
  "price_unit": null,
  "sid": "SMXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
  "status": "sent",
  "subresource_uris": {
    "media": "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Messages/SMXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Media.json"
  },
  "to": "whatsapp:+15005550006",
  "uri": "/2010-04-01/Accounts/ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/Messages/SMXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.json"
} */