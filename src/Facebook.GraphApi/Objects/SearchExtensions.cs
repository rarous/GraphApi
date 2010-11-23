namespace Facebook.GraphApi.Objects {

  using System;
  using System.Collections.Generic;

  public static class SearchExtensions {

    static T[] Search<T>(this Graph graphApi, SearchArguments args) {
      return graphApi.Search(args)["data"].Deserialize<T[]>();
    }

    public static IEnumerable<Event> SearchEvents(this Graph graphApi, string query, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Event>(new SearchArguments {
        Query = query,
        Type = SearchType.Event,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<Event> SearchEvents(this Graph graphApi, string query, int limit, int offset) {
      return graphApi.SearchEvents(query, limit, offset, null, null);
    }

    public static IEnumerable<Event> SearchEvents(this Graph graphApi, string query, int limit, int offset, DateTime since) {
      return graphApi.SearchEvents(query, limit, offset, since, null);
    }

    public static IEnumerable<Group> SearchGroups(this Graph graphApi, string query, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Group>(new SearchArguments {
        Query = query,
        Type = SearchType.Group,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<Group> SearchGroups(this Graph graphApi, string query, int limit, int offset) {
      return graphApi.SearchGroups(query, limit, offset, null, null);
    }

    public static IEnumerable<Group> SearchGroups(this Graph graphApi, string query, int limit, int offset, DateTime since) {
      return graphApi.SearchGroups(query, limit, offset, since, null);
    }

    public static IEnumerable<Checkin> SearchCheckins(this Graph graphApi, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Checkin>(new SearchArguments {
        Type = SearchType.Checkin,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<Checkin> SearchCheckins(this Graph graphApi, int limit, int offset) {
      return graphApi.SearchCheckins(limit, offset, null, null);
    }

    public static IEnumerable<Checkin> SearchCheckins(this Graph graphApi, int limit, int offset, DateTime since) {
      return graphApi.SearchCheckins(limit, offset, since, null);
    }

    public static IEnumerable<Page> SearchPages(this Graph graphApi, string query, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Page>(new SearchArguments {
        Query = query,
        Type = SearchType.Page,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<Page> SearchPages(this Graph graphApi, string query, int limit, int offset) {
      return graphApi.SearchPages(query, limit, offset, null, null);
    }

    public static IEnumerable<Page> SearchPages(this Graph graphApi, string query, int limit, int offset, DateTime since) {
      return graphApi.SearchPages(query, limit, offset, since, null);
    }

    public static IEnumerable<Post> SearchPosts(this Graph graphApi, string query, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Post>(new SearchArguments {
        Query = query,
        Type = SearchType.Post,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<Post> SearchPosts(this Graph graphApi, string query, int limit, int offset) {
      return graphApi.SearchPosts(query, limit, offset, null, null);
    }

    public static IEnumerable<Post> SearchPosts(this Graph graphApi, string query, int limit, int offset, DateTime since) {
      return graphApi.SearchPosts(query, limit, offset, since, null);
    }

    public static IEnumerable<User> SearchUsers(this Graph graphApi, string query, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<User>(new SearchArguments {
        Query = query,
        Type = SearchType.User,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<User> SearchUsers(this Graph graphApi, string query, int limit, int offset) {
      return graphApi.SearchUsers(query, limit, offset, null, null);
    }

    public static IEnumerable<User> SearchUsers(this Graph graphApi, string query, int limit, int offset, DateTime since) {
      return graphApi.SearchUsers(query, limit, offset, since, null);
    }
  }
}
