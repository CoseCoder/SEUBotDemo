using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;

[Serializable]
public class BasicQnADialog : QnAMakerDialog
{
    //Parameters to QnAMakerService are:
    //Required: subscriptionKey, knowledgebaseId, 
    //Optional: defaultMessage, scoreThreshold[Range 0.0 – 1.0]
    public BasicQnADialog() : base(new QnAMakerService(new QnAMakerAttribute("db738f3d9e5c45d89911a02816b05eef", "9e2ead27-9e07-4aaa-a1bf-2672650361f3", "No good match in FAQ.", 0.75)))
    { }
}