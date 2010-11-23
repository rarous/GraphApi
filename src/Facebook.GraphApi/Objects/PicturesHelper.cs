namespace Facebook.GraphApi.Objects {

  using System;

  public static class PicturesHelper {

    public static string GetImageUrl(object id, PictureType type) {

      return String.Concat(Graph.Url, "/", id, "/picture?type=", type.ToString().ToLower());
    }
  }
}
