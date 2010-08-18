using System;

namespace Facebook.GraphApi.Objects {

  public static class GraphExtensions {

    static T Get<T>(this Graph graphApi, long objectId) where T : class {
      return graphApi.Get(objectId).Deserialize<T>();
    }

    static T Get<T>(this Graph graphApi, string objectName) where T : class {
      return graphApi.Get(objectName).Deserialize<T>();
    }

    public static Album GetAlbum(this Graph graphApi, long albumId) {
      return graphApi.Get<Album>(albumId);
    }

    public static Application GetApplication(this Graph graphApi, long appId) {
      return graphApi.Get<Application>(appId);
    }

    public static Event GetEvent(this Graph graphApi, long eventId) {
      return graphApi.Get<Event>(eventId);
    }

    public static Group GetGroup(this Graph graphApi, long groupId) {
      return graphApi.Get<Group>(groupId);
    }

    public static Link GetLink(this Graph graphApi, long linkId) {
      return graphApi.Get<Link>(linkId);
    }

    public static Note GetNote(this Graph graphApi, long noteId) {
      return graphApi.Get<Note>(noteId);
    }

    public static Page GetPage(this Graph graphApi, long pageId) {
      return graphApi.Get<Page>(pageId);
    }

    public static Page GetPage(this Graph graphApi, string page) {
      return graphApi.Get<Page>(page);
    }

    public static Photo GetPhoto(this Graph graphApi, long photoId) {
      return graphApi.Get<Photo>(photoId);
    }

    public static Post GetPost(this Graph graphApi, long profileId, long postId) {
      return graphApi.Get<Post>(String.Format("{0}_{1}", profileId, postId));
    }

    public static User GetUser(this Graph graphApi, string username) {
      return graphApi.Get<User>(username);
    }
   
    public static User GetUser(this Graph graphApi, long uid) {
      return graphApi.Get<User>(uid);
    }

    public static User GetUser(this Graph graphApi) {
      return graphApi.Get<User>("me");
    }
  }
}
