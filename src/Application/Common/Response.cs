using System.Net;

namespace Application.Common
{
    public class Response<T>
    {
        public T? Content { get; set; }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;


        public List<Notify> Notifications { get; }

        public bool IsValid => Notifications.Count == 0;

        public Dictionary<string, string> Headers { get; set; }

        public Response()
        {
            Notifications = [];
            Headers = [];
            Content = default;
        }

        public void AddNotifications(IList<Notify> notifies)
        {
            Notifications.AddRange(notifies);
        }

        public void AddNotification(Notify notification)
        {
            Notifications.Add(notification);
        }

        public void AddNotification(string code, string property, string message)
        {
            Notifications.Add(new Notify
            {
                Code = code,
                Message = message,
                Property = property
            });
        }
    }
}
