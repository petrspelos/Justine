using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Justine.Data.Entities;
using Justine.Services;

namespace Justine.Discord.Providers
{
    public class UserIssuesProvider : ServiceProvider
    {
        private readonly UserIssuesService userIssuesService;

        public UserIssuesProvider(UserIssuesService userIssuesService)
        {
            this.userIssuesService = userIssuesService;
        }

        public async Task InvokeByContext(SocketCommandContext context)
        {
            if(MessageIsNewIssue(context.Message))
            {
                await CreateNewIssue(context);
            }
        }

        public async Task CreateNewIssue(SocketCommandContext context)
        {
            userIssuesService.NewIssue(new UserIssue
            {
                Id = await CreateIssueMessage(context),
                UserId = context.User.Id,
                Contents = context.Message.Content
            });
        }

        private bool MessageIsNewIssue(SocketUserMessage messsage)
        {
            return messsage.Content.StartsWith(Constants.NewIssueToken);
        }

        private async Task<ulong> CreateIssueMessage(SocketCommandContext context)
        {
            var issuesBoard = context.Guild.GetTextChannel(Constants.IssuesBoardId);
            var message = await issuesBoard.SendMessageAsync(GetIssueText(context));
            return message.Id;
        }

        private string GetIssueText(SocketCommandContext context)
        {
            var contents = context.Message.Content;
            var user = context.User as SocketGuildUser;
            return $"**Issue by:** {user.Mention}\n{contents}";
        }
    }
}
