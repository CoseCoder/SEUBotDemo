using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;

namespace BotDemo.Dialogs
{
    [LuisModel("c7a9efc0-7555-4c42-8a2e-97712d5041f1", "1d624d2368674db5aac5493686aa98a9", LuisApiVersion.V2, @"southeastasia.api.cognitive.microsoft.com")]
    [Serializable]
    public class DemoLuisDialog : LuisDialog<object>
    {
        public const string Name = "人物";
        public const string Place = "地点";
        public const string SEU = "学校名称";
        public const string Attr = "属性";
        public const string Adj = "形容词";
        public const string Campus = "校区";
        public const string Action = "行为";
        public const string Status = "身份";
        public const string College = "院系总称";
        public const string Major = "学院";
        public const string Job = "职位";
        public const string Argument = "指示词";
        EntityRecommendation LastEntity;
        IntentRecommendation LastIntent;
        string LastAdj;
        string LastMajor = "";
        string LastName = "";

        public async Task StartAsync(IDialogContext context)
        {
            await this.Greeting(context, new LuisResult());

            context.Wait(MessageReceived);
        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"对不起，我还只是个孩子（这辈子估计都是zz了hhh）";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("您好，有什么可以帮助您的？");
            context.Wait(MessageReceived);
        }


        [LuisIntent("查询人物")]
        public async Task NameOfPeople(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询人物\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                else if (entity.Type == Job)
                    LastName = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("判断")]
        public async Task Judge(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("判断\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询属性")]
        public async Task Something(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询属性\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                await context.PostAsync($"{entity.Entity} ");
            }
            result.TryFindEntity(Attr, out LastEntity);
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询年份")]
        public async Task Time(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询年份\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询数量")]
        public async Task Number(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询数量\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询电话")]
        public async Task Tel(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询电话\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                else if (entity.Type == Job)
                    LastName = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询网站")]
        public async Task Web(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询网站\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询邮箱")]
        public async Task Mail(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询邮箱\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                else if (entity.Type == Job)
                    LastName = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            result.TryFindEntity(Job, out LastEntity);
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("查询面积")]
        public async Task Square(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("查询面积\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                await context.PostAsync($"{entity.Entity} ");
            }
            result.TryFindEntity(Campus, out LastEntity);
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("简介")]
        public async Task Summary(IDialogContext context, LuisResult result)
        {
            LastMajor = "";
            LastName = "";
            await context.PostAsync("简介\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                if (entity.Type == Major)
                    LastMajor = entity.Entity;
                else if (entity.Type == Job)
                    LastName = entity.Entity;
                await context.PostAsync($"{entity.Entity} ");
            }
            LastIntent = result.TopScoringIntent;
            context.Wait(MessageReceived);
        }

        [LuisIntent("连续对话")]
        public async Task Continued(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("连续对话\n");
            if (LastMajor != "")
                await context.PostAsync($"{LastMajor}\n");
            if (LastName != "")
                await context.PostAsync($"{LastName}\n");
            foreach (EntityRecommendation entity in result.Entities)
            {
                await context.PostAsync($"{entity.Entity} ");
            }
            if (result.TryFindEntity(Job, out LastEntity)) { }
            context.Wait(MessageReceived);
        }
    }
}