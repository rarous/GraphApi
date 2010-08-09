using System;
using System.Collections.Generic;

namespace Facebook.GraphApi.Publishing {

  public static class GraphExtensions {

    const string FeedPath = "/feed";
    const string Message = "message";
    const string CurrentUser = "me";

    public static Post CreatePost(this Graph graphApi) {
      return new Post(graphApi);
    }

    public static void PublishMessage(this Graph graphApi, long profileId, string message) {
      var args = new Dictionary<string, object>();
      args.Add(Message, message);
      graphApi.Post(profileId + FeedPath, args);
    }

    public static void PublishMessage(this Graph graphApi, string message) {
      var args = new Dictionary<string, object>();
      args.Add(Message, message);
      graphApi.Post(CurrentUser + FeedPath, args);
      
    }
  }
}
