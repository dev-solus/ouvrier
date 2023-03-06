using Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace asp.SignalR
{
    public class Like : Hub<ILikeHubClient> { }

    public interface ILikeHubClient
    {
        Task BroadcastLike(int id);
        Task DeleteLike(int id);
    }


    //comment
    public class CommentHub : Hub<ICommentHubClient> { }

    public interface ICommentHubClient
    {
        //Task BroadcastMessage(string type, string payload);
        Task BroadcastComment(int id, Commentaire c, User user);
        Task EditComment(int id, Commentaire c);
        Task DeleteComment(int id, Commentaire c);
    }

    //comment count
    public class CountComment : Hub<ICommentCountClient> { }

    public interface ICommentCountClient
    {
        Task BroadcastOne(int s);
        Task DeleteOne(int s);
    }

}
