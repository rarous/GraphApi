using System;
using System.Collections.Generic;

namespace Facebook.GraphApi.Objects {

  public static class SearchExtensions {

    static T[] Search<T>(this Graph graphApi, SearchArguments args) {
      return graphApi.Search(args)["data"].Deserialize<T[]>();
    }

    public static IEnumerable<Checkin> SearchCheckin(this Graph graphApi, int limit, int offset) {
      return graphApi.SearchCheckin(limit, offset, null, null);
    }

    public static IEnumerable<Checkin> SearchCheckin(this Graph graphApi, int limit, int offset, DateTime since) {
      return graphApi.SearchCheckin(limit, offset, since, null);
    }

    public static IEnumerable<Checkin> SearchCheckin(this Graph graphApi, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Checkin>(new SearchArguments {
        Type = SearchType.Checkin,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }

    public static IEnumerable<Page> SearchPage(this Graph graphApi, string query) {
      return graphApi.SearchPage(query, null, null, null, null);
    }

    public static IEnumerable<Page> SearchPage(this Graph graphApi, string query, int limit, int offset) {
      return graphApi.SearchPage(query, limit, offset, null, null);
    }

    public static IEnumerable<Page> SearchPage(this Graph graphApi, string query, int limit, int offset, DateTime since) {
      return graphApi.SearchPage(query, limit, offset, since, null);
    }

    public static IEnumerable<Page> SearchPage(this Graph graphApi, string query, int? limit, int? offset, DateTime? since, DateTime? until) {
      return graphApi.Search<Page>(new SearchArguments {
        Query = query,
        Type = SearchType.Page,
        Limit = limit,
        Offset = offset,
        Since = since,
        Until = until,
      });
    }
  }
}
