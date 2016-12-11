using Discord;
using Discord.Commands;
using System.Collections.Generic;
using Discord.Audio;
using Discord.Modules;
using System;

class Program
{
    static void Main(string[] args) => new Program().Start();



    public void Start()
    {


        var _client = new DiscordClient();

        _client.UsingCommands(x => {
            x.PrefixChar = '#';                         //here we set our prefix. With that we start every Command

            x.HelpMode = HelpMode.Public;
        });





        _client.GetService<CommandService>().CreateCommand("greet")                         //create command greet
            .Alias(new string[] { "hay", "hi" })                                                //add 2 aliases, so it can be run with #gr and #hi
            .Description("Greets a person.")                                                    //add description, it will be shown when #help is used
            .Parameter("GreetedPerson", ParameterType.Required)                                 //as an argument, we have a person we want to greet

            .Do(async e =>
            {
                await e.Channel.SendMessage($"{e.User.Name} greets {e.GetArg("GreetedPerson")}");  //sends a message to channel with the given text

            });








            _client.GetService<CommandService>().CreateCommand("Vanilla")                   //here we see how we can upload a picture from a webserver
            .Alias(new string[] { "waifu" })
            .Description("Vanilla-chan is the best waifu.")


            .Do(async e =>
            {
                await e.Channel.SendMessage("Vanilla-chan is the best waifu, fuck all your waifus!");
                await e.Channel.SendMessage("https://cdn.discordapp.com/attachments/223919560716320768/231871626474553355/vanilla.png");
            });


            _client.GetService<CommandService>().CreateCommand("Picture")                       //here we will upload an local picture    
            .Alias(new string[] { "Picture" })
            .Description("Uploads a Picture.")
            .Do(async e =>
            {
                await e.Channel.SendFile("D:/Bilder_Bot/bild.png");
            });





            _client.GetService<CommandService>().CreateCommand("snipe")                         //create command sNIPE
        .Alias(new string[] { "snipe" })                                                    //add the alias #snipe
        .Parameter("GreetedPerson", ParameterType.Required)                                 //as an argument, we have a person we want to snipe
        .Description("#snipe @user")                                                         //add description, it will be shown when #help is used    
        .Do(async e =>
        {
            await e.Channel.SendMessage($"{e.User.Name} Sniped {e.GetArg("GreetedPerson")}");
            await e.Channel.SendMessage("https://cdn.discordapp.com/attachments/163065989364187146/244549743966027776/sniper.png");
        });




            _client.GetService<CommandService>().CreateCommand("Picture")                       //here we will upload an local picture    
            .Alias(new string[] { "Picture" })
            .Description("Uploads a Picture.")
            .Do(async e =>
            {
                await e.Channel.SendFile("D:/Bilder_Bot/bild.png");
            });


            _client.MessageReceived += async (s, e) =>                                         //for test if you write the bot wil answer with "test
            {
                if (e.Message.Text == ("test"))
                {

                    string test = ("test");


                    if (!e.Message.IsAuthor)
                        await e.Channel.SendMessage(test);                                      //sends a message in the channel where the bot got the command

                }
            };









            _client.ExecuteAndWait(async () => {                                                                                //here we use out api key to connect the bot
                await _client.Connect("Your Api key here", TokenType.Bot);            //you get the your key from  https://discordapp.com/developers/applications/me#top


            });
        }
    }






