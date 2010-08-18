using System;

namespace Facebook.GraphApi.Publishing {

  public static class GraphExtensions {

    public static Album CreateAlbum(this Graph graphApi) {
      return new Album(graphApi);
    }

    public static Link CreateLink(this Graph graphApi) {
      return new Link(graphApi);
    }

    public static Post CreatePost(this Graph graphApi) {
      return new Post(graphApi);
    }

    public static void PublishMessage(this Graph graphApi, long profileId, string message) {

      WallMessage.
        Create(graphApi, message).
        Publish(profileId);
    }

    public static void PublishMessage(this Graph graphApi, string message) {

      WallMessage.
        Create(graphApi, message).
        Publish();
    }

    class WallMessage : FeedPublishingBase {

      public static WallMessage Create(Graph graphApi, string message) {
        return new WallMessage(graphApi) {
          Message = message
        };
      }

      protected WallMessage(Graph graphApi)
        : base(graphApi) {
      }

      public string Message { get; set; }
    }
  }
}
