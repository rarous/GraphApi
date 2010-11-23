namespace Facebook.GraphApi {

  using System;

  [Flags]
  public enum HttpVerb {
    Get = 0x1,
    Post = 0x2,
    Delete = 0x4,
  }
}
